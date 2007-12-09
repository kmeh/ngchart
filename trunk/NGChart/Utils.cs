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
using System.Text;

namespace NGChart
{
    /// <summary>
    /// Utilities class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Append color representation to the string builder
        /// </summary>
        /// <param name="builder">The string builder</param>
        /// <param name="color">Color to convert</param>
        public static void AppendAsRGBA(StringBuilder builder, Color color)
        {
            // google wants color in RGBA format
            builder.AppendFormat("{0:X2}", color.R);
            builder.AppendFormat("{0:X2}", color.G);
            builder.AppendFormat("{0:X2}", color.B);

            if (color.A != byte.MaxValue)
            {
                builder.AppendFormat("{0:X2}", color.A);
            }
        }

        /// <summary>
        /// Make title formatted according to specs:
        ///  Specify a space with a plus sign (+).
        ///  Use a pipe character (|) to force a line break.
        /// </summary>
        /// <param name="builder">Builder to process</param>
        /// <remarks>
        /// http://code.google.com/apis/chart/#chtt
        /// </remarks>
        public static void EncodeTitle(StringBuilder builder)
        {
            builder.Replace("\r\n", "\n");
            builder.Replace('\n', '|');
            builder.Replace(' ', '+');
        }

        /// <summary>
        /// Appends string representation of items in the collection to the string builder.
        /// Separate items with the separator.
        /// </summary>
        /// <typeparam name="TItem">Collection item type</typeparam>
        /// <param name="builder">StringBuilder to fill up</param>
        /// <param name="items">Collection to process</param>
        /// <param name="separator">Separator</param>
        public static void AppendWithSeparator<TItem>(StringBuilder builder, IEnumerable<TItem> items, string separator)
        {
            if (null !=items)
            {
                foreach (TItem label in items)
                {
                    builder.Append(label);
                    builder.Append(separator);
                }

                if (builder.Length > separator.Length)
                    builder.Length -= separator.Length;
            }
        }

        /// <summary>
        /// Generate string from collection of items.
        /// Separate items with the separator.
        /// </summary>
        /// <typeparam name="TItem">Collection item type</typeparam>
        /// <param name="items">Collection to process</param>
        /// <param name="separator">Separator</param>
        /// <returns>Generated string</returns>
        public static string GenerateString<TItem>(IEnumerable<TItem> items, string separator)
        {
            StringBuilder builder = new StringBuilder(1024);
            AppendWithSeparator(builder, items, separator);
            return builder.ToString();
        }

    }
}
