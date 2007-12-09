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
using System.Diagnostics;
using System.Text;

namespace NGChart
{
    /// <summary>
    /// Simple encoding has a resolution of 62 different values. 
    /// Allowing five pixels per data point, this is sufficient for line and bar charts up to about 300 pixels. 
    /// Simple encoding is suitable for all other types of chart regardless of size.
    /// </summary>
    /// <remarks>http://code.google.com/apis/chart/#simple</remarks>
    public class SimpleEncoder
    {
        private static readonly char[] c_encodingValues = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        public static char Convert(int? number)
        {
            // special case for missing values
            if (null == number) 
                return '_';

            if ((number.Value < 0) || (number.Value > 61))
                throw new ArgumentOutOfRangeException("number", "Values should be in [0..61] range for simple encoding");

            return c_encodingValues[number.Value];
        }

        public static string Prefix
        {
            get { return "s"; }
        }
    }

    /// <summary>
    /// Wrapper around encoder (simple encoder for now)
    /// </summary>
    public class ChartData : ChartParam
    {
        #region Constructor

        public ChartData(IEnumerable<IEnumerable<int>> sets)
        {
            _sets = sets;
        }


        public ChartData(IEnumerable<int> dataSet)
        {
            _sets = new IEnumerable<int>[] { dataSet };
        }

        #endregion

        private readonly IEnumerable<IEnumerable<int>> _sets;

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
                Debug.Assert(null != _sets);
                return Encode(_sets);
            }
        }

        #endregion

        /// <summary>
        /// Encode array to string
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static string Encode(IEnumerable<int> set)
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append(SimpleEncoder.Prefix);
            builder.Append(':');

            EncodeSet(builder, set);

            return builder.ToString();
        }

        /// <summary>
        /// Convert array of arrays to dataset
        /// </summary>
        /// <param name="setsOfData">Array of arrays</param>
        /// <returns>Encoded string</returns>
        public static string Encode( IEnumerable< IEnumerable<int> > setsOfData)
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append(SimpleEncoder.Prefix);
            builder.Append(':');

            foreach (IEnumerable<int> values in setsOfData)
            {
                EncodeSet(builder, values);
                builder.Append(',');
            }
            if (builder.Length > 0) builder.Length--;

            return builder.ToString();
        }


        /// <summary>
        /// Encode array to string builder.
        /// </summary>
        /// <param name="builder">String builder</param>
        /// <param name="set">Array to encode</param>
        private static void EncodeSet(StringBuilder builder, IEnumerable<int> set)
        {
            foreach (int i in set)
            {
                builder.Append(SimpleEncoder.Convert(i));
            }
        }
    }
}
