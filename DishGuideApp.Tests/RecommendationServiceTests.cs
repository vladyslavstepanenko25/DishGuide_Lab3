using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DishGuideApp.Tests
{
    [TestFixture]
    public class RecommendationServiceTests
    {
        private RecommendationService _service;  

        [SetUp]
        public void Setup()
        {
            _service = new RecommendationService();
        }

        [Test]
        public void CalculateAverageRating_ValidReviews_ReturnsAverage()
        {
            var reviews = new List<Review>
            {
                new Review { Rating = 4 },
                new Review { Rating = 5 }
            };

            var result = _service.CalculateAverageRating(reviews);

            // Використовуємо сучасний синтаксис NUnit (він працює завжди)
            Assert.That(result, Is.EqualTo(4.5));
        }

        [Test]
        public void CalculateAverageRating_EmptyList_ReturnsZero()
        {
            var reviews = new List<Review>();
            var result = _service.CalculateAverageRating(reviews);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateAverageRating_NullList_ThrowsArgumentNullException()
        {
            // Arrange (EP - негативний, null)
            List<Review> reviews = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _service.CalculateAverageRating(reviews));
        }

        [Test]
        public void CalculateAverageRating_InvalidRating_ThrowsArgumentException()
        {
            // Arrange (BVA - негативний, вихід за межі 1-5)
            var reviews = new List<Review> { new Review { Rating = 6 } };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateAverageRating(reviews));
        }

        // --- ТЕСТИ ДЛЯ GetTopDishes ---

        [Test]
        public void GetTopDishes_ValidCount_ReturnsSortedTopDishes()
        {
            // Arrange (EP - позитивний)
            var dishes = new List<Dish>
        {
            new Dish { Name = "Борщ", Rating = 4.8 },
            new Dish { Name = "Вареники", Rating = 4.2 },
            new Dish { Name = "Сало", Rating = 4.9 }
        };

            // Act
            var result = _service.GetTopDishes(dishes, 2);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Name, Is.EqualTo("Сало"));
            Assert.That(result[1].Name, Is.EqualTo("Борщ"));
        }

        [Test]
        public void GetTopDishes_CountGreaterThanListSize_ReturnsAllSortedDishes()
        {
            // Arrange (BVA - позитивний, count більше за розмір списку)
            var dishes = new List<Dish> { new Dish { Name = "Борщ", Rating = 4.5 } };

            // Act
            var result = _service.GetTopDishes(dishes, 5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetTopDishes_NegativeCount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange (BVA - негативний)
            var dishes = new List<Dish>();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetTopDishes(dishes, -1));
        }

        // --- ТЕСТИ ДЛЯ FilterRestaurants ---

        [Test]
        public void FilterRestaurants_ValidParameters_ReturnsFilteredList()
        {
            // Arrange (EP - позитивний)
            var restaurants = new List<Restaurant>
        {
            new Restaurant { Name = "Пузата Хата", Cuisine = "Ukrainian", Rating = 4.5 },
            new Restaurant { Name = "Сушія", Cuisine = "Japanese", Rating = 4.0 },
            new Restaurant { Name = "Хутірець", Cuisine = "ukrainian", Rating = 3.5 }
        };

            // Act
            var result = _service.FilterRestaurants(restaurants, "Ukrainian", 4.0);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("Пузата Хата"));
        }

        [Test]
        public void FilterRestaurants_RatingAboveFive_ThrowsArgumentOutOfRangeException()
        {
            // Arrange (BVA - негативний, рейтинг > 5.0)
            var restaurants = new List<Restaurant>();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.FilterRestaurants(restaurants, "Italian", 5.1));
        }

        [Test]
        public void FilterRestaurants_EmptyCuisine_ThrowsArgumentException()
        {
            // Arrange (EP - негативний)
            var restaurants = new List<Restaurant>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.FilterRestaurants(restaurants, "", 4.0));
        }

        [Test]
        public void FilterRestaurants_NoMatches_ReturnsEmptyList()
        {
            // Arrange (EP - позитивний, немає збігів)
            var restaurants = new List<Restaurant>
        {
            new Restaurant { Name = "Сушія", Cuisine = "Japanese", Rating = 4.0 }
        };

            // Act
            var result = _service.FilterRestaurants(restaurants, "Italian", 3.0);

            // Assert
            Assert.That(result, Is.Empty);
        }
    }
}
