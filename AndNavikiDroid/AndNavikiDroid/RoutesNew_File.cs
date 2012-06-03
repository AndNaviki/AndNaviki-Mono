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
using Android.OS;
using Android.Widget;
using Android.Content;

namespace de.dhoffmann.mono.andnaviki.droid
{
	[Activity (Label = "AndNaviki - Neue Route")]
	public class RoutesNew_File : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.RoutesNew_File);
			
			// TODO PRÜFEN!!
			/*
			Button btnFileOpen = FindViewById<Button>(Resource.Id.btnFileOpen);
			btnFileOpen.Click += delegate(object sender, EventArgs e) {
				Intent intent = new Intent();
				intent.AddCategory(Intent.CategoryOpenable);
				intent.SetType("text/gpx");
				intent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(Intent.CreateChooser(intent, "Open"), 1);
			};
			
			
				and then onActivityResult()
		        currFileURI = data.getData();
		        filename_editText.setText(currFileURI.getPath());
	        */
			
			Button btnFileImport = FindViewById<Button>(Resource.Id.btnFileImport);
			btnFileImport.Click += delegate(object sender, EventArgs e) {

				EditText etFileStartAddr = FindViewById<EditText>(Resource.Id.etFileStartAddr);
				EditText etFileZielAddr = FindViewById<EditText>(Resource.Id.etFileZielAddr);
				EditText etFilename = FindViewById<EditText>(Resource.Id.etFilename);
				
				if (!String.IsNullOrEmpty(etFilename.Text) && !String.IsNullOrEmpty(etFileStartAddr.Text) && !String.IsNullOrEmpty(etFileZielAddr.Text))
				{
					Guid routeUID = Guid.NewGuid();
					de.dhoffmann.mono.andnaviki.buslog.routingprovider.file.File fileImport = new de.dhoffmann.mono.andnaviki.buslog.routingprovider.file.File();
					
					string currentCountry = Intent.GetStringExtra("CountryID");
					
					if (fileImport.ImportFile(currentCountry, etFileStartAddr.Text, etFileZielAddr.Text, etFilename.Text, routeUID))
					{
						;
					}
					else
					{
						// TODO Fehlermeldung
					}
				}
				else
				{
					// TODO Fehlermeldung
				}
	
			};

			// Get our button from the layout resource,
			// and attach an event to it
		}
	}
}

