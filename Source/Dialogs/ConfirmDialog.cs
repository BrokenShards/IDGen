// ConfirmDialog.cs //

using System;
using System.Windows.Forms;

namespace IDGen
{
	public partial class ConfirmDialog : Form
	{
		public ConfirmDialog( string msg, string title = null, bool hasno = true)
		{
			InitializeComponent();

			if( title != null )
				Title = title;

			Message = msg;
			HasNo   = hasno;
		}

		public string Title
		{
			get { return Text; }
			set { Text = value; }
		}
		public string Message
		{
			get { return errorLab.Text; }
			set { errorLab.Text = value; }
		}
		public bool HasNo
		{
			get { return noBut.Enabled; }
			set { noBut.Enabled = value; }
		}
		public bool Decision
		{
			get; private set;
		}
		public bool Cancelled
		{
			get; private set;
		}

		private void OnFormLoad( object sender, EventArgs e )
		{
			Cancelled = true;
		}
		private void NoClicked( object sender, EventArgs e )
		{
			Decision  = false;
			Cancelled = false;
			Close();
		}
		private void YesClicked( object sender, EventArgs e )
		{
			Decision  = true;
			Cancelled = false;
			Close();
		}
	}
}
