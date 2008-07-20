// Copyright (c) 2007, Eugene Rymski
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

using System.Globalization;

namespace NGChart.Encoders
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// http://code.google.com/apis/chart/#extended
    /// </remarks>
    public class ExtendedEncoder : BaseEncoder<int>
    {
        private static readonly char[] c_encodingValues = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.".ToCharArray();

        /// <summary>
        /// Prefix for data set
        /// </summary>
        protected internal override string Prefix
        {
            get { return "e"; }
        }

        /// <summary>
        /// Separator to insert between data sets
        /// </summary>
        protected internal override string DataSetsSeparator
        {
            get { return ","; }
        }

        /// <summary>
        /// Separator to insert between encoded numbers
        /// </summary>
        protected internal override string NumbersSeparator
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// String to put instead of missing value
        /// </summary>
        protected override string MissingValue
        {
            get { return "__"; }
        }

        /// <summary>
        /// Minimum valid value
        /// </summary>
        protected override int MinValidValue
        {
            get { return 0; }
        }

        /// <summary>
        /// Maximum valid value
        /// </summary>
        public override int MaxValidValue
        {
            get { return 4095; }
        }

        /// <summary>
        /// Method to encode number
        /// </summary>
        /// <param name="number">Number to encode</param>
        /// <returns>Encoded number</returns>
        protected override string EncodeNumber(int number)
        {
            int upper = number >> 6;
            int lower = number % 64;
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", c_encodingValues[upper], c_encodingValues[lower]);
        }
    }
}
