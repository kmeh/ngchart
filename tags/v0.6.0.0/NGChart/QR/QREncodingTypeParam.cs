// Copyright (c) 2008, Eugene Rymski
// All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted 
//  provided that the following conditions are met:
// * Redistributions of source code must retain the above copyright notice, this list of conditions 
//   and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
//   and the following disclaimer in the documentation and/or other materials provided with the distribution.
// * Neither the name of the "NGChart" nor the names of its contributors may be used to endorse or 
//   promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE REGENTS AND CONTRIBUTORS BE LIABLE FOR ANY 
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.

using System;

namespace NGChart.QR
{
    /// <summary>
    /// QR encoding types
    /// </summary>
    public enum EncodingType
    {
        /// <summary>
        /// Shift_JIS encoding
        /// </summary>
        Shift_JIS,

        /// <summary>
        /// UTF-8 encoding
        /// </summary>
        UTF8,

        /// <summary>
        /// ISO-8859-1 encoding
        /// </summary>
        ISO_8859_1
    }

    /// <summary>
    /// QR encoding type parameter
    /// </summary>
    public class EncodingTypeParam : ChartParam
    {
        private readonly EncodingType _encoding;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="encoding">QR encoding type</param>
        public EncodingTypeParam(EncodingType encoding)
        {
            _encoding = encoding;
        }

        /// <summary>
        /// Converts encoding type to its string representation
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ConvertEncodingType(EncodingType encoding)
        {
            string result;

            switch(encoding)
            {
                case EncodingType.Shift_JIS:
                    result = "Shift_JIS";
                    break;
                case EncodingType.UTF8:
                    result = "UTF-8";
                    break;
                case EncodingType.ISO_8859_1:
                    result = "ISO-8859-1";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("encoding");
            }

            return result;
        }

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "choe"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get { return ConvertEncodingType(_encoding); }
        }
    }
}