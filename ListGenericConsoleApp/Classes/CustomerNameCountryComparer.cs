using System.Collections.Generic;

namespace ListGenericConsoleApp.Classes
{
    public class CustomerNameCountryComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer customer1, Customer customer2) => 
            customer1.CompanyName == customer2.CompanyName && customer1.CountryIdentifier == customer2.CountryIdentifier;

        public int GetHashCode(Customer obj) => 
            new { obj.CompanyName, CountryIdentfier = obj.CountryIdentifier }.GetHashCode();
    }
}