using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewRating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedReviewTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Reviews");
        }
    }
}
