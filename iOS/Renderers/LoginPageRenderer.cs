using System;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using XamarinFormsOAuth2Demo;
using XamarinFormsOAuth2Demo.iOS;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace XamarinFormsOAuth2Demo.iOS
{
	public class LoginPageRenderer : PageRenderer
	{

		bool IsShown;

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if(	! IsShown ) {

				IsShown = true;

				var auth = new OAuth2Authenticator (
					clientId: App.Current.Properties ["clientId"].ToString(),
					scope: App.Current.Properties ["scope"].ToString(),
					authorizeUrl: new Uri( App.Current.Properties ["authorizeUrl"].ToString()),
					redirectUrl: new Uri(App.Current.Properties ["redirectUrl"].ToString()));
					

				auth.Completed += (sender, eventArgs) => {
					if (eventArgs.IsAuthenticated) {
						// OK, if we get this far, then the user is authenticated - That's great.  
						// So change the App MainPage so we're at a location that only Auth users can get to.
						App.Current.MainPage = new ProfilePage();

						App.Current.Properties ["access_token"] = eventArgs.Account.Properties ["access_token"].ToString();

					} else {
						// Auth failed - The only way to get to this branch on Google is to hit the 'Cancel' button.
						App.Current.MainPage = new StartPage();

						App.Current.Properties ["access_token"] = "notTokenAvailable";
					}
				};

				// This is what actually launches the auth web UI.
				PresentViewController (auth.GetUI (), true, null);

			}
				
		}

	}
}
