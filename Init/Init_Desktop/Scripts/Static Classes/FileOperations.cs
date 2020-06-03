using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init_Desktop.Scripts.Static_Classes
{
    public static class FileOperations
    {
        public static async Task CopyDirectoryAsync(string sourcePath, string destinationPath, bool subCopy)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);

            if (!Directory.Exists(sourcePath)) throw new DirectoryNotFoundException();

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            FileInfo[] files = sourceDir.GetFiles();
            foreach(FileInfo file in files)
            {
                string destPath = Path.Combine(destinationPath, file.Name);
                using(FileStream sourceStream = File.Open(file.FullName, FileMode.Open), destinationStream = File.Create(destPath))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }
            }

            if(subCopy)
            {
                foreach(DirectoryInfo dir in sourceDir.GetDirectories())
                {
                    await CopyDirectoryAsync(dir.FullName, Path.Combine(destinationPath, dir.Name), true);
                }
            }
        }
        public static string getPath()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "Select a folder to Init project";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            else
            {
                return null;
            }
        }
    }
}
