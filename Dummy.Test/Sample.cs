using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy.Test
{
    /// <summary>
    /// This class will contain all the different property types.
    /// </summary>
    public class Sample
    {
        public int SampleID { get; set; }

        public Guid SampleGuid { get; set; }

        public string SampleName { get; set; }

        public string SampleString { get; set; }

        public short SampleShort { get; set; }

        public int SampleInt { get; set; }

        public long SampleLong { get; set; }

        public float SampleFloat { get; set; }

        public decimal SampleDecimal { get; set; }

        public DateTime SampleDateTime { get; set; }

        public SEnum SampleEnum { get; set; }

        public int? SampleNullableInt { get; set; }
    }

    public enum SEnum  
    {
        Open,
        Close,
        Forward,
        Backward
    }
}
