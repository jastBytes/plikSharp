[![Build status](https://ci.appveyor.com/api/projects/status/gn2x6yuhyahookk2?svg=true)](https://ci.appveyor.com/project/iss0/pliksharp)
[![NuGet version](https://badge.fury.io/nu/iss0.Plik.Client.svg)](https://badge.fury.io/nu/iss0.Plik.Client)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](http://opensource.org/licenses/MIT)

# plikSharp
A .NET API client for Plik, the scalable &amp; friendly temporary file upload system, written in C#.
The API client is available at [NuGet](https://www.nuget.org/packages/iss0.Plik.Client) for .NETFramework >=4.5 and .NETStandard >=2.0.

## Acknowledgements

* [Plik](https://github.com/root-gg/plik) - The scalable & friendly temporary file upload system ( wetransfer like ) in golang
* [Refit](https://github.com/paulcbetts/refit) - The automatic type-safe REST library for Xamarin and .NET

## Examples

 ```csharp
// Create client
var plikApi = RestService.For<IPlikApi>("http://localhost");

// Create a new upload, set properties as needed
var upload = await plikApi.CreateUploadAsync(new UploadRequest
{
    OneShot = false,
    Removable = true
});

using (var file = System.IO.File.OpenRead("test.txt"))
{
    // Add a file to the created upload
    var uploadedFile = await plikApi.UploadFileAsync(upload.Id, upload.UploadToken, new StreamPart(file, "test.txt"));    
}
```
```csharp
// Download a file
var downloadResult = await plikApi.GetFileAsync(upload.Id, uploadedFile.Id, uploadedFile.FileName);
var fileBytes = await downloadResult.ReadAsByteArrayAsync();
```
```csharp
// Download all files as zip
var zipDownloadResult = await _plikApi.GetArchiveAsync(upload.Id, "wholething.zip");
```
```csharp
// Delete a file
var uploadMetaData = await plikApi.DeleteFileAsync(upload.Id, fileId, fileName);
```
