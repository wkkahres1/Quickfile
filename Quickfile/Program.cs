using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics; //for Process.start
using System.ComponentModel; //for win32exception

namespace Quickfile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Quickfile! \n \nThis program will allow you to quickly open a complex file path on your computer.");
            Console.WriteLine("");
            Console.WriteLine("The root path you want to open should be included in a file in this exe directory called pathfile.txt");

            //pull path from filename
            string fileName = "pathfile.txt";

            //write to rootPath string
            string rootPath;
            using (var streamReader = new StreamReader(fileName, Encoding.UTF8))
            {
                rootPath = streamReader.ReadToEnd();
                streamReader.Close();
            }

            Console.WriteLine($"\nYour file path to open is: { rootPath }.\n");
            
            //example path for system
            //string rootPath = @"C:\Users\wkkah\AppData\Local\Packages\CanonicalGroupLimited.UbuntuonWindows_79rhkp1fndgsc\LocalState\rootfs\home\walterkahres";

            //Open RootPath in file system
            try
            {
                Process.Start(rootPath);
                Console.WriteLine($"{ rootPath } was opened successfully!.");
            }
            catch (Win32Exception win32Exception)
            {
                //The system cannot find the file specified..
                Console.WriteLine("Please create a file called 'pathfile.txt' that includes your path you want to access quickly.");
                Console.WriteLine(win32Exception.Message);
            }

            /***********Other cool file manipulation stuff****************/

            /*return Directories to console*/
            /*
            string[] dirs = Directory.GetDirectories(rootPath,"*",SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
            */

            /*returning files to the console
            string[] files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories); 
            foreach(string file in files)
            {
                //Console.WriteLine(file); //fullpath 
                //Console.WriteLine(Path.GetFileName(file)); //only filename and extension
                //Console.WriteLine(Path.GetFileNameWithoutExtension(file)); //only filename (no exstension)
                //Console.WriteLine(Path.GetFullPath(file)); //returns full path
                //Console.WriteLine(Path.GetDirectoryName(file)); //returns full file directory
                
                //var info = new FileInfo(file); //lots of info you can grab including Open
                //Console.WriteLine($"{ Path.GetFileName(file) }:  { info.Length } bytes"); //returns full path
             
            }
            */
  
            //Console.ReadLine();
        }
    }
}
