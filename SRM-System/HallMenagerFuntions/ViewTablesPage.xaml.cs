using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System.HallMenagerFuntions;

public partial class ViewTablesPage : ContentPage
{
	public ViewTablesPage()
    {
		InitializeComponent();

        tableService.GetTables();
        TablesCollectionView.ItemsSource = TablesCollection.Tables;
    }
    TableService tableService = new TableService();
    private void ToRefreshingTablesRefresh(object sender, EventArgs e)
    {
        TablesRefresh.IsRefreshing = true;

        tableService.GetTables();

        TablesRefresh.IsRefreshing = false;
    }
    private void ToFreeStateTableClicked(object sender, EventArgs e)
    {
        TablesCollection.Tables[TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem)].State = "Свободно";
        tableService.UpdateTables(TablesCollection.Tables[TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem)]);
        tableService.GetTables();
    }
    private void ToBusyStateTableClicked(object sender, EventArgs e)
    {
        TablesCollection.Tables[TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem)].State = "Занято";
        tableService.UpdateTables(TablesCollection.Tables[TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem)]);
        tableService.GetTables();
    }
    private void ToBookedStateTableClicked(object sender, EventArgs e)
    {
        TablesCollection.Tables[TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem)].State = $"Забронировано на {BookedTimePicker.Time}";
        tableService.UpdateTables(TablesCollection.Tables[TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem)]);
        tableService.GetTables();
    }
}