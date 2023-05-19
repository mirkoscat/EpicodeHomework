using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcheched : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Images_ImageId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ImageId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagStatus",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "ImageTag",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTag", x => new { x.ImagesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ImageTag_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageTag_TagsId",
                table: "ImageTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageTag");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagStatus",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ImageId",
                table: "Tags",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Images_ImageId",
                table: "Tags",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
