namespace Questions
{
    public static class SqlOrderBy
    {
        public static void Start()
        {
            decimal[] loanAmounts = { 303m, 1000m, 85779, 501.51m, 603m, 1200m, 400m, 22m };

            loanAmounts.ToList().ForEach(delegate (decimal n) { Console.Write($"{n},"); });

            Console.WriteLine();

            IEnumerable<decimal> loanQuery =
                from amount in loanAmounts
                where amount % 2 == 0
                orderby amount ascending
                select amount;

            loanQuery.ToList().ForEach(delegate (decimal n) { Console.Write($"{n},"); });
        }
    }
}
