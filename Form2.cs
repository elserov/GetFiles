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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private int count = 0;
        private int time = 0;
        private bool boolstart;

        private void button2_Click(object sender, EventArgs e)
        {
            boolstart = false;
            timer1.Stop();

            
        }
        private List<string> GetRecursFiles(string start_path)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] folders = Directory.GetDirectories(start_path);
                foreach (string folder in folders)
                {
                    ls.Add("Папка: " + folder);
                    ls.AddRange(GetRecursFiles(folder));
                    TreeNode curNode = treeView1.Nodes.Add("Folder", folder);
                    treeView1.Nodes.Add(folder);
                }
                string[] files = Directory.GetFiles(start_path);
                foreach (string filename in files)
                {
                    ls.Add("Файл: " + filename);
                    treeView1.Nodes.Add(filename);
                }
            }
            catch (System.Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            return ls;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            time = 0;
            timer1.Start();
            count = 0;
            boolstart = true;

            //Thread clientThread = new Thread(new ThreadStart(work));
            //clientThread.IsBackground = true;
            //clientThread.Start();
            
             work();
            
            //Thread t = new Thread(delegate (){work();});
            //t.Start();

        }
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            

            TreeNode curNode = addInMe.Add("Folder", directoryInfo.Name);

            //if (Directory.EnumerateFiles(textBox1.Text, textBox2.Text, SearchOption.AllDirectories).Any())
            //{
            //}

            //Перебираем папки.
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                //if (boolstart)
                //{
                    //treeView1.BeginUpdate();
                    if (Directory.EnumerateFiles(textBox1.Text, textBox2.Text, SearchOption.AllDirectories).Any())
                    {
                        //count++;
                        BuildTree(subdir, curNode.Nodes);
                    }
                    //treeView1.EndUpdate();
                //}
            }
            //Перебираем файлы
            foreach (FileInfo file in directoryInfo.GetFiles(textBox2.Text))
            {
                //count++;
                //if (boolstart)
                //{
                    //treeView1.BeginUpdate();
                    //if (textBox3.Text == "")
                    //{

                    //    TreeNode n = new TreeNode(file.Name);
                    //    count++;
                    //    treeView1.Nodes.Add(n);


                    //}
                    //else
                    //{
                        //if (File.Exists(file.FullName))
                        //{
                            string tmp = File.ReadAllText(file.FullName);
                            if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
                            {
                                TreeNode n = new TreeNode(file.Name);
                                count++;
                                treeView1.Nodes.Add(n);

                            }
                        //}
                        
                    //}
                    //treeView1.EndUpdate();
                //}
            }
            label1.Text = "Найдено файлов - " + count;
            //label2.Text = "Время выполнения - " + time;
            timer1.Stop();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream file = new FileStream("setting.txt", FileMode.Create))
            {
                using (StreamWriter streamFile = new StreamWriter(file))
                {
                    streamFile.WriteLine(textBox1.Text + Environment.NewLine+ textBox2.Text + Environment.NewLine + textBox3.Text); 
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] mass = File.ReadAllLines(@"setting.txt");

            textBox1.Text = mass[0];
            textBox2.Text = mass[1];
            textBox3.Text = mass[2];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label2.Text = time.ToString();
        }

        private void work()
        {
            label1.Text = "Запуск";
            treeView1.Nodes.Clear();
            //treeView1.BeginUpdate();

            DirectoryInfo di;

            DirectoryInfo rootDir = new DirectoryInfo(textBox1.Text);
            foreach (var file in rootDir.GetFiles(textBox2.Text))
            {
                //if (boolstart)
                //{
                    //treeView1.BeginUpdate();
                    //if (textBox3.Text == "")
                    //{
                        
                    //        TreeNode n = new TreeNode(file.Name);
                    //        count++;
                    //        treeView1.Nodes.Add(n);

                        
                    //}
                    //else
                    //{
                        //if (File.Exists(file.FullName))
                        //{ 
                            string tmp = File.ReadAllText(file.FullName);
                            if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
                            {
                                TreeNode n = new TreeNode(file.Name);
                                count++;
                                treeView1.Nodes.Add(n);

                            }
                        //}

                    //}
                    
                    //treeView1.EndUpdate();
                //}

            }

            try
            {

                string[] root = Directory.GetDirectories(textBox1.Text);

                //Проходимся по всем полученным подкаталогам.
                foreach (string s in root)
                {
                    try
                    {
                        di = new DirectoryInfo(s);
                        if (boolstart)
                        {
                            
                            BuildTree(di, treeView1.Nodes);
                             
                        }
                    }
                    catch { }
                }
            }
            catch { }
            //treeView1.EndUpdate();
        }
    }
}
