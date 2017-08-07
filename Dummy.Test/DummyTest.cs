using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dummy.Test
{
    [TestClass]
    public class DummyTest
    {
        [TestMethod]
        public void CanNormalGenerate()
        {
            // arrange
            Sample _sample = new Sample();
            ValueGenerator _generator = new ValueGenerator();


            // act
            _sample =  _generator.Generate<Sample>(_sample);

            // assert

            Assert.IsNotNull(_sample.SampleGuid);
            Assert.IsNotNull(_sample.SampleDateTime);
            Assert.IsNotNull(_sample.SampleDecimal);
            Assert.IsNotNull(_sample.SampleFloat);
            Assert.IsNotNull(_sample.SampleID);
            Assert.IsNotNull(_sample.SampleInt);
            Assert.IsNotNull(_sample.SampleLong);
            Assert.IsNotNull(_sample.SampleName);
            Assert.IsNotNull(_sample.SampleShort);
            Assert.IsNotNull(_sample.SampleString);
            Assert.IsNotNull(_sample.SampleEnum);
        }
    }

}
