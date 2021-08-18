using System;
using Moq;
using NUnit.Framework;
using StoreManagement.BL;
using StoreManagement.Models;
using StoreManagemnt.DB;
using System.Threading.Tasks;

namespace FirstNUnitTest
{
    public class BLLoginTest
    {
        private ICustomerData _customerData;

        private void Setup(string email, string passWord)
        {
            var mockICustomerData = new Mock<ICustomerData>();

            mockICustomerData
                .Setup(repo => repo.LoginCustomer(email, passWord))
                .Returns(Task.FromResult(new Customer { Email = email, Password = passWord }));

            _customerData = mockICustomerData.Object;
        }

        [Test]
        public async Task CustomerAction_LoginCustomer_Method_When_Successful()
        {
            //Arrange
            string email = "doe@gmail.com";
            string passWord = "doe123_";

            Setup(email, passWord);
            CustomerActions customerActions = new CustomerActions(_customerData);
           
            //Act
            Customer customer = await customerActions.LoginCustomer(email, passWord);

            //Assert
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.Email, email);
            Assert.AreEqual(customer.Password, passWord);

        }

        [Test]
        public void CustomerActions_LoginCustomer_Method_When_Not_Successful()
        {
            //Arrange
            Setup();
            CustomerActions customerActions = new CustomerActions(_customerData);
            string email = "doe@gmail.com";
            string passWord = "doe123_";

            //Act & Assert
            Assert.ThrowsAsync<TimeoutException>( 
                async () =>
           await CustomerActions.LoginCustomer(email, passWord)
           );


            Assert.That(
                async ()=> await
                CustomerActions.LoginCustomer(email, passWord),

                Throws.InstanceOf(typeof(TimeoutException))
            );
        }
    }
}