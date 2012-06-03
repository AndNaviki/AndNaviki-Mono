/*
 * This file is part of AndNaviki
 * (based on MoSync examples)
 * Copyright (C) 2011 David Hoffmann
 *
 * AndNaviki is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, version 2.
 *
 * AndNaviki is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AndNaviki; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data.SqlClient;
using System.Data.Common;

namespace de.dhoffmann.mono.andnaviki.buslog.database
{
	public class DBSchema : DataBase
	{
		public DBSchema()
		{
		}
		
		
		/// <summary>
		/// Gets the DB version.
		/// </summary>
		/// <returns>
		/// The DB version.
		/// </returns>
		public int GetDBVersion()
		{
			int retVersion = -1;
			
			SqliteConnection conn = GetConnection();
			
			using(DbCommand c = conn.CreateCommand())
			{
				c.CommandText = "SELECT VersionID FROM version ORDER BY VersionID DESC Limit 1;";
				c.CommandType = System.Data.CommandType.Text;
				conn.Open();
				
				using (DbDataReader reader = c.ExecuteReader())
				{
					// Es gibt nur eine letzte Version
					reader.Read();
					retVersion = reader.GetInt32(0);
				}
				
				conn.Close();
			}
			
			if (retVersion == -1)
				throw new Exception("Fehler beim Zugriff auf die Datenbank!");
			
			return retVersion;
		}
		
		
		/// <summary>
		/// Aktualisiert das Datenbankenschema
		/// </summary>
		public void UpdateDBSchema()
		{
			List<string> commands = new List<string>();
			
			int currentVersion = GetDBVersion();
			
			// Befehle für die Schemaaktualisierung zusmmen sammeln.
			if (currentVersion <= 0)
			{
				commands.Add("CREATE TABLE countries (CountryID VARCHAR(10) PRIMARY KEY, Name_1033 VARCHAR(50), Name_1031 VARCHAR(50));");
				commands.Add("INSERT INTO countries(CountryID, Name_1033, Name_1031) VALUES('de', 'Germany', 'Deutschland');");
				commands.Add("CREATE TABLE routes (UID_Route VARCHAR(40) PRIMARY KEY, CountryID VARCHAR(10), StartAddress VARCHAR(200), DestinationAddress VARCHAR(200));");
				commands.Add("INSERT INTO version (DateCreate) VALUES (date('now'));");
			}
			
			// Befehle an die Datenbank schicken
			if (commands.Count > 0)
			{
				SqliteConnection conn = GetConnection();
				conn.Open();
				
				using(DbCommand c = conn.CreateCommand())
				{
					foreach(string cmd in commands)
					{
						c.CommandText = cmd;
						c.CommandType = System.Data.CommandType.Text;
						c.ExecuteNonQuery();
					}
				}
				
				conn.Close();
			}
		}
	}
}
