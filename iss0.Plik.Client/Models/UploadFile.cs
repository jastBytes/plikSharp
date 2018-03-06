namespace iss0.Plik.Models
{
    public class UploadFile
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string FileMd5 { get; set; }
        public string Status { get; set; }
        public string FileType { get; set; }
        public int FileUploadDate { get; set; }
        public int FileSize { get; set; }
        public string Reference { get; set; }
        public string DownloadUrl(string uploadId) => $"/file/{uploadId}/{Id}/{FileName}";
    }
}
