namespace IDGen
{
	partial class PackEditor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nameLab = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.saveAsBut = new System.Windows.Forms.Button();
			this.saveBut = new System.Windows.Forms.Button();
			this.textBox = new System.Windows.Forms.TextBox();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nameLab
			// 
			this.nameLab.Location = new System.Drawing.Point(15, 15);
			this.nameLab.Name = "nameLab";
			this.nameLab.Size = new System.Drawing.Size(274, 32);
			this.nameLab.TabIndex = 1;
			this.nameLab.Text = "<pack name>";
			this.nameLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.saveAsBut);
			this.panel1.Controls.Add(this.saveBut);
			this.panel1.Location = new System.Drawing.Point(15, 395);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(274, 34);
			this.panel1.TabIndex = 5;
			// 
			// saveAsBut
			// 
			this.saveAsBut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.saveAsBut.Location = new System.Drawing.Point(172, 2);
			this.saveAsBut.Name = "saveAsBut";
			this.saveAsBut.Size = new System.Drawing.Size(80, 30);
			this.saveAsBut.TabIndex = 1;
			this.saveAsBut.Text = "Save As...";
			this.saveAsBut.UseVisualStyleBackColor = true;
			this.saveAsBut.Click += new System.EventHandler(this.SaveAsClicked);
			// 
			// saveBut
			// 
			this.saveBut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.saveBut.Location = new System.Drawing.Point(22, 2);
			this.saveBut.Name = "saveBut";
			this.saveBut.Size = new System.Drawing.Size(80, 30);
			this.saveBut.TabIndex = 2;
			this.saveBut.Text = "Save";
			this.saveBut.UseVisualStyleBackColor = true;
			this.saveBut.Click += new System.EventHandler(this.SaveClicked);
			// 
			// textBox
			// 
			this.textBox.AcceptsReturn = true;
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.Location = new System.Drawing.Point(15, 50);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBox.Size = new System.Drawing.Size(274, 339);
			this.textBox.TabIndex = 0;
			this.textBox.TextChanged += new System.EventHandler(this.TextBoxChanged);
			// 
			// saveDialog
			// 
			this.saveDialog.DefaultExt = "txt";
			// 
			// PackEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 441);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.nameLab);
			this.Name = "PackEditor";
			this.Text = "PackEditor";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label nameLab;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button saveAsBut;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.SaveFileDialog saveDialog;
		private System.Windows.Forms.Button saveBut;
	}
}