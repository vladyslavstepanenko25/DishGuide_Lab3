using System;
using System.Collections.Generic;
using System.Linq;

namespace DishGuideApp  
{
    // Твої базові моделі даних
    public class Dish { public string Name { get; set; } public double Rating { get; set; } }
    public class Review { public int Rating { get; set; } public string Text { get; set; } }
    public class Restaurant { public string Name { get; set; } public string Cuisine { get; set; } public double Rating { get; set; } }

    // Твій основний сервіс
    public class RecommendationService
    {
        // Метод 1: Обчислення середнього рейтингу на основі відгуків
        public double CalculateAverageRating(List<Review> reviews)
        {
            if (reviews == null) throw new ArgumentNullException(nameof(reviews), "Список відгуків не може бути null");
            if (reviews.Count == 0) return 0;

            double sum = 0;
            foreach (var review in reviews)
            {
                if (review.Rating < 1 || review.Rating > 5)
                    throw new ArgumentException("Рейтинг у відгуку має бути в діапазоні від 1 до 5");
                sum += review.Rating;
            }
            return sum / reviews.Count;
        }

        // Метод 2: Отримання Топ-N страв
        public List<Dish> GetTopDishes(List<Dish> dishes, int topCount)
        {
            if (dishes == null) throw new ArgumentNullException(nameof(dishes));
            if (topCount < 0) throw new ArgumentOutOfRangeException(nameof(topCount), "Кількість не може бути від'ємною");
            if (topCount == 0 || dishes.Count == 0) return new List<Dish>();

            return dishes.OrderByDescending(d => d.Rating)
                         .Take(topCount)
                         .ToList();
        }

        // Метод 3: Фільтрація ресторанів за кухнею та мінімальним рейтингом
        public List<Restaurant> FilterRestaurants(List<Restaurant> restaurants, string cuisine, double minRating)
        {
            if (restaurants == null) throw new ArgumentNullException(nameof(restaurants));
            if (string.IsNullOrWhiteSpace(cuisine)) throw new ArgumentException("Кухня не може бути порожньою");
            if (minRating < 0 || minRating > 5) throw new ArgumentOutOfRangeException(nameof(minRating), "Рейтинг має бути від 0 до 5");

            var filtered = new List<Restaurant>();
            foreach (var restaurant in restaurants)
            {
                if (restaurant.Cuisine.Equals(cuisine, StringComparison.OrdinalIgnoreCase) && restaurant.Rating >= minRating)
                {
                    filtered.Add(restaurant);
                }
            }
            return filtered;
        }
    }
    public class Program
    {
        public static void Main()
        {
        }
    }
}
