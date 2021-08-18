using Moq;
using NUnit.Framework;
using Management.BL;
using SManagement.Models;
using Managemnt.DB;
using System.Threading.Tasks;

namespace FirstNUnitTest
{
    public class UnitTest_Store
    {
        private IDataStore dataStore;
        public void Setup(bool val)
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(x => x.Add(It.IsAny<Store>())).Returns(Task.FromResult(val));
            dataStore = mock.Object;
        }

        [Test]
        public async Task UnitTest1()
        {
            Setup(true);
            //Arrange
            var bl = new Kiosk(dataStore);
            var storeType = "Kiosk";
            var storeName = "First";
            var storeId = "2345678";
            var product = "1";

            var expected = new Store
            {
                StoreType = storeType,
                StoreName = storeName,
                StoreId = storeId,
                Product = product
            };

            //Act
            var actual = await bl.CreateStore(storeType, storeName, storeId, product);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.StoreType, actual.StoreType);
            Assert.AreEqual(expected.StoreName, actual.StoreName);
            Assert.AreEqual(expected.StoreId, actual.StoreId);
            Assert.AreEqual(expected.Product, actual.Product);
            Assert.IsInstanceOf<Store>(actual);
        }

        //testing for supermarket
        // [Test]
        // public async Task UnitTest2()
        // {
        //     Setup(true);
            //Arrange
            // var bl = new Supermarket(dataStore);
            // var storeType = "Supermarket";
            // var storeName = "Second";
            // var storeId = "2345678";
            // var product = "2";

            // var expected = new Store
            // {
            //     StoreType = storeType,
            //     StoreName = storeName,
            //     StoreId = storeId,
            //     Product = product
            // };

            //Act
            // var actual = await bl.CreateStore(storeType, storeName, storeId, product);

            // //Assert
            // Assert.IsNotNull(actual);
            // Assert.AreEqual(expected.StoreType, actual.StoreType);
            // Assert.AreEqual(expected.StoreName, actual.StoreName);
            // Assert.AreEqual(expected.StoreId, actual.StoreId);
            // Assert.AreEqual(expected.Product, actual.Product);
            // Assert.IsInstanceOf<Store>(actual);
        // }

        [Test]
        public async Task UnitTest2()
        {
            Setup(true);
            //Arrange
            var bl = new Kiosk(dataStore);
            var product = "1";

            var expected = new Store
            {
                Product = product
            };

            //Act
            var actual = await bl.AddProducts(product);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Product, actual.Product);
            Assert.IsInstanceOf<Store>(actual);
        }

        [Test]
        public async Task UnitTest3()
        {
            Setup(true);
            //Arrange
            var bl = new Kiosk(dataStore);
            var product = "1";

            var expected = new Store
            {
                Product = product
            };

            //Act
            var actual = await bl.RemoveProducts(product);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Product, actual.Product);
            Assert.IsInstanceOf<Store>(actual);
        }

        [Test]
        public async Task UnitTest4()
        {
            Setup(true);
            //Arrange
            var bl = new Kiosk(dataStore);
            var storeType = "Kiosk";
            var storeName = "First";
            var storeId = "2345678";
            var product = "1";

            var expected = new Store
            {
                StoreType = storeType,
                StoreName = storeName,
                StoreId = storeId,
                Product = product
            };

            //Act
            var actual = await bl.GetStoreDetails(storeType, storeName, storeId, product);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.StoreType, actual.StoreType);
            Assert.AreEqual(expected.StoreName, actual.StoreName);
            Assert.AreEqual(expected.StoreId, actual.StoreId);
            Assert.AreEqual(expected.Product, actual.Product);
            Assert.IsInstanceOf<Store>(actual);
        }
    }
}
