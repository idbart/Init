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
using Init_Desktop.Scripts.Interfaces;

namespace Init_Desktop.Views
{
    /// <summary>
    /// Interaction logic for NewTemplateControl.xaml
    /// </summary>
    public partial class NewTemplateControl : UserControl
    {
        IDataAccess dataAccess = new FileDataAccess();
        public NewTemplateControl()
        {
            InitializeComponent();

            submitButton.IsDefault = true;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(templateNameInput.Text))
            {
                MessageBox.Show(Properties.Resources.enterATemplateNameMessage);
            }
            else
            {
                dataAccess.createTemplate(templateNameInput.Text.Trim());

                templateNameInput.Text = default(string);
            }
        }
    }
}
