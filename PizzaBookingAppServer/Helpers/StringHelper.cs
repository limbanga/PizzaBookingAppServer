using System.Text.RegularExpressions;

namespace PizzaBookingAppServer.Helpers
{
    public static class StringHelper
    {
        public static string ConvertToUrlSlug(string value)
        {
            // Chuyển đổi sang chữ thường.
            value = value.ToLowerInvariant();

            // Thay thês các ký tự không hợp lệ.
            value = RemoveSigns(value);

            // Thay thế các khoảng trắng bằng dấu gạch ngang.
            value = Regex.Replace(value, @"\s+", "-").Trim();

            // Xóa các ký tự gạch ngang liên tiếp.
            value = Regex.Replace(value, @"-+", "-");

            return value;
        }

        private static string RemoveSigns(string text)
        {
            string[] signs = new string[]
            {
            "aAeEoOuUiIdDyY",
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
            "ÝỲỴỶỸ"
            };

            for (int i = 1; i < signs.Length; i++)
            {
                for (int j = 0; j < signs[i].Length; j++)
                    text = text.Replace(signs[i][j], signs[0][i - 1]);
            }

            return text;
        }
    }
}
