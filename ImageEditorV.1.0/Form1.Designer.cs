namespace ImageEditorV._1._0
{
    partial class IE_MainScene
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IE_MainScene));
            this.histogramCanvas = new System.Windows.Forms.PictureBox();
            this.mainCanvas = new System.Windows.Forms.PictureBox();
            this.btnRotateLeft = new System.Windows.Forms.PictureBox();
            this.btnRotateRight = new System.Windows.Forms.PictureBox();
            this.btnMirroring = new System.Windows.Forms.PictureBox();
            this.btnGrayScale = new System.Windows.Forms.PictureBox();
            this.btnNegativeInvert = new System.Windows.Forms.PictureBox();
            this.cb_Hisogram = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsm_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_RotateLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_RotateRight = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Mirroring = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_GrayScaling = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_ColorInverting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_About = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_ColorChannel = new System.Windows.Forms.ComboBox();
            this.txt_Histogram = new System.Windows.Forms.Label();
            this.txt_ColorChannel = new System.Windows.Forms.Label();
            this.tb_X = new System.Windows.Forms.TextBox();
            this.tb_Y = new System.Windows.Forms.TextBox();
            this.txt_X = new System.Windows.Forms.Label();
            this.txt_Y = new System.Windows.Forms.Label();
            this.btn_Scale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.histogramCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRotateLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRotateRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMirroring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrayScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNegativeInvert)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // histogramCanvas
            // 
            this.histogramCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramCanvas.Location = new System.Drawing.Point(988, 71);
            this.histogramCanvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.histogramCanvas.Name = "histogramCanvas";
            this.histogramCanvas.Size = new System.Drawing.Size(256, 256);
            this.histogramCanvas.TabIndex = 6;
            this.histogramCanvas.TabStop = false;
            // 
            // mainCanvas
            // 
            this.mainCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainCanvas.Location = new System.Drawing.Point(12, 37);
            this.mainCanvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainCanvas.Name = "mainCanvas";
            this.mainCanvas.Size = new System.Drawing.Size(960, 607);
            this.mainCanvas.TabIndex = 5;
            this.mainCanvas.TabStop = false;
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Image = global::ImageEditorV._1._0.Properties.Resources.left;
            this.btnRotateLeft.Location = new System.Drawing.Point(989, 332);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(45, 45);
            this.btnRotateLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRotateLeft.TabIndex = 10;
            this.btnRotateLeft.TabStop = false;
            this.btnRotateLeft.Click += new System.EventHandler(this.leftRotationClick);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Image = global::ImageEditorV._1._0.Properties.Resources.right;
            this.btnRotateRight.Location = new System.Drawing.Point(1042, 332);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(45, 45);
            this.btnRotateRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRotateRight.TabIndex = 11;
            this.btnRotateRight.TabStop = false;
            this.btnRotateRight.Click += new System.EventHandler(this.rightRotationClick);
            // 
            // btnMirroring
            // 
            this.btnMirroring.Image = global::ImageEditorV._1._0.Properties.Resources.mirror;
            this.btnMirroring.Location = new System.Drawing.Point(1094, 332);
            this.btnMirroring.Name = "btnMirroring";
            this.btnMirroring.Size = new System.Drawing.Size(45, 45);
            this.btnMirroring.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMirroring.TabIndex = 12;
            this.btnMirroring.TabStop = false;
            this.btnMirroring.Click += new System.EventHandler(this.mirroringClick);
            // 
            // btnGrayScale
            // 
            this.btnGrayScale.Image = global::ImageEditorV._1._0.Properties.Resources.gray;
            this.btnGrayScale.Location = new System.Drawing.Point(1147, 332);
            this.btnGrayScale.Name = "btnGrayScale";
            this.btnGrayScale.Size = new System.Drawing.Size(45, 45);
            this.btnGrayScale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGrayScale.TabIndex = 13;
            this.btnGrayScale.TabStop = false;
            this.btnGrayScale.Click += new System.EventHandler(this.grayScaleClick);
            // 
            // btnNegativeInvert
            // 
            this.btnNegativeInvert.Image = global::ImageEditorV._1._0.Properties.Resources.invert;
            this.btnNegativeInvert.Location = new System.Drawing.Point(1200, 332);
            this.btnNegativeInvert.Name = "btnNegativeInvert";
            this.btnNegativeInvert.Size = new System.Drawing.Size(45, 45);
            this.btnNegativeInvert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnNegativeInvert.TabIndex = 14;
            this.btnNegativeInvert.TabStop = false;
            this.btnNegativeInvert.Click += new System.EventHandler(this.negativeInvertClick);
            // 
            // cb_Hisogram
            // 
            this.cb_Hisogram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Hisogram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_Hisogram.Font = new System.Drawing.Font("Futura Bk BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Hisogram.FormattingEnabled = true;
            this.cb_Hisogram.Items.AddRange(new object[] {
            "RGB",
            "Red",
            "Green",
            "Blue"});
            this.cb_Hisogram.Location = new System.Drawing.Point(1078, 38);
            this.cb_Hisogram.Name = "cb_Hisogram";
            this.cb_Hisogram.Size = new System.Drawing.Size(166, 24);
            this.cb_Hisogram.TabIndex = 17;
            this.cb_Hisogram.SelectedIndexChanged += new System.EventHandler(this.cb_Hisogram_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_File,
            this.tsm_Edit,
            this.tsm_About});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1252, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsm_File
            // 
            this.tsm_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_Open,
            this.tsm_Save,
            this.tsm_Reset});
            this.tsm_File.Font = new System.Drawing.Font("Futura Bk BT", 10F);
            this.tsm_File.Name = "tsm_File";
            this.tsm_File.Size = new System.Drawing.Size(40, 20);
            this.tsm_File.Text = "File";
            // 
            // tsm_Open
            // 
            this.tsm_Open.Name = "tsm_Open";
            this.tsm_Open.Size = new System.Drawing.Size(111, 22);
            this.tsm_Open.Text = "Open";
            this.tsm_Open.Click += new System.EventHandler(this.tsm_Open_Click);
            // 
            // tsm_Save
            // 
            this.tsm_Save.Name = "tsm_Save";
            this.tsm_Save.Size = new System.Drawing.Size(111, 22);
            this.tsm_Save.Text = "Save";
            this.tsm_Save.Click += new System.EventHandler(this.tsm_Save_Click);
            // 
            // tsm_Reset
            // 
            this.tsm_Reset.Name = "tsm_Reset";
            this.tsm_Reset.Size = new System.Drawing.Size(111, 22);
            this.tsm_Reset.Text = "Reset";
            this.tsm_Reset.Click += new System.EventHandler(this.tsm_Reset_Click);
            // 
            // tsm_Edit
            // 
            this.tsm_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_RotateLeft,
            this.tsm_RotateRight,
            this.tsm_Mirroring,
            this.tsm_GrayScaling,
            this.tsm_ColorInverting});
            this.tsm_Edit.Font = new System.Drawing.Font("Futura Bk BT", 10F);
            this.tsm_Edit.Name = "tsm_Edit";
            this.tsm_Edit.Size = new System.Drawing.Size(42, 20);
            this.tsm_Edit.Text = "Edit";
            // 
            // tsm_RotateLeft
            // 
            this.tsm_RotateLeft.Name = "tsm_RotateLeft";
            this.tsm_RotateLeft.Size = new System.Drawing.Size(166, 22);
            this.tsm_RotateLeft.Text = "Left rotation";
            this.tsm_RotateLeft.Click += new System.EventHandler(this.tsm_RotateLeft_Click);
            // 
            // tsm_RotateRight
            // 
            this.tsm_RotateRight.Name = "tsm_RotateRight";
            this.tsm_RotateRight.Size = new System.Drawing.Size(166, 22);
            this.tsm_RotateRight.Text = "Right rotation";
            this.tsm_RotateRight.Click += new System.EventHandler(this.tsm_RotateRight_Click);
            // 
            // tsm_Mirroring
            // 
            this.tsm_Mirroring.Name = "tsm_Mirroring";
            this.tsm_Mirroring.Size = new System.Drawing.Size(166, 22);
            this.tsm_Mirroring.Text = "Mirorring";
            this.tsm_Mirroring.Click += new System.EventHandler(this.tsm_Mirroring_Click);
            // 
            // tsm_GrayScaling
            // 
            this.tsm_GrayScaling.Name = "tsm_GrayScaling";
            this.tsm_GrayScaling.Size = new System.Drawing.Size(166, 22);
            this.tsm_GrayScaling.Text = "Grey scale";
            this.tsm_GrayScaling.Click += new System.EventHandler(this.tsm_GrayScaling_Click);
            // 
            // tsm_ColorInverting
            // 
            this.tsm_ColorInverting.Name = "tsm_ColorInverting";
            this.tsm_ColorInverting.Size = new System.Drawing.Size(166, 22);
            this.tsm_ColorInverting.Text = "Color invertion";
            this.tsm_ColorInverting.Click += new System.EventHandler(this.tsm_ColorInverting_Click);
            // 
            // tsm_About
            // 
            this.tsm_About.Font = new System.Drawing.Font("Futura Bk BT", 10F);
            this.tsm_About.Name = "tsm_About";
            this.tsm_About.Size = new System.Drawing.Size(57, 20);
            this.tsm_About.Text = "About";
            this.tsm_About.Click += new System.EventHandler(this.tsm_Help_Click);
            // 
            // cb_ColorChannel
            // 
            this.cb_ColorChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ColorChannel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_ColorChannel.Font = new System.Drawing.Font("Futura Bk BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ColorChannel.FormattingEnabled = true;
            this.cb_ColorChannel.Items.AddRange(new object[] {
            "RGB",
            "Red",
            "Green",
            "Blue"});
            this.cb_ColorChannel.Location = new System.Drawing.Point(1120, 383);
            this.cb_ColorChannel.Name = "cb_ColorChannel";
            this.cb_ColorChannel.Size = new System.Drawing.Size(125, 24);
            this.cb_ColorChannel.TabIndex = 19;
            this.cb_ColorChannel.SelectedIndexChanged += new System.EventHandler(this.cb_ColorChannel_SelectedIndexChanged);
            // 
            // txt_Histogram
            // 
            this.txt_Histogram.AutoSize = true;
            this.txt_Histogram.Font = new System.Drawing.Font("Futura Bk BT", 10F);
            this.txt_Histogram.Location = new System.Drawing.Point(985, 43);
            this.txt_Histogram.Name = "txt_Histogram";
            this.txt_Histogram.Size = new System.Drawing.Size(80, 16);
            this.txt_Histogram.TabIndex = 20;
            this.txt_Histogram.Text = "Histogram :";
            // 
            // txt_ColorChannel
            // 
            this.txt_ColorChannel.AutoSize = true;
            this.txt_ColorChannel.Font = new System.Drawing.Font("Futura Bk BT", 10F);
            this.txt_ColorChannel.Location = new System.Drawing.Point(986, 388);
            this.txt_ColorChannel.Name = "txt_ColorChannel";
            this.txt_ColorChannel.Size = new System.Drawing.Size(106, 16);
            this.txt_ColorChannel.TabIndex = 21;
            this.txt_ColorChannel.Text = "Color Channel :";
            // 
            // tb_X
            // 
            this.tb_X.Font = new System.Drawing.Font("Futura Bk BT", 10.2F);
            this.tb_X.Location = new System.Drawing.Point(1019, 417);
            this.tb_X.Name = "tb_X";
            this.tb_X.Size = new System.Drawing.Size(62, 24);
            this.tb_X.TabIndex = 22;
            // 
            // tb_Y
            // 
            this.tb_Y.Font = new System.Drawing.Font("Futura Bk BT", 10.2F);
            this.tb_Y.Location = new System.Drawing.Point(1119, 417);
            this.tb_Y.Name = "tb_Y";
            this.tb_Y.Size = new System.Drawing.Size(62, 24);
            this.tb_Y.TabIndex = 23;
            // 
            // txt_X
            // 
            this.txt_X.AutoSize = true;
            this.txt_X.Location = new System.Drawing.Point(988, 422);
            this.txt_X.Name = "txt_X";
            this.txt_X.Size = new System.Drawing.Size(21, 15);
            this.txt_X.TabIndex = 24;
            this.txt_X.Text = "X :";
            // 
            // txt_Y
            // 
            this.txt_Y.AutoSize = true;
            this.txt_Y.Location = new System.Drawing.Point(1087, 422);
            this.txt_Y.Name = "txt_Y";
            this.txt_Y.Size = new System.Drawing.Size(22, 15);
            this.txt_Y.TabIndex = 25;
            this.txt_Y.Text = "Y :";
            // 
            // btn_Scale
            // 
            this.btn_Scale.Font = new System.Drawing.Font("Futura Bk BT", 10F);
            this.btn_Scale.Location = new System.Drawing.Point(1187, 417);
            this.btn_Scale.Name = "btn_Scale";
            this.btn_Scale.Size = new System.Drawing.Size(58, 28);
            this.btn_Scale.TabIndex = 26;
            this.btn_Scale.Text = "Scale";
            this.btn_Scale.UseVisualStyleBackColor = true;
            this.btn_Scale.Click += new System.EventHandler(this.btn_Scale_Click);
            // 
            // IE_MainScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1252, 660);
            this.Controls.Add(this.btn_Scale);
            this.Controls.Add(this.txt_Y);
            this.Controls.Add(this.txt_X);
            this.Controls.Add(this.tb_Y);
            this.Controls.Add(this.tb_X);
            this.Controls.Add(this.txt_ColorChannel);
            this.Controls.Add(this.txt_Histogram);
            this.Controls.Add(this.cb_ColorChannel);
            this.Controls.Add(this.cb_Hisogram);
            this.Controls.Add(this.btnNegativeInvert);
            this.Controls.Add(this.btnGrayScale);
            this.Controls.Add(this.btnMirroring);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.btnRotateLeft);
            this.Controls.Add(this.histogramCanvas);
            this.Controls.Add(this.mainCanvas);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Futura Bk BT", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "IE_MainScene";
            this.Text = "Image Editor Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.histogramCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRotateLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRotateRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMirroring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrayScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNegativeInvert)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox mainCanvas;
        private System.Windows.Forms.PictureBox histogramCanvas;
        private System.Windows.Forms.PictureBox btnRotateLeft;
        private System.Windows.Forms.PictureBox btnRotateRight;
        private System.Windows.Forms.PictureBox btnMirroring;
        private System.Windows.Forms.PictureBox btnGrayScale;
        private System.Windows.Forms.PictureBox btnNegativeInvert;
        private System.Windows.Forms.ComboBox cb_Hisogram;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsm_File;
        private System.Windows.Forms.ToolStripMenuItem tsm_Open;
        private System.Windows.Forms.ToolStripMenuItem tsm_Save;
        private System.Windows.Forms.ToolStripMenuItem tsm_Edit;
        private System.Windows.Forms.ToolStripMenuItem tsm_RotateLeft;
        private System.Windows.Forms.ToolStripMenuItem tsm_RotateRight;
        private System.Windows.Forms.ToolStripMenuItem tsm_Mirroring;
        private System.Windows.Forms.ToolStripMenuItem tsm_GrayScaling;
        private System.Windows.Forms.ToolStripMenuItem tsm_ColorInverting;
        private System.Windows.Forms.ToolStripMenuItem tsm_About;
        private System.Windows.Forms.ToolStripMenuItem tsm_Reset;
        private System.Windows.Forms.ComboBox cb_ColorChannel;
        private System.Windows.Forms.Label txt_Histogram;
        private System.Windows.Forms.Label txt_ColorChannel;
        private System.Windows.Forms.TextBox tb_X;
        private System.Windows.Forms.TextBox tb_Y;
        private System.Windows.Forms.Label txt_X;
        private System.Windows.Forms.Label txt_Y;
        private System.Windows.Forms.Button btn_Scale;
    }
}

