// Copyright (c) 2007, Eugene Rymski
// All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted 
//  provided that the following conditions are met:
// * Redistributions of source code must retain the above copyright notice, this list of conditions 
//   and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
//   and the following disclaimer in the documentation and/or other materials provided with the distribution.
// * Neither the name of the “Varozhka” nor the names of its contributors may be used to endorse or 
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
using System.Text;

namespace NGChart
{
    /// <summary>
    /// Abstract class for chart parameter
    /// </summary>
    public abstract class ChartParam
    {
        /// <summary>
        /// Name of the parameter
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Parameter data
        /// </summary>
        public abstract string Data { get; }
    }

    /// <summary>
    /// Helper parameters collection class (ER: TODO: get rid of it)
    /// </summary>
    public class ChartParams : List<ChartParam>
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Count * 128);

            foreach (ChartParam param in this)
            {
                builder.Append(param.Name);
                builder.Append('=');
                builder.Append(param.Data);
                builder.Append('&');
            }

            // remove the last amp
            if (builder.Length > 0)
                builder.Length--;

            return builder.ToString();
        }
    }

}
