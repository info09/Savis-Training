using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewCMS.Common
{
    public partial class Utils
    {
        private static readonly string[] VietnameseSigns = new string[]
        {
        "aAeEoOuUiIdDyY-",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ",
        " "
        };

        public static string removeVietnameseSign(string str)
        {

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;

        }

        /// <summary>
        /// Convert url title
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ConvertToUrlTitle(string name)
        {
            string strNewName = name;

            #region Replace unicode chars
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = name.Normalize(NormalizationForm.FormD);
            strNewName = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            #endregion

            #region Replace special chars
            string strSpecialString = "~\"“”#%&*:;<>?/\\{|}.+_@$^()[]`,!-'";

            foreach (char c in strSpecialString.ToCharArray())
            {
                strNewName = strNewName.Replace(c, ' ');
            }
            #endregion

            #region Replace space

            // Create the Regex.
            var r = new Regex(@"\s+");
            // Strip multiple spaces.
            strNewName = r.Replace(strNewName, @" ").Replace(" ", "-").Trim('-');

            #endregion)

            return strNewName;
        }

        /// <summary>
        /// Check if a string is a guid or not
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool IsGuid(string inputString)
        {
            try
            {
                var guid = new Guid(inputString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsNumber (string inputString)
        {
            try
            {
                var guid = int.Parse(inputString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GeneratePageUrl(string pageTitle)
        {
            var result = removeVietnameseSign(pageTitle);

            // Replace spaces
            result = result.Replace(" ", "-");

            // Replace double spaces
            result = result.Replace("--", "-");

            // Remove triple spaces
            result = result.Replace("---", "-");

            return result;

        }

        public static string GetPublishTime(DateTime publishOnDate, string siteLanguage,string format)
        {
            try
            {
                if (publishOnDate != null)
                {
                    // Init result default
                    string result = publishOnDate.ToString(format);

                    var dateTimeNow = DateTime.Now;
                    //Check today
                    if (DateTime.Compare(new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day), new DateTime(publishOnDate.Year, publishOnDate.Month, publishOnDate.Day)) == 0)
                    {
                        //Caculator time ago
                        TimeSpan tp = dateTimeNow - publishOnDate;
                        if (tp.Hours > 0)
                        {
                            if (tp.Hours == 1) result = siteLanguage == "vn" ? "1 giờ trước" : "1 hour ago";
                            else result = siteLanguage == "vn" ? tp.Hours.ToString() + " giờ trước" : tp.Hours.ToString() + " hours ago";
                        }
                        else
                        {
                            if (tp.Minutes < 2) result = siteLanguage == "vn" ? "1 phút trước" : "1 minute ago";
                            else result = siteLanguage == "vn" ? tp.Minutes.ToString() + " phút trước" : tp.Minutes.ToString() + " minutes ago";
                        }
                    }
                    return result;
                }
                else return null;                
            }
            catch (Exception ex)
            {
                return null;      
            }
        }
        
    }

    public static class Enums
    { 
        #region Comment Type
        public static class CommentType
        {
            public const string GopYVanBan = "GOP_Y_VAN_BAN";
        }
        #endregion
    }
}
