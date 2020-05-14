using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFiles
{
    public partial class GetFiles : Form
    {
        public GetFiles()
        {
            InitializeComponent();

            treeView1.Nodes.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();

            string[] dirs = Directory.GetDirectories(textBox1.Text);
            DirectoryInfo rootDir = new DirectoryInfo(textBox1.Text);
            foreach (var file in rootDir.GetFiles(textBox2.Text))
            {
                TreeNode n = new TreeNode(file.Name);
                treeView1.Nodes.Add(n);
            }

            foreach (string dir in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                TreeNode node = new TreeNode(di.Name);
            
            try
            {
                node.Tag = dir;

                if (di.GetDirectories().Count() > 0)
                    if (File.Exists(textBox2.Text))
                    {
                        //node.Nodes.Add(null, "...");
                    }


                foreach (var file in di.GetFiles(textBox2.Text))
                {
                    TreeNode n = new TreeNode(file.Name);
                    node.Nodes.Add(n);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                //treeView1.Nodes.Add(node);
            }
        }


        //label4.Text = "Найдено файлов - 0";
        //treeView1.Nodes.Clear();
        //int count = 0;
        //try
        //{
        //    string[] allFoundFiles = Directory.GetFiles(textBox1.Text, textBox2.Text, SearchOption.AllDirectories);
        //    FileInfo file = null;
        //    foreach (var i in allFoundFiles)
        //    {
        //        file = new FileInfo(i);
        //        string tmp = File.ReadAllText(file.FullName);
        //        if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
        //        {
        //            count++;
        //            TreeNode curNode = treeView1.Nodes.Add("Folder", file.DirectoryName);
        //            curNode.Nodes.Add("File", file.Name);
        //            label4.Text = "Найдено файлов - " + count;
        //        }
        //    }
        //}
        //catch (UnauthorizedAccessException) { }



        //treeView1.ExpandAll();
    }
}
}
