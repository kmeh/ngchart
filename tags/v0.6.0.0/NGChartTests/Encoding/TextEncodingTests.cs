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
using NGChart;
using NGChart.Encoders;
using NUnit.Framework;

namespace NGChartTests.Encoding
{
    [TestFixture]
    public class TextEncodingTests
    {
        [Test]
        public void TestTextEncoder()
        {
            TextEncoder encoder = new TextEncoder();

            Assert.AreEqual("0.0", encoder.Convert(0));
            Assert.AreEqual("100.0", encoder.Convert(100));
            Assert.AreEqual("1.1", encoder.Convert(1.12f));
            
            Assert.AreEqual("-1", encoder.Convert(null));
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentOutOfRangeException))]
        public void TestLowerBound()
        {
            TextEncoder encoder = new TextEncoder();

            encoder.Convert(-1f);
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentOutOfRangeException))]
        public void TestUpperBound()
        {
            TextEncoder encoder = new TextEncoder();

            encoder.Convert(100.001f);
        }

        [Test]
        public void TestSingleDataSet()
        {
            ChartData chartData = new ChartData(new float[] { 0f, 40.4f, 100f });
            Assert.AreEqual("t:0.0,40.4,100.0", chartData.Data);
        }

        [Test]
        public void TestMultipleDataSet()
        {
            ChartData chartData = new ChartData(
                    new float[][] {
                        new float[] { 0f, 40.4f, 100f }
                    }
                );
            Assert.AreEqual("t:0.0,40.4,100.0", chartData.Data);
        }

        [Test]
        public void TestMultipleDataSet2()
        {
            ChartData chartData = new ChartData(
                    new float[][] {
                        new float[] { 33f, 99.9f, 55.1f },
                        new float[] { 0f, 40.4f, 100f },
                        new float[] { 26f, 0.1f, 64.2f }
                    }
                );
            Assert.AreEqual("t:33.0,99.9,55.1|0.0,40.4,100.0|26.0,0.1,64.2", chartData.Data);
        }
    }
}
