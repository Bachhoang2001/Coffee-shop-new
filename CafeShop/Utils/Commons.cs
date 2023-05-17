using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Utils
{
    public static class Commons
    {
        public static string GetImagesPath()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            string strImagesPath = Path.Combine(strWorkPath, "Images");
            return strImagesPath;
        }
    }
}
