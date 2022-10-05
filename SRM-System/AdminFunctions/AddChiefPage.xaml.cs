using SRM_System.LogInEmoloyee;
using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System.AdminFunctions;

public partial class AddChiefPage : ContentPage
{
	public AddChiefPage()
	{
		InitializeComponent();
	}

	private async void OnAddEmployeeButtonClicked(object sender, EventArgs e)
	{
		if (LoginEntry.Text != null && NameEntry.Text != null && PasswordEntry.Text != null)
		{
			ChiefService chiefService = new ChiefService();
			EmployeePassword employeePassword = new EmployeePassword();
			var passwordHash = employeePassword.OnePasswordHash(PasswordEntry.Text);
			var chief = new Chief
			{
				Login = LoginEntry.Text,
				Name = NameEntry.Text,
				Password = employeePassword.ByteArrayToString(passwordHash)
			};
		await chiefService.AddChief(chief);
		}
	}
}