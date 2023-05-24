using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocHandler
{
    public class UploadDocument
    {
        public static bool Upload(string filePath)
        {

                // Specify the destination path where the file should be copied
                string destinationPath = @"..\..\..\..\Files\Documents";

                try
                {
                    // Use the File.Copy method to copy the file to the destination path
                    File.Copy(filePath, Path.Combine(destinationPath, Path.GetFileName(filePath)));

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred while copying the file: " + ex.Message);
                }

            return false;
            }
        }
    }
