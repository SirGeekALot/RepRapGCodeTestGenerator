namespace RepRapGCodeTestGenerator
{
    partial class Form1
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
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.chkBigSquare = new System.Windows.Forms.CheckBox();
            this.chkSmallSquare = new System.Windows.Forms.CheckBox();
            this.chkLargeCircle = new System.Windows.Forms.CheckBox();
            this.chkSmallCircle = new System.Windows.Forms.CheckBox();
            this.chkDiagonals = new System.Windows.Forms.CheckBox();
            this.txtXMax = new System.Windows.Forms.TextBox();
            this.lblXMax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblYMax = new System.Windows.Forms.Label();
            this.txtYMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtXMin = new System.Windows.Forms.TextBox();
            this.txtYMin = new System.Windows.Forms.TextBox();
            this.lblXMin = new System.Windows.Forms.Label();
            this.lblYMin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRepeats = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCircleSegmentCount = new System.Windows.Forms.TextBox();
            this.btnOpenInNotepad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(15, 323);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(586, 114);
            this.btnCreateFile.TabIndex = 0;
            this.btnCreateFile.Text = "Create G-Code file!";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output file name";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(15, 297);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(586, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // chkBigSquare
            // 
            this.chkBigSquare.AutoSize = true;
            this.chkBigSquare.Checked = true;
            this.chkBigSquare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBigSquare.Location = new System.Drawing.Point(174, 28);
            this.chkBigSquare.Name = "chkBigSquare";
            this.chkBigSquare.Size = new System.Drawing.Size(78, 17);
            this.chkBigSquare.TabIndex = 3;
            this.chkBigSquare.Text = "Big Square";
            this.chkBigSquare.UseVisualStyleBackColor = true;
            // 
            // chkSmallSquare
            // 
            this.chkSmallSquare.AutoSize = true;
            this.chkSmallSquare.Checked = true;
            this.chkSmallSquare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmallSquare.Location = new System.Drawing.Point(174, 51);
            this.chkSmallSquare.Name = "chkSmallSquare";
            this.chkSmallSquare.Size = new System.Drawing.Size(88, 17);
            this.chkSmallSquare.TabIndex = 4;
            this.chkSmallSquare.Text = "Small Square";
            this.chkSmallSquare.UseVisualStyleBackColor = true;
            // 
            // chkLargeCircle
            // 
            this.chkLargeCircle.AutoSize = true;
            this.chkLargeCircle.Checked = true;
            this.chkLargeCircle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLargeCircle.Location = new System.Drawing.Point(174, 97);
            this.chkLargeCircle.Name = "chkLargeCircle";
            this.chkLargeCircle.Size = new System.Drawing.Size(82, 17);
            this.chkLargeCircle.TabIndex = 5;
            this.chkLargeCircle.Text = "Large Circle";
            this.chkLargeCircle.UseVisualStyleBackColor = true;
            // 
            // chkSmallCircle
            // 
            this.chkSmallCircle.AutoSize = true;
            this.chkSmallCircle.Location = new System.Drawing.Point(174, 121);
            this.chkSmallCircle.Name = "chkSmallCircle";
            this.chkSmallCircle.Size = new System.Drawing.Size(80, 17);
            this.chkSmallCircle.TabIndex = 6;
            this.chkSmallCircle.Text = "Small Circle";
            this.chkSmallCircle.UseVisualStyleBackColor = true;
            // 
            // chkDiagonals
            // 
            this.chkDiagonals.AutoSize = true;
            this.chkDiagonals.Checked = true;
            this.chkDiagonals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiagonals.Location = new System.Drawing.Point(174, 74);
            this.chkDiagonals.Name = "chkDiagonals";
            this.chkDiagonals.Size = new System.Drawing.Size(153, 17);
            this.chkDiagonals.TabIndex = 7;
            this.chkDiagonals.Text = "Corner to Corner Diagonals";
            this.chkDiagonals.UseVisualStyleBackColor = true;
            // 
            // txtXMax
            // 
            this.txtXMax.Location = new System.Drawing.Point(55, 83);
            this.txtXMax.Name = "txtXMax";
            this.txtXMax.Size = new System.Drawing.Size(38, 20);
            this.txtXMax.TabIndex = 8;
            this.txtXMax.Text = "200";
            // 
            // lblXMax
            // 
            this.lblXMax.AutoSize = true;
            this.lblXMax.Location = new System.Drawing.Point(12, 86);
            this.lblXMax.Name = "lblXMax";
            this.lblXMax.Size = new System.Drawing.Size(40, 13);
            this.lblXMax.TabIndex = 9;
            this.lblXMax.Text = "X Max:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Build Plate Dimensions:";
            // 
            // lblYMax
            // 
            this.lblYMax.AutoSize = true;
            this.lblYMax.Location = new System.Drawing.Point(12, 113);
            this.lblYMax.Name = "lblYMax";
            this.lblYMax.Size = new System.Drawing.Size(40, 13);
            this.lblYMax.TabIndex = 11;
            this.lblYMax.Text = "Y Max:";
            // 
            // txtYMax
            // 
            this.txtYMax.Location = new System.Drawing.Point(55, 110);
            this.txtYMax.Name = "txtYMax";
            this.txtYMax.Size = new System.Drawing.Size(38, 20);
            this.txtYMax.TabIndex = 12;
            this.txtYMax.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "G-Code Features To Generate:";
            // 
            // txtXMin
            // 
            this.txtXMin.Location = new System.Drawing.Point(55, 29);
            this.txtXMin.Name = "txtXMin";
            this.txtXMin.Size = new System.Drawing.Size(38, 20);
            this.txtXMin.TabIndex = 14;
            this.txtXMin.Text = "0";
            // 
            // txtYMin
            // 
            this.txtYMin.Location = new System.Drawing.Point(55, 56);
            this.txtYMin.Name = "txtYMin";
            this.txtYMin.Size = new System.Drawing.Size(38, 20);
            this.txtYMin.TabIndex = 15;
            this.txtYMin.Text = "0";
            // 
            // lblXMin
            // 
            this.lblXMin.AutoSize = true;
            this.lblXMin.Location = new System.Drawing.Point(12, 32);
            this.lblXMin.Name = "lblXMin";
            this.lblXMin.Size = new System.Drawing.Size(37, 13);
            this.lblXMin.TabIndex = 16;
            this.lblXMin.Text = "X Min:";
            // 
            // lblYMin
            // 
            this.lblYMin.AutoSize = true;
            this.lblYMin.Location = new System.Drawing.Point(12, 59);
            this.lblYMin.Name = "lblYMin";
            this.lblYMin.Size = new System.Drawing.Size(37, 13);
            this.lblYMin.TabIndex = 17;
            this.lblYMin.Text = "Y Min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Number of times to repeat everything:";
            // 
            // txtRepeats
            // 
            this.txtRepeats.Location = new System.Drawing.Point(174, 172);
            this.txtRepeats.Name = "txtRepeats";
            this.txtRepeats.Size = new System.Drawing.Size(100, 20);
            this.txtRepeats.TabIndex = 19;
            this.txtRepeats.Text = "1";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(15, 172);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(110, 20);
            this.txtSpeed.TabIndex = 20;
            this.txtSpeed.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Speed to use, in mm/s";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Circle segments";
            // 
            // txtCircleSegmentCount
            // 
            this.txtCircleSegmentCount.Location = new System.Drawing.Point(438, 26);
            this.txtCircleSegmentCount.Name = "txtCircleSegmentCount";
            this.txtCircleSegmentCount.Size = new System.Drawing.Size(44, 20);
            this.txtCircleSegmentCount.TabIndex = 23;
            this.txtCircleSegmentCount.Text = "720";
            // 
            // btnOpenInNotepad
            // 
            this.btnOpenInNotepad.Location = new System.Drawing.Point(400, 253);
            this.btnOpenInNotepad.Name = "btnOpenInNotepad";
            this.btnOpenInNotepad.Size = new System.Drawing.Size(201, 38);
            this.btnOpenInNotepad.TabIndex = 24;
            this.btnOpenInNotepad.Text = "Open in Notepad";
            this.btnOpenInNotepad.UseVisualStyleBackColor = true;
            this.btnOpenInNotepad.Click += new System.EventHandler(this.btnOpenInNotepad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 449);
            this.Controls.Add(this.btnOpenInNotepad);
            this.Controls.Add(this.txtCircleSegmentCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtRepeats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblYMin);
            this.Controls.Add(this.lblXMin);
            this.Controls.Add(this.txtYMin);
            this.Controls.Add(this.txtXMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtYMax);
            this.Controls.Add(this.lblYMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblXMax);
            this.Controls.Add(this.txtXMax);
            this.Controls.Add(this.chkDiagonals);
            this.Controls.Add(this.chkSmallCircle);
            this.Controls.Add(this.chkLargeCircle);
            this.Controls.Add(this.chkSmallSquare);
            this.Controls.Add(this.chkBigSquare);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateFile);
            this.Name = "Form1";
            this.Text = "RepRap Break-In G-Code Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.CheckBox chkBigSquare;
        private System.Windows.Forms.CheckBox chkSmallSquare;
        private System.Windows.Forms.CheckBox chkLargeCircle;
        private System.Windows.Forms.CheckBox chkSmallCircle;
        private System.Windows.Forms.CheckBox chkDiagonals;
        private System.Windows.Forms.TextBox txtXMax;
        private System.Windows.Forms.Label lblXMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblYMax;
        private System.Windows.Forms.TextBox txtYMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtXMin;
        private System.Windows.Forms.TextBox txtYMin;
        private System.Windows.Forms.Label lblXMin;
        private System.Windows.Forms.Label lblYMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRepeats;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCircleSegmentCount;
        private System.Windows.Forms.Button btnOpenInNotepad;
    }
}

