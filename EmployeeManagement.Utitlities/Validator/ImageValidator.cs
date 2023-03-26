namespace EmployeeManagement.Utitlities.Validator;

public static class ImageValidator
{
    private static string[] validTypes = { "png", "pjp", "jpg", "jpeg", "pjpeg", "jpeg", "jfif" };

    public static bool IsValid(string type) => validTypes.Contains(type);
}
