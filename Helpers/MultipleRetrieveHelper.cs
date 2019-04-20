using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.Xrm.SchemaValidation.Helpers
{
   public class MultipleRetrieveHelper
    {

        public static string RetrieveAll(Microsoft.Xrm.Sdk.IOrganizationService serviceOrgnization, string entityName, string columnSet, string filter, int retrievedNumberOfRecords, string orderBy, bool isDisplayAllRecords, out Microsoft.Xrm.Sdk.EntityCollection _EntityCollection)
        {

            int page = 1;
            string retVal = "";

            int recordCounter = 0;
            var entityCollectionResult = RetrieveAll(serviceOrgnization, entityName, columnSet, filter, retrievedNumberOfRecords, orderBy, page, null);
            _EntityCollection = entityCollectionResult;

            bool isFirstTime = true;

            //List<string> header = Entity.RetrieveAllFacade.GetColumnSet(entityName,columnSet).ToList<string>();
            //header.Insert(0, "#");


            do
            {

                if ((isDisplayAllRecords || isFirstTime ))
                {

                    if (entityCollectionResult.MoreRecords)
                    {
                        if (!isFirstTime)
                        {
                            entityCollectionResult = RetrieveAll(serviceOrgnization, entityName, columnSet, filter, retrievedNumberOfRecords, orderBy, page, entityCollectionResult.PagingCookie);

                            _EntityCollection.Entities.AddRange(entityCollectionResult.Entities);

                        }
                        recordCounter = page * retrievedNumberOfRecords;
                        ++page;
                    }

                }
                else
                {
                    break;
                }
                isFirstTime = false;
            } while (entityCollectionResult.MoreRecords);



            return retVal;
        }


    //    public static Dictionary<string, Microsoft.Xrm.Sdk.EntityCollection> EntityCollectionCached = new Dictionary<string, Microsoft.Xrm.Sdk.EntityCollection>();



        //https://msdn.microsoft.com/en-us/library/mt269606.aspx
        public static Microsoft.Xrm.Sdk.EntityCollection RetrieveAll(Microsoft.Xrm.Sdk.IOrganizationService serviceOrgnization, string entityName
            , string columnSet = "", string filter = "", int retrievedNumberOfRecords = 50, string orderBy = "", int pageNumber = 1, string pagingCookie = null)
        {
            Microsoft.Xrm.Sdk.EntityCollection retVal = null;

            string uniqueRecordString = $"{entityName} '{columnSet}' '{filter}' {retrievedNumberOfRecords} '{orderBy}' {pageNumber}  ";
            /*
            if (EntityCollectionCached.ContainsKey(uniqueRecordString))
            {
                return EntityCollectionCached[uniqueRecordString];
            }*/
            // Query using the paging cookie.
            // Define the paging attributes.
            // The number of records per page to retrieve.
            int queryCount = retrievedNumberOfRecords;
            // Create the query expression and add condition.
            Microsoft.Xrm.Sdk.Query.QueryExpression pagequery = new Microsoft.Xrm.Sdk.Query.QueryExpression();
            pagequery.EntityName = entityName;

            filter = filter.ToLower();
            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrWhiteSpace(filter) && filter != "null")
            {
                string[] conditionsStr = filter.Split(new string[] { "&" }, StringSplitOptions.None);

                foreach (string conditionStr in conditionsStr)
                {
                    string[] conditionStrs = conditionStr.Split('=');
                    string conditionAttributeName = conditionStrs[0];

                    bool isNot = false;

                    if (conditionAttributeName.EndsWith("!"))
                    {
                        isNot = true;
                        conditionAttributeName = conditionAttributeName.Replace("!", "");
                    }

                    string conditionAttributeValue = conditionStrs[1];

                    // Define the condition expression for retrieving records.
                    Microsoft.Xrm.Sdk.Query.ConditionExpression pagecondition = new Microsoft.Xrm.Sdk.Query.ConditionExpression();
                    pagecondition.AttributeName = conditionAttributeName;




                    if (conditionAttributeValue.StartsWith("(") && conditionAttributeValue.EndsWith(")"))
                    {
                        conditionAttributeValue = conditionAttributeValue.Replace("(", "").Replace(")", "");

                        pagecondition.Operator = isNot ? Microsoft.Xrm.Sdk.Query.ConditionOperator.NotIn : Microsoft.Xrm.Sdk.Query.ConditionOperator.In;

                        foreach (var val in conditionAttributeValue.Split(','))
                        {
                            pagecondition.Values.Add(val);
                        }
                    }
                    else if (conditionAttributeValue.StartsWith("%") && conditionAttributeValue.EndsWith("%"))
                    {
                        pagecondition.Operator = isNot ? Microsoft.Xrm.Sdk.Query.ConditionOperator.NotLike : Microsoft.Xrm.Sdk.Query.ConditionOperator.Like;
                        pagecondition.Values.Add(conditionAttributeValue);
                    }
                    else if (conditionAttributeValue.StartsWith(">"))
                    {
                        object objConditionAttributeValue = AttributeManager.GetAttributeValueFromString(serviceOrgnization, entityName, conditionAttributeName, conditionAttributeValue.Replace("<", "").Replace(">", ""));
                        pagecondition.Operator = Microsoft.Xrm.Sdk.Query.ConditionOperator.GreaterEqual;
                        pagecondition.Values.Add(objConditionAttributeValue);
                    }
                    else if (conditionAttributeValue.StartsWith("<"))
                    {
                        object objConditionAttributeValue = AttributeManager.GetAttributeValueFromString(serviceOrgnization, entityName, conditionAttributeName, conditionAttributeValue.Replace("<", "").Replace(">", ""));
                        pagecondition.Operator = Microsoft.Xrm.Sdk.Query.ConditionOperator.LessEqual;
                        pagecondition.Values.Add(objConditionAttributeValue);
                    }
                    else
                    {

                        object objConditionAttributeValue = AttributeManager.GetAttributeValueFromString(serviceOrgnization, entityName, conditionAttributeName, conditionAttributeValue);
                        pagecondition.Operator = isNot ? Microsoft.Xrm.Sdk.Query.ConditionOperator.NotEqual : Microsoft.Xrm.Sdk.Query.ConditionOperator.Equal;
                        pagecondition.Values.Add(objConditionAttributeValue);
                    }

                    pagequery.Criteria.AddCondition(pagecondition);
                }
            }

            // Define the order expression to retrieve the records.
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderBy = orderBy.ToLower();
                string[] orderByStrs = orderBy.Split(' ');

                string orderAttributeName = orderByStrs[0];


                string orderType = "desc";

                if (orderByStrs.Length > 1)
                    orderType = (string.IsNullOrEmpty(orderByStrs[1]) || orderByStrs[1] != "asc") ? "desc" : "asc";

                Microsoft.Xrm.Sdk.Query.OrderExpression order = new Microsoft.Xrm.Sdk.Query.OrderExpression();
                order.AttributeName = orderAttributeName;

                order.OrderType = (orderType == "desc") ? Microsoft.Xrm.Sdk.Query.OrderType.Ascending : Microsoft.Xrm.Sdk.Query.OrderType.Descending;

                pagequery.Orders.Add(order);
            }

            // pagequery.ColumnSet.AddColumns("name", "emailaddress1");
            //By Rasheed
            string[] columns = GetColumnSet(entityName, columnSet);
            pagequery.ColumnSet = new Microsoft.Xrm.Sdk.Query.ColumnSet(columns);
            // end by rasheed

            // Assign the pageinfo properties to the query expression.
            pagequery.PageInfo = new Microsoft.Xrm.Sdk.Query.PagingInfo();
            pagequery.PageInfo.Count = queryCount;
            pagequery.PageInfo.PageNumber = pageNumber;

            // The current paging cookie. When retrieving the first page, 
            // pagingCookie should be null.
            pagequery.PageInfo.PagingCookie = pagingCookie;


            // Retrieve the page.
            retVal = serviceOrgnization.RetrieveMultiple(pagequery);


            //EntityCollectionCached.Add(uniqueRecordString, retVal);
            return retVal;
        }



        public static string[] GetColumnSet(string entityName, string columnSet)
        {
            string[] retVal = columnSet.Split(',');

            return retVal;
        }
    }
}
