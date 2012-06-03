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
using de.dhoffmann.mono.andnaviki.buslog.routingprovider;
using de.dhoffmann.mono.andnaviki.buslog.database;

namespace de.dhoffmann.mono.andnaviki.buslog.routingprovider.file
{
	public class File : IRoutingProvider
	{
		public File ()
		{
		}
		
		
		public bool ImportFile(string countryID, string addrStart, string addrDestination, string srcFilename, Guid routeUID)
		{
			bool ret = false;
			
			if (String.IsNullOrEmpty(addrStart))
				return false;
			else
				addrStart = addrStart.Trim();
			
			if (String.IsNullOrEmpty(addrDestination))
				return false;
			else
				addrDestination = addrDestination.Trim();
						
			// Wurde ein Dateiname angegeben?
			if (String.IsNullOrEmpty(srcFilename))
				return false;
			else
				srcFilename = srcFilename.Trim();
			
			// Ist es eine GPX Datei?
			if (!srcFilename.ToLower().EndsWith(".gpx"))
				return false;
			
			// Existiert die Datei?
			if (!System.IO.File.Exists(srcFilename))
				return false;
			
			// Pfad für die GPX Dateien zusammenbauen
			string gpxPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			gpxPath = System.IO.Path.Combine(gpxPath, "GPX");
			
			// Verzeichnis im zweifelsfall neu anlegen
			if (!System.IO.Directory.Exists(gpxPath))
				System.IO.Directory.CreateDirectory(gpxPath);
			
			try
			{
				System.IO.File.Copy(srcFilename, System.IO.Path.Combine(gpxPath, routeUID.ToString() + ".gpx"));
				ret = true;
			}
			catch(Exception)
			{
				// TODO logging
			}
			
			// Wenn das kopieren der Datei geklappt hat, die Route in der Datenbank hinterlegen
			if (ret)
				ret = new DBRoute().AddNewRoute(routeUID, countryID, addrStart, addrDestination);
			
			return ret;	
		}
	}
}

