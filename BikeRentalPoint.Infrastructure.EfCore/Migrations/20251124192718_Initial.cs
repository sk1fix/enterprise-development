using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikeRentalPoint.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "model",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    wheel_size = table.Column<double>(type: "double", nullable: true),
                    max_passenger_weight = table.Column<double>(type: "double", nullable: true),
                    bike_weight = table.Column<double>(type: "double", nullable: true),
                    brake_type = table.Column<int>(type: "int", nullable: false),
                    model_year = table.Column<int>(type: "int", nullable: true),
                    price_per_hour = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    bike_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "renter",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    last_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    middle_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_renter", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bike",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    serial_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    color = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bike", x => x.id);
                    table.ForeignKey(
                        name: "FK_bike_model_model_id",
                        column: x => x.model_id,
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rent",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    start_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    duration = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    bike_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    renter_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rent", x => x.id);
                    table.ForeignKey(
                        name: "FK_rent_bike_bike_id",
                        column: x => x.bike_id,
                        principalTable: "bike",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rent_renter_renter_id",
                        column: x => x.renter_id,
                        principalTable: "renter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "model",
                columns: new[] { "id", "bike_type", "bike_weight", "brake_type", "max_passenger_weight", "model_year", "price_per_hour", "wheel_size" },
                values: new object[,]
                {
                    { new Guid("1a96f120-7e4e-4e36-a536-07aa6df6112c"), 1, 11.0, 0, 110.0, 2021, 10m, 26.0 },
                    { new Guid("49e4174e-b015-4340-a0fc-dfef5947961a"), 0, 12.0, 1, 120.0, 2025, 17m, 28.0 },
                    { new Guid("81baa0bc-eef3-4797-ba5a-d8e4d862a37a"), 3, 14.0, 1, 100.0, 2024, 16m, 26.0 },
                    { new Guid("a72e8761-ee46-4c3d-a7e0-0d6b17523f16"), 2, 11.0, 0, 95.0, 2021, 11m, 27.0 },
                    { new Guid("aadbd9ee-2517-40f8-9db3-a1161a6c16a5"), 0, 9.0, 1, 100.0, 2022, 12m, 28.0 },
                    { new Guid("c87a3abb-ff4d-45ed-a9d0-88055b9673cf"), 4, 8.0, 3, 80.0, 2019, 8m, 24.0 },
                    { new Guid("e0350b2c-8f99-49d5-b4eb-4f1165b87abc"), 1, 13.0, 1, 120.0, 2023, 15m, 29.0 },
                    { new Guid("ec369c47-c55e-4825-8a3d-438949233514"), 0, 12.0, 2, 100.0, 2024, 14m, 28.0 },
                    { new Guid("ec4c0299-7e52-44cb-9fd9-9fd8f2990232"), 2, 10.0, 0, 90.0, 2020, 9m, 27.5 },
                    { new Guid("fb93836e-474f-48f7-b8fd-2eb25b21f30d"), 1, 15.0, 5, 130.0, 2023, 13m, 29.0 }
                });

            migrationBuilder.InsertData(
                table: "renter",
                columns: new[] { "id", "last_name", "middle_name", "name", "phone_number" },
                values: new object[,]
                {
                    { new Guid("1c9e5593-74e4-4f32-bb1a-aa65013e9749"), "Федоров", "Владимирович", "Федор", "888-888" },
                    { new Guid("3ac86426-26df-46cb-b4f2-576f442d104e"), "Никитин", "Андреевич", "Никита", "777-777" },
                    { new Guid("590c9949-a9d3-4084-81b4-d2b5c59cc0e7"), "Петров", "Петрович", "Петр", "222-222" },
                    { new Guid("682bfc31-dc6f-42db-ac47-233ab1aba084"), "Васильев", "Павлович", "Василий", "555-555" },
                    { new Guid("9bf4355d-d000-4822-9bd1-dea296610a3a"), "Сидоров", "Сидорович", "Сидор", "333-333" },
                    { new Guid("9cec14bf-3470-4394-9899-fdf3519f699f"), "Иванов", "Иванович", "Иван", "111-111" },
                    { new Guid("9d22c91c-85c9-44ac-85d6-2d0cf9c0513c"), "Смирнов", "Валерьевич", "Семен", "999-999" },
                    { new Guid("b7491013-1f84-4866-a8e7-730c226c3659"), "Попов", "Алексеевич", "Дмитрий", "000-000" },
                    { new Guid("cf7dcad8-2859-4f7e-95c1-c1471d134db0"), "Кузнецов", "Игоревич", "Сергей", "666-666" },
                    { new Guid("d8abaf64-e960-486d-a064-7134dc4c0522"), "Алексеев", "Николаевич", "Алексей", "444-444" }
                });

            migrationBuilder.InsertData(
                table: "bike",
                columns: new[] { "id", "color", "model_id", "serial_number" },
                values: new object[,]
                {
                    { new Guid("279902b6-a996-4fe1-8de8-0f36cfcff3eb"), "White", new Guid("ec369c47-c55e-4825-8a3d-438949233514"), "105" },
                    { new Guid("2ff0d2de-a373-41ae-8018-f08f2590ec88"), "Yellow", new Guid("c87a3abb-ff4d-45ed-a9d0-88055b9673cf"), "106" },
                    { new Guid("36358c4c-8620-4fb5-9502-e1ea23d0d3e1"), "Purple", new Guid("49e4174e-b015-4340-a0fc-dfef5947961a"), "110" },
                    { new Guid("3c43bc36-34e8-4fe3-ba3d-9b52777c6976"), "Silver", new Guid("81baa0bc-eef3-4797-ba5a-d8e4d862a37a"), "107" },
                    { new Guid("61865875-b804-4baa-8b2a-3260e62b84f3"), "Orange", new Guid("a72e8761-ee46-4c3d-a7e0-0d6b17523f16"), "109" },
                    { new Guid("745b41c8-ca80-427c-9e86-152b5a1ba5f4"), "Blue", new Guid("1a96f120-7e4e-4e36-a536-07aa6df6112c"), "102" },
                    { new Guid("80d70b89-4692-4eda-9492-cf898aac545d"), "Black", new Guid("e0350b2c-8f99-49d5-b4eb-4f1165b87abc"), "103" },
                    { new Guid("9ca5637c-9c10-419e-9c35-db2d523f5b08"), "Green", new Guid("ec4c0299-7e52-44cb-9fd9-9fd8f2990232"), "104" },
                    { new Guid("d76ea574-e417-4567-a4b3-fd59c314d391"), "Red", new Guid("aadbd9ee-2517-40f8-9db3-a1161a6c16a5"), "101" },
                    { new Guid("e2330abb-386b-45fe-8c3b-52ec852dee1f"), "Gray", new Guid("fb93836e-474f-48f7-b8fd-2eb25b21f30d"), "108" }
                });

            migrationBuilder.InsertData(
                table: "rent",
                columns: new[] { "id", "bike_id", "duration", "renter_id", "start_time" },
                values: new object[,]
                {
                    { new Guid("06ba3375-11d9-49b3-9db5-73703c4b24b0"), new Guid("e2330abb-386b-45fe-8c3b-52ec852dee1f"), new TimeSpan(0, 3, 0, 0, 0), new Guid("9bf4355d-d000-4822-9bd1-dea296610a3a"), new DateTime(2025, 11, 24, 22, 57, 17, 176, DateTimeKind.Local).AddTicks(7042) },
                    { new Guid("13a97ac3-4746-43bc-b4b7-d4cba1edd39b"), new Guid("3c43bc36-34e8-4fe3-ba3d-9b52777c6976"), new TimeSpan(0, 6, 0, 0, 0), new Guid("3ac86426-26df-46cb-b4f2-576f442d104e"), new DateTime(2025, 11, 24, 20, 27, 17, 176, DateTimeKind.Local).AddTicks(7025) },
                    { new Guid("3693a260-f88c-4fea-8535-250979eda36f"), new Guid("279902b6-a996-4fe1-8de8-0f36cfcff3eb"), new TimeSpan(0, 2, 30, 0, 0), new Guid("682bfc31-dc6f-42db-ac47-233ab1aba084"), new DateTime(2025, 11, 24, 13, 27, 17, 176, DateTimeKind.Local).AddTicks(7022) },
                    { new Guid("447a3edb-7bd9-4467-bdd4-b713d189d934"), new Guid("279902b6-a996-4fe1-8de8-0f36cfcff3eb"), new TimeSpan(0, 4, 0, 0, 0), new Guid("cf7dcad8-2859-4f7e-95c1-c1471d134db0"), new DateTime(2025, 11, 24, 15, 27, 17, 176, DateTimeKind.Local).AddTicks(7036) },
                    { new Guid("45467e33-19f4-4465-8dee-8e55be3c6a19"), new Guid("2ff0d2de-a373-41ae-8018-f08f2590ec88"), new TimeSpan(0, 2, 30, 0, 0), new Guid("1c9e5593-74e4-4f32-bb1a-aa65013e9749"), new DateTime(2025, 11, 24, 17, 27, 17, 176, DateTimeKind.Local).AddTicks(7037) },
                    { new Guid("46de07ab-24f5-497d-9d1f-78512c0ab9f6"), new Guid("36358c4c-8620-4fb5-9502-e1ea23d0d3e1"), new TimeSpan(0, 2, 0, 0, 0), new Guid("9cec14bf-3470-4394-9899-fdf3519f699f"), new DateTime(2025, 11, 24, 21, 57, 17, 176, DateTimeKind.Local).AddTicks(7040) },
                    { new Guid("62953104-b9e1-4021-88a2-63f7b78ed558"), new Guid("e2330abb-386b-45fe-8c3b-52ec852dee1f"), new TimeSpan(0, 5, 0, 0, 0), new Guid("d8abaf64-e960-486d-a064-7134dc4c0522"), new DateTime(2025, 11, 24, 11, 27, 17, 176, DateTimeKind.Local).AddTicks(7034) },
                    { new Guid("6957a893-bdee-4e3d-9c19-22bbd4b04710"), new Guid("80d70b89-4692-4eda-9492-cf898aac545d"), new TimeSpan(0, 3, 0, 0, 0), new Guid("9cec14bf-3470-4394-9899-fdf3519f699f"), new DateTime(2025, 11, 23, 22, 27, 17, 176, DateTimeKind.Local).AddTicks(7031) },
                    { new Guid("7799b9fa-cc36-4ce8-ac54-be35ae864392"), new Guid("2ff0d2de-a373-41ae-8018-f08f2590ec88"), new TimeSpan(0, 5, 0, 0, 0), new Guid("cf7dcad8-2859-4f7e-95c1-c1471d134db0"), new DateTime(2025, 11, 24, 18, 27, 17, 176, DateTimeKind.Local).AddTicks(7023) },
                    { new Guid("7d833f9a-1bf3-4191-950b-d724fc3af9a1"), new Guid("61865875-b804-4baa-8b2a-3260e62b84f3"), new TimeSpan(0, 3, 30, 0, 0), new Guid("9d22c91c-85c9-44ac-85d6-2d0cf9c0513c"), new DateTime(2025, 11, 24, 22, 27, 17, 176, DateTimeKind.Local).AddTicks(7028) },
                    { new Guid("86dd46d2-d590-453c-ab9a-47a498917b81"), new Guid("9ca5637c-9c10-419e-9c35-db2d523f5b08"), new TimeSpan(0, 1, 30, 0, 0), new Guid("d8abaf64-e960-486d-a064-7134dc4c0522"), new DateTime(2025, 11, 24, 3, 27, 17, 176, DateTimeKind.Local).AddTicks(7020) },
                    { new Guid("8825d79f-eb62-4d72-bef2-366e86bd0ed7"), new Guid("80d70b89-4692-4eda-9492-cf898aac545d"), new TimeSpan(0, 4, 0, 0, 0), new Guid("9bf4355d-d000-4822-9bd1-dea296610a3a"), new DateTime(2025, 11, 23, 17, 27, 17, 176, DateTimeKind.Local).AddTicks(7007) },
                    { new Guid("afd870f1-6346-42fe-bc98-836f32e16849"), new Guid("9ca5637c-9c10-419e-9c35-db2d523f5b08"), new TimeSpan(0, 3, 30, 0, 0), new Guid("9d22c91c-85c9-44ac-85d6-2d0cf9c0513c"), new DateTime(2025, 11, 24, 19, 27, 17, 176, DateTimeKind.Local).AddTicks(7039) },
                    { new Guid("b7cd534b-1b61-4e3c-b6a2-74e0c79a86c7"), new Guid("2ff0d2de-a373-41ae-8018-f08f2590ec88"), new TimeSpan(0, 2, 0, 0, 0), new Guid("682bfc31-dc6f-42db-ac47-233ab1aba084"), new DateTime(2025, 11, 24, 23, 15, 17, 176, DateTimeKind.Local).AddTicks(7044) },
                    { new Guid("d389a5a6-d398-46f2-a5c3-730f75d41553"), new Guid("e2330abb-386b-45fe-8c3b-52ec852dee1f"), new TimeSpan(0, 2, 30, 0, 0), new Guid("1c9e5593-74e4-4f32-bb1a-aa65013e9749"), new DateTime(2025, 11, 24, 21, 27, 17, 176, DateTimeKind.Local).AddTicks(7027) },
                    { new Guid("d44dc785-ed28-4259-8c64-0de1f1768277"), new Guid("3c43bc36-34e8-4fe3-ba3d-9b52777c6976"), new TimeSpan(0, 2, 0, 0, 0), new Guid("590c9949-a9d3-4084-81b4-d2b5c59cc0e7"), new DateTime(2025, 11, 24, 8, 27, 17, 176, DateTimeKind.Local).AddTicks(7033) },
                    { new Guid("d56a4c5a-3c15-4886-8fd4-73fec0a831b3"), new Guid("d76ea574-e417-4567-a4b3-fd59c314d391"), new TimeSpan(0, 2, 0, 0, 0), new Guid("9cec14bf-3470-4394-9899-fdf3519f699f"), new DateTime(2025, 11, 22, 21, 27, 17, 176, DateTimeKind.Local).AddTicks(6419) },
                    { new Guid("fa62f9da-bbc4-40dc-b24f-97d190aa20bc"), new Guid("745b41c8-ca80-427c-9e86-152b5a1ba5f4"), new TimeSpan(0, 3, 0, 0, 0), new Guid("590c9949-a9d3-4084-81b4-d2b5c59cc0e7"), new DateTime(2025, 11, 23, 7, 27, 17, 176, DateTimeKind.Local).AddTicks(7003) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bike_model_id",
                table: "bike",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_rent_bike_id",
                table: "rent",
                column: "bike_id");

            migrationBuilder.CreateIndex(
                name: "IX_rent_renter_id",
                table: "rent",
                column: "renter_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rent");

            migrationBuilder.DropTable(
                name: "bike");

            migrationBuilder.DropTable(
                name: "renter");

            migrationBuilder.DropTable(
                name: "model");
        }
    }
}
