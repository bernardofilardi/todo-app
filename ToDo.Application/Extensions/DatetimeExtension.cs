namespace ToDo.Application.Extensions
{
    public static class DatetimeExtension
    {
        public static string ToApplicationTime(this DateTime dt) => dt.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
