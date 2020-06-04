using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Init_Desktop.Scripts.Interfaces;
using Init_Desktop.Scripts.Static_Classes;
using System.Windows;

namespace Init_Desktop.Scripts
{
    class FileDataAccess : IDataAccess
    {
        public bool createTemplate(string name)
        {
            verifyRoot();

            try
            {
                Directory.CreateDirectory(Path.Combine(ConfigurationManager.AppSettings.Get("TEMPLATES_ROOT"), name));
                LocalEventManager.OnTemplatesChanged();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void deleteTemplate(string name)
        {
            try
            {
                Directory.Delete(Path.Combine(ConfigurationManager.AppSettings.Get("TEMPLATES_ROOT"), name), true);
                LocalEventManager.OnTemplatesChanged();
            }
            catch(DirectoryNotFoundException e)
            {
                MessageBox.Show(Properties.Resources.templateDoesNotExistErrorMessage);
            }
        }

        public List<Template> getTemplates()
        {
            verifyRoot();

            string[] dirs = Directory.GetDirectories(ConfigurationManager.AppSettings.Get("TEMPLATES_ROOT"));
            List<Template> templates = new List<Template>();
            foreach(string path in dirs)
            {
                templates.Add(new Template(path));
            }

            return templates;
        }

        private void verifyRoot()
        {
            if (!Directory.Exists(ConfigurationManager.AppSettings.Get("TEMPLATES_ROOT")))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings.Get("TEMPLATES_ROOT"));
            }
        }
    }
}
