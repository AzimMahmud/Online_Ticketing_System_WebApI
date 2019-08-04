﻿// <auto-generated />
using System;
using BusTicket.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusTicket.API.Migrations
{
    [DbContext(typeof(BusTicketContext))]
    [Migration("20190727044752_Update Route Model Class")]
    partial class UpdateRouteModelClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusTicket.API.Core.Domain.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("BrandID");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandID = 1,
                            Name = "Hino"
                        },
                        new
                        {
                            BrandID = 2,
                            Name = "Mac"
                        },
                        new
                        {
                            BrandID = 3,
                            Name = "Scania"
                        });
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.BusCategory", b =>
                {
                    b.Property<int>("BusCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("BusCategoryID");

                    b.ToTable("BusCategories");

                    b.HasData(
                        new
                        {
                            BusCategoryID = 1,
                            Name = "Non-AC"
                        },
                        new
                        {
                            BusCategoryID = 2,
                            Name = "AC"
                        });
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.BusDetail", b =>
                {
                    b.Property<int>("BusDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID");

                    b.Property<int>("BusCategoryID");

                    b.Property<int>("VendorID");

                    b.HasKey("BusDetailID");

                    b.HasIndex("BrandID");

                    b.HasIndex("BusCategoryID");

                    b.HasIndex("VendorID");

                    b.ToTable("BusDetails");

                    b.HasData(
                        new
                        {
                            BusDetailID = 1,
                            BrandID = 1,
                            BusCategoryID = 1,
                            VendorID = 1
                        },
                        new
                        {
                            BusDetailID = 2,
                            BrandID = 2,
                            BusCategoryID = 2,
                            VendorID = 2
                        },
                        new
                        {
                            BusDetailID = 3,
                            BrandID = 1,
                            BusCategoryID = 1,
                            VendorID = 3
                        },
                        new
                        {
                            BusDetailID = 4,
                            BrandID = 2,
                            BusCategoryID = 2,
                            VendorID = 2
                        });
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.BusReservation", b =>
                {
                    b.Property<int>("BusReservationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender");

                    b.Property<string>("NoOfBus");

                    b.Property<string>("PassengerEmail");

                    b.Property<string>("PassengerName");

                    b.Property<string>("PassengerPhoneNo");

                    b.Property<DateTime>("ReservationDate");

                    b.Property<decimal>("TotalAmount");

                    b.HasKey("BusReservationID");

                    b.ToTable("BusReservations");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.BusReservationCancel", b =>
                {
                    b.Property<int>("BusRsrvCnclID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("InvoiceID");

                    b.Property<string>("NoOfBus");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("BusRsrvCnclID");

                    b.ToTable("BusReservationCancels");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoardPoint");

                    b.Property<DateTime>("BoardTime");

                    b.Property<string>("BusDetails");

                    b.Property<string>("DropPoint");

                    b.Property<DateTime>("DropTime");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("NoOfTicket");

                    b.Property<string>("PaymentMethod");

                    b.Property<string>("PhoneNo");

                    b.Property<DateTime>("ReservationDate");

                    b.Property<decimal>("TotalAmount");

                    b.Property<string>("TransactionType");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("InvoiceID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MessageBody");

                    b.Property<DateTime>("MessageDeliveryDate");

                    b.Property<DateTime>("MessageDeliveryTime");

                    b.Property<int>("RecipientID");

                    b.Property<int>("UserID");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.PaymentType", b =>
                {
                    b.Property<int>("PayTypID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive");

                    b.Property<string>("PaymentMethod");

                    b.HasKey("PayTypID");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.PromoOffer", b =>
                {
                    b.Property<int>("PromoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PromoCode");

                    b.Property<string>("PromoDetails");

                    b.HasKey("PromoID");

                    b.ToTable("PromoOffers");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.Route", b =>
                {
                    b.Property<int>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoardPoint");

                    b.Property<TimeSpan>("BoardTime");

                    b.Property<int>("BusDetailID");

                    b.Property<string>("DropPoint");

                    b.Property<TimeSpan>("DropTime");

                    b.Property<decimal>("Fare");

                    b.HasKey("RouteID");

                    b.HasIndex("BusDetailID");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.SeatLayout", b =>
                {
                    b.Property<int>("SeatLayoutID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusDetailID");

                    b.Property<int>("BusDetailsID");

                    b.Property<int>("LastSeat");

                    b.Property<string>("Layout");

                    b.Property<string>("LayoutType");

                    b.Property<int>("TotalSeat");

                    b.HasKey("SeatLayoutID");

                    b.HasIndex("BusDetailID");

                    b.ToTable("SeatLayout");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.TicketReservation", b =>
                {
                    b.Property<int>("TicketResrvID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender");

                    b.Property<string>("NoOfTicket");

                    b.Property<string>("PassengerEmail");

                    b.Property<string>("PassengerName");

                    b.Property<string>("PassengerPhoneNo");

                    b.Property<DateTime>("ReservationDate");

                    b.Property<int>("RouteDetailsID");

                    b.Property<int?>("RouteID");

                    b.Property<string>("SeatNo");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("TicketResrvID");

                    b.HasIndex("RouteID");

                    b.ToTable("TicketReservations");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.TicketReturn", b =>
                {
                    b.Property<int>("TicktReturnID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("InvoiceID");

                    b.Property<string>("NoOfTicket");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("TicktReturnID");

                    b.ToTable("TicketReturns");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.Vendor", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VendorAddress");

                    b.Property<string>("VendorEmail");

                    b.Property<string>("VendorName");

                    b.Property<string>("VendorPhone");

                    b.HasKey("VendorID");

                    b.ToTable("Vendors");

                    b.HasData(
                        new
                        {
                            VendorID = 1,
                            VendorAddress = "120 A, Dhaka, Bangladesh",
                            VendorEmail = "greenline@gmail.com",
                            VendorName = "Green Line",
                            VendorPhone = "01731569155"
                        },
                        new
                        {
                            VendorID = 2,
                            VendorAddress = "130 B, Dhaka, Bangladesh",
                            VendorEmail = "shohag@gmail.com",
                            VendorName = "Shohag",
                            VendorPhone = "01731569165"
                        },
                        new
                        {
                            VendorID = 3,
                            VendorAddress = "140 A, Dhaka, Bangladesh",
                            VendorEmail = "skyline@gmail.com",
                            VendorName = "Sky Line",
                            VendorPhone = "01861569155"
                        });
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.VendorPayment", b =>
                {
                    b.Property<int>("VendorPaymentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("PaymentDescription");

                    b.Property<string>("PaymentMethod");

                    b.Property<decimal>("TotalAmount");

                    b.Property<int>("VendorID");

                    b.HasKey("VendorPaymentID");

                    b.HasIndex("VendorID");

                    b.ToTable("VendorPayments");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.BusDetail", b =>
                {
                    b.HasOne("BusTicket.API.Core.Domain.Brand", "Brand")
                        .WithMany("BusDetails")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BusTicket.API.Core.Domain.BusCategory", "BusCategory")
                        .WithMany("BusDetails")
                        .HasForeignKey("BusCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BusTicket.API.Core.Domain.Vendor", "Vendor")
                        .WithMany("BusDetails")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.Route", b =>
                {
                    b.HasOne("BusTicket.API.Core.Domain.BusDetail", "BusDetails")
                        .WithMany()
                        .HasForeignKey("BusDetailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.SeatLayout", b =>
                {
                    b.HasOne("BusTicket.API.Core.Domain.BusDetail", "BusDetail")
                        .WithMany("SeatLayout")
                        .HasForeignKey("BusDetailID");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.TicketReservation", b =>
                {
                    b.HasOne("BusTicket.API.Core.Domain.Route", "Route")
                        .WithMany("TicketReservations")
                        .HasForeignKey("RouteID");
                });

            modelBuilder.Entity("BusTicket.API.Core.Domain.VendorPayment", b =>
                {
                    b.HasOne("BusTicket.API.Core.Domain.Vendor", "Vendor")
                        .WithMany("VendorPayments")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
