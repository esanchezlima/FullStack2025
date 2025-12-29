using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Service.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Author");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
