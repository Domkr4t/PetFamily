﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFamily.Infrastucture;

#nullable disable

namespace PetFamily.Infrastucture.Migrations
{
    [DbContext(typeof(ApplicationDbConbext))]
    [Migration("20241007111642_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFamily.Domain.Pets.Entity.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("address");

                    b.Property<int>("AssistanceStatus")
                        .HasColumnType("integer")
                        .HasColumnName("assistance_status");

                    b.Property<string>("Coloring")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("coloring");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<int>("Growth")
                        .HasColumnType("integer")
                        .HasColumnName("growth");

                    b.Property<bool>("IsCastrated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_castrated");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("PetHealthInfo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("pet_health_info");

                    b.Property<int>("Weight")
                        .HasColumnType("integer")
                        .HasColumnName("weight");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("PetDetails", "PetFamily.Domain.Pets.Entity.Pet.PetDetails#PetDetails", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Breed")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("pet_details_breed");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("pet_details_type");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("VolunteerTelephone", "PetFamily.Domain.Pets.Entity.Pet.VolunteerTelephone#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("volunteer_telephone_value");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Pets.Entity.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("patronymic");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("surname");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("integer")
                        .HasColumnName("years_of_experience");

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "PetFamily.Domain.Pets.Entity.Volunteer.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("phone_number_value");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Pets.Entity.Pet", b =>
                {
                    b.HasOne("PetFamily.Domain.Pets.Entity.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("volunteer_id")
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");

                    b.OwnsOne("PetFamily.Domain.Pets.VO.BankDetailsList", "BankDetails", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId")
                                .HasName("pk_pets");

                            b1.ToTable("pets");

                            b1.ToJson("BankDetails");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_pet_id");

                            b1.OwnsMany("PetFamily.Domain.Pets.VO.BankDetails", "BankDetails", b2 =>
                                {
                                    b2.Property<Guid>("BankDetailsListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("BIC")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("BankName")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("CorrespondentAccount")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("INN")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("KPP")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("BankDetailsListPetId", "Id")
                                        .HasName("pk_pets");

                                    b2.ToTable("pets");

                                    b2.WithOwner()
                                        .HasForeignKey("BankDetailsListPetId")
                                        .HasConstraintName("fk_pets_pets_bank_details_list_pet_id");
                                });

                            b1.Navigation("BankDetails");
                        });

                    b.OwnsOne("PetFamily.Domain.Pets.VO.PetPhotoList", "PetPhotos", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.ToJson("PetPhotos");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");

                            b1.OwnsMany("PetFamily.Domain.Pets.VO.PetPhoto", "PetPhotos", b2 =>
                                {
                                    b2.Property<Guid>("PetPhotoListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<bool>("MainOrNot")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("Path")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("PetPhotoListPetId", "Id")
                                        .HasName("pk_pets");

                                    b2.ToTable("pets");

                                    b2.WithOwner()
                                        .HasForeignKey("PetPhotoListPetId")
                                        .HasConstraintName("fk_pets_pets_pet_photo_list_pet_id");
                                });

                            b1.Navigation("PetPhotos");
                        });

                    b.Navigation("BankDetails")
                        .IsRequired();

                    b.Navigation("PetPhotos")
                        .IsRequired();
                });

            modelBuilder.Entity("PetFamily.Domain.Pets.Entity.Volunteer", b =>
                {
                    b.OwnsOne("PetFamily.Domain.Pets.VO.BankDetailsList", "BankDetails", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("BankDetails");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("PetFamily.Domain.Pets.VO.BankDetails", "BankDetails", b2 =>
                                {
                                    b2.Property<Guid>("BankDetailsListVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("BIC")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("BankName")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("CorrespondentAccount")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("INN")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("KPP")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("BankDetailsListVolunteerId", "Id")
                                        .HasName("pk_volunteers");

                                    b2.ToTable("volunteers");

                                    b2.WithOwner()
                                        .HasForeignKey("BankDetailsListVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_bank_details_list_volunteer_id");
                                });

                            b1.Navigation("BankDetails");
                        });

                    b.OwnsOne("PetFamily.Domain.Pets.VO.SocialNetworkList", "SocialNetworks", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("SocialNetworks");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("PetFamily.Domain.Pets.VO.SocialNetwork", "Networks", b2 =>
                                {
                                    b2.Property<Guid>("SocialNetworkListVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Link")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("SocialNetworkListVolunteerId", "Id")
                                        .HasName("pk_volunteers");

                                    b2.ToTable("volunteers");

                                    b2.WithOwner()
                                        .HasForeignKey("SocialNetworkListVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_social_network_list_volunteer_id");
                                });

                            b1.Navigation("Networks");
                        });

                    b.Navigation("BankDetails")
                        .IsRequired();

                    b.Navigation("SocialNetworks")
                        .IsRequired();
                });

            modelBuilder.Entity("PetFamily.Domain.Pets.Entity.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
