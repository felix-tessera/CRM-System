using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System;

public partial class ChiefMainPage : ContentPage
{
	public ChiefMainPage()
	{
		InitializeComponent();

		cookService.GetCooksPersons();
		CooksCollectionCarouselView.ItemsSource = CummonCollection<Cook>.cummonList;
	}
	CookService cookService = new CookService();
	private async void ToRefreshingMenuItemsRefresh(object sender, EventArgs e)
	{
        MenuItemsRefresh.IsRefreshing = true;

        await cookService.GetCooksPersons();

        MenuItemsRefresh.IsRefreshing = false;
    }
}