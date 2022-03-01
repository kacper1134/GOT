using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GOT.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaneUzytkownika",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adres_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Data_Urodzenia = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaneUzytkownika", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "GrupaGorska",
                columns: table => new
                {
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WPolsce = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupaGorska", x => x.Nazwa);
                });

            migrationBuilder.CreateTable(
                name: "Trasa",
                columns: table => new
                {
                    Numer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasa", x => x.Numer);
                });

            migrationBuilder.CreateTable(
                name: "KsiazeckaGOT",
                columns: table => new
                {
                    Numer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsiazeckaGOT", x => x.Numer);
                    table.ForeignKey(
                        name: "FK_KsiazeckaGOT_DaneUzytkownika_Login",
                        column: x => x.Login,
                        principalTable: "DaneUzytkownika",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Przodownik",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Wyksztalcenie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przodownik", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Przodownik_DaneUzytkownika_Login",
                        column: x => x.Login,
                        principalTable: "DaneUzytkownika",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turysta",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Liczba_Punktow = table.Column<int>(type: "int", nullable: false),
                    Wiarygodny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turysta", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Turysta_DaneUzytkownika_Login",
                        column: x => x.Login,
                        principalTable: "DaneUzytkownika",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PunktGeograficzny",
                columns: table => new
                {
                    Numer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dlugosc_Geograficzna = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Szerokosc_Geograficzna = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Wysokosc = table.Column<int>(type: "int", nullable: false),
                    Zdjecie = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NazwaGrupyGorskiej = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunktGeograficzny", x => x.Numer);
                    table.ForeignKey(
                        name: "FK_PunktGeograficzny_GrupaGorska_NazwaGrupyGorskiej",
                        column: x => x.NazwaGrupyGorskiej,
                        principalTable: "GrupaGorska",
                        principalColumn: "Nazwa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wycieczka",
                columns: table => new
                {
                    Numer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numer_Trasy = table.Column<int>(type: "int", nullable: false),
                    Data_Zgloszenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Login_Przodownika = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wycieczka", x => x.Numer);
                    table.ForeignKey(
                        name: "FK_Wycieczka_Przodownik_Login_Przodownika",
                        column: x => x.Login_Przodownika,
                        principalTable: "Przodownik",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wycieczka_Trasa_Numer_Trasy",
                        column: x => x.Numer_Trasy,
                        principalTable: "Trasa",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odcinek",
                columns: table => new
                {
                    Numer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Punkty = table.Column<int>(type: "int", nullable: false),
                    Zamkniety = table.Column<bool>(type: "bit", nullable: false),
                    Dlugosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Podejscie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Numer_Punktu_Poczatkowego = table.Column<int>(type: "int", nullable: false),
                    Numer_Punktu_Koncowego = table.Column<int>(type: "int", nullable: false),
                    Kolor = table.Column<int>(type: "int", nullable: false),
                    Dwukierunkowy = table.Column<bool>(type: "bit", nullable: false),
                    Zdjecie = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odcinek", x => x.Numer);
                    table.ForeignKey(
                        name: "FK_Odcinek_PunktGeograficzny_Numer_Punktu_Koncowego",
                        column: x => x.Numer_Punktu_Koncowego,
                        principalTable: "PunktGeograficzny",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Odcinek_PunktGeograficzny_Numer_Punktu_Poczatkowego",
                        column: x => x.Numer_Punktu_Poczatkowego,
                        principalTable: "PunktGeograficzny",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wpis",
                columns: table => new
                {
                    Numer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numer_Ksiazecki = table.Column<int>(type: "int", nullable: false),
                    Numer_Wycieczki = table.Column<int>(type: "int", nullable: false),
                    Data_Ukonczenia_Wycieczki = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wpis", x => x.Numer);
                    table.ForeignKey(
                        name: "FK_Wpis_KsiazeckaGOT_Numer_Ksiazecki",
                        column: x => x.Numer_Ksiazecki,
                        principalTable: "KsiazeckaGOT",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wpis_Wycieczka_Numer_Wycieczki",
                        column: x => x.Numer_Wycieczki,
                        principalTable: "Wycieczka",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdcinekTrasy",
                columns: table => new
                {
                    Numer_Trasy = table.Column<int>(type: "int", nullable: false),
                    Numer_Odcinka = table.Column<int>(type: "int", nullable: false),
                    Numer_Odcinka_Trasy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdcinekTrasy", x => new { x.Numer_Odcinka, x.Numer_Trasy });
                    table.ForeignKey(
                        name: "FK_OdcinekTrasy_Odcinek_Numer_Odcinka",
                        column: x => x.Numer_Odcinka,
                        principalTable: "Odcinek",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdcinekTrasy_Trasa_Numer_Trasy",
                        column: x => x.Numer_Trasy,
                        principalTable: "Trasa",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weryfikacja",
                columns: table => new
                {
                    Numer_Wpisu = table.Column<int>(type: "int", nullable: false),
                    Login_Przodownika = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Data_Weryfikacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uzasadnienie = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weryfikacja", x => new { x.Login_Przodownika, x.Numer_Wpisu });
                    table.ForeignKey(
                        name: "FK_Weryfikacja_Przodownik_Login_Przodownika",
                        column: x => x.Login_Przodownika,
                        principalTable: "Przodownik",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weryfikacja_Wpis_Numer_Wpisu",
                        column: x => x.Numer_Wpisu,
                        principalTable: "Wpis",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZdjecieWpisu",
                columns: table => new
                {
                    Identyfikator = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Numer_Wpisu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdjecieWpisu", x => x.Identyfikator);
                    table.ForeignKey(
                        name: "FK_ZdjecieWpisu_Wpis_Numer_Wpisu",
                        column: x => x.Numer_Wpisu,
                        principalTable: "Wpis",
                        principalColumn: "Numer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DaneUzytkownika",
                columns: new[] { "Login", "Adres_Email", "Data_Urodzenia", "Haslo", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { "kacper1134", " abs@o2.pl", new DateTime(2000, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaaaa", "Kacper", "Kochański" },
                    { "jakub1134", " absa@o2.pl", new DateTime(2000, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaaaa", "Jakub", "Kochański" }
                });

            migrationBuilder.InsertData(
                table: "GrupaGorska",
                columns: new[] { "Nazwa", "WPolsce" },
                values: new object[,]
                {
                    { "Tatry", true },
                    { "Beskidy Zachodnie", true },
                    { "Beskidy Wschodnie", true },
                    { "Sudety", true },
                    { "Góry Świętokrzyskie", true },
                    { "Karkonosze", true },
                    { "Pieniny", true }
                });

            migrationBuilder.InsertData(
                table: "Trasa",
                columns: new[] { "Numer", "Opis" },
                values: new object[,]
                {
                    { 1, null },
                    { 2, null },
                    { 3, null },
                    { 4, null },
                    { 5, null },
                    { 6, null }
                });

            migrationBuilder.InsertData(
                table: "KsiazeckaGOT",
                columns: new[] { "Numer", "Login" },
                values: new object[,]
                {
                    { 1, "kacper1134" },
                    { 2, "jakub1134" }
                });

            migrationBuilder.InsertData(
                table: "Przodownik",
                columns: new[] { "Login", "Wyksztalcenie" },
                values: new object[] { "kacper1134", 6 });

            migrationBuilder.InsertData(
                table: "PunktGeograficzny",
                columns: new[] { "Numer", "Dlugosc_Geograficzna", "Nazwa", "NazwaGrupyGorskiej", "Szerokosc_Geograficzna", "Wysokosc", "Zdjecie" },
                values: new object[,]
                {
                    { 76, 20.0066m, "Walentkowy Wierch", "Tatry", 49.2133m, 2156, null },
                    { 75, 19.9298m, "Polana Strążyska", "Tatry", 49.2622m, 1042, null },
                    { 73, 20.0674m, "Mięguszowiecki Szczyt Czarny", "Tatry", 49.1828m, 2410, null },
                    { 72, 20.0652m, "Przełęcz Pod Chłopkiem", "Tatry", 49.1836m, 2308, null },
                    { 71, 20.0599m, "Mięguszowiecki Szczyt Wielki", "Tatry", 49.1871m, 2438, null },
                    { 70, 20.0480m, "Ciemnosmreczyńska Turnia", "Tatry", 49.1899m, 2142, null },
                    { 69, 20.0400m, "Szpiglasowy Wierch", "Tatry", 49.1973m, 2172, null },
                    { 68, 20.0423m, "Szpiglasowa Przełęcz", "Tatry", 49.1979m, 2110, null },
                    { 67, 20.0550m, "Mnich", "Tatry", 49.1925m, 2068, null },
                    { 66, 20.0806m, "Włosienica", "Tatry", 49.2138m, 1315, null },
                    { 65, 20.1151m, "Parking Łysa Polana", "Tatry", 49.2641m, 970, null },
                    { 64, 20.0955m, "Schronisko w Dolinie Roztoki", "Tatry", 49.2337m, 1031, null },
                    { 63, 20.0113m, "Mały Kościelec", "Tatry", 49.2314m, 1866, null },
                    { 62, 20.0146m, "Kościelec", "Tatry", 49.2254m, 2155, null },
                    { 61, 20.0162m, "Przełęcz Zawrat", "Tatry", 49.2191m, 2159, null },
                    { 60, 20.0092m, "Świnica", "Tatry", 49.2194m, 2302, null },
                    { 77, 20.0351m, "Dolina Pięciu Stawów", "Tatry", 49.2106m, 1650, null },
                    { 7, 19.5295m, "Babia Góra", "Beskidy Zachodnie", 49.5731m, 1725, null },
                    { 20, 19.4695m, "Przełęcz Jałowiecka", "Beskidy Zachodnie", 49.5976m, 998, null },
                    { 59, 19.9923m, "Przełęcz Liliowe", "Tatry", 49.2252m, 1947, null },
                    { 26, 20.4112m, "Schronisko Trzy Korony", "Pieniny", 49.4052m, 470, null },
                    { 25, 20.4206m, "Zamek Pieniński", "Pieniny", 49.4203m, 799, null },
                    { 18, 20.4407m, "Sokolica", "Pieniny", 49.4175m, 747, null },
                    { 74, 15.8242m, "Schronisko Na Przełęczy Okraj", "Karkonosze", 50.7471m, 1046, null },
                    { 17, 15.7795m, "Dolina Płomnicy", "Karkonosze", 50.7523m, 912, null },
                    { 16, 15.7045m, "Polana KPN", "Karkonosze", 50.7651m, 1074, null },
                    { 15, 15.7242m, "Kościół Wang", "Karkonosze", 50.7773m, 885, null },
                    { 14, 15.7290m, "Dom Śląski", "Karkonosze", 50.7395m, 1400, null },
                    { 13, 15.6833m, "Słonecznik", "Karkonosze", 50.7597m, 1423, null },
                    { 12, 15.6934m, "Pielgrzymy", "Karkonosze", 50.7679m, 1204, null },
                    { 11, 15.7083m, "Stzecha Akademicka", "Karkonosze", 50.7509m, 1258, null },
                    { 10, 15.7915m, "Skalny Stół", "Karkonosze", 50.7527m, 1281, null },
                    { 6, 15.7399m, "Śnieżka", "Karkonosze", 50.7362m, 1601, "Śnieżka.jpg" },
                    { 24, 19.6494m, "Zubrzyca Górna", "Beskidy Zachodnie", 49.5631m, 715, null },
                    { 23, 19.4997m, "Mała Babia Góra", "Beskidy Zachodnie", 49.5812m, 1516, null },
                    { 22, 19.4321m, "Głuchaczki", "Beskidy Zachodnie", 49.5958m, 830, null },
                    { 21, 19.3872m, "Przyborów", "Beskidy Zachodnie", 49.6208m, 530, null },
                    { 19, 19.582m, "Przełęcz Krowiarki", "Beskidy Zachodnie", 49.5880m, 1009, null },
                    { 58, 19.9321m, "Kondracka Kopa", "Tatry", 49.2364m, 2005, null }
                });

            migrationBuilder.InsertData(
                table: "PunktGeograficzny",
                columns: new[] { "Numer", "Dlugosc_Geograficzna", "Nazwa", "NazwaGrupyGorskiej", "Szerokosc_Geograficzna", "Wysokosc", "Zdjecie" },
                values: new object[,]
                {
                    { 57, 19.9191m, "Małączniak", "Tatry", 49.2358m, 2096, null },
                    { 56, 19.9037m, "Dolina Mułowa", "Tatry", 49.2357m, 1820, null },
                    { 34, 19.8391m, "Siwa Polana", "Tatry", 49.2789m, 910, null },
                    { 33, 19.8497m, "Dolina Lejowa", "Tatry", 49.2775m, 940, null },
                    { 32, 20.0286m, "Kozi Wierch", "Tatry", 49.2183m, 2291, null },
                    { 31, 20.0039m, "Dolina Gąsienicowa", "Tatry", 49.2419m, 1425, null },
                    { 30, 19.9614m, "Szlak nad Reglami", "Tatry", 49.2611m, 1310, null },
                    { 29, 19.9159m, "Przełęcz w Grzybowcu", "Tatry", 49.2594m, 1310, null },
                    { 28, 19.9412m, "Sarnia Skała", "Tatry", 49.2653m, 1377, null },
                    { 27, 20.0453m, "Wielka Siklawa", "Tatry", 49.2147m, 1560, null },
                    { 9, 20.1340277m, "Gerlach", "Tatry", 49.1640277m, 2655, null },
                    { 8, 20.088m, "Rysy", "Tatry", 49.1795m, 2501, null },
                    { 5, 20.070999m, "Morskie Oko", "Tatry", 49.201401m, 1395, null },
                    { 4, 19.90947m, "Krzesanica", "Tatry", 49.23166m, 2122, null },
                    { 3, 19.981555m, "Kasprowy Wierch", "Tatry", 49.23183m, 1987, null },
                    { 2, 19.93411m, "Giewont", "Tatry", 49.250972m, 1894, null },
                    { 1, 19.9325m, "Dolina Strążyska", "Tatry", 49.27027m, 1029, null },
                    { 36, 19.8669m, "Dolina Kościeliska", "Tatry", 49.2539m, 980, null },
                    { 37, 19.8701m, "Jaskinia Mroźna", "Tatry", 49.2523m, 1100, null },
                    { 35, 19.8456m, "Huty Lejowe", "Tatry", 49.2636m, 1018, null },
                    { 39, 19.8587m, "Schronisko na Hali Ornak", "Tatry", 49.2292m, 1100, null },
                    { 55, 19.8865m, "Turnia Piec", "Tatry", 49.2486m, 1460, null },
                    { 54, 19.8949m, "Wyżnia Miętusia Rówień", "Tatry", 49.2523m, 1170, null },
                    { 53, 19.9006m, "Dolina Małej Łąki", "Tatry", 49.2658m, 930, null },
                    { 52, 19.8932m, "Przysłop Miętusi", "Tatry", 49.2622m, 1190, null },
                    { 51, 19.8682m, "Parking TPN Kiry", "Tatry", 49.2756m, 940, null },
                    { 50, 19.8699m, "Cudakowa Polana", "Tatry", 49.2640m, 952, null },
                    { 38, 19.8622m, "Jaskinia Mylna", "Tatry", 49.2394m, 1098, null },
                    { 48, 19.8561m, "Przysłop Kominiarski", "Tatry", 49.2570m, 1124, null },
                    { 49, 19.8447m, "Diabliniec", "Tatry", 49.2564m, 1241, null },
                    { 46, 19.8955m, "Chuda Przełączka", "Tatry", 49.2381m, 1850, null },
                    { 45, 19.8948m, "Wysoki Grzbiet", "Tatry", 49.2299m, 1500, null },
                    { 44, 19.8839m, "Smreczyński Wierch", "Tatry", 49.2041m, 2070, null },
                    { 43, 19.9048m, "Tomanowa Przełęcz", "Tatry", 49.2196m, 1685, null },
                    { 42, 19.9023m, "Tomanowy Wierch Polski", "Tatry", 49.2133m, 1977, null },
                    { 41, 19.8983m, "Czerwony Żleb", "Tatry", 49.2265m, 1645, null },
                    { 40, 19.8906m, "Wyżnia Polana Tomanowa", "Tatry", 49.2228m, 1380, null },
                    { 47, 20.4142m, "Trzy Korony", "Tatry", 49.4138m, 982, null }
                });

            migrationBuilder.InsertData(
                table: "Turysta",
                columns: new[] { "Login", "Liczba_Punktow", "Wiarygodny" },
                values: new object[,]
                {
                    { "jakub1134", 0, true },
                    { "kacper1134", 0, true }
                });

            migrationBuilder.InsertData(
                table: "Wycieczka",
                columns: new[] { "Numer", "Data_Zgloszenia", "Login_Przodownika", "Numer_Trasy" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 },
                    { 2, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Wycieczka",
                columns: new[] { "Numer", "Data_Zgloszenia", "Login_Przodownika", "Numer_Trasy" },
                values: new object[] { 3, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 });

            migrationBuilder.InsertData(
                table: "Wycieczka",
                columns: new[] { "Numer", "Data_Zgloszenia", "Login_Przodownika", "Numer_Trasy" },
                values: new object[] { 5, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5 });

            migrationBuilder.InsertData(
                table: "Odcinek",
                columns: new[] { "Numer", "Dlugosc", "Dwukierunkowy", "Kolor", "Numer_Punktu_Koncowego", "Numer_Punktu_Poczatkowego", "Opis", "Podejscie", "Punkty", "Zamkniety", "Zdjecie" },
                values: new object[,]
                {
                    { 75, 18450m, true, 0, 64, 65, null, 61m, 19, false, null },
                    { 63, 11650m, true, 1, 69, 76, null, 64m, 15, false, null },
                    { 62, 4310m, true, 1, 60, 76, null, 146m, 8, false, null },
                    { 50, 4120m, true, 3, 28, 75, null, 335m, 9, false, null },
                    { 49, 3985m, true, 0, 29, 75, null, 268m, 7, false, null },
                    { 48, 4130m, true, 0, 75, 1, null, 13m, 5, false, null },
                    { 69, 6450m, true, 0, 8, 73, null, 91m, 12, false, null },
                    { 68, 1160m, true, 0, 73, 72, null, 102m, 4, false, null },
                    { 71, 6780m, true, 0, 72, 5, null, 913m, 18, false, null },
                    { 67, 4580m, true, 0, 71, 72, null, 130m, 7, false, null },
                    { 66, 5410m, true, 0, 71, 70, null, 296m, 10, false, null },
                    { 65, 5640m, true, 1, 69, 70, null, 45m, 8, false, null },
                    { 64, 1860m, true, 2, 69, 68, null, 62m, 4, false, null },
                    { 72, 7240m, false, 4, 67, 5, null, 673m, 20, false, null },
                    { 74, 11250m, true, 0, 66, 64, null, 284m, 14, false, null },
                    { 73, 5670m, true, 0, 5, 66, null, 80m, 8, false, null },
                    { 60, 7530m, false, 4, 32, 77, null, 642m, 17, false, null },
                    { 59, 5860m, true, 0, 63, 31, null, 441m, 12, false, null },
                    { 61, 2140m, true, 1, 77, 27, null, 65m, 4, false, null },
                    { 18, 5600m, true, 1, 20, 22, null, 168m, 8, false, null },
                    { 13, 3400m, true, 0, 47, 26, null, 512m, 11, false, null },
                    { 12, 3400m, true, 0, 47, 25, null, 183m, 8, false, null },
                    { 11, 3800m, true, 0, 25, 18, null, 52m, 5, false, null },
                    { 10, 4600m, true, 0, 10, 74, null, 235m, 8, false, null },
                    { 9, 2300m, true, 3, 17, 10, null, 38m, 4, false, null },
                    { 5, 4300m, true, 0, 11, 16, null, 184m, 7, false, null },
                    { 3, 2400m, true, 3, 12, 16, null, 130m, 4, false, null },
                    { 2, 5200m, true, 0, 16, 15, null, 189m, 5, false, null },
                    { 7, 2700m, true, 0, 6, 14, null, 201m, 7, false, null },
                    { 6, 6500m, true, 0, 14, 11, null, 142m, 8, false, null },
                    { 8, 13600m, true, 1, 6, 10, null, 320m, 15, false, null },
                    { 14, 3900m, true, 0, 19, 24, null, 294m, 7, false, null },
                    { 17, 6400m, true, 1, 23, 20, null, 518m, 14, false, null },
                    { 16, 1900m, true, 0, 7, 23, null, 209m, 6, false, null },
                    { 19, 6800m, true, 1, 22, 21, null, 300m, 10, false, null },
                    { 15, 3500m, true, 0, 7, 19, null, 716m, 12, false, null },
                    { 58, 2980m, true, 0, 62, 63, null, 299m, 7, false, null },
                    { 57, 3890m, true, 0, 61, 62, null, 64m, 6, false, null },
                    { 26, 4870m, true, 0, 36, 50, null, 28m, 6, false, null },
                    { 22, 3120m, true, 3, 49, 48, null, 117m, 8, false, null },
                    { 23, 3450m, true, 0, 48, 36, null, 144m, 6, false, null },
                    { 21, 2800m, true, 0, 48, 35, null, 106m, 5, false, null }
                });

            migrationBuilder.InsertData(
                table: "Odcinek",
                columns: new[] { "Numer", "Dlugosc", "Dwukierunkowy", "Kolor", "Numer_Punktu_Koncowego", "Numer_Punktu_Poczatkowego", "Opis", "Podejscie", "Punkty", "Zamkniety", "Zdjecie" },
                values: new object[,]
                {
                    { 38, 1620m, true, 0, 41, 45, null, 145m, 4, false, null },
                    { 41, 8125m, true, 1, 44, 42, null, 293m, 13, false, null },
                    { 40, 3650m, true, 1, 42, 43, null, 292m, 8, false, null },
                    { 39, 5220m, true, 1, 4, 43, null, 437m, 11, false, null },
                    { 36, 2345m, true, 0, 41, 40, null, 265m, 7, false, null },
                    { 37, 5120m, true, 0, 40, 39, null, 280m, 9, false, null },
                    { 28, 2100m, true, 3, 39, 38, null, 2m, 4, false, null },
                    { 27, 2600m, true, 3, 38, 36, null, 118m, 5, false, null },
                    { 24, 1100m, true, 3, 37, 36, null, 120m, 4, false, null },
                    { 20, 4300m, true, 0, 35, 33, null, 78m, 6, false, null },
                    { 1, 1800m, true, 3, 33, 34, null, 30m, 3, false, null },
                    { 51, 5460m, true, 1, 28, 30, null, 67m, 7, false, null },
                    { 56, 5640m, true, 0, 32, 61, null, 132m, 9, false, null },
                    { 47, 6850m, true, 0, 2, 29, null, 584m, 14, false, null },
                    { 25, 5100m, true, 0, 50, 51, null, 12m, 7, false, null },
                    { 45, 3140m, true, 0, 52, 53, null, 260m, 6, false, null },
                    { 55, 4870m, true, 0, 60, 61, null, 143m, 8, false, null },
                    { 54, 5120m, true, 0, 60, 59, null, 355m, 11, false, null },
                    { 4, 10000m, true, 3, 4, 2, null, 500m, 6, true, null },
                    { 53, 4850m, true, 0, 3, 59, null, 40m, 10, false, null },
                    { 52, 11760m, true, 1, 58, 3, null, 240m, 18, false, null },
                    { 44, 9850m, true, 2, 58, 2, null, 345m, 14, false, null },
                    { 43, 4835m, true, 0, 57, 58, null, 189m, 9, false, null },
                    { 42, 4320m, true, 0, 4, 57, null, 212m, 8, false, null },
                    { 35, 3968m, true, 0, 56, 45, null, 320m, 10, false, null },
                    { 34, 3054m, true, 0, 4, 56, null, 302m, 9, false, null },
                    { 33, 2720m, true, 1, 46, 56, null, 30m, 5, false, null },
                    { 32, 3450m, true, 1, 46, 55, null, 390m, 10, false, null },
                    { 31, 2840m, true, 1, 55, 54, null, 290m, 7, false, null },
                    { 30, 3900m, true, 1, 52, 54, null, 20m, 6, false, null },
                    { 46, 6540m, true, 0, 29, 53, null, 380m, 11, false, null },
                    { 29, 4700m, true, 1, 52, 50, null, 238m, 8, false, null },
                    { 70, 16400m, true, 1, 9, 8, null, 154m, 24, false, null }
                });

            migrationBuilder.InsertData(
                table: "Wpis",
                columns: new[] { "Numer", "Data_Ukonczenia_Wycieczki", "Numer_Ksiazecki", "Numer_Wycieczki" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 8, new DateTime(2021, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 5, new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 9, new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 2, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 7, new DateTime(2021, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 3, new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Wycieczka",
                columns: new[] { "Numer", "Data_Zgloszenia", "Login_Przodownika", "Numer_Trasy" },
                values: new object[] { 1, new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "kacper1134", 1 });

            migrationBuilder.InsertData(
                table: "OdcinekTrasy",
                columns: new[] { "Numer_Odcinka", "Numer_Trasy", "Numer_Odcinka_Trasy" },
                values: new object[,]
                {
                    { 2, 2, 6 },
                    { 13, 3, 3 },
                    { 12, 3, 2 },
                    { 11, 3, 1 },
                    { 10, 2, 1 },
                    { 5, 2, 5 },
                    { 5, 1, 2 },
                    { 2, 1, 1 },
                    { 7, 2, 3 },
                    { 7, 1, 4 },
                    { 6, 1, 3 },
                    { 8, 2, 2 },
                    { 6, 2, 4 },
                    { 17, 5, 4 },
                    { 27, 6, 3 },
                    { 28, 6, 4 },
                    { 26, 6, 2 },
                    { 14, 5, 1 },
                    { 15, 5, 2 },
                    { 25, 6, 1 },
                    { 18, 4, 2 },
                    { 19, 4, 1 },
                    { 16, 5, 3 },
                    { 17, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Weryfikacja",
                columns: new[] { "Login_Przodownika", "Numer_Wpisu", "Data_Weryfikacji", "Status", "Uzasadnienie" },
                values: new object[,]
                {
                    { "kacper1134", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "" },
                    { "kacper1134", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "" },
                    { "kacper1134", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "" },
                    { "kacper1134", 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "" },
                    { "kacper1134", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "" },
                    { "kacper1134", 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "" },
                    { "kacper1134", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "" }
                });

            migrationBuilder.InsertData(
                table: "Wpis",
                columns: new[] { "Numer", "Data_Ukonczenia_Wycieczki", "Numer_Ksiazecki", "Numer_Wycieczki" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 4, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ZdjecieWpisu",
                columns: new[] { "Identyfikator", "Numer_Wpisu" },
                values: new object[,]
                {
                    { "Ciemniak.jpg", 3 },
                    { "Rysy.jpg", 6 },
                    { "BaraniaGóra.jpg", 2 },
                    { "SuchaCzuba.jpg", 8 },
                    { "MorskieOko.jpg", 7 },
                    { "Kasprowy.jpg", 5 },
                    { "Śnieżka.jpg", 9 }
                });

            migrationBuilder.InsertData(
                table: "Weryfikacja",
                columns: new[] { "Login_Przodownika", "Numer_Wpisu", "Data_Weryfikacji", "Status", "Uzasadnienie" },
                values: new object[,]
                {
                    { "kacper1134", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "aaaa" },
                    { "kacper1134", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "" }
                });

            migrationBuilder.InsertData(
                table: "ZdjecieWpisu",
                columns: new[] { "Identyfikator", "Numer_Wpisu" },
                values: new object[,]
                {
                    { "giewont.jpg", 1 },
                    { "HalaSzrenicka.jpg", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaneUzytkownika_Adres_Email",
                table: "DaneUzytkownika",
                column: "Adres_Email",
                unique: true,
                filter: "[Adres_Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GrupaGorska_Nazwa",
                table: "GrupaGorska",
                column: "Nazwa");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazeckaGOT_Login",
                table: "KsiazeckaGOT",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_Odcinek_Numer_Punktu_Koncowego",
                table: "Odcinek",
                column: "Numer_Punktu_Koncowego");

            migrationBuilder.CreateIndex(
                name: "IX_Odcinek_Numer_Punktu_Poczatkowego_Numer_Punktu_Koncowego",
                table: "Odcinek",
                columns: new[] { "Numer_Punktu_Poczatkowego", "Numer_Punktu_Koncowego" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OdcinekTrasy_Numer_Trasy",
                table: "OdcinekTrasy",
                column: "Numer_Trasy");

            migrationBuilder.CreateIndex(
                name: "IX_PunktGeograficzny_Nazwa",
                table: "PunktGeograficzny",
                column: "Nazwa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PunktGeograficzny_NazwaGrupyGorskiej",
                table: "PunktGeograficzny",
                column: "NazwaGrupyGorskiej");

            migrationBuilder.CreateIndex(
                name: "IX_PunktGeograficzny_Szerokosc_Geograficzna_Dlugosc_Geograficzna",
                table: "PunktGeograficzny",
                columns: new[] { "Szerokosc_Geograficzna", "Dlugosc_Geograficzna" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weryfikacja_Numer_Wpisu",
                table: "Weryfikacja",
                column: "Numer_Wpisu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wpis_Numer_Ksiazecki_Numer_Wycieczki",
                table: "Wpis",
                columns: new[] { "Numer_Ksiazecki", "Numer_Wycieczki" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wpis_Numer_Wycieczki",
                table: "Wpis",
                column: "Numer_Wycieczki");

            migrationBuilder.CreateIndex(
                name: "IX_Wycieczka_Login_Przodownika",
                table: "Wycieczka",
                column: "Login_Przodownika");

            migrationBuilder.CreateIndex(
                name: "IX_Wycieczka_Numer_Trasy",
                table: "Wycieczka",
                column: "Numer_Trasy");

            migrationBuilder.CreateIndex(
                name: "IX_ZdjecieWpisu_Numer_Wpisu",
                table: "ZdjecieWpisu",
                column: "Numer_Wpisu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdcinekTrasy");

            migrationBuilder.DropTable(
                name: "Turysta");

            migrationBuilder.DropTable(
                name: "Weryfikacja");

            migrationBuilder.DropTable(
                name: "ZdjecieWpisu");

            migrationBuilder.DropTable(
                name: "Odcinek");

            migrationBuilder.DropTable(
                name: "Wpis");

            migrationBuilder.DropTable(
                name: "PunktGeograficzny");

            migrationBuilder.DropTable(
                name: "KsiazeckaGOT");

            migrationBuilder.DropTable(
                name: "Wycieczka");

            migrationBuilder.DropTable(
                name: "GrupaGorska");

            migrationBuilder.DropTable(
                name: "Przodownik");

            migrationBuilder.DropTable(
                name: "Trasa");

            migrationBuilder.DropTable(
                name: "DaneUzytkownika");
        }
    }
}
