using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DY.Inferastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class EditEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "Courses",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "CourseUrl",
                table: "Courses",
                type: "varchar(1000)",
                unicode: false,
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "Desctiption");

            migrationBuilder.AlterColumn<string>(
                name: "CourseUrl",
                table: "Courses",
                type: "varchar(1000)",
                unicode: false,
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000);
        }
    }
}
