using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using ModernHttpClient;
using System.Net.Http;
using System.Net.Http.Headers; // For AuthenticationHeaderValue


namespace XamarinFormsOAuth2Demo
{
	public class ProfilePage : ContentPage
	{
		private Button btnLogout;
		private object accessToken;
		private GoogleUserInfo googleUserInfo;

		public ProfilePage ()
		{

			RenderContent();

			btnLogout.Clicked += (sender, args) =>
			{
				// Kill the access_token so we don't look like we are logged in anymore.
				App.Current.Properties ["access_token"] = "";
				// Make the main page the StartPage, which is where auth is launched from.
				App.Current.MainPage = new StartPage();
			};

			//var res = await LoadUserData();

			LoadUserData ();
				
		}

		private async Task LoadUserData ()
		{

			if (IsBusy)
				return;

			IsBusy = true;

			// Since we have an access token, we may as well go out to google and find out who the hell just logged in.
			if (App.Current.Properties.TryGetValue ("access_token", out accessToken)) {
				if (accessToken.ToString ().Length > 0) {

					string url = @"https://www.googleapis.com/oauth2/v1/userinfo?alt=json";

					var httpClient = new HttpClient(new NativeMessageHandler());
					var authHeader = new AuthenticationHeaderValue ("Bearer", accessToken.ToString());
					httpClient.DefaultRequestHeaders.Authorization = authHeader;

					Task<string> apiWebRequest = httpClient.GetStringAsync(url); // async method!

					string apiResponse = await apiWebRequest;

					try {
						googleUserInfo = JsonConvert.DeserializeObject<GoogleUserInfo> (apiResponse);
					} catch (Exception ex) {
						var temp = ex;
					}
				}
			}

			IsBusy = false;

			try {
				// Change the logout button to be super customized.  Sort of.
				btnLogout.Text = "Log Out " + googleUserInfo.given_name;
			}
			catch {
			}

			return;
		}
			
		private void RenderContent() {

			ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand};
			var rootLayout = new StackLayout() { BackgroundColor = Color.Gray, Spacing = 15, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(0, 0, 0, 10) }; // Padding = new Thickness(45, 15, 45, 15),


			ContentView header = new ContentView() { BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(0, 80, 0, 0) };
			rootLayout.Children.Add(header);

			btnLogout = new Button() {
				Text = " LOG OUT ", 
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.Aqua, 
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center
			};
			rootLayout.Children.Add(btnLogout);

			scrollview.Content = rootLayout;

			if (Device.OS == TargetPlatform.Android)
			{
				scrollview.IsClippedToBounds = true;
			}

			Content = scrollview;

		}

	}
}


