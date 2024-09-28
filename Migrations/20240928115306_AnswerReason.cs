using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class AnswerReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reason",
                value: "Cells are the basic building blocks of life.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reason",
                value: "Tissues are made up of cells, but they are not the smallest unit of life.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Reason",
                value: "Organs are composed of tissues, which consist of cells.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Reason",
                value: "Mitochondria are known as the powerhouse of the cell.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Reason",
                value: "The nucleus contains the cell's genetic material, but does not produce energy.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Reason",
                value: "Ribosomes are responsible for protein synthesis, not energy production.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Reason",
                value: "This is the primary function of ribosomes in the cell.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Reason",
                value: "Energy production occurs in the mitochondria, not during protein synthesis.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Reason",
                value: "DNA replication is a separate process from protein synthesis.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Reason",
                value: "The cell membrane protects the cell from its environment.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Reason",
                value: "DNA is stored in the nucleus, not the cell membrane.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Reason",
                value: "Energy production occurs in mitochondria, not the cell membrane.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Reason",
                value: "Osmosis is the movement of water across a membrane.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Reason",
                value: "Nutrient transport occurs via active and passive transport mechanisms, not osmosis.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Reason",
                value: "Protein synthesis involves ribosomes, not the movement of water.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 16,
                column: "Reason",
                value: "The digestive system's primary role is to break down food.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 17,
                column: "Reason",
                value: "Blood circulation is the role of the circulatory system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 18,
                column: "Reason",
                value: "Oxygen transport is handled by the respiratory system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 19,
                column: "Reason",
                value: "Nutrients are absorbed through the intestinal walls into the bloodstream.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 20,
                column: "Reason",
                value: "The bloodstream transports nutrients after they are absorbed.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 21,
                column: "Reason",
                value: "Chewing is part of the mechanical digestion process, not nutrient absorption.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 22,
                column: "Reason",
                value: "These are the primary organs involved in the digestive process.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 23,
                column: "Reason",
                value: "These organs are not directly involved in digestion.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 24,
                column: "Reason",
                value: "These are not part of the digestive system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 25,
                column: "Reason",
                value: "Enzymes are biological catalysts that accelerate chemical reactions.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 26,
                column: "Reason",
                value: "Enzymes are not absorbed; they assist in reactions.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 27,
                column: "Reason",
                value: "While enzymes help in breaking down food, they do not do so independently.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 28,
                column: "Reason",
                value: "Peristalsis is the wave-like motion that moves food through the digestive tract.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 29,
                column: "Reason",
                value: "Nutrient absorption occurs after food is moved through the digestive tract.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 30,
                column: "Reason",
                value: "Enzyme secretion assists in digestion but is not the motion that moves food.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 31,
                column: "Reason",
                value: "These are the correct components when discussing body structures.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 32,
                column: "Reason",
                value: "Cells are part of organs and systems, not the only component.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 33,
                column: "Reason",
                value: "Muscles are just one type of tissue, which is part of organs and systems.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 34,
                column: "Reason",
                value: "Muscles work by contracting and relaxing to produce movement.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 35,
                column: "Reason",
                value: "While signaling is important, it does not describe how muscles function directly.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 36,
                column: "Reason",
                value: "Muscles do not absorb nutrients; this is a function of the digestive system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 37,
                column: "Reason",
                value: "Anatomy is studied to understand the structure and function of the body.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 38,
                column: "Reason",
                value: "While exams may test knowledge, they are not the purpose of studying anatomy.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 39,
                column: "Reason",
                value: "While anatomy knowledge is important for surgeries, it is not the sole purpose of the study.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 40,
                column: "Reason",
                value: "These are major body systems.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 41,
                column: "Reason",
                value: "While important, they do not encompass all major systems.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 42,
                column: "Reason",
                value: "These systems are essential but are not all-inclusive of body systems.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 43,
                column: "Reason",
                value: "The nervous system regulates bodily functions.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 44,
                column: "Reason",
                value: "Nutrient transport is handled by the circulatory system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 45,
                column: "Reason",
                value: "Energy provision is not a primary role of the nervous system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 46,
                column: "Reason",
                value: "Hemoglobin in red blood cells carries oxygen.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 47,
                column: "Reason",
                value: "Fighting infections is primarily the role of the immune system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 48,
                column: "Reason",
                value: "Blood clotting is done by platelets and certain plasma proteins.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 49,
                column: "Reason",
                value: "The immune system identifies and targets pathogens.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 50,
                column: "Reason",
                value: "Energy production is not a function of the immune system.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 51,
                column: "Reason",
                value: "Nutrient storage is a function of the liver and other organs.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 52,
                column: "Reason",
                value: "These are the stages of the cell cycle.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 53,
                column: "Reason",
                value: "These terms refer to stages of mitosis, not the entire cell cycle.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 54,
                column: "Reason",
                value: "Meiosis is a specific type of cell division, separate from the cell cycle.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 55,
                column: "Reason",
                value: "Apoptosis is the process of programmed cell death.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 56,
                column: "Reason",
                value: "Cell growth is a separate process from apoptosis.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 57,
                column: "Reason",
                value: "Cell division is the process of replicating cells, distinct from programmed cell death.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 58,
                column: "Reason",
                value: "DNA is the molecule that carries genetic information.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 59,
                column: "Reason",
                value: "Energy production is not a role of DNA.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 60,
                column: "Reason",
                value: "DNA does not directly fight diseases; it contains the instructions for making proteins.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db5b7fc3-5265-4cf0-bf1f-390c4042edba", "AQAAAAIAAYagAAAAEH19xLC4E77tD3UZYb0pJLgxh11bCfEGMpHr+1UsVD5JBeSrW0ysG2jrbOHPrK8TSA==", "ab2ef26d-a79b-45d4-ab10-3616d50d4a61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7987c56e-ee32-4ed6-804a-6856def9400d", "AQAAAAIAAYagAAAAEFtGKuoBzEJHM3YEMDxYQ9eDBf0JwbBRVZ7NwJPT+3zZIP/wsoZ+BH99LXU5CMwoBw==", "eee1ee10-9492-4046-bc29-d8936f0414fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9fe9611-e632-40f3-8f30-14c2c4f85649", "AQAAAAIAAYagAAAAELAwFPg43NfONTUMk7e4SkM/vEbFOrEAZ/YgI0M8gyq7wYuagvHSuBC7DnlKivUjBg==", "62018a69-ad9b-46bc-86b9-ddbfd5e1049e" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailURL",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a46769b7-e8ff-490a-b2e3-3e57776ec8f3", "AQAAAAIAAYagAAAAEElQrDPcq62rZhb8krXBamMVEFPCxh/k4RNlDfvDnNFfiCGcddlRW8TP+wext3CwCg==", "44b862f5-266f-4ca9-b816-d42abadcfc1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d818d7bf-2f6f-42e7-9098-ead33c150677", "AQAAAAIAAYagAAAAECu2SV7nnxK04xmwRnwHJ2TGYyj6NHCrSgHqBWOtvDKOkvH/BLT1dtvydGnjRkEl3g==", "6282b736-4934-4fef-bd6a-de3a6ff04505" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c26304ef-3740-4c4a-8b9f-3176a2e0bf0d", "AQAAAAIAAYagAAAAEPU8yXGq3w2BRi7FgK8UazCSTS9uY4U4DWIaEZxkjO4hzZoXVjN1nSy6sDTX7R6BqA==", "e13a7907-0329-40f1-a490-1fc0b38dc390" });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
