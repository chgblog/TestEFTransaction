using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Test.Common.YanZheng
{
    internal class NumericAttribute : ValidationAttribute, IClientValidatable
{
    public override bool IsValid(object value)
    {
        return true;
    }
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        yield return new ModelClientValidationRule { ValidationType = "number", ErrorMessage = this.FormatErrorMessage(metadata.DisplayName)};
    }
}
}
