using System.Collections.Generic;

namespace iss0.Plik.Models
{
    public class UploadMetadata : UploadMetadataBase
    {
        public string Id { get; set; }
        public int UploadDate { get; set; }
        public string DownloadDomain { get; set; }

        /// <summary>
        /// Custom message (in Markdown format)
        /// </summary>
        public string Comments { get; set; }

        public string UploadToken { get; set; }
        public Dictionary<string, UploadFile> Files { get; set; }
        public bool Admin { get; set; }
        public bool ProtectedByPassword { get; set; }
        public bool ProtectedByYubikey { get; set; }

        public string DownloadUrl => $"/archive/{Id}/{Id}.zip";
    }
}
