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
using de.dhoffmann.mono.andnaviki.buslog.routingprovider;

namespace de.dhoffmann.mono.andnaviki.droid
{
	[Activity (Label = "AndNaviki - Providerauswahl")]
	public class ProviderSelection : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.ProviderSelection);
			
			Spinner spnCountry = FindViewById<Spinner>(Resource.Id.spnCountry);

			ArrayAdapter adapterCountries = ArrayAdapter.CreateFromResource(this, Resource.Array.Countries_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapterCountries.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spnCountry.Adapter = adapterCountries;
			
			RoutingProviderHelper routingProviderHelper = new RoutingProviderHelper();
			
			ListView lstProvider = FindViewById<ListView>(Resource.Id.lstProvider);
			ArrayAdapter<string> adapterProvider = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, routingProviderHelper.RoutingProvider);
			lstProvider.Adapter = adapterProvider;
			
			// Providerauswahl 
			lstProvider.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs e) {
				switch(((Android.Widget.TextView)e.View).Text.ToLower()) 
				{
					case "naviki.org":
						StartActivity(typeof(RoutesNew_NavikiOrg));
						break;
					case "datei":
						StartActivity(typeof(RoutesNew_File));
						break;
					case "webadresse":
						StartActivity(typeof(RoutesNew_Url));
						break;
				}
			};
			
		}
			
	}
}

