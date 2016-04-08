using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Test.Common.YanZheng
{
    public class FilterableClientDataTypeModelValidatorProvider : ClientDataTypeModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            var allValidators = base.GetValidators(metadata, context);
            var validators = new List<ModelValidator>();
            foreach (var v in allValidators)
            {
                if (v.GetType().Name != "NumericModelValidator")
                {
                    validators.Add(v);
                }
                else
                {
                    NumericAttribute attribute = new NumericAttribute { ErrorMessage = "{0}必须是一个数字！" };
                    DataAnnotationsModelValidator validator = new DataAnnotationsModelValidator(metadata, context, attribute);
                    validators.Add(validator);
                }
            }
            return validators;
        }
    }
}
