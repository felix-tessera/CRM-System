using SRM_System.RegisterLogic;
using SRM_System.Common;
using SRM_System.Models;

namespace SRM_System;

public partial class AdminRegistrationPage : ContentPage
{
	public AdminRegistrationPage()
	{
		InitializeComponent();
	}

    MailConfirm mailConfirm = new MailConfirm();
    private async void OnRegistrationButtonClicked(object sender, EventArgs e)
	{
		CheckAdminPassword checkHashAdminPassword = new CheckAdminPassword();
		checkHashAdminPassword.RegistrationPasswordsHash(PasswordBase.Text, PasswordConfirmation.Text);
		bool IsPasswordsMath = checkHashAdminPassword.CheckMatchingPasswords();
		if (IsPasswordsMath)
		{
            Password1Frame.BorderColor = Color.FromRgb(80, 110, 47);
            Password2Frame.BorderColor = Color.FromRgb(80, 110, 47);

            mailConfirm.SendConfirmMessage(LoginEntry.Text);
			Admin.login = LoginEntry.Text;

            await Shell.Current.GoToAsync("ConfirmMailPage");
        }
		else
		{
			VibrationAPI.ToVibrate();
			Password1Frame.BorderColor = Color.FromRgb(201, 0, 3);
            Password2Frame.BorderColor = Color.FromRgb(201, 0, 3);
        }
	}
}