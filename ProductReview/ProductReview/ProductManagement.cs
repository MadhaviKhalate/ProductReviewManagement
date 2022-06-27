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
    }
}