# Windows ストア、電話、およびユニバーサル アプリで Office 365 に接続する
認証は、Office 365 サービスを使用するすべてのアプリで実行する最初の手順です。これらの 3 つのコード サンプルは、Windows ストア アプリ、Windows Phone 8.1 アプリ、およびユニバーサル Windows アプリ内の Office 365 テナントにユーザーを接続する方法を示しています。各ソリューションには、ユーザーを認証するためにアクティブ ディレクトリ認証ライブラリ (ADAL) を呼び出す AuthenticationHelper というクラスが含まれています。

ユニバーサル Windows アプリには、Office 365 テナントで操作する Windows ストアと Windows Phone 8.1 の両方のプラットフォームで使用できる共有コード ファイルが含まれています。電話と Windows アプリの両方のユーザー インターフェイスを実装するコード ファイルは別になっていますが、ユニバーサル Windows アプリの残りのロジックは、ほとんどが共有されています。

インターフェイスは、基本的に両方のプラットフォームで同じです。以下の画像は、アプリで認証された後に表示される内容です。

**Windows Phone 8.1**  | **Windows ストア**
------------- | -------------
![](../Readme-images/O365-Windows-Connect-PhoneUI.png "O365-WinPlatform-Connect の Windows Phone インターフェイスのサンプル")|![](../Readme-images/O365-Windows-Connect-WindowsUI.png "O365-WinPlatform-Connect の Windows Phone インターフェイスのサンプル")

## 前提条件と構成 ##

このサンプルを実行するには次のものが必要です。  
  - Visual Studio 2013 更新プログラム 3。  
  - [Office 365 API ツール バージョン 1.3.41104.1](http://aka.ms/k0534n)。  
  - Office 365 アカウント。Office 365 アプリのビルドを開始するために必要なリソースを含む [Office 365 Developer サブスクリプション](http://aka.ms/ro9c62) にサイン アップできます。
 
###アプリを登録および構成する

構成手順は、3 つのサンプルすべてで同じです (ユニバーサル Windows アプリには、もう 1 つ小さい手順があります)。

**注:**手順 7 でパッケージのインストール中にエラーが表示された場合は (「"Microsoft.IdentityModel.Clients.ActiveDirectory" が見つかりません」など)、ソリューションを配置した場所のローカル パスが長すぎたり深すぎたりしないか確認してください。ソリューションをドライブの root の近くに移動すると、この問題が解決されます。

Visual Studio 用 Office 365 API ツールを使用すると、各アプリを登録できます。[Office 365 API ツール](http://aka.ms/k0534n)は、必ず Visual Studio ギャラリーからダウンロードおよびインストールしてください。

   1. Visual Studio 2013 を使用して、実行する目的のサンプルの .sln ファイル (O365-Universal-Connect.sln、O365-Windows-Connect.sln、または O365-WinPhone-Connect.sln) を開きます。
   2. [ソリューション エクスプローラー] ウィンドウで、各プロジェクト名を右クリックし、[追加] -> [接続サービス] の順に選択します。
   3. サービス マネージャーのダイアログ ボックスが表示されます。**[Office 365]**、**[アプリの登録]** の順に選択します。
   4. サインイン ダイアログ ボックスで、Office 365 テナントにユーザー名とパスワードを入力します。このユーザー名は、<名前>@<テナント名>.onmicrosoft.com. のパターンに従っています。まだ Office 365 テナントがない場合は、MSDN の特典の一部として無料の開発者サイトを取得するか、無料試用版にサイン アップしてください。
   5. サインインすると、すべてのサービスの一覧が表示されます。アプリはまだどのサービスでも使用する登録がされていないため、アクセス許可は選択できません。 
   6. このサンプルで使用するサービスを登録するためには、[**(メール) - ユーザーとしてメールを送信**] のアクセス許可を選択します。ダイアログは、次のようになります。![](../Readme-images/O365-Windows-Connect-ServicesManager.png "O365-WinPlatform-Connect サンプルの Windows Phone インターフェイス")
   7. [サービス マネージャー] ダイアログ ボックスで **[OK]** をクリックしたら、Office 365 API に接続するためのアセンブリがプロジェクトに追加されます。 

###ユニバーサル Windows アプリの登録

ユニバーサル Windows アプリのソリューションには 2 つのプロジェクト、**O365-Universal-Connect.Windows** および **O365-Universal-Connect.WindowsPhone** が含まれています。登録手順を 1 つのプロジェクトに対して実行すると、Office 365 のアセンブリは両方のプロジェクトに追加されます。ただし、もう一方のプロジェクト名を右クリックして [追加] -&gt; [接続サービス] を選択する必要があります。この場合、[サービス マネージャー] ダイアログ ボックスに次のメッセージが表示されます。

![](../Readme-images/O365-Windows-Connect-ServicesManager2.png "O365-WinPlatform-Connect サンプルの Windows Phone インターフェイス")

**[はい]** ボタンをクリックします。この追加の手順では、アプリが Azure Active Directory 設定でリダイレクト URI 値を確実に取得するようにします。この URI 値を認識する必要はありませんが、アプリでユーザーを認証するために必要になります。

## ビルドとデバッグ ##

Visual Studio でソリューションを読み込んだら、F5 キーを押してビルドとデバッグを実行します。ソリューションを実行し、所属組織のアカウントで Office 365 にサインインします。

## 次の手順 ##

- このサンプルの実行について問題がある場合は、[問題をログに記録](https://github.com/OfficeDev/O365-WinPlatform-Connect/issues)してください。
- Windows アプリで Office 365 サービスを使用してさらに多くのことを実行するサンプルに関心をお持ちの場合は、「[Office 365 Starter Project for Windows ストア アプリ](https://github.com/OfficeDev/O365-Windows-Start)」をご覧ください。
- 他に Windows アプリで Office 365 サービスを使用して実行できることの詳細については、最初に dev.office.com にある「[使用を開始する](http://aka.ms/rpx192)」のページをご覧ください。

## その他の技術情報 ##

- [Office 365 API ドキュメント](http://aka.ms/kbwa5c)
- [Office 365 API スタート プロジェクトおよびサンプル コード](http://aka.ms/x1kpnz)
- [Office 開発者向けサンプル コード](http://aka.ms/afh45z)
- [Office デベロッパー センター](http://aka.ms/uftrm1)

