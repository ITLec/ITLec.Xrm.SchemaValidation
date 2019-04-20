using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.Xrm.SchemaValidation.Helpers
{
    public static class AttributeManager

    {

        public static string GetAttributeLabel(Microsoft.Xrm.Sdk.IOrganizationService service, Microsoft.Xrm.Sdk.Entity entity, string attribute)

        {

            string strLabel = String.Empty;

            Microsoft.Xrm.Sdk.OptionSetValue option = null;



            var attributeRequest = new Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest

            {

                EntityLogicalName = entity.LogicalName,

                LogicalName = attribute,

                RetrieveAsIfPublished = true

            };



            Microsoft.Xrm.Sdk.Messages.RetrieveAttributeResponse attributeResponse = (Microsoft.Xrm.Sdk.Messages.RetrieveAttributeResponse)service.Execute(attributeRequest);

            Microsoft.Xrm.Sdk.Metadata.AttributeMetadata attrMetadata = (Microsoft.Xrm.Sdk.Metadata.AttributeMetadata)attributeResponse.AttributeMetadata;

            Microsoft.Xrm.Sdk.Metadata.OptionMetadataCollection optionMeta = null;



            //Console.Write("\tDebug attributeType : " + attrMetadata.AttributeType.ToString() + "\t");



            #region Switch

            switch (attrMetadata.AttributeType.ToString())

            {

                case "Status": //Status

                    optionMeta = ((Microsoft.Xrm.Sdk.Metadata.StatusAttributeMetadata)attrMetadata).OptionSet.Options;

                    break;

                case "Picklist": //Picklist

                    optionMeta = ((Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata)attrMetadata).OptionSet.Options;

                    break;

                case "State": //State

                    optionMeta = ((Microsoft.Xrm.Sdk.Metadata.StateAttributeMetadata)attrMetadata).OptionSet.Options;

                    break;

                case "Decimal": //Decimal

                    break;

                case "Enum": //Enum

                    break;

                case "Memo": //Memo

                    break;

                case "Money": //Money

                    break;

                case "Lookup":

                    break;

                case "Integer":

                    break;

                case "Owner":

                    strLabel = ((Microsoft.Xrm.Sdk.EntityReference)entity.Attributes[attribute]).Name;

                    break;

                case "DateTime": //DateTime

                    strLabel = Convert.ToDateTime(entity.Attributes[attribute].ToString()).ToString();

                    break;

                case "Boolean": //Boolean

                    break;

                case "String": //String

                    strLabel = entity[attribute].ToString();

                    break;

                case "Double": //Double

                    break;

                case "EntityName": //Entity Name

                    break;

                case "Image": //Image, it will return image name.

                    break;

                case "BigInt":

                    break;

                case "ManagedProperty":

                    break;

                case "Uniqueidentifier":

                    break;

                case "Virtual":

                    break;

                default:

                    //TODO: Write Err Exception

                    break;

            }

            #endregion Switch

            //If this attr is OptionSet, Find Label
            if (optionMeta != null)
            {
                option = ((Microsoft.Xrm.Sdk.OptionSetValue)entity.Attributes[attribute]);

                foreach (Microsoft.Xrm.Sdk.Metadata.OptionMetadata metadata in optionMeta)

                {

                    if (metadata.Value == option.Value)

                    {
                        strLabel = metadata.Label.UserLocalizedLabel.Label;

                    }

                }

            }



            return strLabel;

        }



        public static object GetAttributeValue(object attributeValue)
        {

            if (attributeValue.GetType() == typeof(Guid))

            {

                return attributeValue;

            }

            else if (attributeValue.GetType() == typeof(int))

            {

                return attributeValue;

            }
            else if (attributeValue.GetType() == typeof(Enum))

            {

                return attributeValue.ToString();

            }



            switch (attributeValue.ToString())



            {



                case "Microsoft.Xrm.Sdk.EntityReference":



                    return ((Microsoft.Xrm.Sdk.EntityReference)attributeValue).Id;



                case "Microsoft.Xrm.Sdk.OptionSetValue":

                    return ((Microsoft.Xrm.Sdk.OptionSetValue)attributeValue).Value;



                case "Microsoft.Xrm.Sdk.Money":

                    return ((Microsoft.Xrm.Sdk.Money)attributeValue).Value;



                case "Microsoft.Xrm.Sdk.AliasedValue":



                    return GetAttributeValue(((Microsoft.Xrm.Sdk.AliasedValue)attributeValue).Value);



                case "Microsoft.Xrm.Sdk.Label":

                    return LabelFacade.GetLabelString((Microsoft.Xrm.Sdk.Label)attributeValue);

                case "Microsoft.Xrm.Sdk.BooleanManagedProperty":

                    return ((Microsoft.Xrm.Sdk.BooleanManagedProperty)attributeValue).Value;



            }
            //  Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata



            return attributeValue.ToString();

        }

        public static string GetAttributeFormatedValue(object attributeValue, string formatedValue = "")

        {

            switch (attributeValue.ToString())
            {



                case "Microsoft.Xrm.Sdk.EntityReference":



                    return ((Microsoft.Xrm.Sdk.EntityReference)attributeValue).LogicalName + "\\" + ((Microsoft.Xrm.Sdk.EntityReference)attributeValue).Id.ToString() + "\\" + ((Microsoft.Xrm.Sdk.EntityReference)attributeValue).Name;



                case "Microsoft.Xrm.Sdk.OptionSetValue":

                    return ((Microsoft.Xrm.Sdk.OptionSetValue)attributeValue).Value.ToString() + ((string.IsNullOrEmpty(formatedValue)) ? "" : "\\" + formatedValue);



                case "Microsoft.Xrm.Sdk.Money":

                    return ((Microsoft.Xrm.Sdk.Money)attributeValue).Value.ToString();



                case "Microsoft.Xrm.Sdk.AliasedValue":
                    return GetAttributeValue(((Microsoft.Xrm.Sdk.AliasedValue)attributeValue).Value).ToString();
                case "Microsoft.Xrm.Sdk.Label":

                    return LabelFacade.GetLabelString((Microsoft.Xrm.Sdk.Label)attributeValue);

                case "Microsoft.Xrm.Sdk.BooleanManagedProperty":

                    return ((Microsoft.Xrm.Sdk.BooleanManagedProperty)attributeValue).Value.ToString() + ((string.IsNullOrEmpty(formatedValue)) ? "" : "\\" + formatedValue);



            }

            Type attributeValueType = attributeValue.GetType();
            if (attributeValueType.IsEnum)

            {

                return $"{ (int)attributeValue}\\{attributeValue}"; ;

            }


            return attributeValue.ToString();

        }





        public static object GetAttributeValueFromString(Microsoft.Xrm.Sdk.IOrganizationService service, string entityName, string attribute, string value)

        {
            object retVal = null;



            var attributeRequest = new Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest

            {

                EntityLogicalName = entityName,

                LogicalName = attribute,

                RetrieveAsIfPublished = true

            };

            Microsoft.Xrm.Sdk.Messages.RetrieveAttributeResponse attributeResponse = (Microsoft.Xrm.Sdk.Messages.RetrieveAttributeResponse)service.Execute(attributeRequest);

            Microsoft.Xrm.Sdk.Metadata.AttributeMetadata attrMetadata = (Microsoft.Xrm.Sdk.Metadata.AttributeMetadata)attributeResponse.AttributeMetadata;



            switch (attrMetadata.AttributeType.ToString())

            {

                case "Status": //Status



                    //Microsoft.Xrm.Sdk.Metadata.StatusAttributeMetadata tmp = new Microsoft.Xrm.Sdk.Metadata.StatusAttributeMetadata();

                    //tmp.DefaultFormValue = int.Parse(value);

                    //retVal = tmp;

                    retVal = int.Parse(value);

                    break;

                case "Picklist": //Picklist



                    retVal = int.Parse(value);

                    break;

                case "State": //State



                    retVal = int.Parse(value);

                    break;

                case "Decimal": //Decimal



                    retVal = decimal.Parse(value);

                    break;

                case "Enum": //Enum



                    retVal = int.Parse(value);

                    break;

                case "Memo": //Memo

                    retVal = value;

                    break;

                case "Money": //Money



                    retVal = decimal.Parse(value);

                    break;

                case "Lookup":

                    {
                        //    attrMetadata

                        string[] strs = value.Split('\\');

                        //Microsoft.Xrm.Sdk.EntityReference er = new Microsoft.Xrm.Sdk.EntityReference();

                        //    er.LogicalName = ((Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata) attrMetadata).Targets[0];
                        //    er.Id = Guid.Parse(strs[0]);

                        if (strs.Length > 1)
                        {
                            retVal = Guid.Parse(strs[1]);
                        }
                        else if (strs.Length == 1)
                        {
                            retVal = Guid.Parse(strs[0]);
                        }




                    }

                    break;

                case "Integer":



                    retVal = int.Parse(value);

                    break;

                case "Owner":

                    {

                        string[] strs = value.Split('\\');

                        Microsoft.Xrm.Sdk.EntityReference er = new Microsoft.Xrm.Sdk.EntityReference();

                        er.LogicalName = strs[0];

                        er.Id = Guid.Parse(strs[1]);

                        retVal = er;

                    }

                    break;

                case "DateTime": //DateTime



                    retVal = DateTime.Parse(value);

                    break;

                case "Boolean": //Boolean

                    retVal = bool.Parse(value);

                    break;

                case "String": //String

                    retVal = value;

                    break;

                case "Double": //Double

                    retVal = Double.Parse(value);

                    break;

                case "EntityName": //Entity Name

                    retVal = value;

                    break;

                case "Image": //Image, it will return image name.

                    retVal = value;

                    break;

                case "BigInt":

                    break;

                case "ManagedProperty":

                    break;

                case "Uniqueidentifier":

                    retVal = Guid.Parse(value);

                    break;

                case "Virtual":

                    break;

                default:

                    //TODO: Write Err Exception

                    break;

            }

            return retVal;

        }

    }
}
