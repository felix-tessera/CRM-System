using SRM_System.LogInEmoloyee;
using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System.AdminFunctions;

public partial class AddCookPage : ContentPage
{
	public AddCookPage()
	{
		InitializeComponent();
	}

    public Cook Cook
    {
        get => default;
        set
        {
        }
    }

    private async void OnAddEmployeeButtonClicked(object sender, EventArgs e)
    {
        if (LoginEntry.Text != null && NameEntry.Text != null && PasswordEntry.Text != null)
        {
            CookService cookService = new CookService();
            EmployeePassword employeePassword = new EmployeePassword();
            var passwordHash = employeePassword.OnePasswordHash(PasswordEntry.Text);
            var cook = new Cook
            {
                Login = LoginEntry.Text,
                Name = NameEntry.Text,
                Password = employeePassword.ByteArrayToString(passwordHash),
                CookMenuItems = new System.Collections.ObjectModel.ObservableCollection<MenuItemm>() { new MenuItemm() {Name = "Empty" } }
            };
            LoginEntryFrame.BorderColor = Color.FromRgb(80, 110, 47);
            PasswordEntryFrame.BorderColor = Color.FromRgb(80, 110, 47);
            await cookService.AddCook(cook);
        }
    }
}