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

using System;
using NGChart;
using NUnit.Framework;

namespace NGChartTests
{
    [TestFixture]
    public class EncodingTests
    {
        [Test]
        public void TestSimpleEncoding()
        {
            Assert.AreEqual(SimpleEncoder.Convert(0), 'A');
            Assert.AreEqual(SimpleEncoder.Convert(25), 'Z');
            
            Assert.AreEqual(SimpleEncoder.Convert(26), 'a');
            Assert.AreEqual(SimpleEncoder.Convert(51), 'z');
            
            Assert.AreEqual(SimpleEncoder.Convert(52), '0');
            Assert.AreEqual(SimpleEncoder.Convert(61), '9');
        }

        [Test]
        public void TestSimpleEncodingSet()
        {
            Assert.AreEqual(ChartData.Encode(new int[] {0, 19, 27, 53, 61}), "s:ATb19");
        }

        [Test]
        public void TestSimpleEncodingSets()
        {
            Assert.AreEqual("s:A,B,CC,91",
                ChartData.Encode(new int[][]
                                        {
                                            new int[] { 0 },
                                            new int[] { 1 },
                                            new int[] { 2, 2 },
                                            new int[] { 61, 53 }
                                        }
        ));
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentOutOfRangeException))]
        public void TestSimpleEncodingInvalid1()
        {
            Assert.AreEqual(SimpleEncoder.Convert(62), '9');
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentOutOfRangeException))]
        public void TestSimpleEncodingInvalid2()
        {
            Assert.AreEqual(SimpleEncoder.Convert(-1), '9');
        }
    }
}
