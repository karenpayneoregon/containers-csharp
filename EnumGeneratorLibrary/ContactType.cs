using System;
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace EnumGeneratorLibrary
{
    /// <summary>
    /// ContactType auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public enum ContactType
    {

        [Description("Accounting Manager")]
        AccountingManager = 1,
        [Description("Assistant Sales Agent")]
        AssistantSalesAgent = 2,
        [Description("Assistant Sales Representative")]
        AssistantSalesRepresentative = 3,
        [Description("Marketing Assistant")]
        MarketingAssistant = 4,
        [Description("Marketing Manager")]
        MarketingManager = 5,
        [Description("Order Administrator")]
        OrderAdministrator = 6,
        [Description("Owner")]
        Owner = 7,
        [Description("Owner/Marketing Assistant")]
        OwnerMarketingAssistant = 8,
        [Description("Sales Agent")]
        SalesAgent = 9,
        [Description("Sales Associate")]
        SalesAssociate = 10,
        [Description("Sales Manager")]
        SalesManager = 11,
        [Description("Sales Representative")]
        SalesRepresentative = 12,
        [Description("Vice President, Sales")]
        VicePresidentSales = 13
    }
}
