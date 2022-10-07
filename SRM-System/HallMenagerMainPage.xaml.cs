namespace SRM_System;

public partial class HallMenagerMainPage : ContentPage
{
	public HallMenagerMainPage()
	{
		InitializeComponent();
	}

	private async void OnTablesViewButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("ViewTablesPage");
	}
}