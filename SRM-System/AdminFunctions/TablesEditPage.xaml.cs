using Microsoft.Extensions.Logging.Abstractions;
using SRM_System.Models;
using SRM_System.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SRM_System.AdminFunctions;

public partial class TablesEditPage : ContentPage
{
	public TablesEditPage()
	{
		InitializeComponent();

        tableService.GetTables();
        TablesCollectionView.ItemsSource = TablesCollection.Tables;
    }
    TableService tableService = new TableService();

	private async void OnAddTableButtonClicked(object sender, EventArgs e)
	{
        if (IdEntry.Text != null && SeatsEntry.Text != null)
        {
            TablesCollection.Tables.Add(new Table
            {
                Id = IdEntry.Text,
                Seats = int.Parse(SeatsEntry.Text),
                State = $"Состояние: ",
            });
            await tableService.AddTable(TablesCollection.Tables[TablesCollection.Tables.Count - 1]);
        }

    }

    private void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
    {
        try
        {
            tableService.RemoveTable(TablesCollection.Tables[TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem)].Key);
            //Удаление выбранного элемента
            //  tableService.GetTables();
            TablesCollection.Tables.RemoveAt(TablesCollection.Tables.IndexOf((Table)TablesCollectionView.SelectedItem));
        }
        catch
        {

        }
    }

    private void ToRefreshingTablesRefresh(object sender, EventArgs e)
    {
        TablesRefresh.IsRefreshing = true;

        tableService.GetTables();

        TablesRefresh.IsRefreshing = false;
    }
}