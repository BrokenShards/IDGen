// PackManager.cs //

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace IDGen
{
	/// <summary>
	///   Singleton class that handles loading, saving and managing word packs.
	/// </summary>
	public class PackManager : IEnumerable<KeyValuePair<string, WordPack>>
	{
		private PackManager()
		{
			m_packs = new Dictionary<string, WordPack>();
		}
		/// <summary>
		///   The singleton object.
		/// </summary>
		public static PackManager Instance
		{
			get
			{
				if( _instance == null )
				{
					lock( _syncRoot )
					{
						if( _instance == null )
							_instance = new PackManager();
					}
				}

				return _instance;
			}
		}

		/// <summary>
		///   Access the word pack with the given name.
		/// </summary>
		/// <remarks>
		///   Using the setter with a pack name that does not exist in the manager will add a new pack.
		/// </remarks>
		/// <param name="name">
		///   The name of the word pack to access.
		/// </param>
		/// <returns>
		///   The word pack with the given name if it exists within the manager, otherwise null.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///   When trying to set a null value.
		/// </exception>
		/// <exception cref="ArgumentException">
		///   If the given name is invalid (<see cref="Naming.IsValidName(string)"/>) or it is not the same as the given
		///   packs' name.
		/// </exception>
		public WordPack this[ string name ]
		{
			get	{ return Get( name ); }
			set
			{
				if( value == null )
					throw new ArgumentNullException();
				if( !Naming.IsValidName( name ) || value.Name != name )
					throw new ArgumentException();

				if( Contains( name ) )
					Set( value );
				else
					Add( value );
			}
		}
		
		/// <summary>
		///   If the manager is empty and contains no packs.
		/// </summary>
		public bool Empty
		{
			get { return Count == 0; }
		}
		/// <summary>
		///   The amount of word packs contained in the manager.
		/// </summary>
		public int Count
		{
			get { return m_packs.Count; }
		}

		/// <summary>
		///   If the manager contains a pack with the given name.
		/// </summary>
		/// <param name="name">
		///   The name to check.
		/// </param>
		/// <returns>
		///   True if the manager contains a pack with the given name and false if it does not.
		/// </returns>
		public bool Contains( string name )
		{
			if( name == null )
				return false;

			return m_packs.ContainsKey( name );
		}

		/// <summary>
		///   Gets the pack with the given name in the manager.
		/// </summary>
		/// <param name="name">
		///   The name of the pack to get.
		/// </param>
		/// <returns>
		///   The pack with the given name if it exists within the manager, otherwise null.
		/// </returns>
		public WordPack Get( string name )
		{
			return Contains( name ) ? m_packs[ name ] : null;
		}
		/// <summary>
		///   Replaces an already existsing pack with the same name as <paramref name="pack"/> if it exists.
		/// </summary>
		/// <param name="pack">
		///   The new pack to replace the old one with.
		/// </param>
		/// <returns>
		///   True if the manager contains a pack with the same name as <paramref name="pack"/> and it was replaced 
		///   successfully.
		/// </returns>
		public bool Set( WordPack pack )
		{
			if( pack == null || !Contains( pack.Name ) )
				return false;

			m_packs[ pack.Name ] = pack;
			return true;
		}
		/// <summary>
		///   Adds a new pack to the manager.
		/// </summary>
		/// <param name="pack">
		///   The pack to add to the manager.
		/// </param>
		/// <param name="replace">
		///   If a pack already exists with the same name, should it be replaced?
		/// </param>
		/// <returns>
		///   True if the pack was successfully added to the manager.
		/// </returns>
		public bool Add( WordPack pack, bool replace = false )
		{
			if( pack == null )
				return false;

			if( Contains( pack.Name ) )
			{
				if( !replace )
					return false;

				return Set( pack );
			}
			else
				m_packs.Add( pack.Name, pack );

			return true;
		}
		/// <summary>
		///   Removes the pack with the given name from the manager.
		/// </summary>
		/// <param name="name">
		///   The name of the pack to removed.
		/// </param>
		/// <param name="delete">
		///   If the word pack file should be deleted.
		/// </param>
		/// <returns>
		///   True if the pack existed in the manager and was removed, and if <paramref name="delete"/> is true, the
		///   file was deleted successfully, otherwise false.
		/// </returns>
		public bool Remove( string name, bool delete = false )
		{
			if( !Contains( name ) )
				return false;

			if( m_packs.Remove( name ) && delete )
			{
				string path = FolderPaths.WordPackDir + "\\" + name + "." + Constants.PackFileExt;

				if( File.Exists( path ) )
				{
					try
					{
						File.Delete( path );
					}
					catch
					{
						return false;
					}
				}
			}

			return true;
		}
		/// <summary>
		///   Clears all packs from the manager.
		/// </summary>
		public void Clear()
		{
			m_packs.Clear();
		}

		/// <summary>
		///   Clears all packs from the manager and loads all packs found in <see cref="FolderPaths.WordPackDir"/>.
		/// </summary>
		/// <returns>
		///   True if packs were loaded successfully and false otherwise.
		/// </returns>
		public bool Load()
		{
			string[] files;
			m_packs.Clear();

			try
			{
				files = Directory.GetFiles( FolderPaths.WordPackDir, "*." + Constants.PackFileExt );
			}
			catch
			{
				return false;
			}

			bool result = true;

			foreach( string file in files )
			{
				WordPack pack = WordPack.FromFile( file );

				if( pack == null )
					result = false;
				else
					Add( pack );
			}

			return result;
		}
		/// <summary>
		///   Loads a new word pack from <see cref="FolderPaths.WordPackDir"/> using <paramref name="name"/> as the file
		///   name.
		/// </summary>
		/// <param name="name">
		///   The name of the word pack to load.
		/// </param>
		/// <param name="replace">
		///   If the manager already contains a word pack with the given name, should it be replaced?
		/// </param>
		/// <returns>
		///   If the word pack was loaded from file and added to the manager successfully.
		/// </returns>
		public bool LoadFromName( string name, bool replace = false )
		{
			if( !Naming.IsValidName( name ) )
				return false;

			return Add( WordPack.FromName( name ), replace );
		}
		/// <summary>
		///   Saves all word packs to <see cref="FolderPaths.WordPackDir"/>.
		/// </summary>
		/// <returns>
		///   True if all word packs saved to file successfully or false if even just one fails.
		/// </returns>
		public bool Save()
		{
			bool result = true;

			foreach( var v in m_packs )
				if( !v.Value.SaveToFile() )
					result = false;

			return result;
		}

		/// <summary>
		///   Returns an enumerator that iterates through the manager.
		/// </summary>
		/// <returns>
		///   An enumerator that can be used to iterate through the manager.
		/// </returns>
		public IEnumerator<KeyValuePair<string, WordPack>> GetEnumerator()
		{
			return ( (IEnumerable<KeyValuePair<string, WordPack>>)m_packs ).GetEnumerator();
		}
		/// <summary>
		///   Returns an enumerator that iterates through the manager.
		/// </summary>
		/// <returns>
		///   An enumerator that can be used to iterate through the manager.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ( (IEnumerable<KeyValuePair<string, WordPack>>)m_packs ).GetEnumerator();
		}

		private static Dictionary<string, WordPack> m_packs;

		private static volatile PackManager _instance;
		private static readonly object _syncRoot = new object();
	}
}
