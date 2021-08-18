using Moq;
using NUnit.Framework;
using Management.BL;
using Management.Models;
using Managemnt.DB;
using System.Threading.Tasks;

namespace FirstNUnitTest
{
    public class UnitTest_Customer
    {
        private ICustomerData customerData;
        public void Setup(bool val)
        {
            var mock = new Mock<ICustomerData>();
            mock.Setup(x => x.Add(It.IsAny<Customer>())).Returns(Task.FromResult(val));
            dataStore = mock.Object;
        }

        [Test]
        public async Task UnitTest()
        {
            Setup(true);
            //Arrange
            var bl = new CustomerActions(customerData);
            var firstName = "John";
            var lastName = "Doe";
            var email = "John@gmail.com";
            var passWord = "Doe123_";

            var expected = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = passWord
            };

            //Act
            var actual = await bl.RegisterCustomer(firstName, lastName, email, passWord);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.IsInstanceOf<Customer>(actual);
        }
    }
}
