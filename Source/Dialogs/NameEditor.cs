// NameEditor.cs //

using System;
using System.Windows.Forms;

namespace IDGen
{
	public partial class NameEditor : Form
	{
		public NameEditor( string name = null )
		{
			InitializeComponent();
			NameField = name;
		}

		public string NameField
		{
			get { return nameBox.Text; }
			set { nameBox.Text = string.IsNullOrWhiteSpace( value ) ? string.Empty : value; }
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
			if( string.IsNullOrWhiteSpace( NameField ) )
			{
				ErrorDialog er = new ErrorDialog( "A pack cannot have an empty name." );
				er.ShowDialog( this );
				return;
			}

			Cancelled = false;
			Close();
		}
	}
}
