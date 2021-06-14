using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.ImageHelper
{
    public class ImageHelperMain
    {
        // Dimesnions of the cropped window - must match frontend definitions
        private const int _avatarWidth = 100;  // ToDo - Change the size of the stored avatar image
        private const int _avatarHeight = 100; // ToDo - Change the size of the stored avatar image


        // Width of initially uploaded image (scale is preserved so height is calculated).
        private const int _avatarScreenWidth = 400;  // ToDo - Change the value of the width of the image on the screen

        private const string _tempFolder = "/Temp";
        private const string _mapTempFolder = "~" + _tempFolder;
        private const string _avatarPath = "/Avatars";

        private readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };




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


    }
}