using SRM_System.Models;
using System.Collections.ObjectModel;

namespace SRM_System.AdminFunctions;

public partial class TablesEditPage : ContentPage
{
	public TablesEditPage()
	{
		InitializeComponent();

		this.BindingContext = Tables;

		Generate();
	}
	public ObservableCollection<Table> Tables = new ObservableCollection<Table>();
	public void Generate()
	{
		for (int i = 0; i < 30; i++)
		{
			Tables.Add(new Table
			{
				Id = i,
				Seats = i,
				Ñondition = i.ToString()
			});
		}
        
        TablesCollectionView.ItemsSource = Tables;
	}
}