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

namespace NGChart.QR
{
    /// <summary>
    /// Error correction level
    /// 
    /// http://code.google.com/apis/chart/#ec_level_table
    /// </summary>
    public enum ErrorCorrectionLevel
    {
        /// <summary>
        /// Allows 7% of a QR code to be restored
        /// </summary>
        L,

        /// <summary>
        /// Allows 15% of a QR code to be restored
        /// </summary>
        M,

        /// <summary>
        /// Allows 25% of a QR code to be restored
        /// </summary>
        Q,

        /// <summary>
        /// Allows 30% of a QR code to be restored
        /// </summary>
        H
    }

    /// <summary>
    /// Options for QR code generation
    /// </summary>
    public class QROptions : ChartParam
    {
        #region Constants

        /// <summary>
        /// The default margin is 4 modules. This means a blank space equivalent to four rows at the top and bottom and 
        /// four columns on the left and right are placed around the QR code. This is the minimum required by QR readers.
        /// </summary>
        public const int MinimalMargin = 4;

        #endregion

        #region Private stuff

        private readonly ErrorCorrectionLevel _errorCorrectionLevel;
        private readonly int _margin;

        #endregion

        #region Overrides

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chld"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get
            {
                return string.Format("{0}|{1}", _errorCorrectionLevel, _margin);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="QROptions"/> class.
        /// </summary>
        /// <param name="ec">Error correction level.</param>
        /// <param name="margin">The margin (or blank space) around the QR code.</param>
        public QROptions(ErrorCorrectionLevel ec, int margin)
        {
            _errorCorrectionLevel = ec;

            // autocorrect margin if necessary
            _margin = margin > MinimalMargin ? margin : MinimalMargin;
        }

        #endregion
    }
}
