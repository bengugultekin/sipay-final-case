using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class FixedMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReaded",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReaded",
                table: "Messages");
        }
    }
}
