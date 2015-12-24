using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.Threading.Tasks;

namespace google_drive_sample
{
    public partial class Form1 : Form
    {
        private const string CredentialPath = "../credentials";
        private string[] Scopes = { 
                                      DriveService.Scope.Drive, 
                                      DriveService.Scope.DriveFile, 
                                      DriveService.Scope.DriveMetadata 
                                  };

        private UserCredential _userCredential;
        private DriveService _driveService;

        public Form1()
        {
            InitializeComponent();
            GetAuth();
            //GetFile();
            GetChildren();
        }

        public void GetAuth()
        {
            using (var stream = new FileStream("../../google_secret.json", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(CredentialPath, true));
                _userCredential = credentials.Result;
                if (credentials.IsCanceled || credentials.IsFaulted)
                    throw new Exception("cannot connect");

                _driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = _userCredential,
                    ApplicationName = ApplicationName,
                });
            }
        }

        public void GetFile()
        {
            FilesResource.ListRequest req = _driveService.Files.List();

            do {
                req.Q = "title='Untitled'";
                FileList qq = req.Execute();
                foreach (Google.Apis.Drive.v2.Data.File a in qq.Items)
                {
                    MessageBox.Show(a.Id);
                }
            }while(!String.IsNullOrEmpty(req.PageToken));
            ChildrenResource.ListRequest rr = _driveService.Children.List("");
            FilesResource.InsertRequest ins = _driveService.Files.Insert(
                new Google.Apis.Drive.v2.Data.File()
                

                );
            
            ins.Execute();
            FileList list = req.Execute();
            ChildList ss = rr.Execute();
            IList<Google.Apis.Drive.v2.Data.File> data = list.Items;
            
        }

        public void GetChildren()
        {
            FilesResource.ListRequest req2 = _driveService.Files.List();
            req2.Q = "title='source'";
            FileList rr = req2.Execute();
            ChildrenResource.ListRequest req = _driveService.Children.List(rr.Items[0].Id);
            ChildList ch = req.Execute();
            foreach (ChildReference a in ch.Items)
            {
                FilesResource.GetRequest getitem = _driveService.Files.Get(a.Id);
                Google.Apis.Drive.v2.Data.File asa = getitem.Execute();
                MessageBox.Show(asa.Title);
            }
        }
    }
}
