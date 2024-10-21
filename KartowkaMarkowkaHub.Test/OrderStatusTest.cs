using AutoFixture;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data;
using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.OrderStatuses;
using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;
using System.Linq.Expressions;

namespace KartowkaMarkowkaHub.Test
{
    public class OrderStatusTest
    {
        [Fact]
        public void GetStatusName_OrderId_ReturnsStatusName()
        {
            //Arrange
            string expectedStatusName = "В работе";
            var fixture = new Fixture();

            var orderStatus = fixture
                .Build<OrderStatus>()
                .With(s => s.Name, expectedStatusName)
                .With(s => s.StatusType, StatusType.InProcess)
                .Without(s => s.Orders)
                .Create();

            var order = fixture.Build<Order>()
                .With(o => o.OrderStatus, orderStatus)
                .Without(s => s.Product)
                .Without(s => s.Client)
                .Create();

            var mockHubContext = new Mock<HubContext>(new DbContextOptions<HubContext>());
            var mockOrderRepository = new Mock<GenericRepository<Order>>(mockHubContext.Object);
            mockOrderRepository
                .Setup(o => o.Get(It.IsAny<Expression<Func<Order, bool>>>(), null, typeof(OrderStatus).Name))
                .Returns([order]);
            var mockUnitOfWork = new Mock<UnitOfWork>(mockHubContext.Object);
            mockUnitOfWork.Setup(u => u.OrderRepository).Returns(mockOrderRepository.Object);
            var orderStatusService = new OrderStatusService(mockUnitOfWork.Object, Guid.NewGuid());

            //Act
            string statusName = orderStatusService.GetStatusName();

            //Assert
            statusName.Should().Be(expectedStatusName);
        }

        [Theory]
        [InlineData(StatusType.Created, StatusType.InProcess)]
        [InlineData(StatusType.InProcess, StatusType.ReadyToReceive)]
        [InlineData(StatusType.ReadyToReceive, StatusType.Completed)]
        public void SetNextStatus_OrderId_ReturnStatus(StatusType startStatus, StatusType endStatus)
        {
            //Arrange
            var fixture = new Fixture();

            var startOrderStatus = fixture
                .Build<OrderStatus>()
                .With(s => s.StatusType, startStatus)
                .Without(s => s.Orders)
                .Create();

            var endOrderStatus = fixture
                .Build<OrderStatus>()
                .With(s => s.StatusType, endStatus)
                .Without(s => s.Orders)
                .Create();

            var order = fixture
                .Build<Order>()
                .With(o => o.OrderStatus, startOrderStatus)
                .Without(s => s.Product)
                .Without(s => s.Client)
                .Create();

            var mockHubContext = new Mock<HubContext>(new DbContextOptions<HubContext>());
            var mockOrderRepository = new Mock<GenericRepository<Order>>(mockHubContext.Object);
            mockOrderRepository
                .Setup(o => o.Get(It.IsAny<Expression<Func<Order, bool>>>(), null, typeof(OrderStatus).Name))
                .Returns([order]);

            var mockOrderStatusRepository = new Mock<GenericRepository<OrderStatus>>(mockHubContext.Object);
            mockOrderStatusRepository
                .Setup(s => s.Get(It.IsAny<Expression<Func<OrderStatus, bool>>>(), null, ""))
                .Returns([endOrderStatus]);

            var mockUnitOfWork = new Mock<UnitOfWork>(mockHubContext.Object);
            mockUnitOfWork.Setup(u => u.OrderRepository).Returns(mockOrderRepository.Object);
            mockUnitOfWork.Setup(u => u.OrderStatusRepository).Returns(mockOrderStatusRepository.Object);

            var orderStatusService = new OrderStatusService(mockUnitOfWork.Object, Guid.NewGuid());

            //Act
            var statusType = orderStatusService.SetNextStatus();


            //Assert
            statusType.Should().Be(endStatus);
        }
    }
}