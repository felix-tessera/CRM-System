namespace SRM_System;

public partial class AdminMainPage : ContentPage
{
	public AdminMainPage()
	{
		InitializeComponent();
	}

	private async void OnAddEmployeeChanged(object sender, EventArgs e)
	{
		switch (EmoployeePicker.SelectedIndex)
		{
			case 0:
				await Shell.Current.GoToAsync("AddCookPage");
				break;
			case 1:
				await Shell.Current.GoToAsync("AddHallMenagerPage");
				break;
			case 2:
				await Shell.Current.GoToAsync("AddChiefPage");
				break;
		}
		EmoployeePicker.SelectedIndex = -1;
	}

	private async void OnTablesEditClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("TablesEditPage");
	}

	private async void OnIngredientsEditClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("IngredientsEditPage");
	}

	private async void OnMenuItemEditClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("MenuEditPage");
	}
}