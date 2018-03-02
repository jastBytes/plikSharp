namespace iss0.Plik.Models
{
    public class UploadRequest : UploadMetadataBase
    {
        /// <summary>
        /// Protect upload with login (Auth Basic)
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Protect upload with password (Auth Basic)
        /// </summary>
        public string Password { get; set; }
    }
}
