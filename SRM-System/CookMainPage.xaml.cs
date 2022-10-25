using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System;

public partial class CookMainPage : ContentPage
{
	public CookMainPage()
	{
		InitializeComponent();

        cookService.GetCooksPersons();
    }
    OrderService orderService = new OrderService();
    CookService cookService = new CookService();
    DoneMenuItemService doneMenuItemService = new DoneMenuItemService();
    private async void ToRefreshingMenuItemsRefresh(object sender, EventArgs e)
	{
        MenuItemsRefresh.IsRefreshing = true;
        await cookService.GetCooksPersons();


        int i = 0;
        foreach(var cook in CummonCollection.cooksList)
        {
            i++;
            if (cook.Login == Common.GlogalCookService.CurrentCookPerson.Login)
            {
                MenuItemsCollectionView.ItemsSource = cook.CookMenuItems;
                CurrentCookIndex = i;
            }
        }
        Common.GlogalCookService.CurrentCookPerson = CummonCollection.cooksList[CurrentCookIndex-1];

        MenuItemsRefresh.IsRefreshing = false;
    }
    int CurrentCookIndex;
    private async void ToMenuItemDoneClick(object sender, EventArgs e)
    {
        DoneMenuItemsCollection.doneItems.Add(CummonCollection.cooksList[CurrentCookIndex - 1]
            .CookMenuItems[CummonCollection.cooksList[CurrentCookIndex - 1]
            .CookMenuItems.IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem)]);

        await doneMenuItemService.AddDoneMenuItem(DoneMenuItemsCollection.doneItems[DoneMenuItemsCollection.doneItems.Count - 1]);

        if (CummonCollection.cooksList[CurrentCookIndex - 1].CookMenuItems.Count > 1)
        {
            await orderService.RemoveMenuItemFromCookMenuItemsList(Common.GlogalCookService.CurrentCookPerson.Key, 
                CummonCollection.cooksList[CurrentCookIndex - 1].CookMenuItems
    .IndexOf((MenuItemm)MenuItemsCollectionView.SelectedItem).ToString());

            CummonCollection.cooksList[CurrentCookIndex - 1].CookMenuItems.Remove((MenuItemm)MenuItemsCollectionView.SelectedItem);
        }
        else
        {
            CummonCollection.cooksList[CurrentCookIndex - 1].CookMenuItems[CummonCollection.cooksList[CurrentCookIndex - 1].CookMenuItems.Count - 1].Name = "Empty";
            cookService.UpdateCook(CummonCollection.cooksList[CurrentCookIndex - 1]);
        }
    }
}