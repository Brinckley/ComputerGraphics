namespace Lab7
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
            this.label1 = new System.Windows.Forms.Label();
            this.valueApprox = new System.Windows.Forms.NumericUpDown();
            this.valueax = new System.Windows.Forms.NumericUpDown();
            this.valueay = new System.Windows.Forms.NumericUpDown();
            this.valueaw = new System.Windows.Forms.NumericUpDown();
            this.picture = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.valuebw = new System.Windows.Forms.NumericUpDown();
            this.valueby = new System.Windows.Forms.NumericUpDown();
            this.valuebx = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.valuecw = new System.Windows.Forms.NumericUpDown();
            this.valuecy = new System.Windows.Forms.NumericUpDown();
            this.valuecx = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.valuedw = new System.Windows.Forms.NumericUpDown();
            this.valuedy = new System.Windows.Forms.NumericUpDown();
            this.valuedx = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.valueew = new System.Windows.Forms.NumericUpDown();
            this.valueey = new System.Windows.Forms.NumericUpDown();
            this.valueex = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.valuefw = new System.Windows.Forms.NumericUpDown();
            this.valuefy = new System.Windows.Forms.NumericUpDown();
            this.valuefx = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize) (this.valueApprox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuebw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuebx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuecw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuecy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuecx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuedw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuedy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuedx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuefw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuefy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuefx)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(863, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Approximation:";
            // 
            // valueApprox
            // 
            this.valueApprox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueApprox.Location = new System.Drawing.Point(859, 37);
            this.valueApprox.Margin = new System.Windows.Forms.Padding(4);
            this.valueApprox.Minimum = new decimal(new int[] {5, 0, 0, 0});
            this.valueApprox.Name = "valueApprox";
            this.valueApprox.Size = new System.Drawing.Size(192, 22);
            this.valueApprox.TabIndex = 11;
            this.valueApprox.Value = new decimal(new int[] {50, 0, 0, 0});
            this.valueApprox.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valueax
            // 
            this.valueax.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueax.DecimalPlaces = 2;
            this.valueax.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valueax.Location = new System.Drawing.Point(859, 85);
            this.valueax.Margin = new System.Windows.Forms.Padding(4);
            this.valueax.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valueax.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valueax.Name = "valueax";
            this.valueax.Size = new System.Drawing.Size(59, 22);
            this.valueax.TabIndex = 13;
            this.valueax.Value = new decimal(new int[] {15, 0, 0, -2147418112});
            this.valueax.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valueay
            // 
            this.valueay.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueay.DecimalPlaces = 2;
            this.valueay.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valueay.Location = new System.Drawing.Point(925, 85);
            this.valueay.Margin = new System.Windows.Forms.Padding(4);
            this.valueay.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valueay.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valueay.Name = "valueay";
            this.valueay.Size = new System.Drawing.Size(59, 22);
            this.valueay.TabIndex = 14;
            this.valueay.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valueaw
            // 
            this.valueaw.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueaw.DecimalPlaces = 2;
            this.valueaw.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valueaw.Location = new System.Drawing.Point(992, 85);
            this.valueaw.Margin = new System.Windows.Forms.Padding(4);
            this.valueaw.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valueaw.Name = "valueaw";
            this.valueaw.Size = new System.Drawing.Size(59, 22);
            this.valueaw.TabIndex = 15;
            this.valueaw.Value = new decimal(new int[] {1, 0, 0, 0});
            this.valueaw.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // picture
            // 
            this.picture.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.picture.BackColor = System.Drawing.Color.Lavender;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picture.Location = new System.Drawing.Point(16, 15);
            this.picture.Margin = new System.Windows.Forms.Padding(4);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(833, 538);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(859, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "A:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(988, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Weight:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(988, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Weight:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(859, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "B:";
            // 
            // valuebw
            // 
            this.valuebw.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuebw.DecimalPlaces = 2;
            this.valuebw.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuebw.Location = new System.Drawing.Point(992, 133);
            this.valuebw.Margin = new System.Windows.Forms.Padding(4);
            this.valuebw.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuebw.Name = "valuebw";
            this.valuebw.Size = new System.Drawing.Size(59, 22);
            this.valuebw.TabIndex = 20;
            this.valuebw.Value = new decimal(new int[] {1, 0, 0, 0});
            this.valuebw.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valueby
            // 
            this.valueby.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueby.DecimalPlaces = 2;
            this.valueby.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valueby.Location = new System.Drawing.Point(925, 133);
            this.valueby.Margin = new System.Windows.Forms.Padding(4);
            this.valueby.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valueby.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valueby.Name = "valueby";
            this.valueby.Size = new System.Drawing.Size(59, 22);
            this.valueby.TabIndex = 19;
            this.valueby.Value = new decimal(new int[] {10, 0, 0, -2147418112});
            this.valueby.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valuebx
            // 
            this.valuebx.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuebx.DecimalPlaces = 2;
            this.valuebx.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuebx.Location = new System.Drawing.Point(859, 133);
            this.valuebx.Margin = new System.Windows.Forms.Padding(4);
            this.valuebx.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuebx.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valuebx.Name = "valuebx";
            this.valuebx.Size = new System.Drawing.Size(59, 22);
            this.valuebx.TabIndex = 18;
            this.valuebx.Value = new decimal(new int[] {10, 0, 0, -2147418112});
            this.valuebx.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(988, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Weight:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(859, 161);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "C:";
            // 
            // valuecw
            // 
            this.valuecw.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuecw.DecimalPlaces = 2;
            this.valuecw.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuecw.Location = new System.Drawing.Point(992, 181);
            this.valuecw.Margin = new System.Windows.Forms.Padding(4);
            this.valuecw.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuecw.Name = "valuecw";
            this.valuecw.Size = new System.Drawing.Size(59, 22);
            this.valuecw.TabIndex = 25;
            this.valuecw.Value = new decimal(new int[] {1, 0, 0, 0});
            this.valuecw.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valuecy
            // 
            this.valuecy.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuecy.DecimalPlaces = 2;
            this.valuecy.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuecy.Location = new System.Drawing.Point(925, 181);
            this.valuecy.Margin = new System.Windows.Forms.Padding(4);
            this.valuecy.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuecy.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valuecy.Name = "valuecy";
            this.valuecy.Size = new System.Drawing.Size(59, 22);
            this.valuecy.TabIndex = 24;
            this.valuecy.Value = new decimal(new int[] {1, 0, 0, -2147483648});
            this.valuecy.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valuecx
            // 
            this.valuecx.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuecx.DecimalPlaces = 2;
            this.valuecx.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuecx.Location = new System.Drawing.Point(859, 181);
            this.valuecx.Margin = new System.Windows.Forms.Padding(4);
            this.valuecx.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuecx.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valuecx.Name = "valuecx";
            this.valuecx.Size = new System.Drawing.Size(59, 22);
            this.valuecx.TabIndex = 23;
            this.valuecx.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(988, 209);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "Weight:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(859, 209);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "D:";
            // 
            // valuedw
            // 
            this.valuedw.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuedw.DecimalPlaces = 2;
            this.valuedw.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuedw.Location = new System.Drawing.Point(992, 229);
            this.valuedw.Margin = new System.Windows.Forms.Padding(4);
            this.valuedw.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuedw.Name = "valuedw";
            this.valuedw.Size = new System.Drawing.Size(59, 22);
            this.valuedw.TabIndex = 30;
            this.valuedw.Value = new decimal(new int[] {1, 0, 0, 0});
            this.valuedw.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valuedy
            // 
            this.valuedy.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuedy.DecimalPlaces = 2;
            this.valuedy.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuedy.Location = new System.Drawing.Point(925, 229);
            this.valuedy.Margin = new System.Windows.Forms.Padding(4);
            this.valuedy.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuedy.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valuedy.Name = "valuedy";
            this.valuedy.Size = new System.Drawing.Size(59, 22);
            this.valuedy.TabIndex = 29;
            this.valuedy.Value = new decimal(new int[] {1, 0, 0, 0});
            this.valuedy.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valuedx
            // 
            this.valuedx.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuedx.DecimalPlaces = 2;
            this.valuedx.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuedx.Location = new System.Drawing.Point(859, 229);
            this.valuedx.Margin = new System.Windows.Forms.Padding(4);
            this.valuedx.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuedx.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valuedx.Name = "valuedx";
            this.valuedx.Size = new System.Drawing.Size(59, 22);
            this.valuedx.TabIndex = 28;
            this.valuedx.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(988, 257);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Weight:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(859, 257);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "E:";
            // 
            // valueew
            // 
            this.valueew.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueew.DecimalPlaces = 2;
            this.valueew.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valueew.Location = new System.Drawing.Point(992, 277);
            this.valueew.Margin = new System.Windows.Forms.Padding(4);
            this.valueew.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valueew.Name = "valueew";
            this.valueew.Size = new System.Drawing.Size(59, 22);
            this.valueew.TabIndex = 35;
            this.valueew.Value = new decimal(new int[] {1, 0, 0, 0});
            this.valueew.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valueey
            // 
            this.valueey.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueey.DecimalPlaces = 2;
            this.valueey.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valueey.Location = new System.Drawing.Point(925, 277);
            this.valueey.Margin = new System.Windows.Forms.Padding(4);
            this.valueey.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valueey.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valueey.Name = "valueey";
            this.valueey.Size = new System.Drawing.Size(59, 22);
            this.valueey.TabIndex = 34;
            this.valueey.Value = new decimal(new int[] {10, 0, 0, 65536});
            this.valueey.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valueex
            // 
            this.valueex.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueex.DecimalPlaces = 2;
            this.valueex.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valueex.Location = new System.Drawing.Point(859, 277);
            this.valueex.Margin = new System.Windows.Forms.Padding(4);
            this.valueex.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valueex.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valueex.Name = "valueex";
            this.valueex.Size = new System.Drawing.Size(59, 22);
            this.valueex.TabIndex = 33;
            this.valueex.Value = new decimal(new int[] {10, 0, 0, 65536});
            this.valueex.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(989, 305);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "Weight:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(860, 305);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 17);
            this.label13.TabIndex = 41;
            this.label13.Text = "F:";
            // 
            // valuefw
            // 
            this.valuefw.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuefw.DecimalPlaces = 2;
            this.valuefw.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuefw.Location = new System.Drawing.Point(993, 325);
            this.valuefw.Margin = new System.Windows.Forms.Padding(4);
            this.valuefw.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuefw.Name = "valuefw";
            this.valuefw.Size = new System.Drawing.Size(59, 22);
            this.valuefw.TabIndex = 40;
            this.valuefw.Value = new decimal(new int[] {1, 0, 0, 0});
            this.valuefw.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valuefy
            // 
            this.valuefy.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuefy.DecimalPlaces = 2;
            this.valuefy.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuefy.Location = new System.Drawing.Point(927, 325);
            this.valuefy.Margin = new System.Windows.Forms.Padding(4);
            this.valuefy.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuefy.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valuefy.Name = "valuefy";
            this.valuefy.Size = new System.Drawing.Size(59, 22);
            this.valuefy.TabIndex = 39;
            this.valuefy.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // valuefx
            // 
            this.valuefx.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valuefx.DecimalPlaces = 2;
            this.valuefx.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.valuefx.Location = new System.Drawing.Point(860, 325);
            this.valuefx.Margin = new System.Windows.Forms.Padding(4);
            this.valuefx.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.valuefx.Minimum = new decimal(new int[] {10, 0, 0, -2147483648});
            this.valuefx.Name = "valuefx";
            this.valuefx.Size = new System.Drawing.Size(59, 22);
            this.valuefx.TabIndex = 38;
            this.valuefx.Value = new decimal(new int[] {15, 0, 0, 65536});
            this.valuefx.ValueChanged += new System.EventHandler(this.UpdateMesh);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 569);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.valuefw);
            this.Controls.Add(this.valuefy);
            this.Controls.Add(this.valuefx);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.valueew);
            this.Controls.Add(this.valueey);
            this.Controls.Add(this.valueex);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.valuedw);
            this.Controls.Add(this.valuedy);
            this.Controls.Add(this.valuedx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.valuecw);
            this.Controls.Add(this.valuecy);
            this.Controls.Add(this.valuecx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.valuebw);
            this.Controls.Add(this.valueby);
            this.Controls.Add(this.valuebx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valueaw);
            this.Controls.Add(this.valueay);
            this.Controls.Add(this.valueax);
            this.Controls.Add(this.valueApprox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picture);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Lab 7";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize) (this.valueApprox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueax)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueay)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuebw)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueby)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuebx)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuecw)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuecy)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuecx)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuedw)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuedy)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuedx)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueew)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueey)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valueex)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuefw)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuefy)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.valuefx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown valueApprox;
        private System.Windows.Forms.NumericUpDown valueax;
        private System.Windows.Forms.NumericUpDown valueay;
        private System.Windows.Forms.NumericUpDown valueaw;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown valuebw;
        private System.Windows.Forms.NumericUpDown valueby;
        private System.Windows.Forms.NumericUpDown valuebx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown valuecw;
        private System.Windows.Forms.NumericUpDown valuecy;
        private System.Windows.Forms.NumericUpDown valuecx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown valuedw;
        private System.Windows.Forms.NumericUpDown valuedy;
        private System.Windows.Forms.NumericUpDown valuedx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown valueew;
        private System.Windows.Forms.NumericUpDown valueey;
        private System.Windows.Forms.NumericUpDown valueex;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown valuefw;
        private System.Windows.Forms.NumericUpDown valuefy;
        private System.Windows.Forms.NumericUpDown valuefx;
    }
}

