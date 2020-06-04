// ErrorForm.cs //

using System;
using System.Windows.Forms;

namespace IDGen
{
	public partial class ErrorDialog : Form
	{
		public ErrorDialog( string msg = null, bool cancel = false )
		{
			InitializeComponent();

			if( msg == null )
				msg = "Unknown Error";

			Message   = msg;
			HasCancel = cancel;
		}

		public string Message
		{
			get { return errorLab.Text; }
			set { errorLab.Text = value; }
		}
		public bool HasCancel
		{
			get { return cancelBut.Enabled; }
			set { cancelBut.Enabled = value; }
		}

		public bool Cancelled
		{
			get; private set;
		}

		private void OnFormLoad( object sender, EventArgs e )
		{
			Cancelled = true;
		}

		private void OkClicked( object sender, EventArgs e )
		{
			Cancelled = false;
			Close();
		}
		private void CancelClicked( object sender, EventArgs e )
		{
			Close();
		}
	}
}
