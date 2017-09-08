using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ProductionPlanDisplay.Entity;
using ViperWin.Entity;

namespace ProductionPlanDisplay.Common
{
    public static class LocalCommon
    {
        
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes,out ulong lpTotalNumberOfFreeBytes);


        //public static Bitmap BellAlert;
        //public static Bitmap BellCaution;
        //public static Bitmap BellNormal;
        private static readonly string _className = "LocalCommon";
        public static Color MmcbackColorRed = Color.FromArgb(178, 31, 21);
        public static Color MmcForeColor  = Color.FromArgb(255, 255, 255);
        public static Color MmcbackColorBlue = Color.FromArgb(51, 102, 204);

        public static readonly Color MmcPanelForeColor = Color.LawnGreen;
        public static readonly Color MmcPanelBackColor = Color.Black;

        public static String MessageCaption = "Viper Imaging Notification";
        public static float FontPinSize = EntityCollection.AppSettings.FontSize;

        public static bool StringCompare(string stringA, string stringB)
        {
            return (String.Compare(stringA, stringB, true,
                 CultureInfo.CurrentCulture) == 0);
        }

        public static IEnumerable<DateTime> Range(this DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }


        internal static bool ObjectHasMethod(object anyObject, string methodName)
        {
            return TypeHasMethod(anyObject.GetType(), methodName);
        }

        internal static bool TypeHasMethod(Type objType, string methodName)
        {
            MethodInfo mi = objType.GetMethod(methodName);
            return mi != null;
        }

        internal static bool ObjectHasProperty(object anyObject, string propName)
        {
            return TypeHasProperty(anyObject.GetType(), propName);
        }

        internal static bool TypeHasProperty(Type objType, string propName)
        {
            var pi = objType.GetProperty(propName, BindingFlags.Public);
            return pi != null;
        }



        public static List<UserCredInfo> InitializeSystemUsers()
        {
            var validFunction = new List<EntityCollection.UserFunction> { EntityCollection.UserFunction.ViewOnly };

            var user = new UserCredInfo() { AuthorizedFunctions = validFunction, Description = "Operator", Password = "viper", UserId = Guid.NewGuid(), UserName = "User" };
            EntityCollection.AppSettings.AppUsers.Add(user);
            validFunction = new List<EntityCollection.UserFunction> { EntityCollection.UserFunction.CanEditCamera, EntityCollection.UserFunction.CanEditMap, EntityCollection.UserFunction.CanEditModule, EntityCollection.UserFunction.CanEditUsers };

            var admin = new UserCredInfo() { AuthorizedFunctions = validFunction, Description = "Administrator", Password = "Lock", UserId = Guid.NewGuid(), UserName = "Admin" };
            EntityCollection.AppSettings.AppUsers.Add(admin);
            
            return EntityCollection.AppSettings.AppUsers;
        }


        public static bool GetDiskUtilization(string networkLocation, out ulong freeBytesAvailable, out ulong totalNumberOfBytes,  out ulong totalNumberOfFreeBytes)
        {
            bool rtn = true;

            freeBytesAvailable = 0; totalNumberOfBytes = 0; totalNumberOfFreeBytes = 0;


            try
            {
               

                rtn   = GetDiskFreeSpaceEx(networkLocation,
                                                  out freeBytesAvailable,
                                                  out totalNumberOfBytes,
                                                  out totalNumberOfFreeBytes);
               

                Console.WriteLine(@"@@@@@@@@@@@@@@@@@@@@@@@@@@{0}", freeBytesAvailable);
                Console.WriteLine(@"@@@@@@@@@@@@@@@@@@@@@@@@@@{0}", totalNumberOfBytes);
                Console.WriteLine(@"@@@@@@@@@@@@@@@@@@@@@@@@@@{0}", totalNumberOfFreeBytes);
            }
            catch (Exception)
            {
                
                
            }








            return rtn;



        }

        public static ulong GetDirectorySize(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            ulong totalSize = 0;
            if (dirInfo.Exists)
            {
                foreach (var fileInfo in dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories))
                {
                    totalSize += (ulong) fileInfo.Length;
                }
            }
            return totalSize;
        }

      

    }

    public static class BoundsUtilities
    {
        public static Rectangle AddBounds(Rectangle sourceBounds, Rectangle newBounds)
        {
            if (newBounds.Right > sourceBounds.Right)
                sourceBounds.Width += (newBounds.Right - sourceBounds.Width);

            if (newBounds.Bottom > sourceBounds.Bottom)
                sourceBounds.Height += (newBounds.Bottom - sourceBounds.Height);

            if (newBounds.Left < sourceBounds.Left)
            {
                sourceBounds.X = newBounds.X;
            }

            if (newBounds.Top < sourceBounds.Top)
            {
                sourceBounds.Y = newBounds.Y;
            }

            return sourceBounds;
        }




        /// <summary>
        /// Creates a new Rectangle by translating an existing Rectangle based on a given Point
        /// </summary>
        /// <param name="r">The original rectangle</param>
        /// <param name="p">The reference point (representing 0,0)</param>
        /// <returns>The translated rectangle</returns>
        public static Rectangle ZeroRectangle(Rectangle r, Point p)
        {
            return new Rectangle(
                r.X + p.X, r.Y + p.Y,
                r.Width + p.X, r.Height + p.Y);
        }

        /// <summary>
        /// Give a Bitmap and bounds, calculates new bounds to maintain the
        /// Bitmap's aspect ratio.
        /// </summary>
        /// <param name="img">The Bitmap to fit</param>
        /// <param name="bounds">The bounding box in which it should fit.  This is modified with the calculated bounds</param>
        /// <returns>The multiplier (aspect ratio) used to fit the image into the given bounds</returns>
        public static double MaintainAspectRatio(Bitmap img, ref Rectangle bounds)
        {
            int x = 0, y = 0;
            float newRatio;

            var widthRatio = ((float)bounds.Width) / ((float)img.Width);
            var heightRatio = ((float)bounds.Height) / ((float)img.Height);

            if ((heightRatio < widthRatio))
            {
                newRatio = heightRatio;
                x = (short)((bounds.Width - (img.Width * newRatio)) / 2f);
            }
            else
            {
                newRatio = widthRatio;
                y = (short)((bounds.Height - (img.Height * newRatio)) / 2f);
            }

            int newWidth = (int)(img.Width * newRatio);
            int newHeight = (int)(img.Height * newRatio);

            bounds.X += x;
            bounds.Y += y;
            bounds.Width = newWidth;
            bounds.Height = newHeight;

            return newRatio;
        }
    }
}
