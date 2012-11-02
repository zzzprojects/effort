﻿// ----------------------------------------------------------------------------------
// <copyright file="CanonicalFunctionsFixture.cs" company="Effort Team">
//     Copyright (C) 2012 by Effort Team
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in
//     all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//     THE SOFTWARE.
// </copyright>
// ----------------------------------------------------------------------------------

namespace Effort.Test
{
    using System;
    using System.Linq;
    using Effort.Test.Data.Feature;
    using Effort.Test.Data.Northwind;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftwareApproach.TestingExtensions;

    [TestClass]
    public class CanonicalFunctionsFixture
    {
        private NorthwindObjectContext context;

        [TestInitialize]
        public void Initialize()
        {
            // This context is initialized from the csv files in Effort.Test.Data/Northwind/Content
            this.context = new LocalNorthwindObjectContext();
        }

        #region System.String Method (Static) Mapping

        [TestMethod]
        public void StringConcat()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                QuantityPerUnit = "kg",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Select(x => String.Concat(x.ProductName,x.QuantityPerUnit));

            var products = query.ToList();
            products.FirstOrDefault(x => x == "Special product"+"kg").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringIsNullOrEmpty()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "",
                UnitPrice = -250,
                QuantityPerUnit = null

            });
            context.SaveChanges();

            var query = context.Products.Where(x => String.IsNullOrEmpty(x.ProductName) && String.IsNullOrEmpty(x.QuantityPerUnit));
            var products = query.ToList();
            products.FirstOrDefault(x => x.UnitPrice == -250).ShouldNotBeNull();
        }

        #endregion

        #region System.String Method (Instance) Mapping

        [TestMethod]
        public void StringContains()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Contains("Sp"));
            var products = query.ToList();
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringEndsWith()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.EndsWith("ct"));
            var products = query.ToList();
            products.Count.ShouldBeLessThan(20);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringStartsWith()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.StartsWith("Sp"));
            var products = query.ToList();
            products.Count.ShouldEqual(2);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringLength()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Length == 15);

            var products = query.ToList();
            products.Count.ShouldBeLessThan(20);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringIndexOf()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.IndexOf("pe") == 1);
            var products = query.ToList();
            products.Count.ShouldBeLessThan(20);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringInsert()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Insert(1, "data") == "Sdatapecial product");
            var products = query.ToList();
            products.Count.ShouldEqual(1);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringRemove1()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Remove(3) == "Spe");
            var products = query.ToList();
            products.Count.ShouldBeLessThan(20);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringRemove2()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Remove(1, 2) == "Scial product");
            var products = query.ToList();
            products.Count.ShouldEqual(1);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringReplace()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product of product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Replace("product", "item") == "Special item of item");
            var products = query.ToList();
            products.Count.ShouldEqual(1);
            products.FirstOrDefault(x => x.ProductName == "Special product of product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringSubstring1()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Substring(3) == "cial product");
            var products = query.ToList();
            products.Count.ShouldEqual(1);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringSubstring2()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Substring(2,2) == "ec");
            var products = query.ToList();
            products.Count.ShouldEqual(1);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringToLower()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.ToLower() == "special product");
            var products = query.ToList();
            products.Count.ShouldEqual(1);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void StringToUpper()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.ToUpper() == "SPECIAL PRODUCT");
            var products = query.ToList();
            products.Count.ShouldEqual(1);
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void Trim()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "   One Product ",
                UnitPrice = -250,
                QuantityPerUnit = null

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.Trim() == "One Product");
            var products = query.ToList();
            products.FirstOrDefault(x => x.UnitPrice == -250).ShouldNotBeNull();
        }

        [TestMethod]
        public void TrimEnd()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "  One Product ",
                UnitPrice = -250,

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.TrimEnd() == "  One Product");
            var products = query.ToList();

            products.FirstOrDefault(x => x.UnitPrice == -250).ShouldNotBeNull();
        }

        [TestMethod]
        public void TrimStart()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "  One Product ",
                UnitPrice = -250,

            });
            context.SaveChanges();

            var query = context.Products.Where(x => x.ProductName.TrimStart() == "One Product ");
            var products = query.ToList();
            products.FirstOrDefault(x => x.UnitPrice == -250).ShouldNotBeNull();
        }

        #endregion

        #region System.DateTime Method (Static) Mapping


        [TestMethod]
        public void DateTimeNow()
        {
            var query = context.Orders.Where(x => x.OrderDate > DateTime.Now);
            var orders = query.ToList();
            orders.Count.ShouldEqual(0);

            query = context.Orders.Where(x => x.OrderDate < DateTime.Now);
            orders = query.ToList();
            orders.Count.ShouldEqual(830);
        }

        [TestMethod]
        public void DateTimeUtcNow()
        {
            var query = context.Orders.Where(x => x.OrderDate > DateTime.UtcNow);
            var orders = query.ToList();
            orders.Count.ShouldEqual(0);

            query = context.Orders.Where(x => x.OrderDate < DateTime.UtcNow);
            orders = query.ToList();
            orders.Count.ShouldEqual(830);
        }

        #endregion

        #region System.DateTime Method (Instance) Mapping

        [TestMethod]
        public void DateTimeDay()
        {
            context.Orders.AddObject(new Order
            {
                OrderDate = new DateTime(2012,1,2,3,4,5,100),
                ShipName = "SuperShip"                

            });
            context.SaveChanges();
            var query = context.Orders.Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Day == 2);
            var orders = query.ToList();
            orders.FirstOrDefault(x=>x.ShipName == "SuperShip").ShouldNotBeNull();

        }

        [TestMethod]
        public void DateTimeDayHour()
        {
            context.Orders.AddObject(new Order
            {
                OrderDate = new DateTime(2012, 1, 2, 3, 4, 5,100),
                ShipName = "SuperShip"

            });
            context.SaveChanges();
            var query = context.Orders.Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Hour == 3);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.ShipName == "SuperShip").ShouldNotBeNull();

        }
        [TestMethod]
        public void DateTimeDayMillisecond()
        {
            context.Orders.AddObject(new Order
            {
                OrderDate = new DateTime(2012, 1, 2, 3, 4, 5, 100),
                ShipName = "SuperShip"

            });
            context.SaveChanges();
            var query = context.Orders.Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Millisecond == 100);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.ShipName == "SuperShip").ShouldNotBeNull();

        }
        [TestMethod]
        public void DateTimeDayMinute()
        {
            context.Orders.AddObject(new Order
            {
                OrderDate = new DateTime(2012, 1, 2, 3, 4, 5, 100),
                ShipName = "SuperShip"

            });
            context.SaveChanges();
            var query = context.Orders.Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Minute == 4);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.ShipName == "SuperShip").ShouldNotBeNull();

        }
        [TestMethod]
        public void DateTimeDayMonth()
        {
            context.Orders.AddObject(new Order
            {
                OrderDate = new DateTime(2012, 1, 2, 3, 4, 5, 100),
                ShipName = "SuperShip"

            });
            context.SaveChanges();
            var query = context.Orders.Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Month == 1);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.ShipName == "SuperShip").ShouldNotBeNull();

        }
        [TestMethod]
        public void DateTimeDaySecond()
        {
            context.Orders.AddObject(new Order
            {
                OrderDate = new DateTime(2012, 1, 2, 3, 4, 5, 100),
                ShipName = "SuperShip"

            });
            context.SaveChanges();
            var query = context.Orders.Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Second == 5);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.ShipName == "SuperShip").ShouldNotBeNull();

        }
        [TestMethod]
        public void DateTimeDayYear()
        {
            context.Orders.AddObject(new Order
            {
                OrderDate = new DateTime(2012, 1, 2, 3, 4, 5, 100),
                ShipName = "SuperShip"

            });
            context.SaveChanges();
            var query = context.Orders.Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Year == 2012);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.ShipName == "SuperShip").ShouldNotBeNull();

        }



        #endregion

        #region System.DateTimeOffset Method (Instance) Mapping

        [TestMethod]
        public void DateTimeOffsetDay()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = new DateTimeOffset(2012, 1, 2, 3, 4, 5, 100, new TimeSpan())
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x=>x.Offset.HasValue && x.Offset.Value.Day == 2);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }

        [TestMethod]
        public void DateTimeOffsetDayHour()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = new DateTimeOffset(2012, 1, 2, 3, 4, 5, 100, new TimeSpan())
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x => x.Offset.HasValue && x.Offset.Value.Hour == 3);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }
        [TestMethod]
        public void DateTimeOffsetDayMillisecond()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = new DateTimeOffset(2012, 1, 2, 3, 4, 5, 100, new TimeSpan())
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x => x.Offset.HasValue && x.Offset.Value.Millisecond == 100);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }
        [TestMethod]
        public void DateTimeOffsetDayMinute()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = new DateTimeOffset(2012, 1, 2, 3, 4, 5, 100, new TimeSpan())
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x => x.Offset.HasValue && x.Offset.Value.Minute == 4);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }
        [TestMethod]
        public void DateTimeOffsetDayMonth()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = new DateTimeOffset(2012, 1, 2, 3, 4, 5, 100, new TimeSpan())
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x => x.Offset.HasValue && x.Offset.Value.Month == 1);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }
        [TestMethod]
        public void DateTimeOffsetDaySecond()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = new DateTimeOffset(2012, 1, 2, 3, 4, 5, 100, new TimeSpan())
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x => x.Offset.HasValue && x.Offset.Value.Second == 5);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }
        [TestMethod]
        public void DateTimeOffsetDayYear()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = new DateTimeOffset(2012, 1, 2, 3, 4, 5, 100, new TimeSpan())
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x => x.Offset.HasValue && x.Offset.Value.Year == 2012);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }



        #endregion

        #region System.DateTimeOffset Method (Static) Mapping

        [TestMethod]
        public void DateTimeOffsetCurrentDateTimeOffset()
        {
            FeatureObjectContext context = new LocalFeatureObjectContext();
            context.PrimaryEntities.AddObject(new PrimaryEntity
            {
                ID1 = 1,
                ID2 = 1,
                PrimaryData = "MyData",
                Offset = DateTimeOffset.Now
            });
            context.SaveChanges();
            var query = context.PrimaryEntities.Where(x => x.Offset.HasValue && x.Offset.Value.Year == DateTimeOffset.Now.Year);
            var orders = query.ToList();
            orders.FirstOrDefault(x => x.PrimaryData == "MyData").ShouldNotBeNull();
        }

        #endregion

        #region Mathematical Function Mapping

        [TestMethod]
        public void DecimalCeiling()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 0.3f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x => Decimal.Ceiling(0.3m) == 1);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x => x.Quantity == -123).ShouldNotBeNull();
        }

        [TestMethod]
        public void DecimalFloor()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 0.3f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x => Decimal.Floor(0.3m) == 0);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x => x.Quantity == -123).ShouldNotBeNull();
        }

        [TestMethod]
        public void DecimalRound()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 0.3f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x => Decimal.Round(0.3m) == 0);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x => x.Quantity == -123).ShouldNotBeNull();
        }


        [TestMethod]
        public void MathCeiling()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 0.3f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x => Math.Ceiling(x.Discount) == 1);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x =>x.Quantity == -123).ShouldNotBeNull();
        }

        [TestMethod]
        public void MathFloor()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 0.3f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x => Math.Floor(x.Discount) == 0);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x => x.Quantity == -123).ShouldNotBeNull();
        }

        [TestMethod]
        public void MathRound()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 0.3f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x => Math.Round(x.Discount) == 0);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x => x.Quantity == -123).ShouldNotBeNull();
        }

        [TestMethod]
        public void MathRoundWithDigits()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 123.396f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x => Math.Round(x.Discount,2) == 123.40);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x => x.Quantity == -123).ShouldNotBeNull();
        }

        [TestMethod]
        public void MathAbs()
        {
            context.Products.AddObject(new Product
            {
                ProductName = "Special product",
                UnitPrice = -250

            });
            context.SaveChanges();

            var query = context.Products.Where(x => Math.Abs(x.UnitPrice.Value) == 250);

            var products = query.ToList();
            products.FirstOrDefault(x => x.ProductName == "Special product").ShouldNotBeNull();
        }

        [TestMethod]
        public void MathPower()
        {
            context.OrderDetails.AddObject(new OrderDetail
            {
                OrderID = 1,
                Discount = 10.3f,
                Quantity = -123
            });
            context.SaveChanges();

            var query = context.OrderDetails.Where(x=> Math.Pow(x.Quantity,2) == 123*123);

            var orderdetails = query.ToList();
            orderdetails.FirstOrDefault(x => x.Quantity == -123).ShouldNotBeNull();
        }

        #endregion
    }
}