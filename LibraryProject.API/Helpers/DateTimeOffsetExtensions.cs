namespace LibraryProject.API.Helpers;

public static class DateTimeOffsetExtensions
{
    public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
    {
        var currentDate = DateTime.UtcNow;
        var age = currentDate.Year - dateTimeOffset.Year;

        if (currentDate < dateTimeOffset.AddYears(age)) age--;

        return age;
    }
}