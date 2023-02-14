using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MythSportEvent.Core.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateAndTimeInfo",
                columns: table => new
                {
                    DateAndTimeInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledStartTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledStartTimeUtcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    ScheduledEndTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledEndTimeUtcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    ActualStartTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualStartTimeUtcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    ActualEndTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndTimeUtcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    StartDateLocal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateLocalSpecified = table.Column<bool>(type: "bit", nullable: false),
                    EndDateLocal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateLocalSpecified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateAndTimeInfo", x => x.DateAndTimeInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    MetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdateId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateIdSpecified = table.Column<bool>(type: "bit", nullable: false),
                    UpdateAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.MetaId);
                });

            migrationBuilder.CreateTable(
                name: "ParentSportEvent",
                columns: table => new
                {
                    ParentSportEventId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentSportEvent", x => x.ParentSportEventId);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "SportsDiscipline",
                columns: table => new
                {
                    SportsDisciplineId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsDiscipline", x => x.SportsDisciplineId);
                });

            migrationBuilder.CreateTable(
                name: "SportsGender",
                columns: table => new
                {
                    SportsGenderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsGender", x => x.SportsGenderId);
                });

            migrationBuilder.CreateTable(
                name: "SportsOrganisation",
                columns: table => new
                {
                    SportsOrganisationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsOrganisation", x => x.SportsOrganisationId);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    VenueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    WeatherConditionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperatureFahrenheit = table.Column<int>(type: "int", nullable: false),
                    TemperatureFahrenheitSpecified = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureCelsius = table.Column<float>(type: "real", nullable: false),
                    TemperatureCelsiusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    WindSpeedMiles = table.Column<int>(type: "int", nullable: false),
                    WindSpeedMilesSpecified = table.Column<bool>(type: "bit", nullable: false),
                    WindSpeedKilometers = table.Column<float>(type: "real", nullable: false),
                    WindSpeedKilometersSpecified = table.Column<bool>(type: "bit", nullable: false),
                    WindDirection = table.Column<int>(type: "int", nullable: false),
                    WindDirectionSpecified = table.Column<bool>(type: "bit", nullable: false),
                    WeatherType = table.Column<int>(type: "int", nullable: false),
                    WeatherTypeSpecified = table.Column<bool>(type: "bit", nullable: false),
                    TailWindSpeed = table.Column<int>(type: "int", nullable: true),
                    BaseballHomePlateWindDirection = table.Column<int>(type: "int", nullable: false),
                    BaseballHomePlateWindDirectionSpecified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.WeatherConditionsId);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    SportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsDisciplineId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportsGenderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.SportId);
                    table.ForeignKey(
                        name: "FK_Sport_SportsDiscipline_SportsDisciplineId",
                        column: x => x.SportsDisciplineId,
                        principalTable: "SportsDiscipline",
                        principalColumn: "SportsDisciplineId");
                    table.ForeignKey(
                        name: "FK_Sport_SportsGender_SportsGenderId",
                        column: x => x.SportsGenderId,
                        principalTable: "SportsGender",
                        principalColumn: "SportsGenderId");
                });

            migrationBuilder.CreateTable(
                name: "ParentSportEventSportsEvent",
                columns: table => new
                {
                    ParentSportsEventsParentSportEventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportsEventsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentSportEventSportsEvent", x => new { x.ParentSportsEventsParentSportEventId, x.SportsEventsId });
                    table.ForeignKey(
                        name: "FK_ParentSportEventSportsEvent_ParentSportEvent_ParentSportsEventsParentSportEventId",
                        column: x => x.ParentSportsEventsParentSportEventId,
                        principalTable: "ParentSportEvent",
                        principalColumn: "ParentSportEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportsEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StartDateLocal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateLocalSpecified = table.Column<bool>(type: "bit", nullable: false),
                    ScheduledStartTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledStartTimeUTCSpecified = table.Column<bool>(type: "bit", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeSpecified = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    CurrentStateId = table.Column<int>(type: "int", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: false),
                    AttendanceSpecified = table.Column<bool>(type: "bit", nullable: false),
                    SportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VenueId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartVenueId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FinishVenueId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhaseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherConditionsId = table.Column<int>(type: "int", nullable: true),
                    SiblingOrder = table.Column<int>(type: "int", nullable: false),
                    SiblingOrderSpecified = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleStatus = table.Column<int>(type: "int", nullable: false),
                    ScheduleStatusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    ResultStatus = table.Column<int>(type: "int", nullable: false),
                    ResultStatusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    EventTypeDetail = table.Column<int>(type: "int", nullable: false),
                    EventTypeDetailSpecified = table.Column<bool>(type: "bit", nullable: false),
                    DirectParentSportEventId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AwayParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParticipantType = table.Column<int>(type: "int", nullable: false),
                    ParticipantTypeSpecified = table.Column<bool>(type: "bit", nullable: false),
                    DateAndTimeInfoId = table.Column<int>(type: "int", nullable: true),
                    MetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportsEvents_DateAndTimeInfo_DateAndTimeInfoId",
                        column: x => x.DateAndTimeInfoId,
                        principalTable: "DateAndTimeInfo",
                        principalColumn: "DateAndTimeInfoId");
                    table.ForeignKey(
                        name: "FK_SportsEvents_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "MetaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportsEvents_Participant_AwayParticipantId",
                        column: x => x.AwayParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId");
                    table.ForeignKey(
                        name: "FK_SportsEvents_Participant_HomeParticipantId",
                        column: x => x.HomeParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId");
                    table.ForeignKey(
                        name: "FK_SportsEvents_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportsEvents_Venue_FinishVenueId",
                        column: x => x.FinishVenueId,
                        principalTable: "Venue",
                        principalColumn: "VenueId");
                    table.ForeignKey(
                        name: "FK_SportsEvents_Venue_StartVenueId",
                        column: x => x.StartVenueId,
                        principalTable: "Venue",
                        principalColumn: "VenueId");
                    table.ForeignKey(
                        name: "FK_SportsEvents_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "VenueId");
                    table.ForeignKey(
                        name: "FK_SportsEvents_WeatherConditions_WeatherConditionsId",
                        column: x => x.WeatherConditionsId,
                        principalTable: "WeatherConditions",
                        principalColumn: "WeatherConditionsId");
                });

            migrationBuilder.CreateTable(
                name: "SportsEventSportsOrganisation",
                columns: table => new
                {
                    SportsEventsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportsOrganisationsSportsOrganisationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsEventSportsOrganisation", x => new { x.SportsEventsId, x.SportsOrganisationsSportsOrganisationId });
                    table.ForeignKey(
                        name: "FK_SportsEventSportsOrganisation_SportsEvents_SportsEventsId",
                        column: x => x.SportsEventsId,
                        principalTable: "SportsEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportsEventSportsOrganisation_SportsOrganisation_SportsOrganisationsSportsOrganisationId",
                        column: x => x.SportsOrganisationsSportsOrganisationId,
                        principalTable: "SportsOrganisation",
                        principalColumn: "SportsOrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsEventId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_SportsEvents_SportsEventId",
                        column: x => x.SportsEventId,
                        principalTable: "SportsEvents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentSportEventSportsEvent_SportsEventsId",
                table: "ParentSportEventSportsEvent",
                column: "SportsEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_SportsDisciplineId",
                table: "Sport",
                column: "SportsDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_SportsGenderId",
                table: "Sport",
                column: "SportsGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_AwayParticipantId",
                table: "SportsEvents",
                column: "AwayParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_CurrentStateId",
                table: "SportsEvents",
                column: "CurrentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_DateAndTimeInfoId",
                table: "SportsEvents",
                column: "DateAndTimeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_FinishVenueId",
                table: "SportsEvents",
                column: "FinishVenueId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_HomeParticipantId",
                table: "SportsEvents",
                column: "HomeParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_MetaId",
                table: "SportsEvents",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_SportId",
                table: "SportsEvents",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_StartVenueId",
                table: "SportsEvents",
                column: "StartVenueId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_VenueId",
                table: "SportsEvents",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_WeatherConditionsId",
                table: "SportsEvents",
                column: "WeatherConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEventSportsOrganisation_SportsOrganisationsSportsOrganisationId",
                table: "SportsEventSportsOrganisation",
                column: "SportsOrganisationsSportsOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_State_SportsEventId",
                table: "State",
                column: "SportsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSportEventSportsEvent_SportsEvents_SportsEventsId",
                table: "ParentSportEventSportsEvent",
                column: "SportsEventsId",
                principalTable: "SportsEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportsEvents_State_CurrentStateId",
                table: "SportsEvents",
                column: "CurrentStateId",
                principalTable: "State",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_SportsEvents_SportsEventId",
                table: "State");

            migrationBuilder.DropTable(
                name: "ParentSportEventSportsEvent");

            migrationBuilder.DropTable(
                name: "SportsEventSportsOrganisation");

            migrationBuilder.DropTable(
                name: "ParentSportEvent");

            migrationBuilder.DropTable(
                name: "SportsOrganisation");

            migrationBuilder.DropTable(
                name: "SportsEvents");

            migrationBuilder.DropTable(
                name: "DateAndTimeInfo");

            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "WeatherConditions");

            migrationBuilder.DropTable(
                name: "SportsDiscipline");

            migrationBuilder.DropTable(
                name: "SportsGender");
        }
    }
}
