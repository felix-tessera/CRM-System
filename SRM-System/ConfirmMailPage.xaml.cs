using SRM_System.Common;
using SRM_System.Models;
using SRM_System.RegisterLogic;
using SRM_System.Services;
using System.Collections.Generic;

namespace SRM_System;

public partial class ConfirmMailPage : ContentPage
{
	public ConfirmMailPage()
	{
		InitializeComponent();
	}
	public AdminService adminService = new AdminService();
	
	private async void OnMailConfirmClicked(object sender, EventArgs e)
	{
		try
		{
			bool mailCheck = MailConfirm.CheckMailMath(MailConfirmEntry.Text);

			if (mailCheck)
			{
				var admin = new Admin
				{
					Login = Admin.login,
					Password = Admin.password,
				};
				await adminService.AddAdmin(admin);
				await Shell.Current.GoToAsync("AdminMainPage");
			}
			else
			{
				await DisplayAlert("Неверный код", "Проверьте код и попробуйте еще раз", "ОK");
			}
		}
		catch
		{
			VibrationAPI.ToVibrate();
			ConfirmMailFrame.BorderColor = Color.FromRgb(201, 0, 3);
        }
	}
}