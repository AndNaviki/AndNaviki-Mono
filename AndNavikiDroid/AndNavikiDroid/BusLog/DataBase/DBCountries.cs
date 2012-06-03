using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data.Common;


namespace de.dhoffmann.mono.andnaviki.buslog.database
{
	public class DBCountries : DataBase
	{
		public DBCountries ()
		{
		}
		
		
		public Dictionary<string, string> GetCountries()
		{
			Dictionary<string, string> ret = new Dictionary<string, string>();
			
			SqliteConnection conn = GetConnection();
			
			using(DbCommand c = conn.CreateCommand())
			{
				c.CommandText = "SELECT CountryID, Name_1031 FROM countries ORDER BY Name_1031;";
				c.CommandType = System.Data.CommandType.Text;
				conn.Open();
				
				using (DbDataReader reader = c.ExecuteReader())
				{
					while(reader.Read())
					{
						string k = reader.GetString(0);
						string v = reader.GetString(1);
						
						ret.Add(k, v);
					}
				}
				
				conn.Close();
			}
			
			return ret;
		}
	}
}

