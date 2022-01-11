
namespace WindowsFormsApplication
{
    partial class MainForm
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenOriginal = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonFilter3 = new System.Windows.Forms.Button();
            this.buttonFilter2 = new System.Windows.Forms.Button();
            this.buttonFilter1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbEdgeDetection = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSaveNewImage = new System.Windows.Forms.Button();
            this.buttonFilter4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.Silver;
            this.picPreview.Location = new System.Drawing.Point(307, 28);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(718, 513);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenOriginal);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1 - Upload .png or .jpeg picture";
            // 
            // btnOpenOriginal
            // 
            this.btnOpenOriginal.Location = new System.Drawing.Point(18, 21);
            this.btnOpenOriginal.Name = "btnOpenOriginal";
            this.btnOpenOriginal.Size = new System.Drawing.Size(233, 41);
            this.btnOpenOriginal.TabIndex = 0;
            this.btnOpenOriginal.Text = "Upload your image";
            this.btnOpenOriginal.UseVisualStyleBackColor = true;
            this.btnOpenOriginal.Click += new System.EventHandler(this.btnOpenOriginal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonFilter4);
            this.groupBox2.Controls.Add(this.buttonFilter3);
            this.groupBox2.Controls.Add(this.buttonFilter2);
            this.groupBox2.Controls.Add(this.buttonFilter1);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 239);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2 - Choose 0, 1 or 3 filters";
            // 
            // buttonFilter3
            // 
            this.buttonFilter3.Location = new System.Drawing.Point(18, 130);
            this.buttonFilter3.Name = "buttonFilter3";
            this.buttonFilter3.Size = new System.Drawing.Size(233, 44);
            this.buttonFilter3.TabIndex = 2;
            this.buttonFilter3.Text = "Swap";
            this.buttonFilter3.UseVisualStyleBackColor = true;
            this.buttonFilter3.Click += new System.EventHandler(this.ApplyFilters);
            // 
            // buttonFilter2
            // 
            this.buttonFilter2.Location = new System.Drawing.Point(18, 81);
            this.buttonFilter2.Name = "buttonFilter2";
            this.buttonFilter2.Size = new System.Drawing.Size(233, 43);
            this.buttonFilter2.TabIndex = 1;
            this.buttonFilter2.Text = "Rainbow";
            this.buttonFilter2.UseVisualStyleBackColor = true;
            this.buttonFilter2.Click += new System.EventHandler(this.ApplyFilters);
            // 
            // buttonFilter1
            // 
            this.buttonFilter1.Location = new System.Drawing.Point(18, 31);
            this.buttonFilter1.Name = "buttonFilter1";
            this.buttonFilter1.Size = new System.Drawing.Size(233, 44);
            this.buttonFilter1.TabIndex = 0;
            this.buttonFilter1.Text = "None";
            this.buttonFilter1.UseVisualStyleBackColor = true;
            this.buttonFilter1.Click += new System.EventHandler(this.ApplyFilters);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbEdgeDetection);
            this.groupBox3.Location = new System.Drawing.Point(12, 361);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 80);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 3 - Add edge detection";
            // 
            // cmbEdgeDetection
            // 
            this.cmbEdgeDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEdgeDetection.FormattingEnabled = true;
            this.cmbEdgeDetection.Items.AddRange(new object[] {
            "None",
            "Sobel 3x3",
            "Prewitt",
            "Kirsch"});
            this.cmbEdgeDetection.Location = new System.Drawing.Point(18, 32);
            this.cmbEdgeDetection.Name = "cmbEdgeDetection";
            this.cmbEdgeDetection.Size = new System.Drawing.Size(233, 24);
            this.cmbEdgeDetection.TabIndex = 0;
            this.cmbEdgeDetection.SelectedIndexChanged += new System.EventHandler(this.NeighbourCountValueChangedEventHandler);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSaveNewImage);
            this.groupBox4.Location = new System.Drawing.Point(12, 447);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 94);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 4 - Download your picture";
            // 
            // btnSaveNewImage
            // 
            this.btnSaveNewImage.Location = new System.Drawing.Point(18, 34);
            this.btnSaveNewImage.Name = "btnSaveNewImage";
            this.btnSaveNewImage.Size = new System.Drawing.Size(233, 38);
            this.btnSaveNewImage.TabIndex = 0;
            this.btnSaveNewImage.Text = "Save";
            this.btnSaveNewImage.UseVisualStyleBackColor = true;
            this.btnSaveNewImage.Click += new System.EventHandler(this.btnSaveNewImage_Click);
            // 
            // buttonFilter4
            // 
            this.buttonFilter4.Location = new System.Drawing.Point(18, 180);
            this.buttonFilter4.Name = "buttonFilter4";
            this.buttonFilter4.Size = new System.Drawing.Size(233, 44);
            this.buttonFilter4.TabIndex = 3;
            this.buttonFilter4.Text = "Black and White";
            this.buttonFilter4.UseVisualStyleBackColor = true;
            this.buttonFilter4.Click += new System.EventHandler(this.ApplyFilters);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 565);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picPreview);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenOriginal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonFilter1;
        private System.Windows.Forms.Button buttonFilter2;
        private System.Windows.Forms.Button buttonFilter3;
        private System.Windows.Forms.ComboBox cmbEdgeDetection;
        private System.Windows.Forms.Button btnSaveNewImage;
        private System.Windows.Forms.Button buttonFilter4;
    }
}