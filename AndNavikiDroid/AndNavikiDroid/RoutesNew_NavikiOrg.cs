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

namespace de.dhoffmann.mono.andnaviki.droid
{
	[Activity (Label = "AndNaviki - Neue Route")]
	public class RoutesNew_NavikiOrg : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.RoutesNew_NavikiOrg);
			
			Spinner spnCalcRouteType = FindViewById<Spinner>(Resource.Id.spnCalcRouteType);
			// spnCalcRouteType.ItemSelected += new EventHandler<ItemEventArgs>(spnCalcRouteType_ItemSelected);
			ArrayAdapter adapterCalcRouteType = ArrayAdapter.CreateFromResource(this, Resource.Array.CalcRouteType_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapterCalcRouteType.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spnCalcRouteType.Adapter = adapterCalcRouteType;

			// Get our button from the layout resource,
			// and attach an event to it
		}
	}
}

