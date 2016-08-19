using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LINQ
{
    class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */
        static void Main()
        {
            //PrintOutOfStock();
            //InStockMoreThan3();
            //CustomersInWashington();
            //NameOfProducts();
            //productPrice();
            //uppercase();
            //evennumber();
            //rename();
            //pairs();
            //lessThan500();
            //first3NumberA();
            //first3();
            //numberAFirst3();
            //allbut2();
            //element();
            //beginningNumberC();
            //divisibleby3();
            //alphabetically();
            //decending();
            //HighestToLowest();
            //ReverseC();
            //divided5();
            //ByCatagory();
            //TheHardOne();
            //uniqe();



            Console.ReadLine();
        }

        private static void PrintOutOfStock()
        {
            var products = DataLoader.LoadProducts();

            //var results = products.Where(p => p.UnitsInStock == 0);
            var results = from p in products
                where p.UnitsInStock == 0
                select p;

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        //2. Find all products that are in stock and cost more than 3.00 per unit.
        private static void InStockMoreThan3()
        {
            var products = DataLoader.LoadProducts();

            //var results = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            var results = from p in products
                where p.UnitsInStock > 0 && p.UnitPrice > 3
                select p;

            foreach (var product in results)
            {
                Console.WriteLine("{0} has {1} in stock with unit price {2}", product.ProductName,
                    product.UnitsInStock, product.UnitPrice);
            }
        }

        //3. Find all customers in Washington, print their name then their orders. (Region == "WA")
        private static void CustomersInWashington()
        {
            var customer = DataLoader.LoadCustomers();
            var result = from c in customer
                where c.Region == "WA"
                select c;
            foreach (var customers in result)
            {
                Console.WriteLine("{0} ordered {1}", customers.CompanyName, customers.Orders);

            }
        }

        //4. Create a new sequence with just the names of the products.
        private static void NameOfProducts()
        {
            var products = DataLoader.LoadProducts();
            var result = from p in products
                         where p.ProductName != ""
                         select p;
            foreach (var r in result)
            {
                Console.WriteLine("The product name is {0}",r.ProductName );
            }
        }

        //5. Create a new sequence of products and unit prices where the unit prices are increased by 25%.
        private static void productPrice()
        {
            var product = DataLoader.LoadProducts();
            var result = product.Select(p => new
            {
                p.ProductName,
                UnitPrice = p.UnitPrice*1.25m
            
            });
            foreach (var r in result)
            {
                Console.WriteLine("The new price of {0} is {1:c}", r.ProductName, r.UnitPrice);
            }
        }

        //6. Create a new sequence of just product names in all upper case.
        private static void uppercase()
        {
            var products = DataLoader.LoadProducts();
            var result = products.Select(p => new
            {
                p.ProductName,
                uppercase = p.ProductName.ToUpper()
            });
            foreach (var r in result)
            {
                Console.WriteLine("{0}",r.uppercase);
            }
        }

        //7. Create a new sequence with products with even numbers of units in stock.
        private static void evennumber()
        {
            var products = DataLoader.LoadProducts();
            var result = products.Where(p => p.UnitsInStock%2 == 0);
            foreach (var r in result)
            {
                Console.WriteLine("{0}\n{1}", r.ProductName, r.Category);
            }
        }

        //8. Create a new sequence of products with ProductName, Category, and rename UnitPrice to Price.
        private static void rename()
        {
            var products = DataLoader.LoadProducts();
            var result = products.Select(p => new
            {
                p.ProductName,
                p.Category,
                Price = p.UnitPrice
            });
            foreach (var r in result)
            {
                Console.WriteLine("Product name = {0} catagory = {1} price = {2}", r.ProductName, r.Category,r.Price);
            }
        }

        //9. Make a query that returns all pairs of numbers from both arrays such that the number from numbersB is less than the number from numbersC.
        private static void pairs()
        {
            var numberB = DataLoader.NumbersB;
            var numberC = DataLoader.NumbersC;
            var result = from b in numberB
                from c in numberC
                where b < c
                select new
                {
                    b,
                    c
                };
            foreach (var r in result)
            {
                Console.WriteLine("{0},{1}",r.b,r.c);
            }
        }

        //10. Select CustomerID, OrderID, and Total where the order total is less than 500.00.
        private static void lessThan500()
        {
            var customer = DataLoader.LoadCustomers();
            var result = from c in customer
                from o in c.Orders
                where o.Total < 500
                select new
                {
                    c.CustomerID,
                    o.OrderID,
                    o.Total
                };
            foreach (var r in result)
            {
                Console.WriteLine("customer id = {0}     order id = {1}     total = {2}", r.CustomerID,r.OrderID,r.Total);
            }
        }

        //11. Write a query to take only the first 3 elements from NumbersA.
        private static void first3NumberA()
        {
            var numberA = DataLoader.NumbersA;
            var result = numberA.Take(3);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        //12. Get only the first 3 orders from customers in Washington.
        private static void first3()
        {
            var customers = DataLoader.LoadCustomers();
            var results = (from c in customers
                           from o in c.Orders
                           where c.Region == "WA"
                           select new { c.CompanyName, o.OrderID, o.OrderDate }).Take(3);


            foreach (var result in results)
            {
                Console.WriteLine($"{result.OrderDate}{result.OrderID} for {result.CompanyName}");
            }
        }

        //13. Skip the first 3 elements of NumbersA.
        private static void numberAFirst3()
        {
            var numberA = DataLoader.NumbersA;
            var result = numberA.Skip(3);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        //14. Get all except the first two orders from customers in Washington.
        private static void allbut2()
        {
            var customers = DataLoader.LoadCustomers();
            var results = (from c in customers
                           from o in c.Orders
                           where c.Region == "WA"
                           select new { c.CompanyName, o.OrderID, o.OrderDate }).Skip(2);


            foreach (var result in results)
            {
                Console.WriteLine($"{result.OrderDate}{result.OrderID} for {result.CompanyName}");
            }
        }

        //15. Get all the elements in NumbersC from the beginning until an element is greater or equal to 6.
        private static void element()
        {
            var numberc = DataLoader.NumbersC;
            var results = numberc.TakeWhile(n => n < 6);
            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }

        //16. Return elements starting from the beginning of NumbersC until a number is hit that is less than its position in the array.
        private static void beginningNumberC()
        {
            var numbersC = DataLoader.NumbersC;

            var results = numbersC.TakeWhile((number, index) => number > index);

            foreach (var num in results)
            {
                Console.WriteLine(num);
            }
        }

        //17. Return elements from NumbersC starting from the first element divisible by 3.
        private static void divisibleby3()
        {
            var numberC = DataLoader.NumbersC;
            var result = numberC.SkipWhile(n => n % 3 != 0);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        //18. Order products alphabetically by name.
        private static void alphabetically()
        {
            var products = DataLoader.LoadProducts();
            var result = products.OrderBy(p => p.ProductName);
            foreach (var r in result)
            {
                Console.WriteLine(r.ProductName);
            }
        }

        //19. Order products by UnitsInStock descending.
        private static void decending()
        {
            var products = DataLoader.LoadProducts();
            var result = products.OrderByDescending(p => p.UnitsInStock);
            foreach (var r in result)
            {
                Console.WriteLine(r.UnitsInStock);
            }
        }

        //20. Sort the list of products, first by category, and then by unit price, from highest to lowest.
        private static void HighestToLowest()
        {
            var products = DataLoader.LoadProducts();
            var result = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var r in result)
            {
                Console.WriteLine("catagory= {0} unit price = {1}",r.Category,r.UnitPrice);
            }
        }

        //21. Reverse NumbersC.
        private static void ReverseC()
        {
            var numberC = DataLoader.NumbersC;
            var result = numberC.Reverse();
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        //22. Display the elements of NumbersC grouped by their remainder when divided by 5.
        private static void divided5()
        {
            var elements = DataLoader.NumbersC;
            var result = from i in elements
                let r = i%5
                orderby r
                group i by r;
            foreach (var r in result)
            {
                Console.WriteLine("\nRemainder: {0}", r.Key);
                foreach (var n in result)
                {
                    Console.WriteLine("Number: {0}", n);
                }
            }


        }

        //23. Display products by Category.
        private static void ByCatagory()
        {
            var products = DataLoader.LoadProducts();
            var result = products.OrderBy(p => p.Category);
            foreach (var r in result)
            {
                Console.WriteLine("{0}",r.Category);
            }
        }

        ////skipped
        ////24. Group customer orders by year, then by month.
        //private static void TheHardOne()
        //{
        //    var customers = DataLoader.LoadCustomers();
        //    var result = from c in customers
        //        select new
        //        {
        //            c.CustomerID,
        //            yeargroups = from o in c.Orders
        //                group o by o.OrderDate
        //                into YG
        //                select new
        //                {
        //                    year = YG.Key,
        //                    monthgroups = from o in YG
        //                        group o by o.OrderDate.Month
        //                        into mg
        //                        select new
        //                        {
        //                            mg.Key,
        //                            orders = mg
        //                        }
        //                }
        //        };
        //    foreach (var r in result)
        //    {
        //        Console.WriteLine($"{r.yeargroups}");
        //        foreach (var y in r.yeargroups)
        //        {
        //            Console.WriteLine($"{y.monthgroups}");
        //            foreach (var VARIABLE in COLLECTION)
        //            {
                        
        //            }
        //        }
        //    }
        //}
        

        //25. Create a list of unique product category names.
        private static void uniqe()
        {
             
        }
    }
}