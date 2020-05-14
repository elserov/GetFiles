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
        public GetFiles()
        {
            InitializeComponent();
        }
        List<string> treeFiles = new List<string>();

        private void BuildTree(TreeNodeCollection nodes, IEnumerable<string> list)
        {
            foreach (var path in list)
            {
                var childs = nodes;
                foreach (var part in path.Split(Path.DirectorySeparatorChar))
                    childs = FindOrCreateNode(childs, part).Nodes;
            }
        }

        private TreeNode FindOrCreateNode(TreeNodeCollection coll, string name)
        {
            var found = coll.Find(name.ToLower(), false);
            if (found.Length > 0) return found[0];
            return coll.Add(name.ToLower(), name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            treeView1.Nodes.Clear();
            //treeFiles.Clear();
            

            //Build(rootDir, textBox2.Text);
            //DirRootSearch();
            //DirSearch(textBox1.Text);

            Thread t = new Thread(delegate () { DirSearch(textBox1.Text); });
            t.Start();
            Thread t1 = new Thread(delegate () { DirRootSearch(); });
            t1.Start();

            
            //foreach (var i in treeFiles)
            //{
            //    label5.Text += i + "\n";
            //}

            Build();
        }
        void DirSearch(string sDir)
        {
            
            foreach (string d in Directory.GetDirectories(sDir))
            {
                try
                {
                    foreach (string f in Directory.GetFiles(d, textBox2.Text))
                    {
                        treeFiles.Add(f);
                    }
                    DirSearch(d);
                }
                catch
                {                    
                }
            }
        }
        void DirRootSearch()
        {
            foreach (string i in Directory.GetFiles(textBox1.Text, textBox2.Text))
            {
                treeFiles.Add(i);
            }
        }

        void Build() 
        {
            BuildTree(treeView1.Nodes, treeFiles);
        }
    }
}