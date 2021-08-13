namespace LiModular.Lib.Utils.Core.Helper
{
    using NPinyin;
    using System;
    using System.Text;
    public class PingYinHelper
    {
        private static Encoding gb2312 = Encoding.GetEncoding("GB2312");

        /// <summary>
        /// 汉字转全拼
        /// </summary>
        /// <param name="strChinese"></param>
        /// <returns></returns>
        public static string ConvertToAllSpell(string strChinese)
        {
            try
            {
                if (strChinese.Length != 0)
                {
                    return Pinyin.GetPinyin(strChinese).Replace(" ", "");
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine("全拼转化出错！" + e.Message);
            }

            return string.Empty;
        }

        /// <summary>
        /// 汉字转首字母
        /// </summary>
        /// <param name="strChinese"></param>
        /// <returns></returns>
        public static string GetFirstSpell(string strChinese)
        {
            //NPinyin.Pinyin.GetInitials(strChinese)  有Bug  洺无法识别
            //return NPinyin.Pinyin.GetInitials(strChinese);
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                if (strChinese.Length != 0)
                {
                    string s = Pinyin.ConvertEncoding(strChinese, Encoding.UTF8, gb2312);
                    return Pinyin.GetInitials(s, gb2312);
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine("首字母转化出错！" + e.Message);
            }

            return string.Empty;
        }


    }
}
