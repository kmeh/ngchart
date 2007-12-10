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

using NGChart;
using NUnit.Framework;
using System.Drawing;

namespace NGChartTests
{
    [TestFixture]
    public class TitleTests
    {
        [Test]
        public void TestTitle()
        {
            ChartTitle title = new ChartTitle("one line\nbreak");
            Assert.AreEqual(title.ToString(), "chtt=one+line|break");
        }

        [Test]
        public void TestTitleWithFont()
        {
            ChartTitle title = new ChartTitle("two\nlines\r\nbreaks test", Color.Green, 15);

            string titleString = title.ToString();
            Assert.IsTrue(titleString.Contains("chtt=two|lines|breaks+test"));
            Assert.IsTrue(titleString.Contains("chts=008000,15"));
        }
    }
}
