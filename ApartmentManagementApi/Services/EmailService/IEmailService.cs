using ApartmentManagementApi.Models;

namespace ApartmentManagementApi.Services;

public interface IEmailService
{
    void SendEmail(EmailDto request);
}
