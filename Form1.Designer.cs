using System.Windows.Forms;

namespace MusicPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (outputDevice != null)
                {
                    outputDevice.Dispose();
                    outputDevice = null;
                }
                if (audioFile != null)
                {
                    audioFile.Dispose();
                    audioFile = null;
                }
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 1; 
            tableLayoutPanel.RowCount = 3; 
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 74F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13F));
            this.Controls.Add(tableLayoutPanel);

            TableLayoutPanel nestedLayoutPanel1 = new TableLayoutPanel();
            nestedLayoutPanel1.Dock = DockStyle.Fill;
            nestedLayoutPanel1.ColumnCount = 3;
            nestedLayoutPanel1.RowCount = 1;
            nestedLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            nestedLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
            nestedLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            nestedLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(nestedLayoutPanel1, 0, 0);

            TableLayoutPanel nestedLayoutPanel2 = new TableLayoutPanel();
            nestedLayoutPanel2.Dock = DockStyle.Fill;
            nestedLayoutPanel2.ColumnCount = 1;
            nestedLayoutPanel2.RowCount = 3;
            nestedLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            nestedLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            nestedLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            nestedLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 84F));
            nestedLayoutPanel1.Controls.Add(nestedLayoutPanel2, 0, 0);

            TableLayoutPanel nestedLayoutPanel3 = new TableLayoutPanel();
            nestedLayoutPanel3.Dock = DockStyle.Fill;
            nestedLayoutPanel3.ColumnCount = 1;
            nestedLayoutPanel3.RowCount = 6;
            nestedLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            nestedLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            nestedLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            nestedLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            nestedLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            nestedLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            nestedLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            nestedLayoutPanel1.Controls.Add(nestedLayoutPanel3, 2, 0);

            TableLayoutPanel nestedLayoutPanel4 = new TableLayoutPanel();
            nestedLayoutPanel4.Dock = DockStyle.Fill;
            nestedLayoutPanel4.ColumnCount = 7;
            nestedLayoutPanel4.RowCount = 1;
            nestedLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            nestedLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            nestedLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            nestedLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            nestedLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            nestedLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            nestedLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            nestedLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(nestedLayoutPanel4, 0, 2);

            TableLayoutPanel nestedLayoutPanel5 = new TableLayoutPanel();
            nestedLayoutPanel5.Dock = DockStyle.Fill;
            nestedLayoutPanel5.ColumnCount = 3;
            nestedLayoutPanel5.RowCount = 1;
            nestedLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            nestedLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            nestedLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            nestedLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(nestedLayoutPanel5, 0, 1);

            TableLayoutPanel nestedLayoutPanel6 = new TableLayoutPanel();
            nestedLayoutPanel6.Dock = DockStyle.Fill;
            nestedLayoutPanel6.ColumnCount = 4;
            nestedLayoutPanel6.RowCount = 1;
            nestedLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            nestedLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            nestedLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            nestedLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            nestedLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            nestedLayoutPanel2.Controls.Add(nestedLayoutPanel6, 0, 1);

            components = new System.ComponentModel.Container();
            trackBar1 = new TrackBar();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            listView1 = new ListView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            openFileDialog1 = new OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            btnOpenFile = new Button();
            btnClearFile = new Button();
            labelCurrentTime = new Label();
            labelRemainingTime = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.None;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(1353, 69);
            trackBar1.TabIndex = 0;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.MouseDown += trackBar1_MouseDown;
            trackBar1.MouseUp += trackBar1_MouseUp;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Shuffle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(btnShuffle_Click);
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 2;
            button2.Text = "Previous";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new EventHandler(btnPrevious_Click);
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 3;
            button3.Text = "Play";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnPlayPause_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 4;
            button4.Text = "Next";
            button4.UseVisualStyleBackColor = true;
            button4.Click += new EventHandler(btnNext_Click);
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.None;
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 5;
            button5.Text = "Repeat";
            button5.UseVisualStyleBackColor = true;
            button5.Click += new EventHandler(btnRepeat_Click);
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 500);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("../../../default.png");
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.None;
            listView1.Name = "listView1";
            listView1.Size = new Size(400, 600);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.Columns.Add("Files:", -2, HorizontalAlignment.Left); // '-2' for auto-size
            listView1.FullRowSelect = true;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Anchor = AnchorStyles.Left;
            label1.Name = "label1";
            label1.Size = new Size(53, 25);
            label1.TabIndex = 8;
            label1.Text = "Title: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Anchor = AnchorStyles.Left;
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 9;
            label2.Text = "Artist: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Anchor = AnchorStyles.Left;
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 10;
            label3.Text = "Album: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Anchor = AnchorStyles.Left;
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 11;
            label4.Text = "Year: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Anchor = AnchorStyles.Left;
            label5.Name = "label5";
            label5.Size = new Size(67, 25);
            label5.TabIndex = 12;
            label5.Text = "Genre: ";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Audio Files|*.mp3;*.wav";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Anchor = AnchorStyles.None;
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(112, 34);
            btnOpenFile.TabIndex = 13;
            btnOpenFile.Text = "Add";
            btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // btnClearFile
            // 
            btnClearFile.Anchor = AnchorStyles.None;
            btnClearFile.Name = "btnClearFile";
            btnClearFile.Size = new Size(112, 34);
            btnClearFile.TabIndex = 14;
            btnClearFile.Text = "Clear";
            btnClearFile.UseVisualStyleBackColor = true;
            btnClearFile.Click += new EventHandler(btnClearList_Click);

            // 
            // labelCurrentTime
            // 
            labelCurrentTime.AutoSize = true;
            labelCurrentTime.Anchor = AnchorStyles.None;
            labelCurrentTime.Name = "labelCurrentTime";
            labelCurrentTime.Size = new Size(60, 15);
            labelCurrentTime.TabIndex = 0;
            labelCurrentTime.Text = "00:00:00";
            // 
            // labelRemainingTime
            // 
            labelRemainingTime.AutoSize = true;
            labelRemainingTime.Anchor = AnchorStyles.None;
            labelRemainingTime.Name = "labelRemainingTime";
            labelRemainingTime.Size = new Size(60, 15);
            labelRemainingTime.TabIndex = 1;
            labelRemainingTime.Text = "-00:00:00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1700, 800);
            nestedLayoutPanel5.Controls.Add(labelCurrentTime, 0, 0);
            nestedLayoutPanel5.Controls.Add(labelRemainingTime, 2, 0);
            nestedLayoutPanel6.Controls.Add(btnOpenFile, 1, 0);
            nestedLayoutPanel6.Controls.Add(btnClearFile, 2, 0);
            nestedLayoutPanel3.Controls.Add(label5, 0, 5);
            nestedLayoutPanel3.Controls.Add(label4, 0, 4);
            nestedLayoutPanel3.Controls.Add(label3, 0, 3);
            nestedLayoutPanel3.Controls.Add(label2, 0, 2);
            nestedLayoutPanel3.Controls.Add(label1, 0, 1);
            nestedLayoutPanel2.Controls.Add(listView1, 0, 2);
            nestedLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
            nestedLayoutPanel4.Controls.Add(button5, 5, 0);
            nestedLayoutPanel4.Controls.Add(button4, 4, 0);
            nestedLayoutPanel4.Controls.Add(button3, 3, 0);
            nestedLayoutPanel4.Controls.Add(button2, 2, 0);
            nestedLayoutPanel4.Controls.Add(button1, 1, 0);
            nestedLayoutPanel5.Controls.Add(trackBar1, 1, 0);
            Name = "Form1";
            Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private PictureBox pictureBox1;
        private ListView listView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private Button btnOpenFile;
        private Button btnClearFile;
        private Label labelCurrentTime;
        private Label labelRemainingTime;
    }
}
