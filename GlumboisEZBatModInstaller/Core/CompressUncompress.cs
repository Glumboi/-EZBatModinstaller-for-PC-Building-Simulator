using System.IO;
using System.IO.Compression;
using System.Threading;

namespace FileDownloader
{
    public class CompressUncompress
    {
        //Zips a folder in a zip file
        public void Zip(string sourceFolder, string destinationFile)
        {
            ZipFile.CreateFromDirectory(sourceFolder, destinationFile);
        }

        //Unzips a zip file in a folder
        public void Unzip(string sourceFile, string destinationFolder)
        {
            Thread t1 = new Thread(() =>
            {
                DeleteFilesAndDirs(destinationFolder);
            });
            
            Thread t2 = new Thread(() =>
            {
                ZipFile.ExtractToDirectory(sourceFile, destinationFolder);
            });
            
            t1.Start();

            while (t1.IsAlive)
            {
                //Wait for the thread to finish
            }
            
            t2.Start();
        }

        private void DeleteFilesAndDirs(string destinationFolder)
        {
            //Deletes all files in a dir
            DirectoryInfo di = new DirectoryInfo(destinationFolder);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            //Deletes all dirs in a dir
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}