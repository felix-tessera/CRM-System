using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System;

public partial class ChiefMainPage : ContentPage
{
	public ChiefMainPage()
	{
		InitializeComponent();

		cookService.GetCooksPersons();
		orderService.GetOrders();
		CooksCollectionCarouselView.ItemsSource = CummonCollection<Cook>.cummonList;
		MenuItemsCollectionView.ItemsSource = MenuItemsFromOrdersCollection.menuItemmsFromOrders;
	}

	CookService cookService = new CookService();
	OrderService orderService = new OrderService(); 
	DoneMenuItemService doneMenuItemService = new DoneMenuItemService();
	private async void ToRefreshingMenuItemsRefresh(object sender, EventArgs e)
	{
        MenuItemsRefresh.IsRefreshing = true;

        await cookService.GetCooksPersons();
		await orderService.GetOrders();

        MenuItemsRefresh.IsRefreshing = false;
    }

	private async void ToMenuItemDoneClick(object sender, EventArgs e)
	{
		try
		{
			//добавление в список готовых заказов
			DoneMenuItemsCollection.doneItems.Add(MenuItemsFromOrdersCollection.menuItemmsFromOrders[
				MenuItemsFromOrdersCollection.menuItemmsFromOrders.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem)]);
			//удаление в базе
			await orderService.RemoveMenuItemFromOrder(MenuItemsFromOrdersCollection.menuItemmsFromOrders[
				MenuItemsFromOrdersCollection.menuItemmsFromOrders.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem)].OrderKey
				, MenuItemsFromOrdersCollection.menuItemmsFromOrders[
				MenuItemsFromOrdersCollection.menuItemmsFromOrders.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem)].Key);
			//Удаление из коллекции
			doneMenuItemService.AddDoneMenuItem(DoneMenuItemsCollection.doneItems[DoneMenuItemsCollection.doneItems.Count - 1]);
			MenuItemsFromOrdersCollection.menuItemmsFromOrders.RemoveAt(MenuItemsFromOrdersCollection
				.menuItemmsFromOrders
				.IndexOf((MenuItemm)MenuItemsCollectionView
				.SelectedItem));
		}
		catch { }
    }

	private void ToSetMenuItemClick(object sender, EventArgs e)
	{

	}

	private async void OnRefreshButtonClicked(object sender, EventArgs e)
	{
        await cookService.GetCooksPersons();
        await orderService.GetOrders();
    }
}