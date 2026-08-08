using System;
using System.IO;
using System.Drawing;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;


namespace DVLD_Shared.Global_Classes
{
    public static class clsImageHelper
    {
        public static clsOperationResult CopyImage(string SelectedImagePath, string destinationPath)
        {
            try
            {
                File.Copy(SelectedImagePath, destinationPath);
            }
            catch
            {
                return new clsOperationResult
                {
                    Status = clsOperationResult.enOperationStatus.Exception,
                    Message = clsImageValidationMessage.FailedToSaveSelectedImageMessage
                };
            }

            return new clsOperationResult { Status = clsOperationResult.enOperationStatus.Success };
        }

        public static clsOperationResult DeleteImage(string oldImagePath)
        {
            try
            {
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                    return new clsOperationResult { Status = clsOperationResult.enOperationStatus.Success };
                }
                else
                    return new clsOperationResult { Status = clsOperationResult.enOperationStatus.Failed, 
                        Message = clsImageValidationMessage.FailedToDeleteOldImageMessage };
            }
            catch
            {
                return new clsOperationResult { Status = clsOperationResult.enOperationStatus.Exception, 
                    Message = clsImageValidationMessage.FailedToDeleteOldImageMessage};
            }
        }

        public static Image LoadImageSafe(string imagePath)
        {
            if (!File.Exists(imagePath))
                return null;

            using (var tempImage = Image.FromFile(imagePath))
            {
                return new Bitmap(tempImage);
            }
        }

        public static string GetOrCreatePersonsImagesFolderPath()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "PersonsImages");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return folderPath;
        }

        public static string GetOrCreateDefaultPersonImageFolderPath()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "GenderImages");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return folderPath;
        }

        public static string GetOrCreateResourcesImageFolderPath()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Resources");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return folderPath;
        }
    }
}
