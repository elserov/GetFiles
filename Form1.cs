using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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
        private int count = 0; // счетчик файлов
        private int time = 0; // таймер 
        bool ButtonEnabled = false; // кнопка паузы
        bool cancel = false; // кнопка отмены

        Thread t;
        Thread t1;
        private void GetFiles_Load(object sender, EventArgs e)// загрузка формы
        {
            if (File.Exists(@"setting.txt"))
            {
                string[] mass = File.ReadAllLines(@"setting.txt"); // чтение файла настроек

                textBox1.Text = mass[0];
                textBox2.Text = mass[1];
                textBox3.Text = mass[2];
            }

        }
        private void GetFiles_FormClosing(object sender, FormClosingEventArgs e)// закрытие формы
        {
            using (FileStream file = new FileStream("setting.txt", FileMode.Create))// открытие потока
            {
                using (StreamWriter streamFile = new StreamWriter(file))// открытие записи в файл
                {
                    streamFile.WriteLine(textBox1.Text + Environment.NewLine + textBox2.Text + Environment.NewLine + textBox3.Text);
                }
            }
        }

        private void bt_Find_Click(object sender, EventArgs e)// кнопка поиска
        {
            label5.Text = ""; label6.Text = ""; label7.Text = ""; // очистка лэйбл перед началом поиска

            cancel = false;// перевод переменной отмены в состояние выкл


            treeView1.Nodes.Clear(); // очистка дерева

            if (Directory.Exists(textBox1.Text))
            {
                timer1.Start();// старт счетчика
                // запуск поиска в потоки
                t = new Thread(delegate () { DirSearch(textBox1.Text); });
                t.IsBackground = true;
                t.Start();
                t1 = new Thread(delegate () { DirRootSearch(); });
                t1.IsBackground = true;
                t1.Start();
            }
            else { MessageBox.Show("Папки для поиска не существует"); }


        }
        private void bt_Pause_Click(object sender, EventArgs e)// кнопка паузы
        {
            if (ButtonEnabled) // если кнопка была нажата
            {
                timer1.Start();
                bt_Pause.Text = "Пауза";
                ButtonEnabled = false;
                try
                {
                    t.Resume(); // старт
                    t1.Resume();
                }
                catch { }
            }
            else
            {
                timer1.Stop();
                bt_Pause.Text = "Старт";
                ButtonEnabled = true;
                try
                {
                    t.Suspend(); // пауза
                    t1.Suspend();
                }
                catch { }
            }
        }
        private void bt_Stop_Click(object sender, EventArgs e)// кнопка остановки поиска
        {
            cancel = true;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)// Открытие формы выбора папки
        {
            string path = null;
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
            textBox1.Text = path;
        }
        private void textBox1_MouseHover(object sender, EventArgs e)// подсказака для поля дириктории
        {
            Thread.Sleep(50);
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox1, "Двойной клик откроет форму выбора");
        }
        private void textBox2_MouseHover(object sender, EventArgs e)// подсказка для поля имени файла
        {
            Thread.Sleep(50);
            ToolTip t2 = new ToolTip();
            t2.SetToolTip(textBox2, "Пример: *.* | * | *.txt");
        }

        private void timer1_Tick_1(object sender, EventArgs e)// функция таймера
        {
            time++;
            label5.Text = "Время :" + time.ToString() + " сек.";
            if (!t.IsAlive || !t1.IsAlive)// отслеживание завершения поиска
            {
                timer1.Stop();
                label5.Text = "Время выполнения :" + time.ToString() + " сек.";
                label7.Text = "";
            }

        }

        private void BuildTree(List<string> list)// функция построения дерева каталогов
        {
            foreach (var path in list)
            {
                var childs = treeView1.Nodes;
                foreach (var part in path.Split(Path.DirectorySeparatorChar))
                {
                    childs = FindOrCreateNode(childs, part).Nodes;
                }
            }
            label6.Text = "Файлов найдено " + count;
        }
        private TreeNode FindOrCreateNode(TreeNodeCollection coll, string name)// функция поиска или создания ветки для дерева каталогов
        {
            var found = coll.Find(name.ToLower(), false);
            if (found.Length > 0)
            {
                return found[0];
            }
            return coll.Add(name.ToLower(), name);
        }
        void DirSearch(string dir)// рекурсивный поиск папок и файлов
        {
            List<string> dirfiles = new List<string>();

            foreach (string d in Directory.GetDirectories(dir))
            {
                if (cancel)// нажатие кнопки отмены
                {
                    timer1.Stop();
                    //label5.Text = "Поиск остановлен";
                    break;
                }
                try
                {
                    foreach (string f in Directory.GetFiles(d, textBox2.Text))// поиск директорий
                    {
                        if (File.Exists(f))
                        {
                            if (textBox3.Text != "")// если поле содержимого не пустое
                            {
                                string tmp = File.ReadAllText(f); // читаем файл
                                if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1) // поиск по содержимому
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

            BeginInvoke(new MyDelegate(treeDir), dirfiles);// передача в построение каталога
        }
        void DirRootSearch()// поиск файлов в корне директории 
        {
            List<string> dirfiles = new List<string>();
            foreach (string i in Directory.GetFiles(textBox1.Text, textBox2.Text))
            {
                if (cancel)// нажатие кнопки отмены
                {
                    timer1.Stop();
                    label5.Text = "Поиск остановлен";
                    break;
                }
                if (File.Exists(i))
                {
                    if (textBox3.Text != "")
                    {
                        string tmp = File.ReadAllText(i); // чтение файла
                        if (tmp.IndexOf(textBox3.Text, StringComparison.CurrentCulture) != -1) // поиск по содержимому
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
            BeginInvoke(new MyDelegate(treeDir), dirfiles);// передача в построение каталога
        }
        public void treeDir(List<string> files)// промежуточная функция для вызова из потока
        {
            BuildTree(files);
        }
    }
}