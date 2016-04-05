using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Model
{
    [MetadataType(typeof(XiaoQuMetadata))]
    public partial class b_XiaoQu
    {
        public class XiaoQuMetadata
        {
            [Key]
            [Required]
            public string XiaoQu { get; set; }
        }
    }
}
