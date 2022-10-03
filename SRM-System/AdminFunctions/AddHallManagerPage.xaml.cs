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
    private async void OnAddEmployeeButtonClicked(object sender, EventArgs e)
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