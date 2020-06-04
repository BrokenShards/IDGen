namespace IDGen
{
	partial class ConfirmDialog
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
			this.yesBut = new System.Windows.Forms.Button();
			this.errorLab = new System.Windows.Forms.Label();
			this.noBut = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.yesBut);
			this.panel1.Controls.Add(this.errorLab);
			this.panel1.Controls.Add(this.noBut);
			this.panel1.Location = new System.Drawing.Point(15, 15);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(344, 100);
			this.panel1.TabIndex = 2;
			// 
			// yesBut
			// 
			this.yesBut.Location = new System.Drawing.Point(184, 67);
			this.yesBut.Name = "yesBut";
			this.yesBut.Size = new System.Drawing.Size(80, 30);
			this.yesBut.TabIndex = 2;
			this.yesBut.Text = "Yes";
			this.yesBut.UseVisualStyleBackColor = true;
			this.yesBut.Click += new System.EventHandler(this.YesClicked);
			// 
			// errorLab
			// 
			this.errorLab.Location = new System.Drawing.Point(3, 3);
			this.errorLab.Name = "errorLab";
			this.errorLab.Size = new System.Drawing.Size(338, 61);
			this.errorLab.TabIndex = 0;
			this.errorLab.Text = "<emessage>";
			this.errorLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// noBut
			// 
			this.noBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.noBut.Location = new System.Drawing.Point(68, 67);
			this.noBut.Name = "noBut";
			this.noBut.Size = new System.Drawing.Size(80, 30);
			this.noBut.TabIndex = 3;
			this.noBut.Text = "No";
			this.noBut.UseVisualStyleBackColor = true;
			this.noBut.Click += new System.EventHandler(this.NoClicked);
			// 
			// ConfirmDialog
			// 
			this.AcceptButton = this.yesBut;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.noBut;
			this.ClientSize = new System.Drawing.Size(376, 131);
			this.Controls.Add(this.panel1);
			this.Name = "ConfirmDialog";
			this.Text = "ConfirmDialog";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button yesBut;
		private System.Windows.Forms.Label errorLab;
		private System.Windows.Forms.Button noBut;
	}
}