namespace Lab1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericAngle = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericYScale = new System.Windows.Forms.NumericUpDown();
            this.numericXScale = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpdateX = new System.Windows.Forms.NumericUpDown();
            this.numericB = new System.Windows.Forms.NumericUpDown();
            this.numericA = new System.Windows.Forms.NumericUpDown();
            this.numericAccuracy = new System.Windows.Forms.NumericUpDown();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericYScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericXScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpdateX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericAccuracy)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.numericAngle);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.numericYScale);
            this.splitContainer1.Panel2.Controls.Add(this.numericXScale);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpdateX);
            this.splitContainer1.Panel2.Controls.Add(this.numericB);
            this.splitContainer1.Panel2.Controls.Add(this.numericA);
            this.splitContainer1.Panel2.Controls.Add(this.numericAccuracy);
            this.splitContainer1.Size = new System.Drawing.Size(817, 561);
            this.splitContainer1.SplitterDistance = 532;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 561);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // numericAngle
            // 
            this.numericAngle.DecimalPlaces = 1;
            this.numericAngle.Increment = new decimal(new int[] {1, 0, 0, 65536});
            this.numericAngle.Location = new System.Drawing.Point(18, 290);
            this.numericAngle.Maximum = new decimal(new int[] {3601, 0, 0, 65536});
            this.numericAngle.Minimum = new decimal(new int[] {1, 0, 0, -2147418112});
            this.numericAngle.Name = "numericAngle";
            this.numericAngle.Size = new System.Drawing.Size(120, 22);
            this.numericAngle.TabIndex = 16;
            this.numericAngle.ValueChanged += new System.EventHandler(this.numericAngle_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(143, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Angle";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(143, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Yscale";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(143, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "Xscale";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(143, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ymovement";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(143, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Xmovement";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(143, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "B";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(143, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "A";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(143, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Acc";
            // 
            // numericYScale
            // 
            this.numericYScale.DecimalPlaces = 2;
            this.numericYScale.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.numericYScale.Location = new System.Drawing.Point(18, 247);
            this.numericYScale.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.numericYScale.Name = "numericYScale";
            this.numericYScale.Size = new System.Drawing.Size(119, 22);
            this.numericYScale.TabIndex = 7;
            this.numericYScale.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numericYScale.ValueChanged += new System.EventHandler(this.numericYScale_ValueChanged);
            // 
            // numericXScale
            // 
            this.numericXScale.DecimalPlaces = 2;
            this.numericXScale.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.numericXScale.Location = new System.Drawing.Point(18, 219);
            this.numericXScale.Name = "numericXScale";
            this.numericXScale.Size = new System.Drawing.Size(119, 22);
            this.numericXScale.TabIndex = 6;
            this.numericXScale.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numericXScale.ValueChanged += new System.EventHandler(this.numericXScale_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(18, 178);
            this.numericUpDown1.Minimum = new decimal(new int[] {100, 0, 0, -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(119, 22);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpdateX
            // 
            this.numericUpdateX.Location = new System.Drawing.Point(18, 150);
            this.numericUpdateX.Minimum = new decimal(new int[] {100, 0, 0, -2147483648});
            this.numericUpdateX.Name = "numericUpdateX";
            this.numericUpdateX.Size = new System.Drawing.Size(119, 22);
            this.numericUpdateX.TabIndex = 4;
            this.numericUpdateX.ValueChanged += new System.EventHandler(this.numericUpdateX_ValueChanged);
            // 
            // numericB
            // 
            this.numericB.DecimalPlaces = 1;
            this.numericB.Increment = new decimal(new int[] {1, 0, 0, 65536});
            this.numericB.Location = new System.Drawing.Point(18, 98);
            this.numericB.Name = "numericB";
            this.numericB.Size = new System.Drawing.Size(120, 22);
            this.numericB.TabIndex = 3;
            this.numericB.Value = new decimal(new int[] {60, 0, 0, 0});
            this.numericB.ValueChanged += new System.EventHandler(this.numericB_ValueChanged);
            // 
            // numericA
            // 
            this.numericA.DecimalPlaces = 1;
            this.numericA.Increment = new decimal(new int[] {1, 0, 0, 65536});
            this.numericA.Location = new System.Drawing.Point(18, 70);
            this.numericA.Minimum = new decimal(new int[] {100, 0, 0, -2147483648});
            this.numericA.Name = "numericA";
            this.numericA.Size = new System.Drawing.Size(120, 22);
            this.numericA.TabIndex = 2;
            this.numericA.Value = new decimal(new int[] {57, 0, 0, 0});
            this.numericA.ValueChanged += new System.EventHandler(this.numericA_ValueChanged);
            // 
            // numericAccuracy
            // 
            this.numericAccuracy.DecimalPlaces = 2;
            this.numericAccuracy.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.numericAccuracy.Location = new System.Drawing.Point(17, 42);
            this.numericAccuracy.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.numericAccuracy.Minimum = new decimal(new int[] {1, 0, 0, 131072});
            this.numericAccuracy.Name = "numericAccuracy";
            this.numericAccuracy.Size = new System.Drawing.Size(120, 22);
            this.numericAccuracy.TabIndex = 1;
            this.numericAccuracy.Value = new decimal(new int[] {1, 0, 0, 131072});
            this.numericAccuracy.ValueChanged += new System.EventHandler(this.numericAccuracy_ValueChanged);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Lab1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericYScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericXScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpdateX)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericB)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericA)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericAccuracy)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericAngle;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.NumericUpDown numericYScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.NumericUpDown numericXScale;

        private System.Windows.Forms.NumericUpDown numericUpdateX;

        private System.Windows.Forms.NumericUpDown numericB;

        private System.Windows.Forms.NumericUpDown numericA;

        private System.Windows.Forms.NumericUpDown numericAccuracy;

        private System.Windows.Forms.NumericUpDown numericUpDown1;

        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;

        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion
    }
}