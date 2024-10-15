using AppProcessing;

namespace AppProcessingTest
{
    public class CarAdvertisementsTests
    {
        [Test]
        public async Task AddCar_CarIsAdded_ReturnsTrue()
        {
            // Arrange
            CarAdvertisements carAdvertisements = CarAdvertisements.Instance;
            AdvertisementElement car = new AdvertisementElement()
            {
                Id = "123",
                Name = "Test Car",
                Price = "10000",
                MileAge = "15000",
                CarType = "Sedan",
                Views = 500,
                ImageUrl = "car.jpg",
                AuthorLogin = "author123"
            };

            // Act
            await carAdvertisements.AddCar(car);

            // Assert
            Assert.IsTrue(carAdvertisements.carWasAdd);
        }

        [Test]
        public void UpdateAllCars_CarsUpdated_ReturnsTrue()
        {
            // Arrange
            CarAdvertisements carAdvertisements = CarAdvertisements.Instance;

            // Act
            bool result = carAdvertisements.updateAllCars();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UpdateOneCar_CarDoesNotExist_ReturnsFalse()
        {
            // Arrange
            CarAdvertisements carAdvertisements = CarAdvertisements.Instance;
            AdvertisementElement car = new AdvertisementElement()
            {
                Id = "999", // Не существующий ID
                Name = "Non-existent Car",
                Price = "15000",
                MileAge = "5000",
                CarType = "Coupe",
                Views = 100,
                ImageUrl = "nonexistent.jpg",
                AuthorLogin = "author123"
            };

            // Act
            await carAdvertisements.UpdateOneCar(car);

            // Assert
            Assert.IsFalse(carAdvertisements.carsWasUpdated);
        }

        [Test]
        public async Task UpdateOneCar_WithInvalidData_ReturnsFalse()
        {
            // Arrange
            CarAdvertisements carAdvertisements = CarAdvertisements.Instance;
            AdvertisementElement car = new AdvertisementElement()
            {
                Id = "123",
                Name = "Test Car",
                Price = "10000",
                MileAge = "15000",
                CarType = "Sedan",
                Views = 500,
                ImageUrl = "car.jpg",
                AuthorLogin = "author123"
            };

            carAdvertisements.AddCar(car);

            // Изменяем данные на некорректные (например, пустая строка для цены)
            car.Price = ""; // Неправильное значение

            // Act
            await carAdvertisements.UpdateOneCar(car);

            // Assert
            Assert.IsFalse(carAdvertisements.carsWasUpdated); // В зависимости от реализации, ожидаем, что результат будет false
        }
    }
}
