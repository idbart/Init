using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Init_Desktop.Scripts.Static_Classes;

namespace Init_Desktop.Scripts
{
    public class Template
    {
        public string name { get; set; }
        public string rootPath { get; private set; }

        public Template(string path)
        {
            this.rootPath = path;

            string[] pathArray = path.Split(@"\".ToCharArray());
            this.name = pathArray[pathArray.Length - 1];
        }
        public async Task<bool> SpawnAsync(string path, string name)
        {
            try
            {
                await FileOperations.CopyDirectoryAsync(rootPath, Path.Combine(path, name), true);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(Properties.Resources.couldNotSpawnErrorMessage);
                return false;
            }
        }
    }
}
