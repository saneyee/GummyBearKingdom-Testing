using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GummyBearKingdom.Migrations
{
    public partial class ReviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                });

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Properties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ReviewId",
                table: "Properties",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Review_ReviewId",
                table: "Properties",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Review_ReviewId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ReviewId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
