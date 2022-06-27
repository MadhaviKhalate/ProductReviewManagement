using System;

namespace ProductReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductManagement getMethod = new ProductManagement();
            var table = getMethod.AddData();
            var dataTable = getMethod.DataTable();


            Console.WriteLine("1.View Data\n2.view Top 3 Data\n3.view Rating > 3\n4.Count ProductID" +
                "\n5.View ProductId and Review\n6.Skip Top 5 Records\n7.ProductId and Review Using Select LINQ" +
                "\n8.Create Data Table\n9.View True Records\n10.Average Rating\n11.Review Message" +
                "\n12.Records For User ID 10\n\nEnter a Number");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        getMethod.ViewData(table);
                        break;
                    }
                case 2:
                    {
                        getMethod.TopThreeData(table);
                        break;
                    }
                case 3:
                    {
                        getMethod.RatingGreater3Records(table);
                        break;
                    }
                case 4:
                    {
                        getMethod.CountRecords(table);
                        break;
                    }
                case 5:
                    {
                        getMethod.ReviewAndProductId(table);
                        break;
                    }
                case 6:
                    {
                        getMethod.SkipTop5Records(table);
                        break;
                    }
                case 7:
                    {
                        getMethod.productIDAndReviewUsingSelectLINQ(table);
                        break;
                    }
                case 8:
                    {
                        getMethod.ViewDataTable(dataTable);
                        break;
                    }
                case 9:
                    {
                        getMethod.IsLikeTrueRecords(dataTable);
                        break;
                    }
                case 10:
                    {
                        getMethod.AverageRating(dataTable);
                        break;
                    }
                case 11:
                    {
                        getMethod.ReviewMessage(dataTable);
                        break;
                    }
                case 12:
                    {
                        getMethod.UserId10Records(dataTable);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a valid Number");
                        break;
                    }
            }
        }
    }
}