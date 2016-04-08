using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Model
{
    [MetadataType(typeof(MingZuMetadata))]
    public partial class b_MingZu
    {
        public class MingZuMetadata
        {
            [Key]
            [Required(ErrorMessage = "名族必填")]
            public string MingZu { get; set; }
            [DisplayName("排序")]
            [Required(ErrorMessage="请输入一个有效的数值。")]
            [Range(0, 999)]
            public int PaiXu { get; set; }
            [DataType(DataType.Date)]
            public DateTime TianJiaShiJian { get; set; }
        }
    }
}
