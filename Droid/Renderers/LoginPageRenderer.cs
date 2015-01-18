using System; 
using Android.App;
using XamarinFormsOAuth2Demo;
using XamarinFormsOAuth2Demo.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace XamarinFormsOAuth2Demo.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
		bool done = false;

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			if (!done) {

				// this is a ViewGroup - so should be able to load an AXML file and FindView<>
				var activity = this.Context as Activity;

				var auth = new OAuth2Authenticator (
					clientId: App.Current.Properties ["clientId"].ToString(),
					scope: App.Current.Properties ["scope"].ToString(),
					authorizeUrl: new Uri( App.Current.Properties ["authorizeUrl"].ToString()),
					redirectUrl: new Uri(App.Current.Properties ["redirectUrl"].ToString()));

				auth.Completed += (sender, eventArgs) => {
					if (eventArgs.IsAuthenticated) 
					{
						App.Current.MainPage = new ProfilePage();

						App.Current.Properties ["access_token"] = eventArgs.Account.Properties ["access_token"].ToString();

					} 
					else 
					{
						// Auth failed - The only way to get to this branch on Google is to hit the 'Cancel' button.
						App.Current.MainPage = new StartPage();
						App.Current.Properties ["access_token"] = "notTokenAvailable";
					}
				};

				//auth.AllowCancel = false;
				activity.StartActivity (auth.GetUI (activity));
				done = true;
			}
		}
	}
}
