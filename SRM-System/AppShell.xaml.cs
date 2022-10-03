using SRM_System.AdminFunctions;

namespace SRM_System;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("AdminRegistrationPage", typeof(AdminRegistrationPage));
        Routing.RegisterRoute("ConfirmMailPage", typeof(ConfirmMailPage));
        Routing.RegisterRoute("AdminMainPage", typeof(AdminMainPage));
        Routing.RegisterRoute("AddChiefPage", typeof(AddChiefPage));
        Routing.RegisterRoute("AddCookPage", typeof(AddCookPage));
        Routing.RegisterRoute("AddHallMenagerPage", typeof(AddHallManagerPage));
        Routing.RegisterRoute("ChiefMainPage", typeof(ChiefMainPage));
        Routing.RegisterRoute("CookMainPage", typeof(CookMainPage));
        Routing.RegisterRoute("HallMenagerMainPage", typeof(HallMenagerMainPage));
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Window.AddFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
        Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
#endif
    }
}
