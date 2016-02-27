using System;

using Xamarin.Forms;

namespace XamarinFormsOAuth2Demo
{
	public class StartPage : ContentPage
	{
		Button btnGoogleLogIn;
		Button btnTwitterLogIn;

		public StartPage ()
		{
			RenderContent();

			btnGoogleLogIn.Clicked += (sender, args) =>
			{
				var loginPage = new LoginPage ();
				Navigation.PushModalAsync (loginPage);
			};


			btnTwitterLogIn.Clicked += (sender, args) =>
			{
				// Consumer Key (API Key) for your app in twitter - In this case, the app is called XamarinFormsOAuth2Demo.
				App.Current.Properties["clientId"] =  "oXiJOBDo4B1VtHjOo2uRqKA49";
				App.Current.Properties["scope"]= "Not Applicable for Twitter";
				// Address that we'll go to in the browser so the user can enter thier twitter credentials.
				App.Current.Properties["authorizeUrl"]= "https://api.twitter.com/oauth/authorize";
				App.Current.Properties["redirectUrl"] = "http://www.twitter.com";

				App.Current.Properties["clientSecret"] = "4tKAaLYwnDZaFbUJBFJN4M1XRGKRoocW9eC7CQGpjDTZtkk8fc";
				App.Current.Properties["accessTokenUrl"] = "https://api.twitter.com/oauth/request_token";

				var loginPage = new TwitterLoginPage ();
				Navigation.PushModalAsync (loginPage);
			};

		}

		private void RenderContent() {
		
			ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand};
			var rootLayout = new StackLayout() { BackgroundColor = Color.Blue, Spacing = 15, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(0, 0, 0, 10) }; // Padding = new Thickness(45, 15, 45, 15),


			ContentView header = new ContentView() { BackgroundColor = Color.Blue, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(0, 80, 0, 0) };
			rootLayout.Children.Add(header);


			btnGoogleLogIn = new Button() {
				Text = " LOG IN WITH GOOGLE ", 
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.Aqua, 
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center
			};
			rootLayout.Children.Add(btnGoogleLogIn);

			btnTwitterLogIn = new Button() {
				Text = " LOG IN WITH TWITTER ", 
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.Aqua, 
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center
			};
			rootLayout.Children.Add(btnTwitterLogIn);

			scrollview.Content = rootLayout;

			if (Device.OS == TargetPlatform.Android)
			{
				scrollview.IsClippedToBounds = true;
			}

			Content = scrollview;
		
		}

	}
}


