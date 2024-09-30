using AppProcessing;
using NUnit.Framework;

namespace AppProcessingTest
{
    public class PersonCollectionTests
    {
        [Test]
        public void CheckCorrectPerson_ValidLoginAndPassword_ReturnsTrue()
        {
            // Arrange
            PersonCollection personCollection = PersonCollection.Instance;
            PersonElement person = new PersonElement()
            {
                Name = "Test User",
                Login = "testlogin",
                Password = "password123",
                Views = 100
            };
            personCollection.AddPerson(person);

            // Act
            bool result = personCollection.CheckCorrectPerson("testlogin", "password123");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckCorrectPerson_InvalidLogin_ReturnsFalse()
        {
            // Arrange
            PersonCollection personCollection = PersonCollection.Instance;

            // Act
            bool result = personCollection.CheckCorrectPerson("invalidlogin", "password123");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void LoginIsUnique_UniqueLogin_ReturnsTrue()
        {
            // Arrange
            PersonCollection personCollection = PersonCollection.Instance;

            // Act
            bool result = personCollection.LoginIsUnique("newlogin");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void LoginIsUnique_ExistingLogin_ReturnsFalse()
        {
            // Arrange
            PersonCollection personCollection = PersonCollection.Instance;
            PersonElement person = new PersonElement()
            {
                Name = "Test User",
                Login = "existinglogin",
                Password = "password123",
                Views = 100
            };
            personCollection.AddPerson(person);

            // Act
            bool result = personCollection.LoginIsUnique("existinglogin");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void AddPerson_PersonIsAdded_ReturnsTrue()
        {
            // Arrange
            PersonCollection personCollection = PersonCollection.Instance;
            PersonElement person = new PersonElement()
            {
                Name = "New User",
                Login = "newuser",
                Password = "newpassword",
                Views = 50
            };

            // Act
            bool result = personCollection.AddPerson(person);

            // Assert
            Assert.IsTrue(result);
        }
    }
}