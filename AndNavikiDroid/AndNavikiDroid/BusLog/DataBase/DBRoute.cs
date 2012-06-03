using System;
using Mono.Data.Sqlite;
using System.Data.Common;


namespace de.dhoffmann.mono.andnaviki.buslog.database
{
	public class DBRoute : DataBase
	{
		public DBRoute ()
		{
		}
		
		
		/// <summary>
		/// Fügt eine neue Route hinzu
		/// </summary>
		/// <returns>
		/// The new route.
		/// </returns>
		/// <param name='routeUID'>
		/// If set to <c>true</c> route user interface.
		/// </param>
		/// <param name='addrStart'>
		/// If set to <c>true</c> address start.
		/// </param>
		/// <param name='addrDestination'>
		/// If set to <c>true</c> address destination.
		/// </param>
		public bool AddNewRoute(Guid routeUID, string countryID, string addrStart, string addrDestination)
		{
			bool ret = false;
			
			SqliteConnection conn = GetConnection();
			
			using(DbCommand c = conn.CreateCommand())
			{
				c.CommandText = "INSERT INTO routes(UID_Route, CountryID, StartAddress, DestinationAddress) VALUES ('" + routeUID.ToString() + "', '" + countryID + "', '" + addrStart + "', '" + addrDestination + "');";
				c.CommandType = System.Data.CommandType.Text;
				conn.Open();
				c.ExecuteNonQuery();
				conn.Close();
				
				ret = true;
			}
			
			return ret;
		}
	}
}

