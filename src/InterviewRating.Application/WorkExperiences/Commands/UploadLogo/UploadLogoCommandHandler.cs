using InterviewRating.Application.User;
using InterviewRating.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InterviewRating.Application.WorkExperiences.Commands.UploadLogo;

public class UploadLogoCommandHandler(
    ILogger<UploadLogoCommandHandler> logger,
    IUserContext userContext,
    IBlobStorageService blobStorageService
    ) : IRequestHandler<UploadLogoCommand, string>
{
    public async Task<string> Handle(UploadLogoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Uploading file {@request}", request);
        var logoUrl = await blobStorageService.UploadToBlobAsync(request.File, request.FileName);
        return logoUrl;
    }
}
