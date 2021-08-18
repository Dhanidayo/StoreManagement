using System;
using Moq;
using NUnit.Framework;
using StoreManagement.BL;
using StoreManagement.Models;
using StoreManagemnt.DB;
using System.Threading.Tasks;

namespace FirstNUnitTest
{
    public class BLTest
    {
         private ICustomerData _customerData;

        private void Setup(bool value = false)
        {
            var mockICustomerData = new Mock<ICustomerData>();

            mockICustomerData
                .Setup(repo => repo.Add(It.IsAny<Customer>()))
                .Returns(Task.FromResult(value));

            _customerData = mockICustomerData.Object;
        }

        [Test]
        public async Task CustomerActions_RegisterCustomer_Method_When_Successful()
        {
            //Arrange
            Setup(true);
            CustomerActions customerActions = new CustomerActions(_customerData);
            string firstName = "Mikel";
            string lastName = "Obi";
            string email = "mikelobi@gmail.com";
            string passWord = "mikel1234";

            //Act
            Customer customer = await CustomerActions.RegisterCustomer(firstName, lastName, email, passWord);

            //Assert
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.FirstName, firstName);
            Assert.AreEqual(customer.LastName, lastName);
            Assert.AreEqual(customer.Email, email);
            Assert.AreEqual(customer.Password, passWord);
        }

        [Test]
        public void CustomerActions_RegisterCustomer_Method_When_Not_Successful()
        {
            //Arrange
            Setup();
            CustomerActions customerActions = new CustomerActions(_customerData);
            string firstName = "Mikel";
            string lastName = "Obi";
            string email = "mikelobi@gmail.com";
            string passWord = "mikel1234";

            //Act & Assert
            Assert.ThrowsAsync<TimeoutException>( 
                async () =>
           await CustomerActions.RegisterCustomer(firstName, lastName, email, passWord)
           );


            Assert.That(
                async ()=> await
                CustomerActions.RegisterCustomer(firstName, lastName, email, passWord),

                Throws.InstanceOf(typeof(TimeoutException))
            );
        }
    }
}