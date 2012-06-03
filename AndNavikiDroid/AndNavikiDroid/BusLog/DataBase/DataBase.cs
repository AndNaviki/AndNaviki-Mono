using System;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using System.Data.SqlClient;
using System.Data.Common;


namespace de.dhoffmann.mono.andnaviki.buslog.database
{
	public abstract class DataBase
	{
		public DataBase ()
		{
		}
		
		
		protected SqliteConnection GetConnection()
		{
			string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string dbFilename = Path.Combine(docPath, "AndNaviki.db");
			
			bool dbExists = File.Exists (dbFilename);
			
			// Existiert die DB schon?
			if (!dbExists)
				SqliteConnection.CreateFile(dbFilename);
			
			SqliteConnection conn = new SqliteConnection("Data Source=" + dbFilename);
			
			// Wenn es eine neue Datenbank ist.. 
			// Eine neue Tabelle für die Versionsverwaltung anlegen.
			if (!dbExists)
			{
				string[] commands = new[]
				{
					"CREATE TABLE version (VersionID INTEGER PRIMARY KEY AUTOINCREMENT, DateCreate DATETIME NOT NULL)",
					"INSERT INTO version (VersionID, DateCreate) VALUES (0, date('now'))"
				};
				
				foreach(string cmd in commands)
				{
					using(DbCommand c = conn.CreateCommand())
					{
						c.CommandText = cmd;
						c.CommandType = CommandType.Text;
						conn.Open();
						c.ExecuteNonQuery();
						conn.Close();
					}
				}
			}
			
			
			return conn;
		}
	}
}

