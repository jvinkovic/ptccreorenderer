namespace Renderer
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
            this.btnStartFromApp = new System.Windows.Forms.Button();
            this.tbExePath = new System.Windows.Forms.TextBox();
            this.gbApp = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbModel = new System.Windows.Forms.GroupBox();
            this.btnStartFromModel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbModelPath = new System.Windows.Forms.TextBox();
            this.btnModelPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExePath = new System.Windows.Forms.Button();
            this.tbImagesPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImagesDir = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.gbApp.SuspendLayout();
            this.gbModel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartFromApp
            // 
            this.btnStartFromApp.Location = new System.Drawing.Point(72, 92);
            this.btnStartFromApp.Name = "btnStartFromApp";
            this.btnStartFromApp.Size = new System.Drawing.Size(75, 31);
            this.btnStartFromApp.TabIndex = 0;
            this.btnStartFromApp.Text = "Start";
            this.btnStartFromApp.UseVisualStyleBackColor = true;
            this.btnStartFromApp.Click += new System.EventHandler(this.btnStartFromApp_Click);
            // 
            // tbExePath
            // 
            this.tbExePath.Location = new System.Drawing.Point(6, 40);
            this.tbExePath.Name = "tbExePath";
            this.tbExePath.ReadOnly = true;
            this.tbExePath.Size = new System.Drawing.Size(233, 20);
            this.tbExePath.TabIndex = 4;
            // 
            // gbApp
            // 
            this.gbApp.Controls.Add(this.label1);
            this.gbApp.Controls.Add(this.btnStartFromApp);
            this.gbApp.Enabled = false;
            this.gbApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApp.Location = new System.Drawing.Point(13, 69);
            this.gbApp.Name = "gbApp";
            this.gbApp.Size = new System.Drawing.Size(224, 155);
            this.gbApp.TabIndex = 5;
            this.gbApp.TabStop = false;
            this.gbApp.Text = "Renders from opened model in parametric";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Open model in parametric before start";
            // 
            // gbModel
            // 
            this.gbModel.Controls.Add(this.btnStartFromModel);
            this.gbModel.Controls.Add(this.label4);
            this.gbModel.Controls.Add(this.tbModelPath);
            this.gbModel.Controls.Add(this.btnModelPath);
            this.gbModel.Controls.Add(this.label3);
            this.gbModel.Controls.Add(this.tbExePath);
            this.gbModel.Controls.Add(this.btnExePath);
            this.gbModel.Enabled = false;
            this.gbModel.Location = new System.Drawing.Point(268, 69);
            this.gbModel.Name = "gbModel";
            this.gbModel.Size = new System.Drawing.Size(313, 155);
            this.gbModel.TabIndex = 6;
            this.gbModel.TabStop = false;
            this.gbModel.Text = "Renders from specified model";
            // 
            // btnStartFromModel
            // 
            this.btnStartFromModel.Enabled = false;
            this.btnStartFromModel.Location = new System.Drawing.Point(117, 116);
            this.btnStartFromModel.Name = "btnStartFromModel";
            this.btnStartFromModel.Size = new System.Drawing.Size(75, 31);
            this.btnStartFromModel.TabIndex = 8;
            this.btnStartFromModel.Text = "Start";
            this.btnStartFromModel.UseVisualStyleBackColor = true;
            this.btnStartFromModel.Click += new System.EventHandler(this.btnStartFromModel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Path to model file";
            // 
            // tbModelPath
            // 
            this.tbModelPath.Location = new System.Drawing.Point(6, 81);
            this.tbModelPath.Name = "tbModelPath";
            this.tbModelPath.ReadOnly = true;
            this.tbModelPath.Size = new System.Drawing.Size(233, 20);
            this.tbModelPath.TabIndex = 12;
            // 
            // btnModelPath
            // 
            this.btnModelPath.Location = new System.Drawing.Point(245, 78);
            this.btnModelPath.Name = "btnModelPath";
            this.btnModelPath.Size = new System.Drawing.Size(57, 23);
            this.btnModelPath.TabIndex = 13;
            this.btnModelPath.Text = "Browse";
            this.btnModelPath.UseVisualStyleBackColor = true;
            this.btnModelPath.Click += new System.EventHandler(this.btnModelPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Path to parametric EXE";
            // 
            // btnExePath
            // 
            this.btnExePath.Location = new System.Drawing.Point(245, 38);
            this.btnExePath.Name = "btnExePath";
            this.btnExePath.Size = new System.Drawing.Size(57, 23);
            this.btnExePath.TabIndex = 9;
            this.btnExePath.Text = "Browse";
            this.btnExePath.UseVisualStyleBackColor = true;
            this.btnExePath.Click += new System.EventHandler(this.btnExePath_Click);
            // 
            // tbImagesPath
            // 
            this.tbImagesPath.Location = new System.Drawing.Point(13, 25);
            this.tbImagesPath.Name = "tbImagesPath";
            this.tbImagesPath.ReadOnly = true;
            this.tbImagesPath.Size = new System.Drawing.Size(346, 20);
            this.tbImagesPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destination folder for rendered images";
            // 
            // btnImagesDir
            // 
            this.btnImagesDir.Location = new System.Drawing.Point(371, 23);
            this.btnImagesDir.Name = "btnImagesDir";
            this.btnImagesDir.Size = new System.Drawing.Size(59, 23);
            this.btnImagesDir.TabIndex = 5;
            this.btnImagesDir.Text = "Browse";
            this.btnImagesDir.UseVisualStyleBackColor = true;
            this.btnImagesDir.Click += new System.EventHandler(this.btnImagesDir_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(541, 25);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(40, 28);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(13, 241);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(568, 193);
            this.tbResult.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 446);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnImagesDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbImagesPath);
            this.Controls.Add(this.gbModel);
            this.Controls.Add(this.gbApp);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(606, 485);
            this.MinimumSize = new System.Drawing.Size(606, 485);
            this.Name = "Form1";
            this.Text = "Renders maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbApp.ResumeLayout(false);
            this.gbApp.PerformLayout();
            this.gbModel.ResumeLayout(false);
            this.gbModel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartFromApp;
        private System.Windows.Forms.TextBox tbExePath;
        private System.Windows.Forms.GroupBox gbApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbModel;
        private System.Windows.Forms.Button btnStartFromModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbModelPath;
        private System.Windows.Forms.Button btnModelPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExePath;
        private System.Windows.Forms.TextBox tbImagesPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImagesDir;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox tbResult;
    }
}

