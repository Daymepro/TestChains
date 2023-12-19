using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnb.Platform.Services.Digital.FisGateway.BBP.Models;
using Cnb.Platform.Services.Digital.FisGateway.BBP.Response;
using Cnb.Platform.Services.Digital.FisGateway.WebApi.BBP;
using Cnb.Platform.Services.Digital.FisGateway.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

public class BBPControllerTests
{
    private Mock<ILogger<BBPController>> _loggerMock;
    private Mock<IElectronicPaymentsSoapClient> _serviceInterfaceMock;
    private Mock<IBbpOperations> _bbpOperationsMock;
    private Mock<IOptionsMonitor<ServiceConfig>> _serviceConfigsMock;

    public BBPControllerTests()
    {
        _loggerMock = new Mock<ILogger<BBPController>>();
        _serviceInterfaceMock = new Mock<IElectronicPaymentsSoapClient>();
        _bbpOperationsMock = new Mock<IBbpOperations>();
        _serviceConfigsMock = new Mock<IOptionsMonitor<ServiceConfig>>();
    }

    [Fact]
    public async Task EnrollCompany_ReturnsOkResult_WhenRequestIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var request = new BBPEnrollRequest();

        _bbpOperationsMock.Setup(x => x.EnrollCompany(request))
                         .ReturnsAsync(new GatewayResponse());

        
        var result = await controller.EnrollCompany(request);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<GatewayResponse>(okResult.Value);
    }

    [Fact]
    public async Task EnrollCompany_ReturnsBadRequest_WhenRequestIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.EnrollCompany(null);

        
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task AddUser_ReturnsOkResult_WhenRequestIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var request = new AdduserRequest();

        _bbpOperationsMock.Setup(x => x.AddUserAsync(request))
                         .ReturnsAsync(new GatewayResponse());

        
        var result = await controller.AddUser(request);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<GatewayResponse>(okResult.Value);
    }

    [Fact]
    public async Task AddUser_ReturnsBadRequest_WhenRequestIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.AddUser(null);

        
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task ApprovePayment_ReturnsOkResult_WhenParametersAreValid()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var userId = "sampleUserId";
        var paymentId = "samplePaymentId";

        _bbpOperationsMock.Setup(x => x.ApprovePayment(paymentId, userId))
                         .ReturnsAsync(new GatewayResponse());

        
        var result = await controller.ApprovePayment(userId, paymentId);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<GatewayResponse>(okResult.Value);
    }

    [Fact]
    public async Task ApprovePayment_ReturnsBadRequest_WhenParametersAreInvalid()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.ApprovePayment(null, null);

        
        Assert.IsType<BadRequestResult>(result);
    }

        [Fact]
    public async Task UserEntitlements_ReturnsOkResult_WhenResponseIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var companyId = "sampleCompanyId";
        var userId = "sampleUserId";

        _bbpOperationsMock.Setup(x => x.GetUserEntitlement(companyId, userId))
                         .ReturnsAsync(new UserEntitlementResponse()); // Provide expected response

        
        var result = await controller.UserEntitlements(companyId, userId);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<UserEntitlementResponse>(okResult.Value);
    }

    [Fact]
    public async Task UserEntitlements_ReturnsNotFoundResult_WhenResponseIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.UserEntitlements(null, null);

        
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task SetUserEntitlements_ReturnsOkResult_WhenResponseIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var request = new SetUserEntitlementRequest();

        _bbpOperationsMock.Setup(x => x.SetBBPUserEntitlements(request))
                         .ReturnsAsync(new SetUserEntitlementResponse()); // Provide expected response

        
        var result = await controller.SetUserEntitlements(request);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<SetUserEntitlementResponse>(okResult.Value);
    }

    [Fact]
    public async Task SetUserEntitlements_ReturnsNotFoundResult_WhenResponseIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.SetUserEntitlements(null);

        
        Assert.IsType<NotFoundResult>(result);
    }


    [Fact]
    public async Task ActivateCompany_ReturnsOkResult_WhenRequestIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var request = new BBPEnrollRequest();

        _bbpOperationsMock.Setup(x => x.ActivateCompany(request))
                         .ReturnsAsync(new GatewayResponse());

        
        var result = await controller.ActivateCompany(request);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<GatewayResponse>(okResult.Value);
    }

    [Fact]
    public async Task ActivateCompany_ReturnsBadRequest_WhenRequestIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.ActivateCompany(null);

        
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task DeactivateCompany_ReturnsOkResult_WhenConsumerIdIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var consumerId = "sampleConsumerId";

        _bbpOperationsMock.Setup(x => x.DeactivateCompany(consumerId))
                         .ReturnsAsync(true); // Provide expected response

        
        var result = await controller.DeactivateCompany(consumerId);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<bool>(okResult.Value);
    }

    [Fact]
    public async Task DeactivateCompany_ReturnsBadRequest_WhenConsumerIdIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.DeactivateCompany(null);

        
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task DeactivateCompanyExt_ReturnsOkResult_WhenConsumerIdIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var consumerId = "sampleConsumerId";

        _bbpOperationsMock.Setup(x => x.DeactivateCompanyExtAsync(consumerId))
                         .ReturnsAsync(new Tuple<bool, List<string>>(true, new List<string>())); // Provide expected response

        
        var result = await controller.DeactivateCompanyExt(consumerId);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<Tuple<bool, List<string>>>(okResult.Value);
    }

    [Fact]
    public async Task DeactivateCompanyExt_ReturnsBadRequest_WhenConsumerIdIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.DeactivateCompanyExt(null);

        
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task UpdateUserRole_ReturnsOkResult_WhenUserIdIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var companyId = "sampleCompanyId";
        var userId = "sampleUserId";

        _bbpOperationsMock.Setup(x => x.UpdateUserRole(companyId, userId.ToUpper(), true))
                         .ReturnsAsync(true); // Provide expected response

        
        var result = await controller.UpdateUserRole(companyId, userId);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<bool>(okResult.Value);
    }

    [Fact]
    public async Task UpdateUserRole_ReturnsBadRequest_WhenUserIdIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.UpdateUserRole(null, null);

        
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task SearchUserAsync_ReturnsOkResult_WhenUserIdIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var userId = "sampleUserId";

        _bbpOperationsMock.Setup(x => x.SearchBBPUserAsync(userId))
                         .ReturnsAsync(new SearchUserResponse()); // Provide expected response

        
        var result = await controller.SearchUserAsync(userId);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<SearchUserResponse>(okResult.Value);
    }

    [Fact]
    public async Task SearchUserAsync_ReturnsNotFoundResult_WhenUserIdIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.SearchUserAsync(null);

        
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateUser_ReturnsOkResult_WhenRequestIsNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var request = new UpdateUserRequest();

        _bbpOperationsMock.Setup(x => x.UpdateUserAsync(request))
                         .ReturnsAsync(new GatewayResponse());

        
        var result = await controller.UpdateUser(request);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<GatewayResponse>(okResult.Value);
    }

    [Fact]
    public async Task UpdateUser_ReturnsBadRequest_WhenRequestIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.UpdateUser(null);

        
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task DeleteUserAsync_ReturnsOkResult_WhenUserIdAndCompanyIdAreNotNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);
        var userId = "sampleUserId";
        var companyId = "sampleCompanyId";

        _bbpOperationsMock.Setup(x => x.DeleteBBPUserAsync(userId, companyId))
                         .ReturnsAsync(new DeleteUserResponse());

        
        var result = await controller.DeleteUserAsync(userId, companyId);

        
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<DeleteUserResponse>(okResult.Value);
    }

    [Fact]
    public async Task DeleteUserAsync_ReturnsNotFoundResult_WhenUserIdOrCompanyIdIsNull()
    {
        
        var controller = new BBPController(_loggerMock.Object, _serviceInterfaceMock.Object, _bbpOperationsMock.Object, _serviceConfigsMock.Object);

        
        var result = await controller.DeleteUserAsync(null, null);

        
        Assert.IsType<NotFoundResult>(result);
    }
    



}
