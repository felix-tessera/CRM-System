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

    public ViewDomeMenuItems ViewDomeMenuItems
    {
        get => default;
        set
        {
        }
    }

    MenuItemService menuItemService = new MenuItemService();
    DataSearchService dataSearchService = new DataSearchService();
    OrderService orderService = new OrderService();

    ObservableCollection<MenuItemm> orderMenuItems = new ObservableCollection<MenuItemm>();

    private void ToRefreshingMenuItemsRefresh(object sender, EventArgs e)
    {
        MenuItemsRefresh.IsRefreshing = true;

        menuItemService.GetMenuItems();

        MenuItemsRefresh.IsRefreshing = false;
    }

    private async void ToMenuItemPostButtonClicked(object sender, EventArgs e)
    {
        await orderService.AddOrder(new Order
        {
            Table = TableEntry.Text,
            OrderList = orderMenuItems
        });
        orderMenuItems.Clear();

    }

    private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
         await dataSearchService.SearchInMenuItemListAsync(MenuItemSearchBar.Text);
        MenuItemsCollectionView.ItemsSource = dataSearchService.SearchingMenuItems;
    }

    private void OnDeleteToOrderMenuItemClick(object sender, EventArgs e)
    {
        try
        {
            if (MenuItemsCollectionView.ItemsSource == dataSearchService.SearchingMenuItems)
            {
                orderMenuItems.Remove(dataSearchService.
                SearchingMenuItems[dataSearchService.
                SearchingMenuItems.
                IndexOf((MenuItemm)MenuItemsCollectionView.
                SelectedItem)]);
            }
            else if (MenuItemsCollectionView.ItemsSource == MenuItemsCollection.MenuItems)
            {
                orderMenuItems.Remove(MenuItemsCollection.
                MenuItems[MenuItemsCollection.
                MenuItems.
                IndexOf((MenuItemm)MenuItemsCollectionView.
                SelectedItem)]);
            }
        }
        catch
        {
        }
    }

    private void OnAddToOrderMenuItemClick(object sender, EventArgs e)
    {
        try
        {
            if (MenuItemsCollectionView.ItemsSource == dataSearchService.SearchingMenuItems)
            {
                orderMenuItems.Add(dataSearchService.
                SearchingMenuItems[dataSearchService.
                SearchingMenuItems.
                IndexOf((MenuItemm)MenuItemsCollectionView.
                SelectedItem)]);
            }
            else if (MenuItemsCollectionView.ItemsSource == MenuItemsCollection.MenuItems)
            {
                orderMenuItems.Add(MenuItemsCollection.
                MenuItems[MenuItemsCollection.
                MenuItems.
                IndexOf((MenuItemm)MenuItemsCollectionView.
                SelectedItem)]);
            }
        }
        catch
        {
        }
    }
}