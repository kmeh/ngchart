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

using System.Web;
using NGChart.QR;

namespace NGChart.QR
{
    /// <summary>
    /// QR Codes are a popular type of two-dimensional barcode, which are also known as hardlinks or physical world hyperlinks.
    /// 
    /// http://code.google.com/apis/chart/#qrcodes
    /// </summary>
    public class QRCodes : BaseChart
    {
        #region Constants

        private const EncodingType DefaultEncoding = EncodingType.UTF8;
        private const ErrorCorrectionLevel DefaultErrorCorrectionLevel = ErrorCorrectionLevel.L;
        private const int DefaultMargin = QROptions.MinimalMargin;
        private static readonly ChartType QRCodeType = new ChartType("qr");

        #endregion

        #region Properties

        /// <summary>
        /// The chart data
        /// </summary>
        public ChartParam Data
        {
            get { return _data;  }
        }
        private readonly ChartParam _data;

        /// <summary>
        /// Encoding for the barcode
        /// </summary>
        public EncodingTypeParam Encoding
        {
            get { return _encoding; }
        }
        private readonly EncodingTypeParam _encoding;

        /// <summary>
        /// QR code options
        /// </summary>
        public QROptions Options
        {
            get { return _options;  }
        }
        private readonly QROptions _options;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="QRCodes"/> class.
        /// </summary>
        /// <param name="size">The chart size.</param>
        /// <param name="text">The text to encode.</param>
        public QRCodes(ChartSize size, string text)
            : this(size, text, DefaultEncoding)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QRCodes"/> class.
        /// </summary>
        /// <param name="size">The chart size.</param>
        /// <param name="text">The text to encode.</param>
        /// <param name="encodingType">Type of the encoding.</param>
        public QRCodes(ChartSize size, string text, EncodingType encodingType)
            : base(QRCodeType, size)
        {
            _data = new PlainParam("chl", HttpUtility.UrlPathEncode(text));

            // to reduce url length - do not add default encoding parameter
            if (DefaultEncoding != encodingType)
            {
                _encoding = new EncodingTypeParam(encodingType);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QRCodes"/> class.
        /// </summary>
        /// <param name="size">The chart size.</param>
        /// <param name="text">The text to encode.</param>
        /// <param name="encodingType">Type of the encoding.</param>
        /// <param name="errorCorrection">Error correction level</param>
        /// <param name="margin">Margin</param>
        public QRCodes(ChartSize size, string text, EncodingType encodingType, ErrorCorrectionLevel errorCorrection, int margin) : this(size, text, encodingType)
        {
            if ((errorCorrection != DefaultErrorCorrectionLevel) && (margin != DefaultMargin))
            {
                _options = new QROptions(errorCorrection, margin);
            }
        }

        #endregion
    }
}