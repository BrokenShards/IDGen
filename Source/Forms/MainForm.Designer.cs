namespace IDGen
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
			this.packPane = new System.Windows.Forms.FlowLayoutPanel();
			this.wordbutPane = new System.Windows.Forms.Panel();
			this.newButton = new System.Windows.Forms.Button();
			this.importBut = new System.Windows.Forms.Button();
			this.wordLab = new System.Windows.Forms.Label();
			this.importDialog = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.clearBut = new System.Windows.Forms.Button();
			this.listPane = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.generateBut = new System.Windows.Forms.Button();
			this.generateBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.wordbutPane.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// packPane
			// 
			this.packPane.AutoScroll = true;
			this.packPane.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.packPane.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.packPane.Location = new System.Drawing.Point(15, 56);
			this.packPane.Name = "packPane";
			this.packPane.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.packPane.Size = new System.Drawing.Size(200, 330);
			this.packPane.TabIndex = 0;
			this.packPane.WrapContents = false;
			// 
			// wordbutPane
			// 
			this.wordbutPane.Controls.Add(this.newButton);
			this.wordbutPane.Controls.Add(this.importBut);
			this.wordbutPane.Location = new System.Drawing.Point(15, 392);
			this.wordbutPane.Name = "wordbutPane";
			this.wordbutPane.Size = new System.Drawing.Size(200, 34);
			this.wordbutPane.TabIndex = 1;
			// 
			// newButton
			// 
			this.newButton.Location = new System.Drawing.Point(110, 2);
			this.newButton.Name = "newButton";
			this.newButton.Size = new System.Drawing.Size(80, 30);
			this.newButton.TabIndex = 1;
			this.newButton.Text = "New";
			this.newButton.UseVisualStyleBackColor = true;
			this.newButton.Click += new System.EventHandler(this.NewPackClicked);
			// 
			// importBut
			// 
			this.importBut.Location = new System.Drawing.Point(10, 2);
			this.importBut.Name = "importBut";
			this.importBut.Size = new System.Drawing.Size(80, 30);
			this.importBut.TabIndex = 0;
			this.importBut.Text = "Import";
			this.importBut.UseVisualStyleBackColor = true;
			this.importBut.Click += new System.EventHandler(this.ImportClicked);
			// 
			// wordLab
			// 
			this.wordLab.Location = new System.Drawing.Point(15, 15);
			this.wordLab.Name = "wordLab";
			this.wordLab.Size = new System.Drawing.Size(200, 38);
			this.wordLab.TabIndex = 2;
			this.wordLab.Text = "Word Packs";
			this.wordLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// importDialog
			// 
			this.importDialog.DefaultExt = "txt";
			this.importDialog.Filter = "IDGen Wordpacks|*.txt|All files|*.*";
			this.importDialog.InitialDirectory = "\\packs";
			this.importDialog.Multiselect = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(218, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(203, 38);
			this.label1.TabIndex = 5;
			this.label1.Text = "Pack Stack";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.clearBut);
			this.panel1.Location = new System.Drawing.Point(221, 392);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 34);
			this.panel1.TabIndex = 4;
			// 
			// clearBut
			// 
			this.clearBut.Location = new System.Drawing.Point(60, 2);
			this.clearBut.Name = "clearBut";
			this.clearBut.Size = new System.Drawing.Size(80, 30);
			this.clearBut.TabIndex = 0;
			this.clearBut.Text = "Clear";
			this.clearBut.UseVisualStyleBackColor = true;
			this.clearBut.Click += new System.EventHandler(this.ClearClicked);
			// 
			// listPane
			// 
			this.listPane.AutoScroll = true;
			this.listPane.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.listPane.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.listPane.Location = new System.Drawing.Point(221, 56);
			this.listPane.Name = "listPane";
			this.listPane.Size = new System.Drawing.Size(200, 330);
			this.listPane.TabIndex = 3;
			this.listPane.WrapContents = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.generateBut);
			this.panel2.Location = new System.Drawing.Point(427, 392);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 34);
			this.panel2.TabIndex = 5;
			// 
			// generateBut
			// 
			this.generateBut.Location = new System.Drawing.Point(60, 2);
			this.generateBut.Name = "generateBut";
			this.generateBut.Size = new System.Drawing.Size(80, 30);
			this.generateBut.TabIndex = 0;
			this.generateBut.Text = "Generate";
			this.generateBut.UseVisualStyleBackColor = true;
			this.generateBut.Click += new System.EventHandler(this.GenerateClicked);
			// 
			// generateBox
			// 
			this.generateBox.AcceptsReturn = true;
			this.generateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.generateBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.generateBox.Location = new System.Drawing.Point(427, 56);
			this.generateBox.Multiline = true;
			this.generateBox.Name = "generateBox";
			this.generateBox.ReadOnly = true;
			this.generateBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.generateBox.Size = new System.Drawing.Size(200, 332);
			this.generateBox.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(424, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(203, 38);
			this.label2.TabIndex = 7;
			this.label2.Text = "Generated";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 441);
			this.Controls.Add(this.generateBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.listPane);
			this.Controls.Add(this.wordLab);
			this.Controls.Add(this.wordbutPane);
			this.Controls.Add(this.packPane);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "IDGen";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.wordbutPane.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel packPane;
		private System.Windows.Forms.Panel wordbutPane;
		private System.Windows.Forms.Button importBut;
		private System.Windows.Forms.Label wordLab;
		private System.Windows.Forms.OpenFileDialog importDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button clearBut;
		private System.Windows.Forms.FlowLayoutPanel listPane;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button generateBut;
		private System.Windows.Forms.TextBox generateBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button newButton;
	}
}

