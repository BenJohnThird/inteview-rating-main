using MediatR;

namespace InterviewRating.Application.WorkExperiences.Commands.UploadLogo;

public class UploadLogoCommand : IRequest<string>
{
    public string FileName { get; set; } = default!;
    public Stream File { get; set; } = default!;
}
