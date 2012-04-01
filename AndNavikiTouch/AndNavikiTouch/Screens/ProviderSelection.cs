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
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;


namespace de.dhoffmann.mono.andnaviki.screens
{
	public partial class ProviderSelection : UIViewController
	{		

		public ProviderSelection () : base ("ProviderSelection", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
	
		public void SetData(int selectedRow)
		{
			
			lstProviders.DataSource = new MainTableDataSource(selectedRow);
			lstProviders.Delegate = new MainTableDelegate(this);
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			Title = "Providerauswahl";
		
			SetData(0);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		
	}
	
	
	public class MainTableDataSource : UITableViewDataSource
	{
		IList<SectionData> _data;
		private Dictionary<int, List<string>> viewData = new Dictionary<int, List<string>>();
 
		private class SectionData
		{
			public string Title { get;set; }
			public string CellId { get;set; }
			public IList<string> Data { get;set; }
			 
			public SectionData(string cellId)
			{
				Title = "";
				CellId = cellId;
				Data = new List<string>();
			}
		}
		 
		public MainTableDataSource(int selectedRow)
		{
			// TODO: DB
			viewData = new Dictionary<int, List<string>>();
			viewData.Add(0, new List<string>() {
				"Deutschland",
				"Deutschland 1",
				"Deutschland 2"
			});
			viewData.Add(1, new List<string>(){
				"Naviki.org",
				"Webadresse",
				"Datei"
			});
			
			
			_data = new List<SectionData>();
			 
			SectionData section1 = new SectionData("section1");
			section1.Title = "Land";

			SectionData section2 = new SectionData("section2");
			section2.Title = "Provider";

			foreach(KeyValuePair<int, List<string>> secItem in GetViewData)
			{
				foreach (string item in secItem.Value)
				{
					switch(secItem.Key)
					{
						case 0:
							section1.Data.Add(item);
							break;
						case 1:
							section2.Data.Add(item);
							break;
					}
				}
			}

			_data.Add(section1);
			_data.Add(section2);
		}
			        
		public Dictionary<int, List<string>> GetViewData
		{
			get 
			{
				return viewData;
			}
			private set 
			{
				viewData = value;
			}
		}
		 
		public override string TitleForHeader(UITableView tableView, int section)
		{
			return _data[section].Title;
		}
		 
		public override int RowsInSection(UITableView tableview, int section)
		{
			// Es soll nur das ausgewählte Land angezeigt werden.
			if (section == 0 && _data[section].Data.Count > 0)
				return 1;
			
			// In der anderen Liste alle Elemente anzeigen
			return _data[section].Data.Count;
		}
		 
		public override int NumberOfSections(UITableView tableView)
		{
			return _data.Count;
		}
		 
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			SectionData sectionData = _data[indexPath.Section];
			string cellId = sectionData.CellId;
			string row = sectionData.Data[indexPath.Row];
			 
			UITableViewCell cell = tableView.DequeueReusableCell(cellId);      
			if (cell == null )
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);

			cell.TextLabel.Text = row;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			
			return cell;
		}
	}
	
	public class MainTableDelegate : UITableViewDelegate
	{      
		private ProviderSelection _controller;
		 
		public MainTableDelegate(ProviderSelection controller)
		{
			_controller = controller;  
		}
		 
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			Section sec = new Section();
			
			// Länderauswahl
			if (indexPath.Section == 0 && indexPath.Row == 0)
			{
				
				RootElement root = new RootElement(null);
				root.Add(sec);
				
				foreach(KeyValuePair<int, List<string>> secItem in ((MainTableDataSource)tableView.DataSource).GetViewData)
				{
					foreach (string item in secItem.Value)
					{
						switch(secItem.Key)
						{
							case 0:
								sec.Add(new CheckboxElement(item, false));
								break;
						}	
					}
				}
				
				
				var dv = new DialogViewController(root, true);
				dv.Title = "Länderauswahl";
				
				dv.ViewDissapearing += delegate(object sender, EventArgs e) {
					
					int checkedRow = -1;
					string sCountry = null;
					RootElement itemRow = ((DialogViewController)sender).Root;
					
					for (int nIndex=0; nIndex < itemRow[0].Elements.Count; nIndex++)
					{
						if (((CheckboxElement)itemRow[0].Elements[nIndex]).Value)
						{
							checkedRow = nIndex;
							break;
						}
					}
					
					_controller.SetData(checkedRow);
					
				};

				_controller.NavigationController.PushViewController(dv, true);
			}
		}
	}

}

