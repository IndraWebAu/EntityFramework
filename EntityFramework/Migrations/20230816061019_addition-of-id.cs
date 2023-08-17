using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class additionofid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Factions_MyPropertyId",
                table: "CharacterFaction");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "CharacterFaction",
                newName: "FactionsId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterFaction_MyPropertyId",
                table: "CharacterFaction",
                newName: "IX_CharacterFaction_FactionsId");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Factions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Factions_FactionsId",
                table: "CharacterFaction",
                column: "FactionsId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Factions_FactionsId",
                table: "CharacterFaction");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Factions");

            migrationBuilder.RenameColumn(
                name: "FactionsId",
                table: "CharacterFaction",
                newName: "MyPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterFaction_FactionsId",
                table: "CharacterFaction",
                newName: "IX_CharacterFaction_MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Factions_MyPropertyId",
                table: "CharacterFaction",
                column: "MyPropertyId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
