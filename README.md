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

   