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
using NGChart.Encoders;
using NUnit.Framework;

namespace NGChartTests.Encoding
{
    [TestFixture]
    public class ExtendedEncodingTests
    {
        [Test]
        public void TestExtendedEncoding()
        {
            ExtendedEncoder encoder = new ExtendedEncoder();

            Assert.AreEqual("AA", encoder.Convert(0));
            Assert.AreEqual("Ba", encoder.Convert(90));
            Assert.AreEqual(".z", encoder.Convert(4083));
            Assert.AreEqual("..", encoder.Convert(4095));
            
            Assert.AreEqual("__", encoder.Convert(null));
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentOutOfRangeException))]
        public void TestSimpleEncodingInvalid1()
        {
            ExtendedEncoder encoder = new ExtendedEncoder();
            Assert.AreEqual(encoder.Convert(4096), "9");
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentOutOfRangeException))]
        public void TestSimpleEncodingInvalid2()
        {
            ExtendedEncoder encoder = new ExtendedEncoder();
            Assert.AreEqual(encoder.Convert(-1), "9");
        }

    }
}
