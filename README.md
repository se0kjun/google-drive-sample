#google-drive-sample

This project is implemented by [Google Drive API](https://developers.google.com/api-client-library/dotnet/) for C#.

##Installation

	git clone https://github.com/se0kjun/google-drive-sample.git

You have to install Google Drive API for dotnet using nuget package console.

	PM> Install-Package Google.Apis.Drive.v3

And then you have to create or select a project in the Google Developers Console and turn on the API. After turn on the API, you can get credential file. [reference Step1](https://developers.google.com/drive/v3/web/quickstart/dotnet)

After download JSON file
	
1. rename to `google_secret.json`
2. create `credentials` directory under the `google-drive-sample`
3. move `google_secret.json` to `google-drive-sample/credentials`

##Features

- [Create a folder in a particular folder](https://github.com/se0kjun/google-drive-sample/blob/master/google-drive-sample/GoogleDriveHelper.cs#L45)
- [Get a id of particular file using path (unix type)](https://github.com/se0kjun/google-drive-sample/blob/master/google-drive-sample/GoogleDriveHelper.cs#L108)
- [Get a files in a particular folder](https://github.com/se0kjun/google-drive-sample/blob/master/google-drive-sample/GoogleDriveHelper.cs#L160)

##Description

This sample is the File Explorer for Google Drive. 

![](https://raw.githubusercontent.com/se0kjun/google-drive-sample/master/example/example.gif)
   