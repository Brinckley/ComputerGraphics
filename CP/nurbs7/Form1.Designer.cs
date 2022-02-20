namespace CP
{
    partial class Form1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picture = new System.Windows.Forms.PictureBox();
            this.textT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericIndex = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textCoords = new System.Windows.Forms.TextBox();
            this.textWeight = new System.Windows.Forms.TextBox();
            this.applyPoint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericApprox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize) (this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericApprox)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.picture.BackColor = System.Drawing.Color.Azure;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picture.Location = new System.Drawing.Point(231, 13);
            this.picture.Margin = new System.Windows.Forms.Padding(4);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(819, 525);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.Plot);
            // 
            // textT
            // 
            this.textT.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textT.Location = new System.Drawing.Point(16, 174);
            this.textT.Margin = new System.Windows.Forms.Padding(4);
            this.textT.Name = "textT";
            this.textT.Size = new System.Drawing.Size(202, 22);
            this.textT.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nodal vector:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Point:";
            // 
            // numericIndex
            // 
            this.numericIndex.Location = new System.Drawing.Point(77, 47);
            this.numericIndex.Margin = new System.Windows.Forms.Padding(4);
            this.numericIndex.Maximum = new decimal(new int[] {12, 0, 0, 0});
            this.numericIndex.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numericIndex.Name = "numericIndex";
            this.numericIndex.Size = new System.Drawing.Size(141, 22);
            this.numericIndex.TabIndex = 6;
            this.numericIndex.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Сoordinates:";
            // 
            // textCoords
            // 
            this.textCoords.Location = new System.Drawing.Point(16, 95);
            this.textCoords.Margin = new System.Windows.Forms.Padding(4);
            this.textCoords.Name = "textCoords";
            this.textCoords.Size = new System.Drawing.Size(202, 22);
            this.textCoords.TabIndex = 13;
            // 
            // textWeight
            // 
            this.textWeight.Location = new System.Drawing.Point(77, 127);
            this.textWeight.Margin = new System.Windows.Forms.Padding(4);
            this.textWeight.Name = "textWeight";
            this.textWeight.Size = new System.Drawing.Size(141, 22);
            this.textWeight.TabIndex = 16;
            // 
            // applyPoint
            // 
            this.applyPoint.Location = new System.Drawing.Point(16, 204);
            this.applyPoint.Margin = new System.Windows.Forms.Padding(4);
            this.applyPoint.Name = "applyPoint";
            this.applyPoint.Size = new System.Drawing.Size(202, 26);
            this.applyPoint.TabIndex = 15;
            this.applyPoint.Text = "OK";
            this.applyPoint.UseVisualStyleBackColor = true;
            this.applyPoint.Click += new System.EventHandler(this.applyPoint_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Weight:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Approximation:";
            // 
            // numericApprox
            // 
            this.numericApprox.Location = new System.Drawing.Point(141, 15);
            this.numericApprox.Margin = new System.Windows.Forms.Padding(4);
            this.numericApprox.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.numericApprox.Name = "numericApprox";
            this.numericApprox.Size = new System.Drawing.Size(77, 22);
            this.numericApprox.TabIndex = 18;
            this.numericApprox.Value = new decimal(new int[] {25, 0, 0, 0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.numericApprox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textWeight);
            this.Controls.Add(this.applyPoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textCoords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textT);
            this.Controls.Add(this.picture);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericApprox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.TextBox textT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCoords;
        private System.Windows.Forms.TextBox textWeight;
        private System.Windows.Forms.Button applyPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericApprox;
    }
}

