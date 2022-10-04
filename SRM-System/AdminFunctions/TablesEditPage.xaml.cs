using SRM_System.Models;
using SRM_System.Services;
using System.Collections.ObjectModel;

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
        TablesCollection.Tables.Add(new Table
        {
            Id = int.Parse(IdEntry.Text),
            Seats = int.Parse(SeatsEntry.Text),
            State = $"Состояние: "
        });

        await tableService.AddTable(TablesCollection.Tables[TablesCollection.Tables.Count-1]);
    }
}