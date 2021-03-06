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

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using de.dhoffmann.mono.andnaviki.buslog.database;

namespace de.dhoffmann.mono.andnaviki.droid
{
	[Activity (Label = "AndNaviki", MainLauncher = true)]
	public class Root : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Root);
			
			// Datenbankenschema prüfen/aktualisieren
			new DBSchema().UpdateDBSchema();

			// Get our button from the layout resource,
			// and attach an event to it
			Button btnNewRoute = FindViewById<Button> (Resource.Id.btnNewRoute);
			btnNewRoute.Click += delegate {
				StartActivity(typeof(ProviderSelection));
			};
		}
	}
}


