using System;

namespace ListGenericConsoleApp.Classes
{
    public class Customer
    {
        public int Id => CustomerIdentifier;
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public int? ContactIdentifier { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string Phone { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? InUse { get; set; }

        public override string ToString() => CompanyName;


    }
}