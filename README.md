# O365-WinPlatform-Connect
These three code samples show how to connect to an Office 365 tenant send an e-mail inside a Windows Store app, a Windows Phone 8.1 app, and a [universal Windows app](http://blogs.windows.com/buildingapps/2014/04/02/extending-platform-commonality-through-universal-windows-apps/). The universal Windows app contains shared code files that you can use on both the Windows Store and Windows Phone 8.1 platforms to interact with an Office 365 tenant. The code files that implement the user interfaces for both the Phone and the Windows apps are separate, but the rest of the logic in the universal Windows app is mostly shared.

The interface is essentially the same on both platforms. The images below show what you'll see after you've authenticated in the apps.

**Windows Phone 8.1**  | **Windows Store**
------------- | -------------
![](/Readme-images/O365-Windows-Connect-PhoneUI.png "Windows Phone interface for the O365-WinPlatform-Connect sample")  | ![](/Readme-images/O365-Windows-Connect-WindowsUI.png "Windows Phone interface for the O365-WinPlatform-Connect sample")

## Prerequisites and Configuration ##

This sample requires the following:  
  - Visual Studio 2013 with Update 3.  
  - [Office 365 API Tools version 1.3.41104.1](https://visualstudiogallery.msdn.microsoft.com/a15b85e6-69a7-4fdf-adda-a38066bb5155).  
  - An Office 365 account. You can sign up for [an Office 365 Developer subscription](https://portal.microsoftonline.com/Signup/MainSignUp.aspx?OfferId=6881A1CB-F4EB-4db3-9F18-388898DAF510&DL=DEVELOPERPACK) that includes the resources that you need to start building Office 365 apps.
 
###Register and configure the apps

The configuration steps are the same for all three samples (with one small extra step for the universal Windows app).

You can register each app with the Office 365 API Tools for Visual Studio. Be sure to download and install the [Office 365 API tools](https://visualstudiogallery.msdn.microsoft.com/a15b85e6-69a7-4fdf-adda-a38066bb5155) from the Visual Studio Gallery.

   1. Open the .sln file for each sample (O365-Universal-Connect.sln, O365-Windows-Connect.sln, and O365-WinPhone-Connect.sln) using Visual Studio 2013.
   2. In the Solution Explorer window, left-click each project name and select Add -> Connected Service.
   3. A Services Manager dialog box will appear. Choose **Office 365** and then **Register your app**.
   4. On the sign-in dialog box, enter the user name and password for your Office 365 tenant. We recommend that you use your Office 365 Developer Site. This user name will often follow the pattern <your-name>@<tenant-name>.onmicrosoft.com. If you do not have a developer site, you can get a free Developer Site as part of your MSDN Benefits or sign up for a free trial.
   5. After you're signed in, you will see a list of all the services. No permissions will be selected, since the app is not registered to use any services yet. 
   6. To register for the services used in this sample, choose the **(Mail) - Send mail as a user** permission. The dialog will look like this:
![](/Readme-images/O365-Windows-Connect-ServicesManager.png "Windows Phone interface for the O365-WinPlatform-Connect sample")
   7. After you click **OK** in the Services Manager dialog box, assemblies for connecting to Office 365 APIs will be added to your project. 

###Universal Windows app registration

The universal Windows app solution contains two projects: **O365-Universal-Connect.Windows** and **O365-Universal-Connect.WindowsPhone**. You can perform the registration steps for one project, and the Office 365 assemblies will be added to both projects. However, you'll still need to left-click the other project name and select Add -> Connected Service. When you do this, you'll see this prompt in the Services Manager dialog box:

![](/Readme-images/O365-Windows-Connect-ServicesManager2.png "Windows Phone interface for the O365-WinPlatform-Connect sample")

Click the **Yes** button. This extra step will make sure that your app gets a redirect URI value in its Azure Active Directory settings. You don't need to know the value of this URI, but it's required for authenticating users in your app.


**Note:** If you see any errors while installing packages during step 7, for example, *Unable to find "Microsoft.IdentityModel.Clients.ActiveDirectory"*, make sure the local path where you placed the solution is not too long/deep. Moving the solution closer to the root of your drive resolves this issue. We'll also work on shortening the folder names in a future update.      

## Build ##

After you've loaded the solution in Visual Studio, press F5 to build and debug.
Run the solution and sign in with your organizational account to Office 365.