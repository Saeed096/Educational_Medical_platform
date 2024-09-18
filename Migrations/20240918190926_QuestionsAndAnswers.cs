using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class QuestionsAndAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Questions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "BlogId", "CourseId", "Description", "SubCategoryId", "TestId" },
                values: new object[,]
                {
                    { 1, null, 1, "What is the basic unit of life?", null, null },
                    { 2, null, 1, "Which organelle is known as the powerhouse of the cell?", null, null },
                    { 3, null, 2, "What is the function of ribosomes?", null, null },
                    { 4, null, 2, "What is the role of the cell membrane?", null, null },
                    { 5, null, 2, "What is osmosis?", null, null },
                    { 6, null, null, "What is the primary function of the digestive system?", 1, null },
                    { 7, null, null, "How does the body absorb nutrients?", 1, null },
                    { 8, null, null, "What are the main components of the digestive system?", 2, null },
                    { 9, null, null, "What is the role of enzymes in digestion?", 2, null },
                    { 10, null, null, "What is the process of peristalsis?", 3, null },
                    { 11, 1, null, "What are the key structures of the human body?", null, null },
                    { 12, 1, null, "How does the muscular system work?", null, null },
                    { 13, 2, null, "What is the importance of studying anatomy?", null, null },
                    { 14, 2, null, "What are the different systems of the human body?", null, null },
                    { 15, 3, null, "What role does the nervous system play in body functions?", null, null }
                });

            migrationBuilder.InsertData(
                table: "StandardTests",
                columns: new[] { "Id", "DurationInMinutes", "Fullmark", "Title" },
                values: new object[,]
                {
                    { 1, 60, 100, "Test1" },
                    { 2, 100, 150, "Test2" },
                    { 3, 200, 300, "Test3" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Cell", true, 1 },
                    { 2, "Tissue", false, 1 },
                    { 3, "Organ", false, 1 },
                    { 4, "Mitochondria", true, 2 },
                    { 5, "Nucleus", false, 2 },
                    { 6, "Ribosome", false, 2 },
                    { 7, "Protein synthesis", true, 3 },
                    { 8, "Energy production", false, 3 },
                    { 9, "DNA replication", false, 3 },
                    { 10, "Protects the cell", true, 4 },
                    { 11, "Stores DNA", false, 4 },
                    { 12, "Produces energy", false, 4 },
                    { 13, "Movement of water", true, 5 },
                    { 14, "Transport of nutrients", false, 5 },
                    { 15, "Protein synthesis", false, 5 },
                    { 16, "Breaks down food", true, 6 },
                    { 17, "Circulates blood", false, 6 },
                    { 18, "Transports oxygen", false, 6 },
                    { 19, "Through the walls of the intestines", true, 7 },
                    { 20, "Via the bloodstream", false, 7 },
                    { 21, "By chewing", false, 7 },
                    { 22, "Mouth, esophagus, stomach", true, 8 },
                    { 23, "Brain, heart, lungs", false, 8 },
                    { 24, "Skin, muscles, bones", false, 8 },
                    { 25, "They speed up chemical reactions", true, 9 },
                    { 26, "They are absorbed", false, 9 },
                    { 27, "They break down food", false, 9 },
                    { 28, "The wave-like motion that moves food", true, 10 },
                    { 29, "The absorption of nutrients", false, 10 },
                    { 30, "The secretion of enzymes", false, 10 },
                    { 31, "Organs and systems", true, 11 },
                    { 32, "Cells only", false, 11 },
                    { 33, "Muscles only", false, 11 },
                    { 34, "By contracting and relaxing", true, 12 },
                    { 35, "By sending signals", false, 12 },
                    { 36, "By absorbing nutrients", false, 12 },
                    { 37, "To understand the human body", true, 13 },
                    { 38, "To pass exams", false, 13 },
                    { 39, "To perform surgeries", false, 13 },
                    { 40, "Nervous, muscular, skeletal", true, 14 },
                    { 41, "Respiratory, circulatory", false, 14 },
                    { 42, "Digestive, excretory", false, 14 },
                    { 43, "Controls body functions", true, 15 },
                    { 44, "Transports nutrients", false, 15 },
                    { 45, "Provides energy", false, 15 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "BlogId", "CourseId", "Description", "SubCategoryId", "TestId" },
                values: new object[,]
                {
                    { 16, null, null, "What is the primary function of red blood cells?", null, 1 },
                    { 17, null, null, "How does the immune system protect the body?", null, 1 },
                    { 18, null, null, "What are the stages of the cell cycle?", null, 2 },
                    { 19, null, null, "What is apoptosis?", null, 2 },
                    { 20, null, null, "What role does DNA play in inheritance?", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 46, "To carry oxygen", true, 16 },
                    { 47, "To fight infections", false, 16 },
                    { 48, "To clot blood", false, 16 },
                    { 49, "By recognizing pathogens", true, 17 },
                    { 50, "By producing energy", false, 17 },
                    { 51, "By storing nutrients", false, 17 },
                    { 52, "Interphase, mitosis, cytokinesis", true, 18 },
                    { 53, "Prophase, metaphase, anaphase", false, 18 },
                    { 54, "Meiosis only", false, 18 },
                    { 55, "Programmed cell death", true, 19 },
                    { 56, "Cell growth", false, 19 },
                    { 57, "Cell division", false, 19 },
                    { 58, "Carries genetic information", true, 20 },
                    { 59, "Produces energy", false, 20 },
                    { 60, "Fights diseases", false, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Questions");
        }
    }
}
