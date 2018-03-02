using iss0.Plik.Models;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace iss0.Plik.Client
{
    public interface IPlikApi
    {
        /// <summary>
        /// Show plik server version, and some build information (build host, date, git revision,...)
        /// </summary>
        /// <returns></returns>
        [Get("/version")]
        Task<dynamic> GetVersionAsync();

        /// <summary>
        /// Show plik server configuration (ttl values, max file size, ...)
        /// </summary>
        /// <returns></returns>
        [Get("/config")]
        Task<dynamic> GetConfigAsync();

        /// <summary>
        /// Get upload metadata (files list, upload date, ttl,...)
        /// </summary>
        /// <param name="uploadId"></param>
        /// <returns></returns>
        [Get("/upload/{uploadId}")]
        Task<UploadMetadata> GetUploadMetadataAsync(string uploadId);

        /// <summary>
        /// Create upload.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Post("/upload")]
        Task<UploadMetadata> CreateUploadAsync([Body] UploadRequest request);

        /// <summary>
        /// Upload file. Upload has to be created first via <see cref="CreateUploadAsync"/>.
        /// </summary>
        /// <param name="uploadId"></param>
        /// <param name="uploadToken"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        [Multipart]
        [Post("/file/{uploadId}")]
        Task<UploadFile> UploadFileAsync(string uploadId, [Header("X-UploadToken")] string uploadToken, [AliasAs("file")] StreamPart fileStream);

        /// <summary>
        /// Returns only HTTP headers. Usefull to know Content-Type and Content-Length without downloading the file. Especially if upload has OneShot option enabled.
        /// </summary>
        /// <param name="uploadId"></param>
        /// <param name="fileId"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Head("/file/{uploadId}/{fileId}/{fileName}")]
        Task<HttpContent> GetFileHeadAsync(string uploadId, string fileId, string fileName);

        /// <summary>
        /// Download file. Filename MUST match. A browser, might try to display the file if it's a jpeg for example. You may try to force download with ?dl=1 in url.
        /// </summary>
        /// <param name="uploadId"></param>
        /// <param name="fileId"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Get("/file/{uploadId}/{fileId}/{fileName}")]
        Task<HttpContent> GetFileAsync(string uploadId, string fileId, string fileName);

        /// <summary>
        /// Download uploaded files in a zip archive. :filename: must end with .zip.
        /// </summary>
        /// <param name="uploadId"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Get("/archive/{uploadId}/{fileName}")]
        Task<HttpContent> GetArchiveAsync(string uploadId, string fileName = "download.zip");

        /// <summary>
        /// Delete file. Upload MUST have "removable" option enabled.
        /// </summary>
        /// <param name="uploadId"></param>
        /// <param name="fileId"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Delete("/file/{uploadId}/{fileId}/{fileName}")]
        Task<UploadMetadata> DeleteFileAsync(string uploadId, string fileId, string fileName);
    }
}
