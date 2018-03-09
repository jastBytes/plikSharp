// MIT License
// 
// Copyright (c) 2018 Jan Steffen
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;

namespace iss0.Plik.Client.Models
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
