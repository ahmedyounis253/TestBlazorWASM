using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestBlazorWASM.Server.Migrations
{
    public partial class fixing1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "Upper(Concat(SubString([Role],1,1) + SubString([Name],1,1)+SubString([Name],3,3),Round([Age]*Round(RAND()*100,0)/(RAND()*10),0)))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "Upper(Concat(SubString([Role],1,1) + SubString([Name],1,1),Round([Age]*Round(RAND()*1000,0)/(RAND()*10),0)))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "Upper(Concat(SubString([Role],1,1) + SubString([Name],1,1),Round([Age]*Round(RAND()*1000,0)/(RAND()*10),0)))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "Upper(Concat(SubString([Role],1,1) + SubString([Name],1,1)+SubString([Name],3,3),Round([Age]*Round(RAND()*100,0)/(RAND()*10),0)))");
        }
    }
}
