using System;

namespace Chapter2
{
    public static class Null_CoalescingOperator
    {
        private class  Vendor
        {
            public string CompanyName { get; set; }
        }

        public static void Start()
        {
            int? x = null;
            int y = x ?? -1;

            Console.WriteLine("x: {0}", x);
            Console.WriteLine("y: {0}", y);


            String companyName;
            Vendor vendor1 = new Vendor();            
            vendor1.CompanyName = "Company1";
            Vendor vendor2 = new Vendor();

            companyName = vendor1?.CompanyName;
            Console.WriteLine(String.Format("Company name: {0}", companyName));
            
            companyName = vendor2?.CompanyName;
            Console.WriteLine(String.Format("Company name: {0}", companyName));

            Console.ReadLine();
        }
    }
}
