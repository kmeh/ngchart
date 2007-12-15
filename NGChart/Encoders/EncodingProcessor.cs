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
using System.Collections.Generic;
using System.Text;

namespace NGChart.Encoders
{
    /// <summary>
    /// Wrapper for encoding process
    /// </summary>
    /// <typeparam name="TEncoder">Encoder to use</typeparam>
    /// <typeparam name="TNumber">Type of data</typeparam>
    public class EncodingProcessor<TEncoder, TNumber> : IEncodingProcessor
        where TNumber : struct, IComparable<TNumber>
        where TEncoder : BaseEncoder<TNumber>, new()
    {
        #region Properties

        /// <summary>
        /// Encoder
        /// </summary>
        protected TEncoder Encoder
        {
            get { return _encoder; }
        }
        private readonly TEncoder _encoder = new TEncoder();

        /// <summary>
        /// Sets of data
        /// </summary>
        public IEnumerable<IEnumerable<TNumber>> DataSets
        {
            get { return _sets; }
        }
        private readonly IEnumerable<IEnumerable<TNumber>> _sets;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sets">Data sets to process</param>
        public EncodingProcessor(IEnumerable<IEnumerable<TNumber>> sets)
        {
            _sets = sets;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataSet">Dataset to process</param>
        public EncodingProcessor(IEnumerable<TNumber> dataSet)
        {
            _sets = new IEnumerable<TNumber>[] { dataSet };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generate string with encoded data
        /// </summary>
        /// <returns>String with the encoded data</returns>
        public string Generate()
        {
            StringBuilder builder = new StringBuilder(50);

            builder.Append(Encoder.Prefix);
            builder.Append(':');

            foreach (IEnumerable<TNumber> values in _sets)
            {
                foreach (TNumber number in values)
                {
                    builder.Append(Encoder.Convert(number));
                    builder.Append(Encoder.NumbersSeparator);
                }

                // remove trailing separator
                if (builder.Length > Encoder.NumbersSeparator.Length) builder.Length -= Encoder.NumbersSeparator.Length;

                builder.Append(Encoder.DataSetsSeparator);
            }

            // remove trailing separator if necessary
            if (builder.Length > 0) builder.Length--;

            return builder.ToString();

        }

        #endregion

    }
}
