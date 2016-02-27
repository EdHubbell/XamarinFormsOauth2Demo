using System;

using Xamarin.Forms;

namespace XamarinFormsOAuth2Demo
{
	public class App : Application
	{
		private object accessToken;
		private bool loggedIn;

		public App ()
		{
		
			// This code is re-launched when an Android app is restarted from a sleep.  So we need to make sure that any calls in this area 
			// are idempotent, which is a word really only programmers and math geeks know.  This shit will run again - Make sure it doesn't trip over itself.

			loggedIn = false;

			if (App.Current.Properties.TryGetValue ("access_token", out accessToken)) {
				if (accessToken.ToString ().Length > 0) {
					loggedIn = true;
				}
			}

			if (!loggedIn) {
				// If we aren't logged in, then this may be the first time we're starting the app, in which case we want to
				// jam some settings in for our auth that we can retrieve later.  
				// But MAYBE, we are re-launching an app that was not logged in, in which case jamming these values in would 
				// cause a crash.  So we wrap them up in an empty try-catch, which is not elegant but is effective.
				try {
					App.Current.Properties.Add ("clientId", "730990345527-h7r23gcdmdllgke4iud4di76b0bmpnbb.apps.googleusercontent.com");
					App.Current.Properties.Add ("scope", "https://www.googleapis.com/auth/userinfo.email");
					App.Current.Properties.Add ("authorizeUrl", "https://accounts.google.com/o/oauth2/auth");
					App.Current.Properties.Add ("redirectUrl", "https://www.googleapis.com/plus/v1/people/me");

					// These are not applicable for Twitter login
					App.Current.Properties.Add ("clientSecret", "na");
					App.Current.Properties.Add ("accessTokenUrl", "na");

				} catch {
				}

				// The root page of your application before login.
				MainPage = new StartPage();

			} else {
				// If we ARE logged in, then fire up the root page of your application after login.
				MainPage = new ProfilePage();
			}


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

