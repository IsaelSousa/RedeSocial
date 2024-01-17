using System;

namespace rede_social_domain.Utils
{
    public static class Utils
    {

        public static DateTimeOffset DateTimeOffset()
        {
            DateTime now = DateTime.Now;

            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            TimeSpan serverOffset = localTimeZone.GetUtcOffset(DateTime.UtcNow);

            DateTimeOffset dateTimeOffset = new DateTimeOffset(now, serverOffset);
            return dateTimeOffset;
        }

    }
}
