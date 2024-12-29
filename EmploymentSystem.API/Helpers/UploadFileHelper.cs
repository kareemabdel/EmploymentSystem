namespace EmploymentSystem.Api.Helpers
{
    public static class UploadFileHelper
    {
       
        public async static Task<List<string>> UploadFiles(List<IFormFile>? UploadedFiles, IConfiguration _config, IWebHostEnvironment _rootpath)
        {
            try
            {
                if (UploadedFiles != null)
                {
                    var tripphotos = new List<string>();
                    var configpath = _config["AttachmentPathConfig:AttachmentPath"] + @"/";
                    string SavePath = _rootpath.WebRootPath + configpath;
                    foreach (var file in UploadedFiles)
                    {
                        if (file.Length > 0)
                        {
                            var uniquefilename = ("Attachment_" + DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString()).Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");

                            FileInfo fileInfo = new FileInfo(file.FileName);
                            string fileName = uniquefilename + fileInfo.Extension;
                            var filePath = Path.Combine(SavePath, fileName);
                            if (!Directory.Exists(SavePath))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(SavePath);
                            }
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(stream);
                            }
                            tripphotos.Add(Path.Combine(configpath, fileName));
                        }
                    }
                    return tripphotos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
   
}
