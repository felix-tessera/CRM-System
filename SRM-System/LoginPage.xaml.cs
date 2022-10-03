using SRM_System.LogInEmoloyee;
using SRM_System.RegisterLogic;
using SRM_System.Services;

namespace SRM_System;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	AdminService adminService = new AdminService();
	ChiefService chiefService = new ChiefService();
	CookService cookService = new CookService();
	HallMenagerService hallMenagerService = new HallMenagerService();

	CheckAdminPassword checkAdmin = new CheckAdminPassword();
	EmployeePassword employeePassword = new EmployeePassword();
	private void OnLogInClicked(object sender, EventArgs e)
	{
		//��������� ������� � ������� ��� �����������
		adminService.GetAdmin(LoginEntry.Text, 
			CheckAdminPassword.ByteArrayToString(checkAdmin.OnePasswordHash(PasswordEntry.Text)));
		chiefService.GetChief(LoginEntry.Text,
			employeePassword.ByteArrayToString(employeePassword.OnePasswordHash(PasswordEntry.Text)));
		cookService.GetCooks(LoginEntry.Text,
			employeePassword.ByteArrayToString(employeePassword.OnePasswordHash(PasswordEntry.Text)));
		hallMenagerService.GetHallMenager(LoginEntry.Text,
			employeePassword.ByteArrayToString(employeePassword.OnePasswordHash(PasswordEntry.Text)));
    }

	private async void OnTapAmdinRegistationLink(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("AdminRegistrationPage");
    }
}