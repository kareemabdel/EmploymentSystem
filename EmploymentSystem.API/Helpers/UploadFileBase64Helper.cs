using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System;
using EmploymentSystem.Application.DTOs;

namespace EmploymentSystem.Api.Helpers
{
    public static class UploadFileBase64Helper
    {
        public static bool UploadFileToPathHelper(string uploadedBase64,string path)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(uploadedBase64);
                File.WriteAllBytesAsync(path, bytes);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
