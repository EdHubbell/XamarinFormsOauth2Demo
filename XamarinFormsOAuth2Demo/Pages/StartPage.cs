using System;

using Xamarin.Forms;

namespace XamarinFormsOAuth2Demo
{
	public class StartPage : ContentPage
	{
		Button btnGoogleLogIn;

		public StartPage ()
		{
			RenderContent();

			btnGoogleLogIn.Clicked += (sender, args) =>
			{
				// IssueReport sends us to the IssueReport page.
				var loginPage = new LoginPage ();
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

			scrollview.Content = rootLayout;

			if (Device.OS == TargetPlatform.Android)
			{
				scrollview.IsClippedToBounds = true;
			}

			Content = scrollview;
		
		}

	}
}


