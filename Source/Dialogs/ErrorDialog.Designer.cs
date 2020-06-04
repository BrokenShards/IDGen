namespace IDGen
{
	partial class ErrorDialog
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
			this.errorLab = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.okBut = new System.Windows.Forms.Button();
			this.cancelBut = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// errorLab
			// 
			this.errorLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorLab.Location = new System.Drawing.Point(3, 3);
			this.errorLab.Name = "errorLab";
			this.errorLab.Size = new System.Drawing.Size(338, 61);
			this.errorLab.TabIndex = 0;
			this.errorLab.Text = "<error message>";
			this.errorLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.okBut);
			this.panel1.Controls.Add(this.errorLab);
			this.panel1.Controls.Add(this.cancelBut);
			this.panel1.Location = new System.Drawing.Point(16, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(344, 100);
			this.panel1.TabIndex = 1;
			// 
			// okBut
			// 
			this.okBut.Location = new System.Drawing.Point(184, 67);
			this.okBut.Name = "okBut";
			this.okBut.Size = new System.Drawing.Size(80, 30);
			this.okBut.TabIndex = 2;
			this.okBut.Text = "OK";
			this.okBut.UseVisualStyleBackColor = true;
			this.okBut.Click += new System.EventHandler(this.OkClicked);
			// 
			// cancelBut
			// 
			this.cancelBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBut.Location = new System.Drawing.Point(68, 67);
			this.cancelBut.Name = "cancelBut";
			this.cancelBut.Size = new System.Drawing.Size(80, 30);
			this.cancelBut.TabIndex = 3;
			this.cancelBut.Text = "Cancel";
			this.cancelBut.UseVisualStyleBackColor = true;
			this.cancelBut.Click += new System.EventHandler(this.CancelClicked);
			// 
			// ErrorDialog
			// 
			this.AcceptButton = this.okBut;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBut;
			this.ClientSize = new System.Drawing.Size(376, 131);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ErrorDialog";
			this.Text = "Oh fuck...";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label errorLab;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button okBut;
		private System.Windows.Forms.Button cancelBut;
	}
}