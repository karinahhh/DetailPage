using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DetailPage
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
			profImg.Source = ImageSource.FromFile("solar.png");
			abtList.ItemsSource = GetMenuList();
			var homePage = typeof(Views.SolarEn);
			Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
			IsPresented = false;
		}
		//https://byjus.com/physics/energy/
		public List<MasterMenuItems> GetMenuList()
		{
			var list = new List<MasterMenuItems>();
			list.Add(new MasterMenuItems()
			{
				Text="Solar Energy",
				Detail="Some info about solar energy",
				ImagePatch = "solar.png",
				TargetPage=typeof(Views.SolarEn)
			});
			list.Add(new MasterMenuItems()
			{
				Text="Water Energy",
				Detail = "Some info about water energy",
				ImagePatch = "",
				TargetPage = typeof(Views.WaterEn)
			});
			list.Add(new MasterMenuItems()
			{
				Text = "Wind Energy",
				Detail = "Some info about wind energy",
				ImagePatch = "",
				TargetPage = typeof(Views.WindEn)
			});
			list.Add(new MasterMenuItems()
			{
				Text = "Gas Energy",
				Detail = "Some info about gas energy",
				ImagePatch = "",
				TargetPage = typeof(Views.GasEn)
			});
			list.Add(new MasterMenuItems()
			{
				Text = "Coal Energy",
				Detail = "Some info about coal energy",
				ImagePatch = "",
				TargetPage = typeof(Views.CoalEn)
			});
			return list;
		}

		private void abtList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var selMenuItem = (MasterMenuItems)e.SelectedItem;
			Type selPage = selMenuItem.TargetPage;
			Detail = new NavigationPage((Page)Activator.CreateInstance(selPage));
			IsPresented = false;
		}
	}
}
