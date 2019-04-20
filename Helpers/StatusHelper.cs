using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.Xrm.SchemaValidation.Helpers
{
 public   class StatusHelper
    {

        public static Microsoft.Crm.Sdk.Messages.SetStateRequest Get_SetStateRequest(string entityName, Guid entityId, int stateVal, int statusVal)
        {
            Microsoft.Crm.Sdk.Messages.SetStateRequest setStateRequest = new Microsoft.Crm.Sdk.Messages.SetStateRequest();

            // Set the Request Object's Properties
            setStateRequest.State = new Microsoft.Xrm.Sdk.OptionSetValue(stateVal);
            setStateRequest.Status = new Microsoft.Xrm.Sdk.OptionSetValue(statusVal);

            // Point the Request to the case whose state is being changed
            setStateRequest.EntityMoniker = new Microsoft.Xrm.Sdk.EntityReference(entityName, entityId);
            return setStateRequest;
        }
    }
}
