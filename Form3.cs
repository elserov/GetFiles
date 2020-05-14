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
    public partial class Form3 : Form
    {
        public delegate void MyDelegate();
        public Form3()
        {
            InitializeComponent();
        }
        private int count = 0;
        private int time = 0;
        private bool boolstart;

        private void button2_Click(object sender, EventArgs e)
        {
            boolstart = false;
            // timer1.Stop();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] mass = File.ReadAllLines(@"setting.txt");

            textBox1.Text = mass[0];
            textBox2.Text = mass[1];
            textBox3.Text = mass[2];
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream file = new FileStream("setting.txt", FileMode.Create))
            {
                using (StreamWriter streamFile = new StreamWriter(file))
                {
                    streamFile.WriteLine(textBox1.Text + Environment.NewLine + textBox2.Text + Environment.NewLine + textBox3.Text);
                }
            }
        }
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = new TreeNode();
            if (Directory.EnumerateFiles(textBox1.Text, textBox2.Text, SearchOption.AllDirectories).Any())
            {
                //curNode = addInMe.Add("Folder", directoryInfo.Name);
            }
            //Перебираем папки.
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                if (Directory.EnumerateFiles(textBox1.Text, textBox2.Text, SearchOption.AllDirectories).Any())
                {
                    BuildTree(subdir, curNode.Nodes);
                }
            }

            //Перебираем файлы
            foreach (FileInfo file in directoryInfo.GetFiles(textBox2.Text))
            {
                string tmp = File.ReadAllText(file.FullName);
                if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
                {
                    //curNode.Nodes.Add("File", file.Name);
                }
            }
            label1.Text = "Найдено файлов - ";
        }
        private void tree()
        {
            label1.Text = "Запуск";
            treeView1.Nodes.Clear();

            BeginInvoke(new MyDelegate(IzmeniElement));

            DirectoryInfo di;

            DirectoryInfo rootDir = new DirectoryInfo(textBox1.Text);
            foreach (var file in rootDir.GetFiles(textBox2.Text))
            {
                string tmp = File.ReadAllText(file.FullName);
                if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
                {
                    TreeNode n = new TreeNode(file.Name);
                    //treeView1.Nodes.Add(n);
                }
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
                        BuildTree(di, treeView1.Nodes);
                    }
                    catch { }
                }
            }
            catch { }
        }
        public void IzmeniElement()
        {
            label2.Visible = false; // скрыли элемент
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tree();

            Thread clientThread = new Thread(new ThreadStart(tree));
            clientThread.IsBackground = true;
            clientThread.Start();

            //Task task = new Task(tree);
            ////task.ContinueWith(CodeAfterJoin);
            //task.Start();

            // Thread t = new Thread(delegate () { tree(); });
            // t.Start();
        }
    }
    static class treeFiles
    {
        static List<string> dir { get; set; }
        static List<string> name { get; set; }
        static List<string> idTree { get; set; }


    }
}
