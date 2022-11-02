using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System.HallMenagerFuntions;

public partial class ViewDomeMenuItems : ContentPage
{
	public ViewDomeMenuItems()
	{
		InitializeComponent();
		doneMenuItemService.GetDoneMenuItems();
		DoneMenuItemsCollectionView.ItemsSource = DoneMenuItemsCollection.doneItems;
	}

	public ViewTablesPage ViewTablesPage
	{
		get => default;
		set
		{
		}
	}

	DoneMenuItemService doneMenuItemService = new DoneMenuItemService();

	private void ToRefreshingDoneMenuItemsRefresh(object sender, EventArgs e)
	{
        DoneMenuItemsRefresh.IsRefreshing = true;
        doneMenuItemService.GetDoneMenuItems();
		DoneMenuItemsRefresh.IsRefreshing = false;
    }

	private void OnCheckMenuItemClick(object sender, EventArgs e)
	{
		doneMenuItemService.RemoveDoneItem(
			DoneMenuItemsCollection.doneItems[DoneMenuItemsCollection.doneItems.IndexOf((MenuItemm)DoneMenuItemsCollectionView.SelectedItem)].Key);
		DoneMenuItemsCollection.doneItems.RemoveAt(DoneMenuItemsCollection.doneItems.IndexOf((MenuItemm)DoneMenuItemsCollectionView.SelectedItem));
	}
}