namespace INFOIBV
{
    partial class INFOIBV
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
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageFileName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.wantGrayscale = new System.Windows.Forms.CheckBox();
            this.filterCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeBox = new System.Windows.Forms.TextBox();
            this.filterBox = new System.Windows.Forms.CheckBox();
            this.edgeBox = new System.Windows.Forms.CheckBox();
            this.thresholdBox = new System.Windows.Forms.CheckBox();
            this.thresholdField = new System.Windows.Forms.TextBox();
            this.sharpenBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.smoothBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sharpBox = new System.Windows.Forms.TextBox();
            this.smoothSizeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.strucSizeBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.strucShapeCombo = new System.Windows.Forms.ComboBox();
            this.closeBox = new System.Windows.Forms.CheckBox();
            this.preButton = new System.Windows.Forms.Button();
            this.circleDetect = new System.Windows.Forms.CheckBox();
            this.rMin = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rMax = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.classifyButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.noiseTrack = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.noiseCount = new System.Windows.Forms.Label();
            this.preClassifyButton = new System.Windows.Forms.Button();
            this.copperCount = new System.Windows.Forms.Label();
            this.countUnclassified = new System.Windows.Forms.Label();
            this.goldCount = new System.Windows.Forms.Label();
            this.countOneEu = new System.Windows.Forms.Label();
            this.countTwoEu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiseTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(16, 15);
            this.LoadImageButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(131, 28);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Load image...";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = "Bitmap files (*.bmp;*.gif;*.jpg;*.png;*.tiff;*.jpeg)|*.bmp;*.gif;*.jpg;*.png;*.ti" +
    "ff;*.jpeg";
            this.openImageDialog.InitialDirectory = "..\\..\\images";
            // 
            // imageFileName
            // 
            this.imageFileName.Location = new System.Drawing.Point(155, 17);
            this.imageFileName.Margin = new System.Windows.Forms.Padding(4);
            this.imageFileName.Name = "imageFileName";
            this.imageFileName.ReadOnly = true;
            this.imageFileName.Size = new System.Drawing.Size(420, 22);
            this.imageFileName.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 630);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(637, 15);
            this.applyButton.Margin = new System.Windows.Forms.Padding(4);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(137, 28);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.Filter = "Bitmap file (*.bmp)|*.bmp";
            this.saveImageDialog.InitialDirectory = "..\\..\\images";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1264, 14);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(127, 28);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save as BMP...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(708, 55);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(683, 630);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(783, 17);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(368, 25);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // wantGrayscale
            // 
            this.wantGrayscale.AutoSize = true;
            this.wantGrayscale.Cursor = System.Windows.Forms.Cursors.Default;
            this.wantGrayscale.Location = new System.Drawing.Point(1399, 54);
            this.wantGrayscale.Margin = new System.Windows.Forms.Padding(4);
            this.wantGrayscale.Name = "wantGrayscale";
            this.wantGrayscale.Size = new System.Drawing.Size(160, 21);
            this.wantGrayscale.TabIndex = 9;
            this.wantGrayscale.Text = "(Re)apply Grayscale";
            this.wantGrayscale.UseVisualStyleBackColor = true;
            // 
            // filterCombo
            // 
            this.filterCombo.FormattingEnabled = true;
            this.filterCombo.Items.AddRange(new object[] {
            "Median"});
            this.filterCombo.Location = new System.Drawing.Point(1508, 82);
            this.filterCombo.Margin = new System.Windows.Forms.Padding(4);
            this.filterCombo.Name = "filterCombo";
            this.filterCombo.Size = new System.Drawing.Size(105, 24);
            this.filterCombo.TabIndex = 11;
            this.filterCombo.Text = "Median";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1424, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Size";
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point(1428, 135);
            this.sizeBox.Margin = new System.Windows.Forms.Padding(4);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(185, 22);
            this.sizeBox.TabIndex = 14;
            this.sizeBox.Text = "3";
            // 
            // filterBox
            // 
            this.filterBox.AutoSize = true;
            this.filterBox.Location = new System.Drawing.Point(1399, 82);
            this.filterBox.Margin = new System.Windows.Forms.Padding(4);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(100, 21);
            this.filterBox.TabIndex = 18;
            this.filterBox.Text = "Apply Filter";
            this.filterBox.UseVisualStyleBackColor = true;
            // 
            // edgeBox
            // 
            this.edgeBox.AutoSize = true;
            this.edgeBox.Location = new System.Drawing.Point(1399, 171);
            this.edgeBox.Margin = new System.Windows.Forms.Padding(4);
            this.edgeBox.Name = "edgeBox";
            this.edgeBox.Size = new System.Drawing.Size(127, 21);
            this.edgeBox.TabIndex = 19;
            this.edgeBox.Text = "Edge Detection";
            this.edgeBox.UseVisualStyleBackColor = true;
            // 
            // thresholdBox
            // 
            this.thresholdBox.AutoSize = true;
            this.thresholdBox.Location = new System.Drawing.Point(1399, 200);
            this.thresholdBox.Margin = new System.Windows.Forms.Padding(4);
            this.thresholdBox.Name = "thresholdBox";
            this.thresholdBox.Size = new System.Drawing.Size(94, 21);
            this.thresholdBox.TabIndex = 20;
            this.thresholdBox.Text = "Threshold";
            this.thresholdBox.UseVisualStyleBackColor = true;
            // 
            // thresholdField
            // 
            this.thresholdField.Location = new System.Drawing.Point(1504, 197);
            this.thresholdField.Margin = new System.Windows.Forms.Padding(4);
            this.thresholdField.Name = "thresholdField";
            this.thresholdField.Size = new System.Drawing.Size(109, 22);
            this.thresholdField.TabIndex = 21;
            this.thresholdField.Text = "44";
            // 
            // sharpenBox
            // 
            this.sharpenBox.AutoSize = true;
            this.sharpenBox.Location = new System.Drawing.Point(1399, 230);
            this.sharpenBox.Margin = new System.Windows.Forms.Padding(4);
            this.sharpenBox.Name = "sharpenBox";
            this.sharpenBox.Size = new System.Drawing.Size(128, 21);
            this.sharpenBox.TabIndex = 22;
            this.sharpenBox.Text = "Sharpen Edges";
            this.sharpenBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1424, 262);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Smoothing Factor";
            // 
            // smoothBox
            // 
            this.smoothBox.Location = new System.Drawing.Point(1428, 283);
            this.smoothBox.Margin = new System.Windows.Forms.Padding(4);
            this.smoothBox.Name = "smoothBox";
            this.smoothBox.Size = new System.Drawing.Size(185, 22);
            this.smoothBox.TabIndex = 24;
            this.smoothBox.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1428, 362);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Sharpening Factor";
            // 
            // sharpBox
            // 
            this.sharpBox.Location = new System.Drawing.Point(1428, 383);
            this.sharpBox.Margin = new System.Windows.Forms.Padding(4);
            this.sharpBox.Name = "sharpBox";
            this.sharpBox.Size = new System.Drawing.Size(185, 22);
            this.sharpBox.TabIndex = 26;
            this.sharpBox.Text = "8";
            // 
            // smoothSizeBox
            // 
            this.smoothSizeBox.Location = new System.Drawing.Point(1428, 333);
            this.smoothSizeBox.Margin = new System.Windows.Forms.Padding(4);
            this.smoothSizeBox.Name = "smoothSizeBox";
            this.smoothSizeBox.Size = new System.Drawing.Size(185, 22);
            this.smoothSizeBox.TabIndex = 28;
            this.smoothSizeBox.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1428, 312);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Smoothing Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1399, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Pre-Processing";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1424, 449);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "Structure Shape";
            // 
            // strucSizeBox
            // 
            this.strucSizeBox.Location = new System.Drawing.Point(1431, 525);
            this.strucSizeBox.Margin = new System.Windows.Forms.Padding(4);
            this.strucSizeBox.Name = "strucSizeBox";
            this.strucSizeBox.Size = new System.Drawing.Size(185, 22);
            this.strucSizeBox.TabIndex = 37;
            this.strucSizeBox.Text = "8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1427, 505);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Structure Size";
            // 
            // strucShapeCombo
            // 
            this.strucShapeCombo.FormattingEnabled = true;
            this.strucShapeCombo.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Plus"});
            this.strucShapeCombo.Location = new System.Drawing.Point(1428, 470);
            this.strucShapeCombo.Margin = new System.Windows.Forms.Padding(4);
            this.strucShapeCombo.Name = "strucShapeCombo";
            this.strucShapeCombo.Size = new System.Drawing.Size(185, 24);
            this.strucShapeCombo.TabIndex = 38;
            this.strucShapeCombo.Text = "Circle";
            // 
            // closeBox
            // 
            this.closeBox.AutoSize = true;
            this.closeBox.Location = new System.Drawing.Point(1397, 419);
            this.closeBox.Margin = new System.Windows.Forms.Padding(4);
            this.closeBox.Name = "closeBox";
            this.closeBox.Size = new System.Drawing.Size(107, 21);
            this.closeBox.TabIndex = 40;
            this.closeBox.Text = "Close Image";
            this.closeBox.UseVisualStyleBackColor = true;
            // 
            // preButton
            // 
            this.preButton.Location = new System.Drawing.Point(1469, 564);
            this.preButton.Margin = new System.Windows.Forms.Padding(4);
            this.preButton.Name = "preButton";
            this.preButton.Size = new System.Drawing.Size(100, 28);
            this.preButton.TabIndex = 81;
            this.preButton.Text = "Pre-Process";
            this.preButton.UseVisualStyleBackColor = true;
            this.preButton.Click += new System.EventHandler(this.preButton_Click);
            // 
            // circleDetect
            // 
            this.circleDetect.AutoSize = true;
            this.circleDetect.Location = new System.Drawing.Point(1629, 114);
            this.circleDetect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.circleDetect.Name = "circleDetect";
            this.circleDetect.Size = new System.Drawing.Size(129, 21);
            this.circleDetect.TabIndex = 82;
            this.circleDetect.Text = "Circle Detection";
            this.circleDetect.UseVisualStyleBackColor = true;
            // 
            // rMin
            // 
            this.rMin.Location = new System.Drawing.Point(1629, 82);
            this.rMin.Margin = new System.Windows.Forms.Padding(4);
            this.rMin.Name = "rMin";
            this.rMin.Size = new System.Drawing.Size(90, 22);
            this.rMin.TabIndex = 86;
            this.rMin.Text = "40";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1623, 58);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 17);
            this.label18.TabIndex = 85;
            this.label18.Text = "Minimum";
            // 
            // rMax
            // 
            this.rMax.Location = new System.Drawing.Point(1724, 82);
            this.rMax.Margin = new System.Windows.Forms.Padding(4);
            this.rMax.Name = "rMax";
            this.rMax.Size = new System.Drawing.Size(90, 22);
            this.rMax.TabIndex = 88;
            this.rMax.Text = "90";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1722, 58);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 17);
            this.label19.TabIndex = 87;
            this.label19.Text = "Maximum";
            // 
            // classifyButton
            // 
            this.classifyButton.Location = new System.Drawing.Point(1676, 244);
            this.classifyButton.Margin = new System.Windows.Forms.Padding(4);
            this.classifyButton.Name = "classifyButton";
            this.classifyButton.Size = new System.Drawing.Size(100, 28);
            this.classifyButton.TabIndex = 95;
            this.classifyButton.Text = "Classify";
            this.classifyButton.UseVisualStyleBackColor = true;
            this.classifyButton.Click += new System.EventHandler(this.classifyButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1623, 147);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 96;
            this.label7.Text = "Color Noise";
            // 
            // noiseTrack
            // 
            this.noiseTrack.LargeChange = 2;
            this.noiseTrack.Location = new System.Drawing.Point(1623, 171);
            this.noiseTrack.Margin = new System.Windows.Forms.Padding(4);
            this.noiseTrack.Name = "noiseTrack";
            this.noiseTrack.Size = new System.Drawing.Size(191, 56);
            this.noiseTrack.TabIndex = 97;
            this.noiseTrack.Scroll += new System.EventHandler(this.noiseTrack_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1623, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 17);
            this.label10.TabIndex = 98;
            this.label10.Text = "Circle Radius";
            // 
            // noiseCount
            // 
            this.noiseCount.AutoSize = true;
            this.noiseCount.Location = new System.Drawing.Point(1709, 210);
            this.noiseCount.Name = "noiseCount";
            this.noiseCount.Size = new System.Drawing.Size(16, 17);
            this.noiseCount.TabIndex = 101;
            this.noiseCount.Text = "0";
            // 
            // preClassifyButton
            // 
            this.preClassifyButton.Location = new System.Drawing.Point(1657, 279);
            this.preClassifyButton.Name = "preClassifyButton";
            this.preClassifyButton.Size = new System.Drawing.Size(136, 49);
            this.preClassifyButton.TabIndex = 102;
            this.preClassifyButton.Text = "Pre-Process and Classify";
            this.preClassifyButton.UseVisualStyleBackColor = true;
            this.preClassifyButton.Click += new System.EventHandler(this.preClassifyButtonClick);
            // 
            // copperCount
            // 
            this.copperCount.AutoSize = true;
            this.copperCount.Location = new System.Drawing.Point(1626, 337);
            this.copperCount.Name = "copperCount";
            this.copperCount.Size = new System.Drawing.Size(0, 17);
            this.copperCount.TabIndex = 103;
            // 
            // countUnclassified
            // 
            this.countUnclassified.AutoSize = true;
            this.countUnclassified.Location = new System.Drawing.Point(1626, 437);
            this.countUnclassified.Name = "countUnclassified";
            this.countUnclassified.Size = new System.Drawing.Size(0, 17);
            this.countUnclassified.TabIndex = 104;
            // 
            // goldCount
            // 
            this.goldCount.AutoSize = true;
            this.goldCount.Location = new System.Drawing.Point(1626, 361);
            this.goldCount.Name = "goldCount";
            this.goldCount.Size = new System.Drawing.Size(0, 17);
            this.goldCount.TabIndex = 104;
            // 
            // countOneEu
            // 
            this.countOneEu.AutoSize = true;
            this.countOneEu.Location = new System.Drawing.Point(1626, 385);
            this.countOneEu.Name = "countOneEu";
            this.countOneEu.Size = new System.Drawing.Size(0, 17);
            this.countOneEu.TabIndex = 105;
            // 
            // countTwoEu
            // 
            this.countTwoEu.AutoSize = true;
            this.countTwoEu.Location = new System.Drawing.Point(1626, 411);
            this.countTwoEu.Name = "countTwoEu";
            this.countTwoEu.Size = new System.Drawing.Size(0, 17);
            this.countTwoEu.TabIndex = 106;
            // 
            // INFOIBV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1867, 711);
            this.Controls.Add(this.countTwoEu);
            this.Controls.Add(this.countOneEu);
            this.Controls.Add(this.goldCount);
            this.Controls.Add(this.countUnclassified);
            this.Controls.Add(this.copperCount);
            this.Controls.Add(this.preClassifyButton);
            this.Controls.Add(this.noiseCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.noiseTrack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.classifyButton);
            this.Controls.Add(this.rMax);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.rMin);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.circleDetect);
            this.Controls.Add(this.preButton);
            this.Controls.Add(this.closeBox);
            this.Controls.Add(this.strucShapeCombo);
            this.Controls.Add(this.strucSizeBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.smoothSizeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sharpBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.smoothBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sharpenBox);
            this.Controls.Add(this.thresholdField);
            this.Controls.Add(this.thresholdBox);
            this.Controls.Add(this.edgeBox);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterCombo);
            this.Controls.Add(this.wantGrayscale);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imageFileName);
            this.Controls.Add(this.LoadImageButton);
            this.Location = new System.Drawing.Point(10, 10);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "INFOIBV";
            this.ShowIcon = false;
            this.Text = "INFOIBV";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiseTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.TextBox imageFileName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox wantGrayscale;
        private System.Windows.Forms.ComboBox filterCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sizeBox;
        private System.Windows.Forms.CheckBox filterBox;
        private System.Windows.Forms.CheckBox edgeBox;
        private System.Windows.Forms.CheckBox thresholdBox;
        private System.Windows.Forms.TextBox thresholdField;
        private System.Windows.Forms.CheckBox sharpenBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox smoothBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sharpBox;
        private System.Windows.Forms.TextBox smoothSizeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox strucSizeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox strucShapeCombo;
        private System.Windows.Forms.CheckBox closeBox;
        private System.Windows.Forms.Button preButton;
        private System.Windows.Forms.CheckBox circleDetect;
        private System.Windows.Forms.TextBox rMin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox rMax;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button classifyButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar noiseTrack;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label noiseCount;
        private System.Windows.Forms.Button preClassifyButton;
        private System.Windows.Forms.Label copperCount;
        private System.Windows.Forms.Label countUnclassified;
        private System.Windows.Forms.Label goldCount;
        private System.Windows.Forms.Label countOneEu;
        private System.Windows.Forms.Label countTwoEu;
    }
}

