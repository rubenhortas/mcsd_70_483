using System;

namespace Chapter2
{
    // Null Coalescing Operator also known as Elvis Operator
    public static class NullCoalescingOperator
    {
        private class Vendor
        {
            public string CompanyName { get; set; }
        }

        public static void Start()
        {
            int? x = null;
            int y = x ?? -1;

            Console.WriteLine("x: {0}", x);
            Console.WriteLine("y: {0}", y);

            string companyName;
            Vendor vendor1 = new Vendor { CompanyName = "Company1" };
            Vendor vendor2 = new Vendor();

            companyName = vendor1?.CompanyName;
            Console.WriteLine($"Company name: {companyName}");

            companyName = vendor2?.CompanyName;
            Console.WriteLine($"Company name: {companyName}");
        }
    }
}
