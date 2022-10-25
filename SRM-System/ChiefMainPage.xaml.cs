using Microsoft.Maui.Controls.Internals;
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
		CooksCollectionCarouselView.ItemsSource = CummonCollection.cooksList;
		MenuItemsCollectionView.ItemsSource = MenuItemsFromOrdersCollection.menuItemmsFromOrders;
        GetCooksLocalNames();
        CookPicker.ItemsSource = CooksNameCollection.cooksNames;
    }
    public void GetCooksLocalNames()
    {
		if (CooksNameCollection.cooksNames != null)
		{
			CooksNameCollection.cooksNames.Clear();
			for (int i = 0; i < CummonCollection.cooksList.Count; i++)
			{
				CooksNameCollection.cooksNames.Add(CummonCollection.cooksList[i].Name);
			}
		}
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
		if (MenuItemsCollectionView.ItemsSource == MenuItemsFromOrdersCollection.menuItemmsFromOrders)
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
		else
		{
			//добавление в список готовых заказов
			DoneMenuItemsCollection.doneItems.Add(CummonCollection.cooksList[CummonCollection.cooksList
				.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].CookMenuItems[CummonCollection.cooksList[CummonCollection.cooksList
				.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].CookMenuItems.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem)]);

            //добавление в базе из коллекции
            await doneMenuItemService.AddDoneMenuItem(DoneMenuItemsCollection.doneItems[DoneMenuItemsCollection.doneItems.Count - 1]);
			//
			if(CummonCollection.cooksList[CummonCollection.cooksList
                .IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].CookMenuItems.Count > 1)
			{
				//удаление в базе
				await orderService.RemoveMenuItemFromCookMenuItemsList(CummonCollection.cooksList[CummonCollection.cooksList
					.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].Key,
					CummonCollection.cooksList[CummonCollection.cooksList
					.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].CookMenuItems
					.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem).ToString());
				//удаление в коллекции
                CummonCollection.cooksList[CummonCollection.cooksList
				.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].CookMenuItems.RemoveAt(CummonCollection.cooksList[CummonCollection.cooksList
				.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].CookMenuItems.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem));
            }
			else
			{
                CummonCollection.cooksList[CummonCollection.cooksList.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)]
				.CookMenuItems[CummonCollection.cooksList[CummonCollection.cooksList.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)]
				.CookMenuItems.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem)].Name = "Empty";
            }	
        }
    }
	private async void OnRefreshButtonClicked(object sender, EventArgs e)
	{
        await cookService.GetCooksPersons();
        await orderService.GetOrders();
        GetCooksLocalNames();
    }

	private async void OnChiefAssignSelect(object sender, EventArgs e)
	{
		int SelectedIndex = CookPicker.SelectedIndex;

		if (SelectedIndex != -1)
		{
			bool isInTheArrayBoundary = MenuItemsFromOrdersCollection//если выбранный элемент в границах массива
				.menuItemmsFromOrders
				.IndexOf((MenuItemm)MenuItemsCollectionView
				.SelectedItem) >= 0
				&& MenuItemsFromOrdersCollection
				.menuItemmsFromOrders
				.IndexOf((MenuItemm)MenuItemsCollectionView
				.SelectedItem)
				< MenuItemsFromOrdersCollection.menuItemmsFromOrders.Count;

			if (isInTheArrayBoundary)
			{
				if (CummonCollection.cooksList[SelectedIndex].CookMenuItems[0].Name == "Empty")
				{
					CummonCollection.cooksList[SelectedIndex].CookMenuItems.Clear();
				}

				CummonCollection.cooksList[SelectedIndex].CookMenuItems.Add(MenuItemsFromOrdersCollection.menuItemmsFromOrders[
					MenuItemsFromOrdersCollection.menuItemmsFromOrders.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem)]);
				//удаляем из общих блюд
				MenuItemsFromOrdersCollection.menuItemmsFromOrders
					.RemoveAt(MenuItemsFromOrdersCollection.menuItemmsFromOrders
					.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem));

				await cookService.UpdateCook(CummonCollection.cooksList[SelectedIndex]);
				CookPicker.SelectedIndex = -1;
			}
		}
    }

	private void OnChiefViewManuItemsClick(object sender, SelectionChangedEventArgs e)
	{
		MenuItemsCollectionView.ItemsSource = CummonCollection.cooksList[CummonCollection.cooksList
			.IndexOf((Cook)CooksCollectionCarouselView.SelectedItem)].CookMenuItems;

    }

	private void OnViewAllMenuItemsButtonClicked(object sender, EventArgs e)
	{
        MenuItemsCollectionView.ItemsSource = MenuItemsFromOrdersCollection.menuItemmsFromOrders;	
    }
}