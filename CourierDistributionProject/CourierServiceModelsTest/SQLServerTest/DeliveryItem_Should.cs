using CourierService.DbContext.SQLServer;
using CourierService.Models.SQLServer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServiceModelsTest.SQLServerTest
{
    [TestFixture]
    public class DeliveryItem_Should
    {
        [Test]
        public void DoSomting()
        {
            var formAdderMock = new Mock<IFormAdder>();
            var dbContMock = new Mock<ICorierServiceContext>();
            var sut = new DeliveryItem(dbContMock.Object, formAdderMock.Object);

            //dbContMock.Setup(s => s.)
            formAdderMock.Setup(s => s.AddOfficeToForm(dbContMock.Object)).Returns(new List<string>() { "Pesho", "Gosho" });

            sut.declareItem();
        }
    }
}
