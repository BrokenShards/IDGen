// PackEditor.cs //

using System;
using System.IO;
using System.Windows.Forms;

namespace IDGen
{
	public partial class PackEditor : Form
	{
		public PackEditor( WordPack pack = null )
		{
			InitializeComponent();
			m_nameeditor = new NameEditor();
			FormClosed += new FormClosedEventHandler( OnFormClose );

			try
			{
				CurrentPack = pack;
			}
			catch
			{
				ErrorDialog er = new ErrorDialog( "Unable to create new pack." );
				er.ShowDialog( this );
				throw new InvalidOperationException();
			}
		}

		public WordPack CurrentPack
		{
			get { return m_pack; }
			set
			{
				if( value == null )
				{
					OpenNameEditor();

					if( m_nameeditor.Cancelled )
					{
						Close();
						return;
					}

					try
					{
						value = new WordPack( m_nameeditor.NameField );
					}
					catch
					{
						throw;
					}

					Changed = true;
				}
				else
					Changed = false;

				m_pack = value;
				UpdateText();
			}
		}

		public bool Changed { get; private set; }

		private void OnFormLoad( object sender, EventArgs e )
		{
			UpdateText();
			Changed = false;
		}
		private void OnFormClose( object sender, EventArgs e )
		{
			if( Changed )
			{
				ConfirmDialog d = new ConfirmDialog( Dialogs.SaveChanges, "Save changes?" );
				d.ShowDialog( this );

				if( !d.Cancelled && d.Decision )
				{
					m_pack.Clear();
					m_pack.Add( textBox.Lines );

					if( !m_pack.SaveToFile() )
					{
						ErrorDialog er = new ErrorDialog( Dialogs.PackSaveFail );
						er.ShowDialog( this );
					}
					else
						PackManager.Instance[ m_pack.Name ] = m_pack;
				}
			}
		}

		private void UpdateText()
		{
			nameLab.Text = m_pack.Name;

			if( !m_pack.Empty )
			{
				string[] lines = new string[ m_pack.Count ];

				for( int i = 0; i < m_pack.Count; i++ )
					lines[ i ] = new string( m_pack.Get( i ).ToCharArray() );

				textBox.Lines = lines;
			}
			else
				textBox.Text = string.Empty;
		}

		private void SaveClicked( object sender, EventArgs e )
		{
			m_pack.Clear();
			m_pack.Add( textBox.Lines );

			if( !m_pack.SaveToFile() )
			{
				ErrorDialog er = new ErrorDialog( Dialogs.PackSaveFail );
				er.ShowDialog( this );
			}
			else
				Changed = false;
		}
		private void SaveAsClicked( object sender, EventArgs e )
		{
			NameEditor ne = new NameEditor( m_pack.Name + " Copy" );
			ne.ShowDialog( this );

			if( ne.Cancelled )
				return;

			string name = ne.NameField.Trim();

			if( !Naming.IsValidName( name ) )
			{
				ErrorDialog er = new ErrorDialog( Dialogs.InvalidPackName( name ?? string.Empty ) );
				er.ShowDialog( this );
				return;
			}

			m_pack.Name = name;
			string filename = FolderPaths.WordPackDir + "\\" + name + "." + Constants.PackFileExt;		

			if( File.Exists( filename ) )
			{
				ConfirmDialog cd = new ConfirmDialog( Dialogs.ReplacePack( name ), "Replace pack?" );
				cd.ShowDialog( this );

				if( cd.Cancelled || !cd.Decision )
					return;
			}

			m_pack.Clear();
			m_pack.Add( textBox.Lines );

			if( !m_pack.SaveToFile( filename ) )
			{
				ErrorDialog er = new ErrorDialog( Dialogs.PackSaveFail );
				er.ShowDialog( this );
			}
			else
				Changed = false;
		}
		private void TextBoxChanged( object sender, EventArgs e )
		{
			Changed = true;

			if( !string.IsNullOrWhiteSpace( textBox.Text ) )
			{
				if( textBox.Text[ textBox.Text.Length - 1 ] == Constants.CommentChar )
					textBox.Text = textBox.Text.Remove( textBox.Text.Length - 1 );
			}
		}

		private void OpenNameEditor( string name = null )
		{
			if( m_nameeditor == null || m_nameeditor.IsDisposed )
				m_nameeditor = new NameEditor( name );
			else
				m_nameeditor.NameField = name;

			if( !m_nameeditor.Visible )
				m_nameeditor.ShowDialog( this );
			else
				m_nameeditor.Focus();
		}

		private WordPack   m_pack;
		private NameEditor m_nameeditor;
	}
}
