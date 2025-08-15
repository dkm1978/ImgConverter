namespace ImgConvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            pictureBox1 = new PictureBox();
            button7 = new Button();
            button8 = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            progressBar1 = new ProgressBar();
            textBox1 = new TextBox();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(47, 23);
            button1.TabIndex = 0;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(65, 12);
            button2.Name = "button2";
            button2.Size = new Size(41, 23);
            button2.TabIndex = 1;
            button2.Text = "24bit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(112, 11);
            button3.Name = "button3";
            button3.Size = new Size(60, 23);
            button3.TabIndex = 2;
            button3.Text = "RGB565";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(178, 11);
            button4.Name = "button4";
            button4.Size = new Size(59, 23);
            button4.TabIndex = 3;
            button4.Text = "RGB332";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.FlatStyle = FlatStyle.System;
            button5.Location = new Point(243, 11);
            button5.Name = "button5";
            button5.Size = new Size(97, 23);
            button5.TabIndex = 4;
            button5.Text = "RGB565 dither";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(346, 11);
            button6.Name = "button6";
            button6.Size = new Size(90, 23);
            button6.TabIndex = 5;
            button6.Text = "RGB332 dither";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(682, 480);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.DragDrop += pictureBox1_DragDrop;
            pictureBox1.DragEnter += pictureBox1_DragEnter;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(442, 11);
            button7.Name = "button7";
            button7.Size = new Size(77, 23);
            button7.TabIndex = 7;
            button7.Text = "Save as bin";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Enabled = false;
            button8.Location = new Point(525, 11);
            button8.Name = "button8";
            button8.Size = new Size(83, 23);
            button8.TabIndex = 8;
            button8.Text = "Save as C++";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.Red;
            progressBar1.Enabled = false;
            progressBar1.ForeColor = Color.Red;
            progressBar1.Location = new Point(12, 527);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(682, 15);
            progressBar1.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.Location = new Point(11, 548);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(639, 97);
            textBox1.TabIndex = 10;
            textBox1.Visible = false;
            textBox1.WordWrap = false;
            // 
            // button9
            // 
            button9.AutoEllipsis = true;
            button9.Enabled = false;
            button9.Location = new Point(614, 11);
            button9.Name = "button9";
            button9.Size = new Size(80, 23);
            button9.TabIndex = 11;
            button9.Text = "Save bitmap";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(706, 556);
            Controls.Add(button9);
            Controls.Add(textBox1);
            Controls.Add(progressBar1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(pictureBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Padding = new Padding(8);
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Converter by ProteusPL";
            TransparencyKey = Color.Transparent;
            HelpButtonClicked += Form1_HelpButtonClicked;
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            DragEnter += Form1_DragEnter;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private PictureBox pictureBox1;
        private Button button7;
        private Button button8;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ProgressBar progressBar1;
        private TextBox textBox1;
        private Button button9;
    }
}
