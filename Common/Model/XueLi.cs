using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Model
{
    [MetadataType(typeof(XueLiMetadata))]
    public partial class b_XueLi
    {
        public class XueLiMetadata
        {
            [Key]
            [Required]
            public string XueLi { get; set; }
        }
    }
}
