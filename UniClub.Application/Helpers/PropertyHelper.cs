namespace UniClub.Application.Helpers
{
    public static class PropertyHelper
    {
        public static string HasProperty(this object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            return property != null ? property.Name : null;
        }
    }
}
