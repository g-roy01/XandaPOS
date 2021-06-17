using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace XandaPOS.ClientLibrary.ImageHelper
{
    public class ImageHelperMain
    {
        #region DECLARATIONS
        // Dimesnions of the cropped window - must match frontend definitions
        private const int _avatarWidth = 100;  // ToDo - Change the size of the stored avatar image
        private const int _avatarHeight = 100; // ToDo - Change the size of the stored avatar image


        // Width of initially uploaded image (scale is preserved so height is calculated).
        private const int _avatarScreenWidth = 250;  // ToDo - Change the value of the width of the image on the screen

        private const string _tempFolder = "/Temp"; //Location Where Image Will Be Temporaryily Stored Before Uploading
        private const string _mapTempFolder = "~" + _tempFolder;
        private const string _avatarPath = "/Avatars";  //Final Location Where Image Will Be Stored

        private readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };
        //private HttpContext _httpContext = new HttpContext();

        public int AvatarWidth
        {
            get { return _avatarWidth; }
            set { }
        }
        public int AvatarHeight
        {
            get { return _avatarHeight; }
            set { }
        }
        public int AvatarScreenWidth
        {
            get { return _avatarScreenWidth; }
            set { }
        }
        public string TempFolder
        {
            get { return _tempFolder; }
            set { }
        }
        public string MapTempFolder
        {
            get { return _mapTempFolder; }
            set { }
        }
        public string AvatarPath
        {
            get { return _avatarPath; }
            set { }
        }
        public string[] ImageFileExtensions
        {
            get { return _imageFileExtensions; }
            set { }
        }
        #endregion

        #region METHODS

        public string SaveImageInServer(string t, string l, string h, string w, string fileName, string sourceTempPath, string destinationPath)
        {
            //t - Image Margin Top
            //l - Image Margin Left
            //h - Image Height
            //w - Image Width

            var newFileName = "";
            try
            {
                ImageHelperMain _imageHelper = new ImageHelperMain();
                // Get file from temporary folder, ...
                var fn = Path.Combine(sourceTempPath, Path.GetFileName(fileName));

                // ... get the image, ...
                var img = new WebImage(fn);

                // ... calculate its new dimensions, ...
                var height = Convert.ToInt32(h.Replace("-", "").Replace("px", ""));
                var width = Convert.ToInt32(w.Replace("-", "").Replace("px", ""));

                // ... scale it, ...
                img.Resize(width, height);

                // ... crop the part the user selected, ...
                var top = Convert.ToInt32(t.Replace("-", "").Replace("px", ""));
                var left = Convert.ToInt32(l.Replace("-", "").Replace("px", ""));
                var bottom = img.Height - top - _imageHelper.AvatarHeight;
                var right = img.Width - left - _imageHelper.AvatarWidth;

                // ... check for validity of calculations, ...
                if (bottom < 0 || right < 0)
                {
                    //THIS CONDITION OCCURS IF THE THE INITIAL IMAGE UPLOADED HAS A DIFF DIMENSION THAN CURRENT IMAGE
                    if (bottom < 0)
                        bottom = 0;
                    if (right < 0)
                        right = 0;

                    // If you reach this point, your avatar sizes in here and in the CSS file are different.
                    // Check _avatarHeight and _avatarWidth in this file
                    // and height and width for #preview-pane .preview-container in site.avatar.css

                    //Commented for testing
                    //throw new ArgumentException("Definitions of dimensions of the cropping window do not match. Talk to the developer who customized the sample code :)");
                }

                img.Crop(top, left, bottom, right);

                // ... delete the temporary file,...
                //Commented for Client Presentation - Will delete the temporary file
                //System.IO.File.Delete(fn);

                // ... and save the new one.
                newFileName = Path.Combine(_imageHelper.AvatarPath, Path.GetFileName(fn));
                var newFileLocation = Path.Combine(destinationPath, Path.GetFileName(fn));

                if (Directory.Exists(Path.GetDirectoryName(newFileLocation)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileLocation));
                }


                string var1 = DateTime.Now.ToString("MMddyyyyHHmmss");
                int var2 = (int)Math.Truncate((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
                var randomFileName = string.Concat(var1, var2.ToString());


                string filePartName = _imageHelper.GetImageNameFromFilePath(fileName, newFileLocation);
                newFileLocation = newFileLocation.Replace(filePartName, randomFileName);

                img.Save(newFileLocation);

                newFileName = newFileName.Replace(filePartName, randomFileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newFileName;
        }

        public bool IsImage(HttpPostedFileBase file)
        {
            ImageHelperMain _imageHelper = new ImageHelperMain();
            if (file == null) return false;
            return file.ContentType.Contains("image") ||
                _imageHelper.ImageFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        public string GetCleanCoordinateValue(string coordinate)
        {
            try
            {
                //if the sting is in decimal format
                if (coordinate.Contains("."))
                {
                    bool isPx = false;
                    //remove pixel mark
                    if (coordinate.EndsWith("px"))
                    {
                        coordinate = coordinate.Replace("px", "");
                        isPx = true;
                    }

                    bool isMinus = false;
                    //if the value is in -ve
                    if (coordinate.StartsWith("-"))
                    {
                        coordinate = coordinate.Replace("-", "");
                        isMinus = true;
                    }

                    coordinate = Math.Floor(Decimal.Parse(coordinate)).ToString();

                    if (isMinus)
                        coordinate = string.Concat("-", coordinate);

                    if (isPx)
                        coordinate = string.Concat(coordinate, "px");

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return coordinate;
        }

        public string GetImageNameFromFilePath(string fileName, string httpContextServerPath)
        {
            //Define destination
            var serverPath = httpContextServerPath;
            fileName = fileName.Replace(TempFolder + @"/", "");
            string newFileName = "";
            if (fileName.EndsWith(".jpg")) //if .jpg Image
            {   //This step is imp to make sure the .jpg substring is always at the end
                newFileName = string.Concat(fileName, " ");
                newFileName = newFileName.Replace(".jpg ", "");
            }
            if (fileName.EndsWith(".png")) //if .png Image
            {   //This step is imp to make sure the .png substring is always at the end
                newFileName = string.Concat(fileName, " ");
                newFileName = newFileName.Replace(".png ", "");
            }
            if (fileName.EndsWith(".gif")) //if .gif Image
            {   //This step is imp to make sure the .gif substring is always at the end
                newFileName = string.Concat(fileName, " ");
                newFileName = newFileName.Replace(".gif ", "");
            }
            if (fileName.EndsWith(".jpeg")) //if .jpeg Image
            {   //This step is imp to make sure the .jpeg substring is always at the end
                newFileName = string.Concat(fileName, " ");
                newFileName = newFileName.Replace(".jpeg ", "");
            }

            return newFileName;
        }

        public string GetTempSavedFilePath(HttpPostedFileBase file, string httpContextServerPath)
        {
            //httpContextServerPath - This is the temporary Image location and it must be sent from the calling method
            // Define destination
            var serverPath = httpContextServerPath;
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }

            // Generate unique file name
            var fileName = Path.GetFileName(file.FileName);
            fileName = SaveTemporaryAvatarFileImage(file, serverPath, fileName);

            // Clean up old files after every save
            CleanUpTempFolder(1, serverPath);
            return Path.Combine(TempFolder, fileName);
        }

        public static string SaveTemporaryAvatarFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            ImageHelperMain _imageHelper = new ImageHelperMain();
            var img = new WebImage(file.InputStream);
            var ratio = img.Height / (double)img.Width;
            img.Resize(_avatarScreenWidth, (int)(_avatarScreenWidth * ratio));

            var fullFileName = Path.Combine(serverPath, fileName);
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);
            return Path.GetFileName(img.FileName);
        }

        public void CleanUpTempFolder(int hoursOld, string httpContextServerPath)
        {
            try
            {
                var currentUtcNow = DateTime.UtcNow;
                var serverPath = httpContextServerPath;
                if (!Directory.Exists(serverPath)) return;
                var fileEntries = Directory.GetFiles(serverPath);
                foreach (var fileEntry in fileEntries)
                {
                    var fileCreationTime = System.IO.File.GetCreationTimeUtc(fileEntry);
                    var res = currentUtcNow - fileCreationTime;
                    if (res.TotalHours > hoursOld)
                    {
                        System.IO.File.Delete(fileEntry);
                    }
                }
            }
            catch
            {
                // Deliberately empty.
            }
        }

        //public string HttpContext.Server.MapPath(TempFolder)()
        //{
        //    try
        //    {
        //        return HttpContext.Server.MapPath(TempFolder);
        //    }
        //    catch(Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}
        #endregion
    }
}