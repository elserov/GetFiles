using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFiles
{
    public partial class GetFiles : Form
    {
        public delegate void MyDelegate(List<string> files);
        public GetFiles()
        {
            InitializeComponent();
        }
        private int count = 0;
        private int time = 0;
        bool ButtonEnabled = false;
        bool cancel = false;
        Thread t;
        Thread t1;

        private void BuildTree(List<string> list)
        {
            foreach (var path in list)
            {
                var childs = treeView1.Nodes;
                foreach (var part in path.Split(Path.DirectorySeparatorChar))
                    childs = FindOrCreateNode(childs, part).Nodes;
            }
            label6.Text = "Файлов найдено "+ count;
            //timer1.Stop();
            
        }

        private TreeNode FindOrCreateNode(TreeNodeCollection coll, string name)
        {
            var found = coll.Find(name.ToLower(), false);
            if (found.Length > 0) return found[0];
            return coll.Add(name.ToLower(), name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = ""; label6.Text = ""; label7.Text = "";
            cancel = false;

            timer1.Start();
            
            treeView1.Nodes.Clear();

            t = new Thread(delegate () { DirSearch(textBox1.Text); });
            t.IsBackground = true;
            t.Start();
            t1 = new Thread(delegate () { DirRootSearch(); });
            t1.IsBackground = true;
            t1.Start();

        }
        void DirSearch(string dir)
        {
            List<string> dirfiles = new List<string>();
            foreach (string d in Directory.GetDirectories(dir))
            {
                if (cancel)
                {
                    timer1.Stop();
                    label5.Text = "Поиск остановлен";
                    break;
                }
                try
                {
                    foreach (string f in Directory.GetFiles(d, textBox2.Text))
                    {
                        if (File.Exists(f))
                        {
                            if (textBox3.Text != "")
                            {
                                string tmp = File.ReadAllText(f);
                                if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
                                {
                                    count++;
                                    label7.Text = f;
                                    dirfiles.Add(f);
                                }
                            }
                            else
                            {
                                count++;
                                label7.Text = f;
                                dirfiles.Add(f);
                            }
                        }
                    }
                    DirSearch(d);
                }
                catch
                {                    
                }
            }
            BeginInvoke(new MyDelegate(treeDir), dirfiles);
        }
        void DirRootSearch()
        {
            
            List<string> dirfiles = new List<string>();
            foreach (string i in Directory.GetFiles(textBox1.Text, textBox2.Text))
            {
                if (cancel)
                {
                    timer1.Stop();
                    label5.Text = "Поиск остановлен";
                    break;
                }
                if (File.Exists(i))
                {
                    if (textBox3.Text!="")
                    {
                        string tmp = File.ReadAllText(i);
                        if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
                        {
                            count++;
                            label7.Text = i;
                            dirfiles.Add(i);
                        }
                    }
                    else
                    {
                        count++;
                        label7.Text = i;
                        dirfiles.Add(i);
                    }
                }
            }
            BeginInvoke(new MyDelegate(treeDir), dirfiles);
            //BuildTree( dirfiles);
        }
        public void treeDir(List<string> files)
        {
            BuildTree(files);
            
        }
        private void GetFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream file = new FileStream("setting.txt", FileMode.Create))
            {
                using (StreamWriter streamFile = new StreamWriter(file))
                {
                    streamFile.WriteLine(textBox1.Text + Environment.NewLine + textBox2.Text + Environment.NewLine + textBox3.Text);
                }
            }
        }
        private void GetFiles_Load(object sender, EventArgs e)
        {
            string[] mass = File.ReadAllLines(@"setting.txt");

            textBox1.Text = mass[0];
            textBox2.Text = mass[1];
            textBox3.Text = mass[2];

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            time++;
            label5.Text = "Время :"+time.ToString()+" сек.";
            if(!t.IsAlive && !t1.IsAlive)
            {
                timer1.Stop();
                label5.Text = "Время выполнения :" + time.ToString() + " сек.";
                label7.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ButtonEnabled)
            {
                timer1.Start();
                button1.Text = "Пауза";
                ButtonEnabled = false;
                try
                {
                    t.Resume();
                    t1.Resume();
                    
                }
                catch
                {
                }
                    
                       
            }
            else
            {
                timer1.Stop();
                button1.Text = "Старт";
                ButtonEnabled = true;
                try
                {
                    t.Suspend();
                    t1.Suspend();
                    
                }
                catch
                {
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancel = true;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            string path = null;
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                    path = dialog.SelectedPath;
            textBox1.Text = path;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(50);
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox1, "Двойной клик откроет форму выбора");
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(50);
            ToolTip t2 = new ToolTip();
            t2.SetToolTip(textBox2, "Пример: *.* | * | *.txt");
        }
    }
}