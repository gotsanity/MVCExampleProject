using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCExampleProject.Migrations
{
    public partial class fixedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Todos_TodoItemId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "TodoItemId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Todos_TodoItemId",
                table: "Comments",
                column: "TodoItemId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Todos_TodoItemId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "TodoItemId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Todos_TodoItemId",
                table: "Comments",
                column: "TodoItemId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
