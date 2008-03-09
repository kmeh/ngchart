// Copyright (c) 2008, Eugene Rymski
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


using NGChart;
using NUnit.Framework;

namespace NGChartTests
{
    [TestFixture]
    public class LineStylesTest
    {
        [Test]
        public void OneStyles()
        {
            LineStyles styles = new LineStyles(new LineStyle(1f, 6.5456f, 0.21f));
            Assert.AreEqual(styles.Name, "chls");
            Assert.AreEqual(styles.Data, "1,6.5,0.2");
        }

        [Test]
        public void TwoStyles()
        {
            LineStyles styles = new LineStyles(
                                                new LineStyle[]
                                                   {
                                                       new LineStyle(3f, 6f, 3f), 
                                                       new LineStyle(1f, 1f, 0f)
                                                    }
                                                );
            Assert.AreEqual(styles.Name, "chls");
            Assert.AreEqual(styles.Data, "3,6,3|1,1,0");
        }
    }
}
