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

using System.Collections.Generic;
using NGChart.Encoders;

namespace NGChart
{
    /// <summary>
    /// Parameter with data series
    /// </summary>
    public class ChartData : ChartParam 
    {
        #region Constructors

        #region Simple encoding cases

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sets">Set of data sets</param>
        public ChartData(IEnumerable<IEnumerable<int>> sets)
        {
            if (IsSimpleEncoderEnough(sets))
            {
                _processor = new EncodingProcessor<SimpleEncoder, int>(sets);
            }
            else
            {
                _processor = new EncodingProcessor<ExtendedEncoder, int>(sets);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataSet">Single data set</param>
        public ChartData(IEnumerable<int> dataSet)
        {
            if (IsSimpleEncoderEnough(dataSet))
            {
                _processor = new EncodingProcessor<SimpleEncoder, int>(dataSet);
            }
            else
            {
                _processor = new EncodingProcessor<ExtendedEncoder, int>(dataSet);
            }
        }

        #endregion

        #region Text encoding cases

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sets">Set of data sets</param>
        public ChartData(IEnumerable<IEnumerable<float>> sets)
        {
            _processor = new EncodingProcessor<TextEncoder, float>(sets);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataSet">Single data set</param>
        public ChartData(IEnumerable<float> dataSet)
        {
            _processor = new EncodingProcessor<TextEncoder, float>(dataSet);
        }

        #endregion

        #endregion

        /// <summary>
        /// Encoding processor
        /// </summary>
        public IEncodingProcessor Processor
        {
            get { return _processor; }
        }
        private readonly IEncodingProcessor _processor;

        #region Overrides

        /// <summary>
        /// Name of the parameter
        /// </summary>
        /// <value></value>
        public override string Name
        {
            get { return "chd"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        /// <value></value>
        public override string Data
        {
            get
            {
                return Processor.Generate();
            }
        }

        #endregion


        /// <summary>
        /// Analyze the incoming dataset to check if Simple Encoding would be enough
        /// </summary>
        /// <param name="set">Set to analyze</param>
        /// <returns>true if the data can be encoded with simple encoding</returns>
        private static bool IsSimpleEncoderEnough(IEnumerable<int> set)
        {
            bool allow = true;

            SimpleEncoder encoder = new SimpleEncoder();
            foreach (int i in set)
            {
                if (i > encoder.MaxValidValue)
                {
                    allow = false;
                    break;
                }
            }

            return allow;
        }

        /// <summary>
        /// Analyze the incoming datasets to check if Simple Encoding would be enough
        /// </summary>
        /// <param name="sets">Sets to analyze</param>
        /// <returns>true if the data can be encoded with simple encoding</returns>
        private static bool IsSimpleEncoderEnough(IEnumerable<IEnumerable<int>> sets)
        {
            bool allow = true;

            foreach (IEnumerable<int> set in sets)
            {
                if (! IsSimpleEncoderEnough(set))
                {
                    allow = false;
                    break;
                }
            }
            return allow;
        }
    }
}
