namespace Tarifler.Web.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile fromFile, string filePath = "/img/")
        {
            var fileName = "";

            if (fromFile != null && fromFile.Length > 0)
            {
                fileName = fromFile.FileName.ToLower();//Dosya ismini küçük harflere dönder
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName; //Dizini bul
                using var stream = new FileStream(directory, FileMode.Create); // Yaratma modenda aç stream'i
                await fromFile.CopyToAsync(stream);// Stream çalıştır
            }

            return fileName;
        }

        public static bool FileRemover(string fileName, string filePath = "/img/")
        {
            string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName; //Dizini bul
            if (File.Exists(directory))
            {
                File.Delete(directory);
                return true;
            }

            return false;
        }
    }
}
