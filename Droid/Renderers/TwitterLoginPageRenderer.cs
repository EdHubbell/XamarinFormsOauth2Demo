using System; 
using Android.App;
using XamarinFormsOAuth2Demo;
using XamarinFormsOAuth2Demo.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (TwitterLoginPage), typeof (TwitterLoginPageRenderer))]

namespace XamarinFormsOAuth2Demo.Droid
{
	public class TwitterLoginPageRenderer : PageRenderer
	{
		bool done = false;

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			if (!done) {

				// this is a ViewGroup - so should be able to load an AXML file and FindView<>
				var activity = this.Context as Activity;


				// Pretty sure we are on the right track here, but we  to make it actually work we'll need to 
				// override Xamarin Auth so we can get it to use the correct names in the requests. Pain in the ass.
				var auth = new OAuth2Authenticator (
					clientId: App.Current.Properties ["clientId"].ToString(),
					clientSecret: App.Current.Properties ["clientSecret"].ToString(),
					scope: App.Current.Properties ["scope"].ToString(),
					authorizeUrl: new Uri( App.Current.Properties ["authorizeUrl"].ToString()),
					redirectUrl: new Uri(App.Current.Properties ["redirectUrl"].ToString()),
					accessTokenUrl: new Uri(App.Current.Properties ["accessTokenUrl"].ToString()));


				auth.Completed += (sender, eventArgs) => {
					if (eventArgs.IsAuthenticated) 
					{
						App.Current.MainPage = new ProfilePage();

						App.Current.Properties ["access_token"] = eventArgs.Account.Properties ["access_token"].ToString();

					} 
					else 
					{
						// Auth failed - The only way to get to this branch is to hit the 'Cancel' button.
						App.Current.MainPage = new StartPage();
						App.Current.Properties["access_token"] = "";
					}
				};

				//auth.AllowCancel = false;
				activity.StartActivity (auth.GetUI (activity));
				done = true;
			}
		}
	}
}
