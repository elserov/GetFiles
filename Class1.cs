using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFiles
{
    class Class1
    {
        //private void button1_Click(object sender, EventArgs e)
        //{

        //    label4.Text = "Найдено файлов - 0";
        //    treeView1.Nodes.Clear();

        //    int count = 0;
        //    string[] allFoundFiles = Directory.GetFiles(textBox1.Text, textBox2.Text, SearchOption.AllDirectories);

        //    string[] dirictory = textBox1.Text.Split('\\');


        //    TreeNode root = new TreeNode() { Text = dirictory[0] };

        //    treeView1.Nodes.Add(root);

        //    foreach (var i in dirictory)
        //    {
        //        if (!i.Contains(":"))
        //        {
        //            TreeNode dirNode = new TreeNode();
        //            dirNode.Text = i.Remove(0, i.LastIndexOf("\\") + 1);

        //            root.Nodes.Add(dirNode);
        //        }


        //    }
        //    //TreeNode root = new TreeNode() { Text = "имя диска" };

        //    //treeView1.Nodes.Add(root);



        //    foreach (string file in allFoundFiles)
        //    {
        //        string tmp = File.ReadAllText(file);
        //        if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1)
        //        {
        //            TreeNode treeNode = new TreeNode();
        //            treeNode.Tag = file;

        //            root.Nodes.Add(Text = file.Replace(textBox1.Text, ""));
        //            count++;
        //            label4.Text = "Найдено файлов - " + count;
        //            //break;
        //        }
        //    }

        //}

        //private void InitTreeFolders()
        //{
        //    treeView1.BeginUpdate(); //Отключаем любую перерисовку

        //    DirectoryInfo di;
        //    FileInfo file;

        //    try
        //    {
        //        string[] root = Directory.GetDirectories(textBox1.Text);

        //        foreach (string s in root)
        //        {
        //            try
        //            {
        //                di = new DirectoryInfo(s);

        //                BuildTree(di, treeView1.Nodes);
        //            }
        //            catch { }
        //        }
        //    }
        //    catch { }

        //    treeView1.EndUpdate(); //Разрешаем перерисовку иерархического представления.
        //}

        ////Процесс получения папок и файлов
        //private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        //{
        //    //Добавляем новый узел в коллекцию Nodes
        //    //с именем текущей директории и указанием ключа 
        //    //со значением "Folder".
        //    TreeNode curNode = addInMe.Add("Folder", directoryInfo.Name);


        //    //Перебираем папки.
        //    foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
        //    {
        //        BuildTree(subdir, curNode.Nodes);
        //    }

        //    //Перебираем файлы
        //    foreach (FileInfo file in directoryInfo.GetFiles(textBox2.Text))
        //    {
        //        curNode.Nodes.Add("File", file.Name);
        //    }
        //}


        //private void button2_Click(object sender, EventArgs e)
        //{
        //    treeView1.BeginUpdate(); //Отключаем любую перерисовку

        //    DirectoryInfo di;
        //    FileInfo file;

        //    try
        //    {
        //        string[] root = Directory.GetFiles(textBox1.Text, textBox2.Text, SearchOption.AllDirectories);

        //        foreach (string s in root)
        //        {
        //            try
        //            {
        //                di = new DirectoryInfo(s);
        //                file = new FileInfo(s);

        //                //TreeNode curNode = treeView1.Nodes.Add("Folder", di.Name);
        //                //curNode.Nodes.Add("File", file.Name);
        //                BuildTree(file.Directory, treeView1.Nodes);
        //            }
        //            catch { }
        //        }
        //    }
        //    catch { }

        //    treeView1.EndUpdate(); //Разрешаем перерисовку иерархического представления.

        //}
    }
}
