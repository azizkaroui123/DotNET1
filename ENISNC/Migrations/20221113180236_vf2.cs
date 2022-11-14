using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENISNC.Migrations
{
    /// <inheritdoc />
    public partial class vf2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sectionId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spacialitée = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    schoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_sectionId",
                table: "users",
                column: "sectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_DepartementId",
                table: "Section",
                column: "DepartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Section_sectionId",
                table: "users",
                column: "sectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Section_sectionId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropIndex(
                name: "IX_users_sectionId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "sectionId",
                table: "users");
        }
    }
}
