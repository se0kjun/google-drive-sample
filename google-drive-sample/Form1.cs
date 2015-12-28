using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Drive.v2.Data;

namespace google_drive_sample
{
    public partial class Form1 : Form
    {
        public GoogleDriveHelper gdrive_helper;
        public string current_file_path;

        public Form1()
        {
            InitializeComponent();
            init();
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
        }

        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected_item = listView1.SelectedItems[0];

            if (selected_item.SubItems[1].Text == "Directory")
            {
                listView1.Items.Clear();
                current_file_path += ("/" + selected_item.Text);
                string id = gdrive_helper.GetIdByPath(current_file_path);
                render(gdrive_helper.GetChildrenById(id));
            }
            else
                MessageBox.Show(gdrive_helper.GetIdByPath(current_file_path + "/" + selected_item.Text));
        }

        private void init()
        {
            current_file_path = "";
            gdrive_helper = new GoogleDriveHelper();
            List<File> root_file = gdrive_helper.GetRoot();
            render(root_file);
        }

        private void render(List<File> file_list)
        {
            listView1.BeginUpdate();
            foreach (File f in file_list)
            {
                ListViewItem item = new ListViewItem(f.Title, 0);
                if (gdrive_helper.IsDirectory(f))
                    item.SubItems.Add("Directory");
                else
                    item.SubItems.Add("File");
                item.SubItems.Add(f.CreatedDate.Value.ToString());
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int last = current_file_path.LastIndexOf('/');
            if (last >= 0)
            {
                current_file_path = current_file_path.Substring(0, last);
                listView1.Items.Clear();
                string id = gdrive_helper.GetIdByPath(current_file_path);
                render(gdrive_helper.GetChildrenById(id));
            }
        }
    }
}
