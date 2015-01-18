## XamarinFormsOauth2Demo

This was based on https://github.com/jsauve/OAuthTwoDemo.XForms, which was published before Xamarin.Forms 1.3.X

1.3.X allows for the ability to just set a MainPage, which looks like a logical way to do things.  For reference, take a look here: http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/app-lifecycle/

This is just a demo that allows you to see all the various config screens that you'll encounter when setting up a Google app.  I included the api keys and whatnot, as I don't see any reason not to.  It isn't a real app. 

The app starts on a start page that has a button that says 'Log On With Google'.  I'd love to get more auth methods in here.  I'd especially love to see a demo of native Facebook auth in a Xamarin.Forms app. 

Any and all feedback is welcome - There are probably better ways to handle much of this.  I'm a Xamarin novice.

Some things that I don't like - 
- Every time there is a login, we're making new pages.  Seems like the old ones are probably floating around somewhere, but I don't know how to find a reference to the previous page.
- Probably should make that google button look decent if we're going to add other login methods.

So here are some nice screenshots:

### Login Flow

Startup screen - This gives us a place to go back to when someone logs out.  If the app starts right out into an Auth page, I think that's a little befuddling.

![Alt text](/screenshots/StartPage.png?raw=true "StartPage")

![Alt text](/screenshots/Login_AndroidPlayer.png?raw=true "Login_AndroidPlayer")

![Alt text](/screenshots/Login_iOS.png?raw=true&width=100 "Login_iOS")

This screen is only seen once per authenticating user - Once the user grants permission to the app, subsequent logins won't ask for permissions.

![Alt text](/screenshots/Login_AppPermissions.png?raw=true "Login_AppPermissions")



![Alt text](/screenshots/ProfilePage.png?raw=true "ProfilePage")


### Google OAuth2 Config Box Checkkin'

Any time you set up a new app, you're going to have to go thru some screens over at https://console.developers.google.com/project  I have problems even getting to the correct screens, as my box is constantly logged in to at least 2 gmail addresses at any time.

The redirect address used here is as suggested by a StackOverflow thread here:
http://stackoverflow.com/questions/25520180/google-account-login-integration-for-android-xamarin


![Alt text](/screenshots/Google_CreateNewProject.png?raw=true "Google_CreateNewProject")
![Alt text](/screenshots/Google_ChooseWebApplication.png?raw=true "Google_ChooseWebApplication")
![Alt text](/screenshots/Google_SetRedirectAddress.png?raw=true "Google_SetRedirectAddress")
![Alt text](/screenshots/Google_EnableGooglePlusApi.png?raw=true "Google_EnableGooglePlusApi")
![Alt text](/screenshots/Google_OAuth2Parameters.png?raw=true "Google_OAuth2Parameters")
