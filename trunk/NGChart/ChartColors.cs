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
using System.Drawing;
using System.Globalization;
using System.Text;

namespace NGChart
{
    /// <summary>
    /// Data set color
    /// </summary>
    public class ChartColors : ChartParam
    {
        #region Properties

        public IEnumerable<Color> Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }
        private IEnumerable<Color> _colors;

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chco"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get
            {
                StringBuilder builder = new StringBuilder(128);
                foreach (Color color in Colors)
                {
                    ColorToRGBA(builder, color);
                    builder.Append(',');
                }

                if (builder.Length > 0) builder.Length--;

                return builder.ToString();
            }
        }

        #endregion

        private static void ColorToRGBA(StringBuilder builder, Color color)
        {
            // google wants color in RGBA format
            int rgba = color.ToArgb();
            rgba <<= 8;
            rgba |= color.A;

            builder.Append(rgba.ToString("X8", CultureInfo.InvariantCulture));
        }

        #region Constructors

        public ChartColors(Color color)
        {
            _colors = new Color[] { color };
        }


        public ChartColors(IEnumerable<Color> colors)
        {
            _colors = colors;
        }

        #endregion
    }
}
