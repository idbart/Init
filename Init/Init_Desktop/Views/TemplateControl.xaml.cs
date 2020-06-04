using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Init_Desktop.Scripts;
using Init_Desktop.Scripts.Static_Classes;
using System.Diagnostics;
using Init_Desktop.Scripts.Interfaces;

namespace Init_Desktop.Views
{
    /// <summary>
    /// Interaction logic for TemplateControl.xaml
    /// </summary>
    public partial class TemplateControl : UserControl
    {
        IDataAccess dataAccess = new FileDataAccess();
        private Template template;

        public TemplateControl(Template template)
        {
            InitializeComponent();

            this.template = template;
            initButton.IsDefault = true;
        }

        // handle init new project button
        private async void initButton_Click(object sender, RoutedEventArgs e)
        {
            // get path and name
            string path = FileOperations.getPath();
            if (path == null) return;
            // if the user does not give a name for the new project than use the template name
            string name = String.IsNullOrEmpty(nameInput.Text) ? template.name : nameInput.Text.Trim();

            LocalEventManager.OnLoading();

            await template.SpawnAsync(path, name);

            LocalEventManager.OnDoneLoading();

            // reset the name input field and open a new file explorer at the new project location
            nameInput.Text = default(string);
            Process.Start("explorer.exe", System.IO.Path.Combine(path, name));
        }

        // handle edit template button
        // opens a new file explore window at the location project template
        private void editTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", template.rootPath);
        }

        // handle delete template button
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.deleteTemplate(template.name);
        }
    }
}
