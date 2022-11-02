using SRM_System.LogInEmoloyee;
using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System.AdminFunctions;

public partial class AddHallManagerPage : ContentPage
{
	public AddHallManagerPage()
	{
		InitializeComponent();
	}

    public HallMenager HallMenager
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
            HallMenagerService hallMenagerService = new HallMenagerService();
            EmployeePassword employeePassword = new EmployeePassword();
            var passwordHash = employeePassword.OnePasswordHash(PasswordEntry.Text);
            var hallMenager = new HallMenager
            {
                Login = LoginEntry.Text,
                Name = NameEntry.Text,
                Password = employeePassword.ByteArrayToString(passwordHash)
            };
            await hallMenagerService.AddHallMenager(hallMenager);
        }
    }
}