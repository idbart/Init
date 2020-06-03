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
using Init_Desktop.Models;
using Init_Desktop.Scripts;
using Init_Desktop.Views;
using Init_Desktop.Scripts.Static_Classes;

namespace Init_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainModel model = new MainModel(new FileDataAccess());

        public MainWindow()
        {
            InitializeComponent();

            refreshTemplatesList();
            LocalEventManager.TemplatesChanged += refreshTemplatesList;
        }

        // retrieve templates and display them on the list view 
        private void refreshTemplatesList()
        {
            this.templatesListView.ItemsSource = model.getTemplatesList();
        }

        // handle new template button
        private void newTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            templatesListView.SelectedItem = null;
            centerControl.Content = new NewTemplateControl();
        }

        // for when a user selects a new template on the list view
        private void templatesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // if a new template was selected than set the center screen to the controls for that template, else make it blank 
            if(e.AddedItems.Count != 0)
            {
                Template selectedTemplate = (Template)e.AddedItems[0];
                centerControl.Content = new TemplateControl(selectedTemplate);
            }
            else
            {
                centerControl.Content = new Control();
            }
        }


        // handle buttons on header
        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
