using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOEFileManager.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaveFile");

            migrationBuilder.CreateTable(
                name: "FileStorages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileCreatedUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FilePath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FileHidden = table.Column<bool>(type: "boolean", nullable: false),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FileExtension = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    FileContentType = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileAllowAnanymousAccess = table.Column<bool>(type: "boolean", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    FileDescription = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileStorages");

            migrationBuilder.CreateTable(
                name: "SaveFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileAllowAnanymousAccess = table.Column<bool>(type: "boolean", nullable: false),
                    FileContentType = table.Column<string>(type: "text", nullable: true),
                    FileCreatedUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FileDescription = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    FileExtension = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    FileHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    FileHidden = table.Column<bool>(type: "boolean", nullable: false),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FilePath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveFile", x => x.Id);
                });
        }
    }
}
