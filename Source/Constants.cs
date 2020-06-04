// Constants.cs //

using System;
using System.IO;
using System.Reflection;

namespace IDGen
{
	public static class Constants
	{
		public const char   CommentChar =   '#';
		public const string PackFileExt = "txt";

		public const string AddExt    = "_a";
		public const string EditExt   = "_e";
		public const string DeleteExt = "_d";
		public const string PanelExt  = "_p";
		public const string NameExt   = "_n";

		public const string GeneratingText = "<...generating...>";
		public const string EmptyStackText = "<no packs in the stack>";
	}

	public static class Dialogs
	{
		public static readonly string PackFolderCreationFail =
			"Pack folder does not exist and cannot be created. Try manually creating \"" + 
			FolderPaths.WordPackDir + "\" or running the program as admin";

		public const string AccessFail =
			"Unable to get access to the packs folder.Try running again as admin?";
		public const string PathTooLong =
			"Pack file name is too long.Try reinstalling closer to the root directory.";
		public const string PackExists =
			"A pack with the given name already exists.";
		public const string PackSaveFail =
			"Unable to save pack to file. (Maybe try copying it to a file and saving manually just in case)";
		public const string PackLoadFail =
			"Unable to load packs from file.";
		public const string SaveChanges = "Would you like to save your changes before closing the editor?";

		public static string PackDeleteFail( string name )
		{
			return "Unable to delete pack \"" + name + "\".";
		}
		public static string PackAddFail( string name )
		{
			return "Unable to add pack \"" + name + "\".";
		}
		public static string InvalidPackName( string name )
		{
			return "\"" + name + "\" is not a valid pack name.";
		}

		public static string ReplacePack( string name )
		{
			return "A pack already exists with the name \"" + name + 
			       "\".\nWould you like to replace it?";
		}
		public static string ImportError( string file, Exception exc = null )
		{
			string msg = "Unable to import \"" + file + "\".";

			if( exc != null )
				msg += " Argument error: " + exc.Message;

			return msg;
		}
		public static string ConfirmDelete( string name )
		{
			return "Are you sure you would like to delete " + name + "\"?\n" +
				"This will also PERMANENTLY DELETE the file from the packs folder!\n" +
				"(NOT to the recycle bin).";
		}
		public static string DeleteFail( string name )
		{
			return "Unable to delete pack \"" + name + "\".";
		}
	}

	/// <summary>
	///   Contains path related functionality.
	/// </summary>
	public static class Paths
	{
		public static string ToWindows( string path )
		{
			if( string.IsNullOrWhiteSpace( path ) )
				return path;

			return path.Replace( '/', '\\' );
		}
		public static string FromWindows( string path )
		{
			if( string.IsNullOrWhiteSpace( path ) )
				return path;

			return path.Replace( '\\', '/' );
		}
	}

	/// <summary>
	///   Contains folder paths.
	/// </summary>
	public static class FolderPaths
	{
		/// <summary>
		///   The folder path containing the binary executable.
		/// </summary>
		public static string Executable
		{
			get
			{
				string path = Path.GetDirectoryName( Assembly.GetExecutingAssembly().CodeBase );

				try
				{
					string s5 = path.Substring( 0, 5 ).ToLower();
					string s6 = path.Substring( 0, 6 ).ToLower();
					string s8 = path.Substring( 0, 8 ).ToLower();
					string s10 = path.Substring( 0, 10 ).ToLower();

					if( s5 == "dir:/" || s5 == "dir:\\" )
						path = path.Substring( 5 );
					else if( s6 == "file:/" || s6 == "file:\\" || s6 == "path:/" || s6 == "path:\\" )
						path = path.Substring( 6 );
					else if( s8 == "folder:/" || s8 == "folder:\\" )
						path = path.Substring( 8 );
					else if( s10 == "directory:/" || s10 == "directory:\\" )
						path = path.Substring( 10 );
				}
				catch( Exception e )
				{
					Console.WriteLine( e.Message );
				}

				return Paths.ToWindows( path );
			}
		}

		/// <summary>
		///   The path to the word pack directory.
		/// </summary>
		public static string WordPackDir = Executable + "\\packs";

		/// <summary>
		///   Creates the folder structure.
		/// </summary>
		public static void CreateFolderStructure()
		{
			Directory.CreateDirectory( WordPackDir );
		}
	}
}
