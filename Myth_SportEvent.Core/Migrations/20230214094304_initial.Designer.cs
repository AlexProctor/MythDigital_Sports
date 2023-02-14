﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Myth_SportEvent.Core.Data;

#nullable disable

namespace MythSportEvent.Core.Migrations
{
    [DbContext(typeof(SportEventsContext))]
    [Migration("20230214094304_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Myth_SportEvent.Core.Models.DateAndTimeInfo", b =>
                {
                    b.Property<int>("DateAndTimeInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateAndTimeInfoId"));

                    b.Property<DateTime>("ActualEndTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ActualEndTimeUtcSpecified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ActualStartTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ActualStartTimeUtcSpecified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDateLocal")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EndDateLocalSpecified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ScheduledEndTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ScheduledEndTimeUtcSpecified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ScheduledStartTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ScheduledStartTimeUtcSpecified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDateLocal")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StartDateLocalSpecified")
                        .HasColumnType("bit");

                    b.HasKey("DateAndTimeInfoId");

                    b.ToTable("DateAndTimeInfo");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.Meta", b =>
                {
                    b.Property<int>("MetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetaId"));

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateAction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdateId")
                        .HasColumnType("bigint");

                    b.Property<bool>("UpdateIdSpecified")
                        .HasColumnType("bit");

                    b.HasKey("MetaId");

                    b.ToTable("Meta");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.ParentSportEvent", b =>
                {
                    b.Property<string>("ParentSportEventId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ParentSportEventId");

                    b.ToTable("ParentSportEvent");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.Participant", b =>
                {
                    b.Property<string>("ParticipantId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ParticipantId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.Sport", b =>
                {
                    b.Property<string>("SportId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportsDisciplineId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SportsGenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SportId");

                    b.HasIndex("SportsDisciplineId");

                    b.HasIndex("SportsGenderId");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.SportsDiscipline", b =>
                {
                    b.Property<string>("SportsDisciplineId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SportsDisciplineId");

                    b.ToTable("SportsDiscipline");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.SportsEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Attendance")
                        .HasColumnType("int");

                    b.Property<bool>("AttendanceSpecified")
                        .HasColumnType("bit");

                    b.Property<string>("AwayParticipantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CurrentStateId")
                        .HasColumnType("int");

                    b.Property<int?>("DateAndTimeInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectParentSportEventId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EndTimeSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("EventTypeDetail")
                        .HasColumnType("int");

                    b.Property<bool>("EventTypeDetailSpecified")
                        .HasColumnType("bit");

                    b.Property<string>("FinishVenueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeParticipantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MetaId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantType")
                        .HasColumnType("int");

                    b.Property<bool>("ParticipantTypeSpecified")
                        .HasColumnType("bit");

                    b.Property<string>("PhaseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResultStatus")
                        .HasColumnType("int");

                    b.Property<bool>("ResultStatusSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("ScheduleStatus")
                        .HasColumnType("int");

                    b.Property<bool>("ScheduleStatusSpecified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ScheduledStartTimeUTC")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ScheduledStartTimeUTCSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("SiblingOrder")
                        .HasColumnType("int");

                    b.Property<bool>("SiblingOrderSpecified")
                        .HasColumnType("bit");

                    b.Property<string>("SportId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDateLocal")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StartDateLocalSpecified")
                        .HasColumnType("bit");

                    b.Property<string>("StartVenueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("StatusSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VenueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("WeatherConditionsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayParticipantId");

                    b.HasIndex("CurrentStateId");

                    b.HasIndex("DateAndTimeInfoId");

                    b.HasIndex("FinishVenueId");

                    b.HasIndex("HomeParticipantId");

                    b.HasIndex("MetaId");

                    b.HasIndex("SportId");

                    b.HasIndex("StartVenueId");

                    b.HasIndex("VenueId");

                    b.HasIndex("WeatherConditionsId");

                    b.ToTable("SportsEvents");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.SportsGender", b =>
                {
                    b.Property<string>("SportsGenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SportsGenderId");

                    b.ToTable("SportsGender");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.SportsOrganisation", b =>
                {
                    b.Property<string>("SportsOrganisationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SportsOrganisationId");

                    b.ToTable("SportsOrganisation");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportsEventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SportsEventId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.Venue", b =>
                {
                    b.Property<string>("VenueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VenueId");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.WeatherConditions", b =>
                {
                    b.Property<int>("WeatherConditionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeatherConditionsId"));

                    b.Property<int>("BaseballHomePlateWindDirection")
                        .HasColumnType("int");

                    b.Property<bool>("BaseballHomePlateWindDirectionSpecified")
                        .HasColumnType("bit");

                    b.Property<int?>("TailWindSpeed")
                        .HasColumnType("int");

                    b.Property<float>("TemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<bool>("TemperatureCelsiusSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("TemperatureFahrenheit")
                        .HasColumnType("int");

                    b.Property<bool>("TemperatureFahrenheitSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("WeatherType")
                        .HasColumnType("int");

                    b.Property<bool>("WeatherTypeSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("WindDirection")
                        .HasColumnType("int");

                    b.Property<bool>("WindDirectionSpecified")
                        .HasColumnType("bit");

                    b.Property<float>("WindSpeedKilometers")
                        .HasColumnType("real");

                    b.Property<bool>("WindSpeedKilometersSpecified")
                        .HasColumnType("bit");

                    b.Property<int>("WindSpeedMiles")
                        .HasColumnType("int");

                    b.Property<bool>("WindSpeedMilesSpecified")
                        .HasColumnType("bit");

                    b.HasKey("WeatherConditionsId");

                    b.ToTable("WeatherConditions");
                });

            modelBuilder.Entity("ParentSportEventSportsEvent", b =>
                {
                    b.Property<string>("ParentSportsEventsParentSportEventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SportsEventsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ParentSportsEventsParentSportEventId", "SportsEventsId");

                    b.HasIndex("SportsEventsId");

                    b.ToTable("ParentSportEventSportsEvent");
                });

            modelBuilder.Entity("SportsEventSportsOrganisation", b =>
                {
                    b.Property<string>("SportsEventsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SportsOrganisationsSportsOrganisationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SportsEventsId", "SportsOrganisationsSportsOrganisationId");

                    b.HasIndex("SportsOrganisationsSportsOrganisationId");

                    b.ToTable("SportsEventSportsOrganisation");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.Sport", b =>
                {
                    b.HasOne("Myth_SportEvent.Core.Models.SportsDiscipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("SportsDisciplineId");

                    b.HasOne("Myth_SportEvent.Core.Models.SportsGender", "Gender")
                        .WithMany()
                        .HasForeignKey("SportsGenderId");

                    b.Navigation("Discipline");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.SportsEvent", b =>
                {
                    b.HasOne("Myth_SportEvent.Core.Models.Participant", "AwayParticipant")
                        .WithMany()
                        .HasForeignKey("AwayParticipantId");

                    b.HasOne("Myth_SportEvent.Core.Models.State", "CurrentState")
                        .WithMany()
                        .HasForeignKey("CurrentStateId");

                    b.HasOne("Myth_SportEvent.Core.Models.DateAndTimeInfo", "DateAndTimeInfo")
                        .WithMany()
                        .HasForeignKey("DateAndTimeInfoId");

                    b.HasOne("Myth_SportEvent.Core.Models.Venue", "FinishVenue")
                        .WithMany()
                        .HasForeignKey("FinishVenueId");

                    b.HasOne("Myth_SportEvent.Core.Models.Participant", "HomeParticipant")
                        .WithMany()
                        .HasForeignKey("HomeParticipantId");

                    b.HasOne("Myth_SportEvent.Core.Models.Meta", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Myth_SportEvent.Core.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Myth_SportEvent.Core.Models.Venue", "StartVenue")
                        .WithMany()
                        .HasForeignKey("StartVenueId");

                    b.HasOne("Myth_SportEvent.Core.Models.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");

                    b.HasOne("Myth_SportEvent.Core.Models.WeatherConditions", "WeatherConditions")
                        .WithMany()
                        .HasForeignKey("WeatherConditionsId");

                    b.Navigation("AwayParticipant");

                    b.Navigation("CurrentState");

                    b.Navigation("DateAndTimeInfo");

                    b.Navigation("FinishVenue");

                    b.Navigation("HomeParticipant");

                    b.Navigation("Meta");

                    b.Navigation("Sport");

                    b.Navigation("StartVenue");

                    b.Navigation("Venue");

                    b.Navigation("WeatherConditions");
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.State", b =>
                {
                    b.HasOne("Myth_SportEvent.Core.Models.SportsEvent", null)
                        .WithMany("State")
                        .HasForeignKey("SportsEventId");
                });

            modelBuilder.Entity("ParentSportEventSportsEvent", b =>
                {
                    b.HasOne("Myth_SportEvent.Core.Models.ParentSportEvent", null)
                        .WithMany()
                        .HasForeignKey("ParentSportsEventsParentSportEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Myth_SportEvent.Core.Models.SportsEvent", null)
                        .WithMany()
                        .HasForeignKey("SportsEventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsEventSportsOrganisation", b =>
                {
                    b.HasOne("Myth_SportEvent.Core.Models.SportsEvent", null)
                        .WithMany()
                        .HasForeignKey("SportsEventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Myth_SportEvent.Core.Models.SportsOrganisation", null)
                        .WithMany()
                        .HasForeignKey("SportsOrganisationsSportsOrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Myth_SportEvent.Core.Models.SportsEvent", b =>
                {
                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
