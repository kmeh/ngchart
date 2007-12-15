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

using System;

namespace NGChart.Encoders
{
    /// <summary>
    /// Base encoder
    /// </summary>
    public abstract class BaseEncoder<TNumber> where TNumber:struct, IComparable<TNumber>
    {
        #region Properties

        /// <summary>
        /// Prefix for data set
        /// </summary>
        protected internal abstract string Prefix { get; }

        /// <summary>
        /// Separator to insert between data sets
        /// </summary>
        protected internal abstract string DataSetsSeparator { get; }
        
        /// <summary>
        /// Separator to insert between encoded numbers
        /// </summary>
        protected internal abstract string NumbersSeparator { get; }

        /// <summary>
        /// String to put instead of missing value
        /// </summary>
        protected abstract string MissingValue { get; }

        /// <summary>
        /// Minimum valid value
        /// </summary>
        protected abstract TNumber MinValidValue { get; }

        /// <summary>
        /// Maximum valid value
        /// </summary>
        protected abstract TNumber MaxValidValue { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Method to encode number
        /// </summary>
        /// <param name="number">Number to encode</param>
        /// <returns>Encoded number</returns>
        protected abstract string EncodeNumber(TNumber number);

        #endregion

        /// <summary>
        /// Convert value to string with validation
        /// </summary>
        /// <param name="number">Value to convert</param>
        /// <returns>Converted string</returns>
        public string Convert(TNumber? number)
        {
            // special case for missing values
            if (null == number) 
                return MissingValue;

            if (! IsRangeValid(number.Value))
                throw new ArgumentOutOfRangeException("number", 
                    string.Format("Values should be in [{0}..{1}] range", 
                    MinValidValue, MaxValidValue));

            return EncodeNumber(number.Value);
        }

        /// <summary>
        /// Validate number range
        /// </summary>
        /// <param name="number">Number to validate</param>
        /// <returns>true if number is valid</returns>
        private bool IsRangeValid(TNumber number)
        {
            // ER: to avoid CS0019 compiler error. 
            // TNumber.CompareTo() is the only way to compare numeric types in generics
            return (number.CompareTo(MinValidValue) >= 0) && (number.CompareTo(MaxValidValue) <= 0);
        }
    }
}