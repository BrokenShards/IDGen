namespace IDGen
{
	partial class NameEditor
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.okBut = new System.Windows.Forms.Button();
			this.nameBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.nameBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(16, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(310, 93);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.okBut);
			this.panel2.Location = new System.Drawing.Point(3, 54);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(304, 34);
			this.panel2.TabIndex = 5;
			// 
			// okBut
			// 
			this.okBut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.okBut.Location = new System.Drawing.Point(102, 2);
			this.okBut.Name = "okBut";
			this.okBut.Size = new System.Drawing.Size(95, 30);
			this.okBut.TabIndex = 0;
			this.okBut.Text = "OK";
			this.okBut.UseVisualStyleBackColor = true;
			this.okBut.Click += new System.EventHandler(this.OkClicked);
			// 
			// nameBox
			// 
			this.nameBox.Location = new System.Drawing.Point(72, 18);
			this.nameBox.Name = "nameBox";
			this.nameBox.Size = new System.Drawing.Size(220, 20);
			this.nameBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NameEditor
			// 
			this.AcceptButton = this.okBut;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 129);
			this.Controls.Add(this.panel1);
			this.Name = "NameEditor";
			this.Text = "Enter Pack Name";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox nameBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button okBut;
	}
}