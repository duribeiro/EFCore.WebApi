﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebApi.Migrations
{
    public partial class HeroisBatalhas_Identidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroi_Batalhas_BatalhaId",
                table: "Heroi");

            migrationBuilder.DropIndex(
                name: "IX_Heroi_BatalhaId",
                table: "Heroi");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Heroi");

            migrationBuilder.CreateTable(
                name: "HeroisBatalhas",
                columns: table => new
                {
                    HeroiId = table.Column<int>(type: "int", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisBatalhas", x => new { x.BatalhaId, x.HeroiId });
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_Heroi_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Heroi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadesSecretas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadesSecretas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentidadesSecretas_Heroi_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Heroi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_HeroiId",
                table: "HeroisBatalhas",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas",
                column: "HeroiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroisBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadesSecretas");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Heroi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Heroi_BatalhaId",
                table: "Heroi",
                column: "BatalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroi_Batalhas_BatalhaId",
                table: "Heroi",
                column: "BatalhaId",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
