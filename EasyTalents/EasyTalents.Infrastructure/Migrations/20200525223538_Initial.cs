using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTalents.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BestTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Skype = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Linkedin = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Portfolio = table.Column<string>(nullable: true),
                    SalaryRequirements = table.Column<int>(nullable: false),
                    ExtraKnowledges = table.Column<string>(nullable: true),
                    CrudUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knowledge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateBestTimes",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(nullable: false),
                    BestTimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateBestTimes", x => new { x.CandidateId, x.BestTimeId });
                    table.ForeignKey(
                        name: "FK_CandidateBestTimes_BestTime_BestTimeId",
                        column: x => x.BestTimeId,
                        principalTable: "BestTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateBestTimes_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateKnowledges",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(nullable: false),
                    KnowledgeId = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateKnowledges", x => new { x.CandidateId, x.KnowledgeId });
                    table.ForeignKey(
                        name: "FK_CandidateKnowledges_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateKnowledges_Knowledge_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalTable: "Knowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateWorkingTimes",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(nullable: false),
                    WorkingTimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateWorkingTimes", x => new { x.CandidateId, x.WorkingTimeId });
                    table.ForeignKey(
                        name: "FK_CandidateWorkingTimes_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateWorkingTimes_WorkingTime_WorkingTimeId",
                        column: x => x.WorkingTimeId,
                        principalTable: "WorkingTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BestTime",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" },
                    { 2, "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)" },
                    { 3, "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)" },
                    { 4, "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)" },
                    { 5, "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)" }
                });

            migrationBuilder.InsertData(
                table: "Knowledge",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 22, "Express - NodeJs" },
                    { 23, "Cake" },
                    { 24, "Django" },
                    { 25, "Majento" },
                    { 26, "PHP" },
                    { 27, "Vue" },
                    { 28, "Wordpress" },
                    { 29, "Phyton" },
                    { 31, "My SQL Server" },
                    { 21, "NodeJS" },
                    { 32, "My SQL" },
                    { 33, "Salesforce" },
                    { 34, "Photoshop" },
                    { 35, "Illustrator" },
                    { 36, "SEO" },
                    { 37, "Laravel" },
                    { 30, "Ruby" },
                    { 20, "C#" },
                    { 19, "C" },
                    { 18, "Asp.Net WebForm" },
                    { 1, "Ionic" },
                    { 2, "ReactJS" },
                    { 3, "React Native" },
                    { 4, "Android" },
                    { 5, "Flutter" },
                    { 6, "SWIFT" },
                    { 8, "HTML" },
                    { 9, "CSS" },
                    { 7, "IOS" },
                    { 11, "Jquery" },
                    { 12, "AngularJs 1.*" },
                    { 13, "Angular" },
                    { 14, "Java" },
                    { 15, "Python" },
                    { 16, "Flask" },
                    { 17, "Asp.Net MVC" },
                    { 10, "Bootstrap" }
                });

            migrationBuilder.InsertData(
                table: "WorkingTime",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 4, "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)" },
                    { 1, "Up to 4 hours per day / Até 4 horas por dia" },
                    { 2, "4 to 6 hours per day / De 4 á 6 horas por dia" },
                    { 3, "6 to 8 hours per day /De 6 á 8 horas por dia" },
                    { 5, "Only weekends / Apenas finais de semana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateBestTimes_BestTimeId",
                table: "CandidateBestTimes",
                column: "BestTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKnowledges_KnowledgeId",
                table: "CandidateKnowledges",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateWorkingTimes_WorkingTimeId",
                table: "CandidateWorkingTimes",
                column: "WorkingTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateBestTimes");

            migrationBuilder.DropTable(
                name: "CandidateKnowledges");

            migrationBuilder.DropTable(
                name: "CandidateWorkingTimes");

            migrationBuilder.DropTable(
                name: "BestTime");

            migrationBuilder.DropTable(
                name: "Knowledge");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "WorkingTime");
        }
    }
}
