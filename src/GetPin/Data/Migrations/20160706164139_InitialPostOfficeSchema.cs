using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetPin.Data.Migrations
{
    public partial class InitialPostOfficeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<Guid>(nullable: false),
                    OfficeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(nullable: false),
                    RegionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<Guid>(nullable: false),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "PinCode",
                columns: table => new
                {
                    PinCodeId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: true),
                    PinCodeNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinCode", x => x.PinCodeId);
                    table.ForeignKey(
                        name: "FK_PinCode_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionId = table.Column<Guid>(nullable: false),
                    DivisionName = table.Column<string>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Divisions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<Guid>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true),
                    StateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Taluk",
                columns: table => new
                {
                    TalukId = table.Column<Guid>(nullable: false),
                    DistrictId = table.Column<Guid>(nullable: true),
                    TalukName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taluk", x => x.TalukId);
                    table.ForeignKey(
                        name: "FK_Taluk_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostOffices",
                columns: table => new
                {
                    PostOfficeId = table.Column<Guid>(nullable: false),
                    CircleStateId = table.Column<Guid>(nullable: true),
                    DeliveryStatus = table.Column<int>(nullable: false),
                    DistrictId = table.Column<Guid>(nullable: true),
                    DivisionId = table.Column<Guid>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    OfficeType = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    PinCodeId = table.Column<Guid>(nullable: true),
                    PostOfficeName = table.Column<string>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: true),
                    RelatedHeadOfficeOfficeId = table.Column<Guid>(nullable: true),
                    RelatedSubOfficeOfficeId = table.Column<Guid>(nullable: true),
                    StateId = table.Column<Guid>(nullable: true),
                    TalukId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOffices", x => x.PostOfficeId);
                    table.ForeignKey(
                        name: "FK_PostOffices_States_CircleStateId",
                        column: x => x.CircleStateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_PinCode_PinCodeId",
                        column: x => x.PinCodeId,
                        principalTable: "PinCode",
                        principalColumn: "PinCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_Offices_RelatedHeadOfficeOfficeId",
                        column: x => x.RelatedHeadOfficeOfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_Offices_RelatedSubOfficeOfficeId",
                        column: x => x.RelatedSubOfficeOfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostOffices_Taluk_TalukId",
                        column: x => x.TalukId,
                        principalTable: "Taluk",
                        principalColumn: "TalukId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_StateId",
                table: "Districts",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_RegionId",
                table: "Divisions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PinCode_CountryId",
                table: "PinCode",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_CircleStateId",
                table: "PostOffices",
                column: "CircleStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_DistrictId",
                table: "PostOffices",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_DivisionId",
                table: "PostOffices",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_PinCodeId",
                table: "PostOffices",
                column: "PinCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_RegionId",
                table: "PostOffices",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_RelatedHeadOfficeOfficeId",
                table: "PostOffices",
                column: "RelatedHeadOfficeOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_RelatedSubOfficeOfficeId",
                table: "PostOffices",
                column: "RelatedSubOfficeOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_StateId",
                table: "PostOffices",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffices_TalukId",
                table: "PostOffices",
                column: "TalukId");

            migrationBuilder.CreateIndex(
                name: "IX_Taluk_DistrictId",
                table: "Taluk",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostOffices");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "PinCode");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Taluk");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
