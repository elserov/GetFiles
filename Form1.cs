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
            label6.Text = "Поиск завершён.";
            timer1.Stop();
            label5.Text = "Время поиска " + time;
        }

        private TreeNode FindOrCreateNode(TreeNodeCollection coll, string name)
        {
            var found = coll.Find(name.ToLower(), false);
            if (found.Length > 0) return found[0];
            return coll.Add(name.ToLower(), name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = ""; label6.Text = "";
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
                try
                {
                    foreach (string f in Directory.GetFiles(d, textBox2.Text))
                    {

                        dirfiles.Add(f);
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
                dirfiles.Add(i);
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
            label5.Text = time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Suspend();
            t1.Suspend();
        }
    }
}