namespace EmploymentSystem.Api.Helpers
{
    public static class MimeTypesHelper
    {
        public static string GetExtension(string contentType)
        {
            return MimeTypes.MimeTypeMap.GetExtension(contentType);
        }
    }
}
