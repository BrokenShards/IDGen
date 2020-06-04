// MainForm.cs //

using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IDGen
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			m_packpanes = new Dictionary<string, Panel>();
			m_listpanes = new List<Panel>();
			m_packstack = new List<string>();
			m_random    = new Random();

			InitializeComponent();

			try
			{
				if( !Directory.Exists( FolderPaths.WordPackDir ) )
					Directory.CreateDirectory( FolderPaths.WordPackDir );
			}
			catch
			{
				ErrorDialog er = new ErrorDialog( Dialogs.PackFolderCreationFail );
			}
		}

		private void OnFormLoad( object sender, EventArgs e )
		{
			if( !LoadPacks() )
				Close();
		}

		#region Button Clicks
		private void ImportClicked( object sender, EventArgs e )
		{
			if( importDialog.ShowDialog( this ) == DialogResult.OK )
			{
				foreach( string file in importDialog.FileNames )
				{
					string packname = Path.GetFileNameWithoutExtension( file );

					if( PackManager.Instance.Contains( packname ) )
					{
						ConfirmDialog confirm = new ConfirmDialog( Dialogs.ReplacePack( packname ) );
						confirm.ShowDialog( this );

						if( confirm.Cancelled || !confirm.Decision )
							return;

						if( !PackManager.Instance.Remove( packname, true ) )
						{
							ErrorDialog er = new ErrorDialog( Dialogs.PackDeleteFail( packname ) );
							er.ShowDialog( this );
							return;
						}
					}


					string filename = packname + "." + Constants.PackFileExt;
					string filepath = FolderPaths.WordPackDir + "\\" + filename;

					try
					{
						File.Copy( file, filepath, true );
					}
					catch( ArgumentException argex )
					{
						ErrorDialog er = new ErrorDialog( Dialogs.ImportError( file, argex ) );
						er.ShowDialog( this );
					}
					catch
					{
						ErrorDialog er = new ErrorDialog( Dialogs.ImportError( file ) );
						er.ShowDialog( this );
					}

					if( !PackManager.Instance.Add( WordPack.FromName( packname ), true ) )
					{
						ErrorDialog er = new ErrorDialog( Dialogs.PackAddFail( packname ) );
						er.ShowDialog( this );
					}
				}

				CreatePackUI();
			}
		}
		private void NewPackClicked( object sender, EventArgs e )
		{
			OpenPackEditor();
		}

		private void AddPackClicked( object sender, EventArgs e )
		{
			Button but = sender as Button;
			AddToStack( but.Name.Substring( 0, but.Name.Length - Constants.DeleteExt.Length ) );
		}
		private void EditPackClicked( object sender, EventArgs e )
		{
			Button but = sender as Button;
			string name = but.Name.Substring( 0, but.Name.Length - Constants.DeleteExt.Length );

			OpenPackEditor( PackManager.Instance[ name ] );

			if( m_editor.Changed )
			{
				PackManager.Instance[ name ] = m_editor.CurrentPack;

				if( !PackManager.Instance[ name ].SaveToFile() )
				{
					ErrorDialog er = new ErrorDialog( Dialogs.PackSaveFail );
					er.ShowDialog( this );
				}
			}
		}
		private void DeletePackClicked( object sender, EventArgs e )
		{
			Button but  = sender as Button;
			string name = but.Name.Substring( 0, but.Name.Length - Constants.DeleteExt.Length );

			ConfirmDialog dialog = new ConfirmDialog( Dialogs.ConfirmDelete( name ), "Delete " + name + " word pack?" );
			dialog.ShowDialog( this );

			if( dialog.Cancelled || !dialog.Decision )
				return;

			if( !PackManager.Instance.Remove( name, true ) )
			{
				ErrorDialog error = new ErrorDialog( Dialogs.DeleteFail( name ) );
				error.ShowDialog( this );
			}

			m_packpanes[ name ].Controls.Clear();
			packPane.Controls.Remove( m_packpanes[ name ] );
			m_packpanes[ name ].Dispose();
			m_packpanes.Remove( name );
		}

		private void ClearClicked( object sender, EventArgs e )
		{
			ClearPackStack();
		}

		private void GenerateClicked( object sender, EventArgs e )
		{
			generateBox.Text = Constants.GeneratingText;

			if( m_packstack.Count > 0 )
			{
				List<string> list = new List<string>( m_packstack.Count );

				foreach( string packname in m_packstack )
				{
					WordPack pack = PackManager.Instance[ packname ];
					list.Add( pack[ m_random.Next( 0, pack.Count ) ] );
				}

				generateBox.Lines = list.ToArray();
			}
			else
				generateBox.Text = Constants.EmptyStackText;
		}
		#endregion

		private bool LoadPacks()
		{
			ClearPackStack();

			if( !PackManager.Instance.Load() )
			{
				ErrorDialog e = new ErrorDialog( Dialogs.PackLoadFail );
				e.ShowDialog( this );
				return false;
			}

			CreatePackUI();
			return true;
		}

		private void CreatePackUI()
		{
			ClearPacksUI();

			foreach( var pair in PackManager.Instance )
			{
				WordPack pack = pair.Value;

				Panel pan = new Panel
				{
					Name = pack.Name + Constants.PanelExt,
					Size = new Size( 190, 29 )
				};
				Button del = new Button
				{
					Name = pack.Name + Constants.DeleteExt,
					Size = new Size( 23, 23 ),
					Text = "-"
				};
				del.Click += DeletePackClicked;
				Button name = new Button
				{
					Name = pack.Name + Constants.EditExt,
					Size = new Size( 102, 23 ),
					Text = pack.Name
				};
				name.Click += EditPackClicked;
				Button add = new Button
				{
					Name = pack.Name + Constants.AddExt,
					Size = new Size( 23, 23 ),
					Text = "+"
				};
				add.Click += AddPackClicked;

				pan.Controls.Add( del );
				del.Location = new Point( 3, 3 );
				pan.Controls.Add( name );
				name.Location = new Point( 32, 3 );
				pan.Controls.Add( add );
				add.Location = new Point( 140, 3 );

				m_packpanes.Add( pack.Name, pan );
				packPane.Controls.Add( m_packpanes[ pack.Name ] );
			}
		}
		private void ClearPacksUI()
		{
			foreach( var v in m_packpanes )
			{
				v.Value.Controls.Clear();
				packPane.Controls.Remove( v.Value );
				v.Value.Dispose();
			}

			m_packpanes.Clear();
			packPane.Controls.Clear();
		}

		private bool AddToStack( string name )
		{
			if( name == null || !PackManager.Instance.Contains( name ) )
				return false;

			m_packstack.Add( name );

			Panel pan = new Panel
			{
				Name = name + Constants.PanelExt,
				Size = new Size( 176, 29 )
			};
			Button namebut = new Button
			{
				Name = name + Constants.DeleteExt,
				Size = new Size( 170, 23 ),
				Text = name
			};

			pan.Controls.Add( namebut );
			namebut.Location = new Point( 3, 3 );

			m_listpanes.Add( pan );
			listPane.Controls.Add( m_listpanes[ m_listpanes.Count - 1 ] );
			return true;
		}
		private void ClearPackStack()
		{
			m_packstack.Clear();

			foreach( var p in m_listpanes )
			{
				p.Dispose();
				listPane.Controls.Remove( p );
			}

			m_listpanes.Clear();
		}

		private void OpenPackEditor( WordPack pack = null )
		{
			if( m_editor == null || m_editor.IsDisposed )
				m_editor = new PackEditor( pack );
			else
				m_editor.CurrentPack = pack;

			if( !m_editor.IsDisposed )
				m_editor.ShowDialog( this );

			if( !LoadPacks() )
				Close();
		}

		private Dictionary<string, Panel>    m_packpanes;

		private List<string> m_packstack;
		private List<Panel>  m_listpanes;

		private Random     m_random;
		private PackEditor m_editor;
	}
}
