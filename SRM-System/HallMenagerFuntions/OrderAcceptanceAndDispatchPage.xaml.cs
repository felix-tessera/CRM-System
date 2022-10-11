using SRM_System.Models;
using SRM_System.Services;
using System.Collections.ObjectModel;

namespace SRM_System.HallMenagerFuntions;

public partial class OrderAcceptanceAndDispatchPage : ContentPage
{
	public OrderAcceptanceAndDispatchPage()
	{
		InitializeComponent();
        menuItemService.GetMenuItems();
        MenuItemsCollectionView.ItemsSource = MenuItemsCollection.MenuItems;
    }
    MenuItemService menuItemService = new MenuItemService();
    DataSearchService dataSearchService = new DataSearchService();
    private void ToRefreshingMenuItemsRefresh(object sender, EventArgs e)
    {
        MenuItemsRefresh.IsRefreshing = true;

        menuItemService.GetMenuItems();

        MenuItemsRefresh.IsRefreshing = false;
    }

    private void OnAddMenuItemToOrderClick(object sender, EventArgs e)
    {
        
    }

    private void ToMenuItemPostButtonClicked(object sender, EventArgs e)
    {

    }

    private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
         await dataSearchService.SearchInMenuItemListAsync(MenuItemSearchBar.Text);
        MenuItemsCollectionView.ItemsSource = dataSearchService.SearchingMenuItems;
    }
}