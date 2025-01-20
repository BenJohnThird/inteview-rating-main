using Xunit;
using interview_rating.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using InterviewRating.Domain.Exceptions;
using InterviewRating.Domain.Entities;
using FluentAssertions;

namespace interview_rating.Middleware.Tests
{
    public class ErrorHandlingMiddlewareTests
    {
        [Fact()]
        public async void InvokeAsync_WhenNoExceptionThrown_ShouldCallDelegate()
        {
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
            var context = new DefaultHttpContext();
            var nextDelegateMock = new Mock<RequestDelegate>();

            // Act
            await middleware.InvokeAsync(context, nextDelegateMock.Object);

            // Assert
            nextDelegateMock.Verify(next => next.Invoke(context), Times.Once);
        }

        [Fact()]
        public async void InvokeAsync_WhenNotFoundException_ShouldThrowError()
        {
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
            var context = new DefaultHttpContext();
            var notFoundException = new NotFoundException(nameof(WorkExperience), "1");
 
            // Act
            await middleware.InvokeAsync(context, _ => throw notFoundException);

            // Assert
            context.Response.StatusCode.Should().Be(404);
        }
    }
}