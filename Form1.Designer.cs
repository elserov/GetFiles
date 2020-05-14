namespace GetFiles
{
    partial class GetFiles
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bt_Pause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_Find = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // bt_Pause
            // 
            this.bt_Pause.CausesValidation = false;
            this.bt_Pause.Location = new System.Drawing.Point(31, 395);
            this.bt_Pause.Name = "bt_Pause";
            this.bt_Pause.Size = new System.Drawing.Size(75, 23);
            this.bt_Pause.TabIndex = 0;
            this.bt_Pause.Text = "Пауза";
            this.bt_Pause.UseVisualStyleBackColor = true;
            this.bt_Pause.Click += new System.EventHandler(this.bt_Pause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Директория";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(455, 104);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "C:\\tmp";
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            this.textBox1.MouseHover += new System.EventHandler(this.textBox1_MouseHover);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(455, 151);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(315, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "gogo.txt";
            this.textBox2.MouseHover += new System.EventHandler(this.textBox2_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя файла";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(455, 202);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(315, 105);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Содержимое файла";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(31, 35);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(393, 272);
            this.treeView1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // bt_Find
            // 
            this.bt_Find.Location = new System.Drawing.Point(663, 313);
            this.bt_Find.Name = "bt_Find";
            this.bt_Find.Size = new System.Drawing.Size(107, 41);
            this.bt_Find.TabIndex = 10;
            this.bt_Find.Text = "Найти";
            this.bt_Find.UseVisualStyleBackColor = true;
            this.bt_Find.Click += new System.EventHandler(this.bt_Find_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Время";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Найдено";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Файл";
            // 
            // bt_Stop
            // 
            this.bt_Stop.CausesValidation = false;
            this.bt_Stop.Location = new System.Drawing.Point(137, 395);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(75, 23);
            this.bt_Stop.TabIndex = 14;
            this.bt_Stop.Text = "Стоп";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GetFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_Stop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bt_Find);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Pause);
            this.Name = "GetFiles";
            this.Text = "GetFiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetFiles_FormClosing);
            this.Load += new System.EventHandler(this.GetFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Pause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_Find;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

