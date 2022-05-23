using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Tests.Common;
using Notes.Persistence;
using AutoMapper;
using Shouldly;
using Xunit;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests : TestCommandBase
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture) =>
            (Context, Mapper) = (fixture.Context, fixture.Mapper);

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("8975D059-A9AD-4E70-85EB-4C079DA39CCE")
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }

    }
}
