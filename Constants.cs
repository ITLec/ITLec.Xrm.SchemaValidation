using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.Xrm.SchemaValidation
{
 public   class AttributeType
    {
        public static readonly string Uniqueidentifier = Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Uniqueidentifier.ToString();
        public static readonly string String = Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.String.ToString();
        public static readonly string EntityName = Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.EntityName.ToString();
        public static readonly string Decimal = Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Decimal.ToString();
    }
}
