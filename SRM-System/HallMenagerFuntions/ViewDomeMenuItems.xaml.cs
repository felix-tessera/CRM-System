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
	DoneMenuItemService doneMenuItemService = new DoneMenuItemService();

	private void ToRefreshingDoneMenuItemsRefresh(object sender, EventArgs e)
	{
        DoneMenuItemsRefresh.IsRefreshing = true;
        doneMenuItemService.GetDoneMenuItems();
		DoneMenuItemsRefresh.IsRefreshing = false;
    }

	private void OnCheckMenuItemClick(object sender, EventArgs e)
	{

	}
}