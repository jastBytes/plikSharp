using System;

namespace iss0.Plik.Models
{
    public class UploadMetadataBase
    {
        /// <summary>
        /// Files are destructed after the first download
        /// </summary>
        public bool OneShot { get; set; }

        /// <summary>
        /// Files are streamed from the uploader to the downloader (nothing stored server side)
        /// </summary>
        public bool Stream { get; set; }

        /// <summary>
        /// Give the ability to the uploader to remove files at any time
        /// </summary>
        public bool Removable { get; set; } = true;

        /// <summary>
        /// Expiration date in seconds
        /// </summary>
        public int Ttl { get; set; } = (int)TimeSpan.FromDays(7).TotalSeconds;
    }
}
