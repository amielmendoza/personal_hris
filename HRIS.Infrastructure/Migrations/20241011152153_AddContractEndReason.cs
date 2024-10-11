using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContractEndReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractEndReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEndReasons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractEndReasonId",
                table: "Employees",
                column: "ContractEndReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEndReasons_Name",
                table: "ContractEndReasons",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ContractEndReasons_ContractEndReasonId",
                table: "Employees",
                column: "ContractEndReasonId",
                principalTable: "ContractEndReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ContractEndReasons_ContractEndReasonId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ContractEndReasons");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractEndReasonId",
                table: "Employees");
        }
    }
}
