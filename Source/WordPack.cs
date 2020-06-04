// WordPack.cs //

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace IDGen
{
	/// <summary>
	///   Contains naming functionality.
	/// </summary>
	public static class Naming
	{
		/// <summary>
		///   Checks if the given string is a valid pack name.
		/// </summary>
		/// <param name="name">
		///   The string to check.
		/// </param>
		/// <returns>
		///   True if <paramref name="name"/> is a valid pack name and false otherwise
		/// </returns>
		public static bool IsValidName( string name )
		{
			if( name == null || string.IsNullOrWhiteSpace( name ) || 
				char.IsWhiteSpace( name[ 0 ] ) || name == "." )
				return false;

			foreach( char v in name )
				foreach( char c in Path.GetInvalidFileNameChars() )
					if( v == c )
						return false;

			return true;
		}
	}

	/// <summary>
	///   A package containing related words used for idea generation.
	/// </summary>
	public class WordPack : IEnumerable<string>
	{
		/// <summary>
		///   Constructs a new word pack with an optional name.
		/// </summary>
		/// <remarks>
		///   If the given name is not valid (<see cref="Naming.IsValidName(string)"/>) it will be replaced with
		///   "New WordPack".
		/// </remarks>
		/// <param name="name">
		///   The name of the new pack.
		/// </param>
		public WordPack( string name = null )
		{
			Name    = !Naming.IsValidName( name ) ? "New Wordpack" : name;
			m_words = new List<string>();
		}
		/// <summary>
		///   Constructs a new word pack by deep copying data from another object.
		/// </summary>
		/// <remarks>
		///   The name of the new word pack will be <paramref name="w"/> + " Copy" so that it may be saved to file
		///   without colliding with the coppied objects' file.
		/// </remarks>
		/// <param name="w">
		///   The word pack to copy from.
		/// </param>
		public WordPack( WordPack w )
		{
			Name    = w.Name + " Copy";
			m_words = new List<string>( w.Count );

			for( int i = 0; i < w.Count; i++ )
				m_words.Add( new string( w.m_words[ i ].ToCharArray() ) );
		}

		/// <summary>
		///   Word accessor.
		/// </summary>
		/// <param name="index">
		///   The index of the word to access.
		/// </param>
		/// <returns>
		///   The word at the given index in the word pack.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///   If <paramref name="index"/> is out of range.
		/// </exception>
		public string this[ int index ]
		{
			get
			{
				return Get( index ) ?? throw new ArgumentOutOfRangeException();
			}
			set
			{
				if( index < 0 || index >= Count )
					throw new ArgumentOutOfRangeException();

				Set( index, value );
			}
		}

		/// <summary>
		///   The name of the pack.
		/// </summary>
		/// <remarks>
		///   This string is used as the file name to save and load the pack and because of this, it must be a valid
		///   file name.
		/// </remarks>
		/// <exception cref="ArgumentNullException">
		///   If trying to assign a null value.
		/// </exception>
		/// <exception cref="ArgumentException">
		///   If trying to assign an invalid name.
		/// </exception>
		public string Name
		{
			get { return m_name; }
			set
			{
				if( value == null )
					throw new ArgumentNullException();
				if( !Naming.IsValidName( value ) )
					throw new ArgumentException();

				m_name = value;
			}
		}

		/// <summary>
		///   If the word pack is empty and contains no words.
		/// </summary>
		public bool Empty
		{
			get { return Count == 0; }
		}
		/// <summary>
		///   The amount of words contained in the word pack.
		/// </summary>
		public int Count
		{
			get { return m_words.Count; }
		}

		/// <summary>
		///   If the word pack contains the given word.
		/// </summary>
		/// <param name="word">
		///   The word to check.
		/// </param>
		/// <returns>
		///   True if the word pack contains the word and false if it does not or the word is null.
		/// </returns>
		public bool Contains( string word )
		{
			if( word == null )
				return false;

			return m_words.Contains( word.ToLower() );
		}
		/// <summary>
		///   Returns the index of the given word in the wordpack.
		/// </summary>
		/// <param name="word">
		///   The word to get the index of.
		/// </param>
		/// <returns>
		///   The index of the word in the word pack if it exists, otherwise -1.
		/// </returns>
		public int IndexOf( string word )
		{
			if( word == null && !Contains( word ) )
				return -1;

			return m_words.IndexOf( word.ToLower() );
		}

		/// <summary>
		///   Gets the word contained in the word pack at the given index.
		/// </summary>
		/// <param name="index">
		///   The index of the word to get.
		/// </param>
		/// <returns>
		///   The word at the given index in the word pack if the index is valid and it exists, otherwise null.
		/// </returns>
		public string Get( int index )
		{
			if( index < 0 || index >= Count )
				return null;

			return m_words[ index ];
		}
		/// <summary>
		///   Sets the word at the given index in the word pack.
		/// </summary>
		/// <param name="index">
		///   The index of the word to modify.
		/// </param>
		/// <param name="word">
		///   The word to replace the old one.
		/// </param>
		/// <returns>
		///   True if the given index is valid, the given word is valid, the pack does not contain the given string,
		///   and the old string was replaced successfully, otherwise false.
		/// </returns>
		public bool Set( int index, string word )
		{
			if( index < 0 || index >= Count || string.IsNullOrWhiteSpace( word ) || Contains( word ) )
				return false;

			string s = word.Trim().ToLower();

			m_words[ index ] = s;
			return true;
		}
		/// <summary>
		///   Adds a new word to the word pack.
		/// </summary>
		/// <remarks>
		///   If added successfully, the word will be trimmed of surrounding whitespace and converted to lowercase.
		/// </remarks>
		/// <param name="word">
		///   The new word to add to the pack.
		/// </param>
		/// <returns>
		///   True if the word is not null, empty or contains just whitespace and was added to the pack successfully,
		///   otherwise false.
		/// </returns>
		public bool Add( string word )
		{
			if( string.IsNullOrWhiteSpace( word ) )
				return false;

			string l = word.Trim();

			int i = l.IndexOf( Constants.CommentChar );
			if( i > 0 )
				l = l.Substring( 0, i );

			else if( i == 0 || Contains( l ) )
				return false;

			m_words.Add( l.ToLower() );
			return true;
		}
		/// <summary>
		///   Adds mutiple new words to the pack and returns how many were successfully added.
		/// </summary>
		/// <param name="words">
		///   The words to add to the pack.
		/// </param>
		/// <returns>
		///   The amount of words in <paramref name="words"/> that were successfully added to the pack.
		/// </returns>
		public int Add( params string[] words )
		{
			if( words == null )
				return 0;

			int count = 0;

			foreach( string s in words )
				if( Add( s ) )
					count++;

			return count;
		}
		/// <summary>
		///   Removes the word at the given index from the pack.
		/// </summary>
		/// <param name="index">
		///   The index of the word to remove.
		/// </param>
		/// <returns>
		///   True if <paramref name="index"/> is within range and the word was removed successfully, otherwise false.
		/// </returns>
		public bool Remove( int index )
		{
			if( index < 0 || index >= Count )
				return false;

			m_words.RemoveAt( index );
			return true;
		}
		/// <summary>
		///   Removes a given word from the pack.
		/// </summary>
		/// <param name="word">
		///   The word to remove from the pack.
		/// </param>
		/// <returns>
		///   True if the pack contained <paramref name="word"/> and it waa removed successfully, otherwise false.
		/// </returns>
		public bool Remove( string word )
		{
			return Remove( IndexOf( word ) );
		}
		/// <summary>
		///   Clears all words from the pack.
		/// </summary>
		public void Clear()
		{
			m_words.Clear();
		}

		/// <summary>
		///   Loads the pack from either <see cref="FolderPaths.WordPackDir"/>, using <see cref="Name"/> as the file 
		///   name, or an optional file path if <paramref name="path"/> is not null.
		/// </summary>
		/// <param name="path">
		///   The path to load the word pack from or null to load from <see cref="FolderPaths.WordPackDir"/> using 
		///   <see cref="Name"/> as the file name.
		/// </param>
		/// <returns>
		///   True if the word pack was successfully loaded from file and false if it failed.
		/// </returns>
		public bool LoadFromFile( string path = null )
		{
			if( path == null )
				path = FolderPaths.WordPackDir + "\\" + Name + "." + Constants.PackFileExt;
			if( !File.Exists( path ) )
				return false;

			Clear();

			string[] lines;
			
			try
			{
				lines = File.ReadAllLines( path );
			}
			catch
			{
				return false;
			}

			Name = Path.GetFileNameWithoutExtension( path );

			foreach( string ln in lines )
				Add( ln );

			return true;
		}
		/// <summary>
		///   Saves the pack to either <see cref="FolderPaths.WordPackDir"/>, using <see cref="Name"/> as the file name,
		///   or an optional file path if <paramref name="path"/> is not null.
		/// </summary>
		/// <param name="path">
		///   The path to save the word pack to or null to save to <see cref="FolderPaths.WordPackDir"/> using 
		///   <see cref="Name"/> as the file name.
		/// </param>
		/// <param name="overwrite">
		///   If a file already exists, should it be overwritten?
		/// </param>
		/// <returns>
		///   True if the word pack was successfully saved to file and false if it failed.
		/// </returns>
		public bool SaveToFile( string path = null, bool overwrite = true )
		{
			if( path == null )
				path = FolderPaths.WordPackDir + "\\" + Name + "." + Constants.PackFileExt;
			if( File.Exists( path ) && !overwrite )
				return false;

			try
			{
				File.WriteAllLines( path, m_words.ToArray() );
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		///   Returns an enumerator that iterates through the word pack.
		/// </summary>
		/// <returns>
		///   An enumerator that can be used to iterate through the word pack.
		/// </returns>
		public IEnumerator<string> GetEnumerator()
		{
			return ( (IEnumerable<string>)m_words ).GetEnumerator();
		}
		/// <summary>
		///   Returns an enumerator that iterates through the word pack.
		/// </summary>
		/// <returns>
		///   An enumerator that can be used to iterate through the word pack.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ( (IEnumerable<string>)m_words ).GetEnumerator();
		}

		/// <summary>
		///   Returns a new word pack loaded from the given file path.
		/// </summary>
		/// <param name="path">
		///   The path to load the word pack from.
		/// </param>
		/// <returns>
		///   The word pack loaded from <paramref name="path"/> on success, otherwise null.
		/// </returns>
		public static WordPack FromFile( string path )
		{
			WordPack w = new WordPack();

			if( !w.LoadFromFile( path ) )
				return null;

			return w;
		}
		/// <summary>
		///   Returns a new word pack loaded from <see cref="FolderPaths.WordPackDir"/>, using <paramref name="name"/>
		///   as the file name.
		/// </summary>
		/// <param name="name">
		///   The name of the word pack and file to load.
		/// </param>
		/// <returns>
		///   The word pack loaded from file on success, otherwise null.
		/// </returns>
		public static WordPack FromName( string name )
		{
			if( !Naming.IsValidName( name ) )
				return null;

			return FromFile( FolderPaths.WordPackDir + "\\" + name + "." + Constants.PackFileExt );
		}

		private string       m_name;
		private List<string> m_words;
	}
}
