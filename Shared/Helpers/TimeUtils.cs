namespace Shared.Helpers
{
    public static class TimeUtils
    {
        private static readonly TimeZoneInfo VietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        public static DateTime GetVietnamNow()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, VietnamTimeZone);
        }

        public static DateTime ConvertUtcToVietnam(DateTime utcTime)
        {
            if (utcTime.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Input must be UTC time", nameof(utcTime));
            }

            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, VietnamTimeZone);
        }
    }
}
