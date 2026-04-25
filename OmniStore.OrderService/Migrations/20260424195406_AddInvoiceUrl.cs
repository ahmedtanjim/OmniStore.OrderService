using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniStore.OrderService.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceUrl",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceUrl",
                table: "Orders");
        }
    }
}
