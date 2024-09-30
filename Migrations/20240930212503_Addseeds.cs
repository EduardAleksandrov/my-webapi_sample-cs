using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webone.Migrations
{
    /// <inheritdoc />
    public partial class Addseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id_department = table.Column<Guid>(type: "uuid", nullable: false),
                    Dep_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Dep_manager = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Auto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id_department);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id_department", "Dep_manager", "Dep_name" },
                values: new object[,]
                {
                    { new Guid("072fa384-7167-4fdd-bada-82c1fab0a936"), "Феликсов Алексей Сергеевич", "финансовый отдел" },
                    { new Guid("76ba7ada-5a47-43ff-bbf0-c6e7e0231cae"), "Кирьянов Алексей Сергеевич", "финансовый отдел" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
