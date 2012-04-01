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
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using de.dhoffmann.mono.andnaviki.screens;

namespace de.dhoffmann.mono.andnaviki
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController rootNavigationController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			rootNavigationController = new UINavigationController();
			
			// Start Screen
			Root rootScreen = new Root();
			rootScreen.Title = "AndNaviki";
			
			// Startscreen dem Navigation-Controller hinzufügen
			rootNavigationController.PushViewController(rootScreen, false);
			
			// make the window visible
			window.RootViewController = rootNavigationController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

