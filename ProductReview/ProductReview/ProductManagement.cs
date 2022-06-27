using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview
{
    public class ProductManagement
    {
        public readonly DataTable table = new DataTable();

        public List<ProductModel> AddData()
        {
            List<ProductModel> table = new List<ProductModel>()
            {
                new ProductModel() { ProductId = 1, UserId = 1, Rating = 2, Review = "Average", isLike = true },
                new ProductModel() { ProductId = 2, UserId = 2, Rating = 1, Review = "Bad", isLike = false },
                new ProductModel() { ProductId = 3, UserId = 3, Rating = 3, Review = "Nice", isLike = true },
                new ProductModel() { ProductId = 4, UserId = 4, Rating = 4, Review = "Good", isLike = false },
                new ProductModel() { ProductId = 5, UserId = 5, Rating = 5, Review = "Excelent", isLike = false },
                new ProductModel() { ProductId = 6, UserId = 3, Rating = 3, Review = "Nice", isLike = true },
                new ProductModel() { ProductId = 7, UserId = 6, Rating = 2, Review = "Average", isLike = true },
                new ProductModel() { ProductId = 8, UserId = 5, Rating = 1, Review = "Bad", isLike = true },
                new ProductModel() { ProductId = 5, UserId = 10, Rating = 4, Review = "Good", isLike = true },
                new ProductModel() { ProductId = 10, UserId = 23, Rating = 5, Review = "Excelent", isLike = false },
                new ProductModel() { ProductId = 11, UserId = 5, Rating = 4, Review = "Nice", isLike = false },
                new ProductModel() { ProductId = 12, UserId = 4, Rating = 1, Review = "Very Bad", isLike = true },
                new ProductModel() { ProductId = 13, UserId = 12, Rating = 5, Review = "Excelent", isLike = false },
                new ProductModel() { ProductId = 4, UserId =17, Rating = 2, Review = "Average", isLike = true },
                new ProductModel() { ProductId = 15, UserId = 10, Rating = 3, Review = "Nice", isLike = true },
                new ProductModel() { ProductId = 16, UserId = 8, Rating = 1, Review = "Very Bad", isLike = false },
                new ProductModel() { ProductId = 17, UserId = 18, Rating = 5, Review = "Excelent", isLike = true },
                new ProductModel() { ProductId = 18, UserId = 9, Rating = 4, Review = "Good", isLike = true },
                new ProductModel() { ProductId = 19, UserId = 10, Rating = 5, Review = "Nice", isLike = false },
                new ProductModel() { ProductId = 20, UserId = 7, Rating = 2, Review = "Average", isLike = true },
                new ProductModel() { ProductId = 21, UserId = 6, Rating = 1, Review = "Bad", isLike = true },
                new ProductModel() { ProductId = 22, UserId = 5, Rating = 1, Review = "Very Bad", isLike = false },
                new ProductModel() { ProductId = 23, UserId = 10, Rating = 4, Review = "Good", isLike = false },
                new ProductModel() { ProductId = 24, UserId = 8, Rating = 1, Review = "Bad", isLike = true },
                new ProductModel() { ProductId = 25, UserId = 12, Rating = 2, Review = "Average", isLike = false },
            };
            return table;
        }
        public void ViewData(List<ProductModel> model)
        {
            foreach (var data in model)
            {
                Console.WriteLine("ProductID: " + data.ProductId + "\tUserID: " + data.UserId + "\tRating: " + data.Rating + "\tReview: " +
                    data.Review + "\tIsLike: " + data.isLike);
            }
        }
        public void TopThreeData(List<ProductModel> products)
        {
            var data = (from item in products orderby item.Rating descending select item).Take(3);

            foreach (var item in data)
            {
                Console.WriteLine("ProductID: " + item.ProductId + "\tUserID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " +
                     item.Review + "\tIsLike: " + item.isLike);
            }
        }
        public void RatingGreater3Records(List<ProductModel> products)
        {
            var data = from item in products
                       where item.Rating > 3 && (item.ProductId == 11 || item.ProductId == 14 || item.ProductId == 17)
                       select item;

            foreach (var item in data)
            {
                Console.WriteLine("ProductID: " + item.ProductId + "\tUserID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " +
                     item.Review + "\tIsLike: " + item.isLike);
            }
        }
        public void CountRecords(List<ProductModel> products)
        {
            var data = products.GroupBy(x => (x.ProductId)).Select(x => new { ProductId = x.Key, count = x.Count() });
            foreach (var item in data)
            {
                Console.WriteLine("ProductID: " + item.ProductId + " has Count of: " + item.count);
            }
        }
        public void ReviewAndProductId(List<ProductModel> products)
        {
            var data = products.Select(x => (x.ProductId, x.Review));

            foreach (var item in data)
            {
                Console.WriteLine("ProductID: " + item.ProductId + "\tReview: " + item.Review);
            }
        }
        public void SkipTop5Records(List<ProductModel> products)
        {
            var data = products.OrderByDescending(x => (x.Rating)).Skip(5);
            foreach (var item in data)
            {
                Console.WriteLine("ProductID: " + item.ProductId + "\tUserID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " +
                     item.Review + "\tIsLike: " + item.isLike);
            }
        }
        public void productIDAndReviewUsingSelectLINQ(List<ProductModel> productReviews)
        {
            var result = productReviews.Select(reviews => new { ProductID = reviews.ProductId, Review = reviews.Review });
            Console.WriteLine("Product ID\t|\tReview");
            foreach (var item in result)
            {
                Console.WriteLine("\t" + item.ProductID + "\t|\t" + item.Review);
            }
        }
        public DataTable DataTable()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("ProductID");
            datatable.Columns.Add("UserID");
            datatable.Columns.Add("Rating");
            datatable.Columns.Add("Review");
            datatable.Columns.Add("IsLike");

            datatable.Rows.Add(10, 1, 4.2, "Nice", true);
            datatable.Rows.Add(10, 2, 3.7, "Okay", true);
            datatable.Rows.Add(10, 3, 3.0, "Bad", false);
            datatable.Rows.Add(11, 1, 4.2, "Nice", true);
            datatable.Rows.Add(11, 2, 3.7, "Okay", true);
            datatable.Rows.Add(11, 3, 3.0, "Bad", false);
            datatable.Rows.Add(12, 1, 4.2, "Nice", true);
            datatable.Rows.Add(12, 2, 3.7, "Okay", true);
            datatable.Rows.Add(12, 3, 3.0, "Bad", false);
            datatable.Rows.Add(13, 1, 4.2, "Nice", true);
            datatable.Rows.Add(13, 2, 3.7, "Okay", true);
            datatable.Rows.Add(13, 3, 3.0, "Bad", false);
            datatable.Rows.Add(14, 1, 4.2, "Nice", true);
            datatable.Rows.Add(14, 2, 3.7, "Okay", true);
            datatable.Rows.Add(14, 3, 3.0, "Bad", false);
            datatable.Rows.Add(15, 1, 4.2, "Nice", true);
            datatable.Rows.Add(15, 2, 3.7, "Okay", true);
            datatable.Rows.Add(15, 3, 3.0, "Bad", false);
            datatable.Rows.Add(16, 1, 4.2, "Nice", true);
            datatable.Rows.Add(16, 2, 3.7, "Okay", true);
            datatable.Rows.Add(16, 3, 3.0, "Bad", false);
            datatable.Rows.Add(17, 1, 4.2, "Nice", true);
            datatable.Rows.Add(17, 2, 3.7, "Okay", true);
            datatable.Rows.Add(17, 3, 3.0, "Bad", false);
            datatable.Rows.Add(18, 1, 4.2, "Nice", true);
            return datatable;
        }
        public void ViewDataTable(DataTable products)
        {
            var column = from table in products.AsEnumerable() select table;
            foreach (var item in column)
            {
                Console.WriteLine("ProductID: " + item.Field<string>("ProductID") + "\tUserID: " + item.Field<string>("UserID") + "\tRating: " + item.Field<string>("Rating") + "\tReview: " +
                     item.Field<string>("Review") + "\tIsLike: " + item.Field<string>("IsLike"));
            }
        }
        public void IsLikeTrueRecords(DataTable products)
        {
            var data = products.AsEnumerable().Where(x => (x.Field<string>("IsLike") == "True"));
            foreach (var item in data)
            {
                Console.WriteLine("ProductID: " + item.Field<string>("ProductID") + "\tUserID: " + item.Field<string>("UserID") + "\tRating: "
            + item.Field<string>("Rating") + "\tReview: " + item.Field<string>("Review") + "\tIsLike: " + item.Field<string>("IsLike"));
            }
        }
    }
}