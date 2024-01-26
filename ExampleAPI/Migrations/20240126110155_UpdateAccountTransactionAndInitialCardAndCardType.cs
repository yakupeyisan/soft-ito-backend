using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountTransactionAndInitialCardAndCardType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransactions_Users_UserId",
                table: "AccountTransactions");
            migrationBuilder.DropIndex(
                name: "IX_AccountTransactions_UserId",
                table: "AccountTransactions");
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccountTransactions");

            migrationBuilder.AddColumn<Guid>(
                name: "CardId",
                table: "AccountTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardUID = table.Column<long>(type: "bigint", nullable: false),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_CardTypes_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_CardId",
                table: "AccountTransactions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeId",
                table: "Cards",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            /*
             migrationBuilder.AddForeignKey(
                name: "FK_AccountTransactions_Cards_CardId",
                table: "AccountTransactions",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction); */

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransactions_Cards_CardId",
                table: "AccountTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransactions_Users_UserId",
                table: "AccountTransactions");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransactions_CardId",
                table: "AccountTransactions");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "AccountTransactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AccountTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransactions_Users_UserId",
                table: "AccountTransactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
