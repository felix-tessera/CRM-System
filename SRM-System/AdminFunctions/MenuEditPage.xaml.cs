using Microsoft.Maui.Controls;
using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System.AdminFunctions;

public partial class MenuEditPage : ContentPage
{
	public MenuEditPage()
	{
		InitializeComponent();

        menuItemService.GetMenuItems();
		MenuItemsCollectionView.ItemsSource = MenuItemsCollection.MenuItems;
    }
    MenuItemService menuItemService = new MenuItemService();
	private async void ToMenuItemAddButtonClicked(object sender, EventArgs e)
	{
        if (NameEntry.Text != null && PriceEntry.Text != null && CurrencyEntry.Text != null)
        {
            MenuItemsCollection.MenuItems.Add(new MenuItemm
            {
                Name = NameEntry.Text,
                Price = PriceEntry.Text,
                Currency = CurrencyEntry.Text,
            });

            await menuItemService
                .AddMenuItem(MenuItemsCollection.MenuItems[MenuItemsCollection.MenuItems.Count - 1]);
        }
    }
    private void ToRefreshingMenuItemsRefresh(object sender, EventArgs e)
    {
        MenuItemsRefresh.IsRefreshing = true;

        menuItemService.GetMenuItems();

        MenuItemsRefresh.IsRefreshing = false;
    }
    private void OnDeleteMenuItemClick(object sender, EventArgs e)
    {
        try
        {
            menuItemService.RemoveMenuItem(MenuItemsCollection
                .MenuItems[MenuItemsCollection
                .MenuItems.IndexOf((MenuItemm)MenuItemsCollectionView
                .SelectedItem)]
            .Key);

            MenuItemsCollection.MenuItems
                .RemoveAt(MenuItemsCollection.MenuItems
                .IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem));
        }
        catch
        {

        }
    }
}