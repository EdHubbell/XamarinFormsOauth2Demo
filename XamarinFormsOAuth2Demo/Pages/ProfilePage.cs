using System;

using Xamarin.Forms;

namespace XamarinFormsOAuth2Demo
{
	public class ProfilePage : ContentPage
	{
		Button btnLogout;

		public ProfilePage ()
		{

			RenderContent();

			btnLogout.Clicked += (sender, args) =>
			{
				App.Current.MainPage = new StartPage();
				// IssueReport sends us to the IssueReport page.
			};
				
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


