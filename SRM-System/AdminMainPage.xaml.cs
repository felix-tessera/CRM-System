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
}