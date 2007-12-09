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

using System.Drawing;
using System.Text;

namespace NGChart
{
    /// <summary>
    /// Title of the chart
    /// </summary>
    /// <remarks>
    /// http://code.google.com/apis/chart/#chtt
    /// </remarks>
    public class ChartTitle : ChartParam
    {
        #region Properties

        #region Overrides

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chtt"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get
            {
                StringBuilder builder = new StringBuilder(Title, 256);
                Utils.EncodeTitle(builder);

                if (FontColor.HasValue && fontSize.HasValue)
                {
                    builder.Append("&chts=");
                    Utils.AppendAsRGBA(builder, FontColor.Value);
                    builder.Append(',');
                    builder.Append(fontSize.Value);
                }
                return builder.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Chart title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _title;

        /// <summary>
        /// Font color for the chart title
        /// </summary>
        public Color? FontColor
        {
            get { return _fontColor; }
            set { _fontColor = value; }
        }
        private Color? _fontColor;

        /// <summary>
        /// Font size for the chart title
        /// </summary>
        public int? fontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }
        private int? _fontSize;

        #endregion

        #region Constructors

        public ChartTitle(string title)
        {
            _title = title;
        }

        public ChartTitle(string title, Color fontColor, int fontSize)
        {
            _title = title;
            _fontSize = fontSize;
            _fontColor = fontColor;
        }

        #endregion

    }
}
