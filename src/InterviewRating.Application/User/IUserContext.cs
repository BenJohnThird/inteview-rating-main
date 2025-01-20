namespace InterviewRating.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}