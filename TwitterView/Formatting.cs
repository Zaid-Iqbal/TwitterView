using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitterView
{
    class Formatting
    {
        
        public static String CatIDtoCategory(int CatID)
        {
            if (CatID == 7)
            {
                return "Audio";
            }
            else if (CatID == 9)
            {
                return "Computers and Tablets";
            }
            else if (CatID == 13)
            {
                return "Displays";
            }
            else if (CatID == 5)
            {
                return "Gaming";
            }
            else if (CatID == 10)
            {
                return "Misc";
            }
            else if (CatID == 6)
            {
                return "PC Parts";
            }
            else if (CatID == 8)
            {
                return "Phones";
            }
            else
            {
                MessageBox.Show("Formatting.CatIDtoCategory() Error: Categroy not found");
                return "";
            }

        }
        public static String getXprice(String str)
        {
            int dollar = str.IndexOf("$");
            str = str.Substring(dollar + 1);
            for (int x = 1; x < str.Length - 1; x++)
            {
                foreach (char c in str.Substring(0, x))
                {
                    if (c != '1' && c != '2' && c != '3' && c != '4' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9' && c != '0')
                    {
                        return str.Substring(0, x - 1);
                    }
                }
            }
            return "not found";
        }

        public static String getPrice(String str)
        {
            int dollar = str.IndexOf("$");
            str = str.Substring(dollar + 1);
            dollar = str.IndexOf("$");
            str = str.Substring(dollar + 1);
            for (int x = 1; x < str.Length - 1; x++)
            {
                foreach (char c in str.Substring(0, x))
                {
                    if (c != '1' && c != '2' && c != '3' && c != '4' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9' && c != '0')
                    {
                        return str.Substring(0, x - 1);
                    }
                }
            }
            return "not found";
        }

        public static String TweetBody(String title, String price, String dif, String tags)
        {
            if(tags == null || tags == "" || tags == " ")
            {
                return title + "\nPrice: $" + price + " ($" + dif + " OFF)\nFind more deals at https://zed.exioite.com";
            }
            return title + "\nPrice: $" + price + " ($" + dif + " OFF)\nFind more deals at https://zed.exioite.com\n" + tags;
        }

        public static List<String> HashTagsToList(String tags)
        {
            return tags.Split(' ').ToList();
        }
        public static List<String> HashTagsFromFile(String category)
        {
            return File.ReadAllText(GetHashFilePath(category)).Split(' ').ToList();
        }

        public static String ListToHashTags(List<String> tags)
        {
            String send = "";
            if(tags.Count == 0 || tags[0] == "")
            {
                return send;
            }
            foreach (String tag in tags)
            {
                if (tag == tags[tags.Count - 1])
                {
                    if(tag.Contains(' '))
                    {
                        tag.Remove(' ');
                    }
                    send += tag;
                }
                else
                {
                    if (tag.Contains(' '))
                    {
                        tag.Remove(' ');
                    }
                    send += tag + " ";
                }
            }
            return send;
        }

        public static String FormatDate(String date)
        {
            String name;
            String month;
            String day;
            String year;
            char[] testChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            //Month
            if (date.Contains("January"))
            {
                month = "01";
            }
            else if (date.Contains("February"))
            {
                month = "02";
            }
            else if (date.Contains("March"))
            {
                month = "03";
            }
            else if (date.Contains("April"))
            {
                month = "04";
            }
            else if (date.Contains("May"))
            {
                month = "05";
            }
            else if (date.Contains("June"))
            {
                month = "06";
            }
            else if (date.Contains("July"))
            {
                month = "07";
            }
            else if (date.Contains("August"))
            {
                month = "08";
            }
            else if (date.Contains("September"))
            {
                month = "09";
            }
            else if (date.Contains("October"))
            {
                month = "10";
            }
            else if (date.Contains("November"))
            {
                month = "11";
            }
            else if (date.Contains("December"))
            {
                month = "12";
            }
            else
            {
                month = "Unknown (Error: Formatting.FormatDate())";
            }

            try
            {
                year = date.Substring(date.IndexOfAny(testChars) + 4, 4);
                day = date.Substring(date.IndexOfAny(testChars), 2);

            }
            catch (System.ArgumentOutOfRangeException)
            {
                year = date.Substring(date.IndexOfAny(testChars) + 3, 4);
                day = date.Substring(date.IndexOfAny(testChars), 1);
            }
            return month + "/" + day + "/" + year;
        }

        public static String GetNextDate(DataGridView DGV)
        {
            DateTime date = new DateTime();
            if (DGV.Rows.Count == 1)
            {
                if (DateTime.Now.Hour < 16)
                {
                    date = DateTime.Today;
                    return date.ToString("D");
                }
                else
                {
                    date = DateTime.Today.AddDays(1);
                    return date.ToString("D");
                }
                
            }
            String lastDate = DGV.Rows[DGV.Rows.Count - 2].Cells[5].Value.ToString();
            date = Convert.ToDateTime(FormatDate(lastDate));
            date = date.AddDays(1);
            return date.ToString("D");
        }

        public static String GetHashFilePath(String category)
        {
            if (category == "Laptops")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Computers and Tablets Tags.txt");
            }
            else if (category == "Desktops")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Computers and Tablets Tags.txt");

            }
            else if (category == "Monitors")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Displays Tags.txt");

            }
            else if (category == "Networking")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Misc Tags.txt");

            }
            else if (category == "Computer Components")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\PC Parts Tags.txt");

            }
            else if (category == "Storage")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\PC Parts Tags.txt");

            }
            else if (category == "TV & Video")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Displays Tags.txt");

            }
            else if (category == "Speakers")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Audio Tags.txt");

            }
            else if (category == "Headphones")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Audio Tags.txt");

            }
            else if (category == "Bluetooth Earbuds")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Audio Tags.txt");

            }
            else if (category == "Phones")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Phones Tags.txt");

            }
            else if (category == "Misc")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Misc Tags.txt");

            }
            else if (category == "Audio")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Audio Tags.txt");

            }
            else if (category == "Computers & Tablets")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Computers and Tablets Tags.txt");

            }
            else if (category == "Computers and Tablets")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Computers and Tablets Tags.txt");

            }
            else if (category == "Displays")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Displays Tags.txt");

            }
            else if (category == "Gaming")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Gaming Tags.txt");

            }
            else if (category == "PC Parts")
            {
                return (@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\PC Parts Tags.txt");

            }
            else
            {
                MessageBox.Show("category not found");
                return "";
            }
        }

        public static String GetHashTags(String category)
        {
            return (File.ReadAllText(GetHashFilePath(category)));
        }
    }
}
