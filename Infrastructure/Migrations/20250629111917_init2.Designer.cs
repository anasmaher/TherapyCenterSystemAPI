﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250629111917_init2")]
    partial class init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.0-preview.5.25277.114")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TherapistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("TherapistId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Domain.Entities.ExerciseSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedByTherapistId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("ReflectionNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedByTherapistId");

                    b.HasIndex("ExerciseTemplateId");

                    b.HasIndex("PatientId");

                    b.ToTable("ExerciseSubmissions");
                });

            modelBuilder.Entity("Domain.Entities.ExerciseTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Example")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InputSchemaJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExerciseTemplates");
                });

            modelBuilder.Entity("Domain.Entities.GroupSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("PatientsIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TherapistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TherapistId");

                    b.ToTable("GroupSessions");
                });

            modelBuilder.Entity("Domain.Entities.GroupSessionParticipant", b =>
                {
                    b.Property<int>("GroupSessionId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("GroupSessionId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("GroupSessionParticipants");
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedTherapistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.Entities.PaymentTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PaymobOrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymobTransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.HasIndex("PatientId");

                    b.ToTable("PaymentTransactions");
                });

            modelBuilder.Entity("Domain.Entities.SessionNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<int>("TherapistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.ToTable("SessionNotes");
                });

            modelBuilder.Entity("Domain.Entities.Therapist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("Specializations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Therapists");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Goals")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("TherapistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("TherapistId");

                    b.ToTable("TreatmentPlans");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlanGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("bit");

                    b.Property<string>("ProgressNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TreatmentPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentPlanId");

                    b.ToTable("TreatmentPlanGoal");
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Therapist", "Therapist")
                        .WithMany("Appointments")
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Therapist");
                });

            modelBuilder.Entity("Domain.Entities.ExerciseSubmission", b =>
                {
                    b.HasOne("Domain.Entities.Therapist", "AssignedByTherapist")
                        .WithMany("AssignedExercises")
                        .HasForeignKey("AssignedByTherapistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ExerciseTemplate", "ExerciseTemplate")
                        .WithMany()
                        .HasForeignKey("ExerciseTemplateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithMany("ExerciseSubmissions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedByTherapist");

                    b.Navigation("ExerciseTemplate");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.GroupSession", b =>
                {
                    b.HasOne("Domain.Entities.Therapist", "Therapist")
                        .WithMany("GroupSessionsLed")
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Therapist");
                });

            modelBuilder.Entity("Domain.Entities.GroupSessionParticipant", b =>
                {
                    b.HasOne("Domain.Entities.GroupSession", "GroupSession")
                        .WithMany("GroupSessionPatients")
                        .HasForeignKey("GroupSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithMany("GroupSessions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GroupSession");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.PaymentTransaction", b =>
                {
                    b.HasOne("Domain.Entities.Appointment", "Appointment")
                        .WithOne("Payment")
                        .HasForeignKey("Domain.Entities.PaymentTransaction", "AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithMany("Payments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.SessionNote", b =>
                {
                    b.HasOne("Domain.Entities.Appointment", "Appointment")
                        .WithOne("SessionNote")
                        .HasForeignKey("Domain.Entities.SessionNote", "AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlan", b =>
                {
                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithMany("TreatmentPlans")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Therapist", "Therapist")
                        .WithMany("TreatmentPlans")
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Therapist");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlanGoal", b =>
                {
                    b.HasOne("Domain.Entities.TreatmentPlan", null)
                        .WithMany("GoalsList")
                        .HasForeignKey("TreatmentPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();

                    b.Navigation("SessionNote")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.GroupSession", b =>
                {
                    b.Navigation("GroupSessionPatients");
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("ExerciseSubmissions");

                    b.Navigation("GroupSessions");

                    b.Navigation("Payments");

                    b.Navigation("TreatmentPlans");
                });

            modelBuilder.Entity("Domain.Entities.Therapist", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("AssignedExercises");

                    b.Navigation("GroupSessionsLed");

                    b.Navigation("TreatmentPlans");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlan", b =>
                {
                    b.Navigation("GoalsList");
                });
#pragma warning restore 612, 618
        }
    }
}
