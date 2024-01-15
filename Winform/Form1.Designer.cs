namespace Telle.YoloV8DotNet.Winform
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
            pictureBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            cbCamera = new ComboBox();
            label3 = new Label();
            btnRefresh = new Button();
            btnStart = new Button();
            label4 = new Label();
            txtConfidence = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            btnImage = new Button();
            btnDirectory = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Location = new Point(-2, 43);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(516, 300);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(535, 93);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 1;
            label1.Text = "Time: ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(535, 124);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 2;
            label2.Text = "Result: ";
            // 
            // cbCamera
            // 
            cbCamera.FormattingEnabled = true;
            cbCamera.Location = new Point(85, 9);
            cbCamera.Name = "cbCamera";
            cbCamera.Size = new Size(223, 28);
            cbCamera.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 12);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 4;
            label3.Text = "Camera:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(314, 9);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(414, 8);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStart_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(529, 43);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 7;
            label4.Text = "Min Confidence:";
            // 
            // txtConfidence
            // 
            txtConfidence.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtConfidence.Location = new Point(651, 38);
            txtConfidence.Name = "txtConfidence";
            txtConfidence.Size = new Size(77, 27);
            txtConfidence.TabIndex = 8;
            txtConfidence.Text = "0.40";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Images|*.jpg";
            openFileDialog1.RestoreDirectory = true;
            // 
            // btnImage
            // 
            btnImage.Location = new Point(514, 8);
            btnImage.Name = "btnImage";
            btnImage.Size = new Size(94, 29);
            btnImage.TabIndex = 9;
            btnImage.Text = "Imagen";
            btnImage.UseVisualStyleBackColor = true;
            btnImage.Click += BtnImage_Click;
            // 
            // btnDirectory
            // 
            btnDirectory.Location = new Point(614, 8);
            btnDirectory.Name = "btnDirectory";
            btnDirectory.Size = new Size(94, 29);
            btnDirectory.TabIndex = 10;
            btnDirectory.Text = "Directorio";
            btnDirectory.UseVisualStyleBackColor = true;
            btnDirectory.Click += BtnDirectory_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 409);
            Controls.Add(btnDirectory);
            Controls.Add(btnImage);
            Controls.Add(txtConfidence);
            Controls.Add(label4);
            Controls.Add(btnStart);
            Controls.Add(btnRefresh);
            Controls.Add(label3);
            Controls.Add(cbCamera);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label label1;
        private Label label2;
        private ComboBox cbCamera;
        private Label label3;
        private Button btnRefresh;
        private Button btnStart;
        private Label label4;
        private TextBox txtConfidence;
        private OpenFileDialog openFileDialog1;
        private Button btnImage;
        private Button btnDirectory;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
