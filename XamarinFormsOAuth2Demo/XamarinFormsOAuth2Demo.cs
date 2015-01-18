using System;

using Xamarin.Forms;

namespace XamarinFormsOAuth2Demo
{
	public class App : Application
	{
		public App ()
		{
		
			App.Current.Properties.Add ("clientId", "730990345527-h7r23gcdmdllgke4iud4di76b0bmpnbb.apps.googleusercontent.com");
			App.Current.Properties.Add ("scope", "https://www.googleapis.com/auth/userinfo.email");
			App.Current.Properties.Add ("authorizeUrl", "https://accounts.google.com/o/oauth2/auth");
			App.Current.Properties.Add ("redirectUrl", "https://www.googleapis.com/plus/v1/people/me");

			// The root page of your application before login.
			MainPage = new StartPage();

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

