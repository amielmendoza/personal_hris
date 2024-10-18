using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables10192024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Sites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Sites",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "EmployeeStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "EmployeeStatuses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "EmployeeStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "EmployeeLoanTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeLoanTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeLoanTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "EmployeeLoanTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "EmployeeLoanTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "EmployeeLoanStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeLoanStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeLoanStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "EmployeeLoanStatuses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "EmployeeLoanStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "EmployeeLeaveTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeLeaveTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeLeaveTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "EmployeeLeaveTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "EmployeeLeaveTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "EmployeeLeaveStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeLeaveStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeLeaveStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "EmployeeLeaveStatuses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "EmployeeLeaveStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ContractEndReasons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ContractEndReasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ContractEndReasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "ContractEndReasons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ContractEndReasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "EmployeeStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeStatuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeStatuses");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "EmployeeStatuses");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "EmployeeStatuses");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "EmployeeLoanTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeLoanTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeLoanTypes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "EmployeeLoanTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "EmployeeLoanTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "EmployeeLoanStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeLoanStatuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeLoanStatuses");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "EmployeeLoanStatuses");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "EmployeeLoanStatuses");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "EmployeeLeaveTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeLeaveTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeLeaveTypes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "EmployeeLeaveTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "EmployeeLeaveTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "EmployeeLeaveStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeLeaveStatuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeLeaveStatuses");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "EmployeeLeaveStatuses");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "EmployeeLeaveStatuses");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ContractEndReasons");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContractEndReasons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContractEndReasons");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ContractEndReasons");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ContractEndReasons");
        }
    }
}
