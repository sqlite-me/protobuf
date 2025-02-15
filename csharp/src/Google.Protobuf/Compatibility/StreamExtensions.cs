﻿#region Copyright notice and license
// Protocol Buffers - Google's data interchange format
// Copyright 2015 Google Inc.  All rights reserved.
// https://developers.google.com/protocol-buffers/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

#if NET35 || NET40
using System;
using System.IO;

namespace Google.Protobuf.Compatibility
{
    /// <summary>
    /// Extension methods for <see cref="Stream"/> in order to provide
    /// backwards compatibility with .NET 3.5
    /// </summary>
    public static class StreamExtensions
    {
        // 81920 seems to be the default buffer size used in .NET 4.5.1
        private const int BUFFER_SIZE = 81920;

        /// <summary>
        /// Write the contents of the current stream to the destination stream
        /// </summary>
        public static void CopyTo(this Stream source, Stream destination)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            byte[] buffer = new byte[BUFFER_SIZE];
            int numBytesRead;
            while ((numBytesRead = source.Read(buffer, 0, buffer.Length)) > 0) {
                destination.Write(buffer, 0, numBytesRead);
            }
        }
    }
}
#endif
