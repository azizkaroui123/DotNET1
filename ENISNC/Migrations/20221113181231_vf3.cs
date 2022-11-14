using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENISNC.Migrations
{
    /// <inheritdoc />
    public partial class vf3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandePFE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    demandedat = table.Column<string>(name: "demanded_at", type: "nvarchar(max)", nullable: false),
                    approvedat = table.Column<string>(name: "approved_at", type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandePFE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandePFE_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    demandedat = table.Column<string>(name: "demanded_at", type: "nvarchar(max)", nullable: false),
                    approvedat = table.Column<string>(name: "approved_at", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaperUser",
                columns: table => new
                {
                    papersId = table.Column<int>(type: "int", nullable: false),
                    usersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperUser", x => new { x.papersId, x.usersUserId });
                    table.ForeignKey(
                        name: "FK_PaperUser_Paper_papersId",
                        column: x => x.papersId,
                        principalTable: "Paper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperUser_users_usersUserId",
                        column: x => x.usersUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandePFE_UserId",
                table: "DemandePFE",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperUser_usersUserId",
                table: "PaperUser",
                column: "usersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandePFE");

            migrationBuilder.DropTable(
                name: "PaperUser");

            migrationBuilder.DropTable(
                name: "Paper");
        }
    }
}
