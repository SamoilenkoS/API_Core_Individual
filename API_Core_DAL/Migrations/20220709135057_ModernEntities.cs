using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Core_DAL.Migrations
{
    public partial class ModernEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DelayPrice",
                table: "Libraries",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "BookRevisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PagesCount = table.Column<int>(type: "int", nullable: false),
                    PublishedCount = table.Column<int>(type: "int", nullable: false),
                    LostPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRevisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRevisions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountTotal = table.Column<int>(type: "int", nullable: false),
                    CountBorrowed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryBooks_BookRevisions_RevisionId",
                        column: x => x.RevisionId,
                        principalTable: "BookRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryBooks_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryRents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryRents_BookRevisions_BookRevisionId",
                        column: x => x.BookRevisionId,
                        principalTable: "BookRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryRents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryRents_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRevisions_BookId",
                table: "BookRevisions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBooks_LibraryId",
                table: "LibraryBooks",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBooks_RevisionId",
                table: "LibraryBooks",
                column: "RevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryRents_BookRevisionId",
                table: "LibraryRents",
                column: "BookRevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryRents_ClientId",
                table: "LibraryRents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryRents_LibraryId",
                table: "LibraryRents",
                column: "LibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryBooks");

            migrationBuilder.DropTable(
                name: "LibraryRents");

            migrationBuilder.DropTable(
                name: "BookRevisions");

            migrationBuilder.AlterColumn<decimal>(
                name: "DelayPrice",
                table: "Libraries",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
