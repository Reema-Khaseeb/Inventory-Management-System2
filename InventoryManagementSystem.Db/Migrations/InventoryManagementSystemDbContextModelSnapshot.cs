﻿// <auto-generated />
using InventoryManagementSystem.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InventoryManagementSystem.Db.Migrations
{
    [DbContext(typeof(InventoryManagementSystemDbContext))]
    partial class InventoryManagementSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InventoryManagementSystem.Db.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kitchen Appliances"
                        });
                });

            modelBuilder.Entity("InventoryManagementSystem.Db.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Item", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A portable computer",
                            Name = "Laptop",
                            Quantity = 10,
                            Status = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "A cotton shirt",
                            Name = "T-Shirt",
                            Quantity = 50,
                            Status = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "High-end mobile phone",
                            Name = "Smartphone",
                            Quantity = 25,
                            Status = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Denim jeans",
                            Name = "Jeans",
                            Quantity = 0,
                            Status = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Electronic book reader",
                            Name = "E-Reader",
                            Quantity = 15,
                            Status = 1,
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 4,
                            Description = "Kitchen appliance",
                            Name = "Blender",
                            Quantity = 20,
                            Status = 0,
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            Description = "Heats food quickly and efficiently",
                            Name = "Microwave Oven",
                            Quantity = 30,
                            Status = 0,
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "A novel set in a fictional universe",
                            Name = "Fantasy Novel",
                            Quantity = 50,
                            Status = 0,
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Description = "Wireless over-ear headphones",
                            Name = "Headphones",
                            Quantity = 60,
                            Status = 0,
                            UserId = 9
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "Warm wool sweater",
                            Name = "Sweater",
                            Quantity = 35,
                            Status = 0,
                            UserId = 10
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            Description = "LED desk lamp",
                            Name = "Lamp",
                            Quantity = 40,
                            Status = 0,
                            UserId = 11
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Covers world history",
                            Name = "History Book",
                            Quantity = 20,
                            Status = 0,
                            UserId = 12
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = "Latest generation home video game console",
                            Name = "Gaming Console",
                            Quantity = 15,
                            Status = 1,
                            UserId = 13
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Description = "Lightweight and comfortable running shoes",
                            Name = "Running Shoes",
                            Quantity = 25,
                            Status = 0,
                            UserId = 14
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Description = "Space adventure novel",
                            Name = "Sci-Fi Novel",
                            Quantity = 30,
                            Status = 0,
                            UserId = 15
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            Description = "Automatic drip coffee maker",
                            Name = "Coffee Maker",
                            Quantity = 20,
                            Status = 0,
                            UserId = 16
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 1,
                            Description = "Wearable technology for fitness tracking",
                            Name = "Smartwatch",
                            Quantity = 40,
                            Status = 0,
                            UserId = 17
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 2,
                            Description = "High-quality leather jacket",
                            Name = "Leather Jacket",
                            Quantity = 10,
                            Status = 1,
                            UserId = 18
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 3,
                            Description = "Collection of gourmet recipes",
                            Name = "Cookbook",
                            Quantity = 50,
                            Status = 0,
                            UserId = 19
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Description = "Improves indoor air quality",
                            Name = "Air Purifier",
                            Quantity = 15,
                            Status = 1,
                            UserId = 20
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 2,
                            Description = "Portable touchscreen computer",
                            Name = "Tablet",
                            Quantity = 25,
                            Status = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 2,
                            Description = "Soft cotton hoodie",
                            Name = "Hoodie",
                            Quantity = 60,
                            Status = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 4,
                            Description = "Adjustable LED desk lamp",
                            Name = "Desk Lamp",
                            Quantity = 70,
                            Status = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 3,
                            Description = "Engaging and suspenseful mystery novel",
                            Name = "Mystery Novel",
                            Quantity = 80,
                            Status = 0,
                            UserId = 4
                        },
                        new
                        {
                            Id = 29,
                            CategoryId = 1,
                            Description = "1TB USB external hard drive",
                            Name = "External Hard Drive",
                            Quantity = 90,
                            Status = 0,
                            UserId = 5
                        },
                        new
                        {
                            Id = 30,
                            CategoryId = 2,
                            Description = "UV protection sunglasses",
                            Name = "Sunglasses",
                            Quantity = 100,
                            Status = 0,
                            UserId = 6
                        },
                        new
                        {
                            Id = 31,
                            CategoryId = 4,
                            Description = "4-slice toaster",
                            Name = "Toaster",
                            Quantity = 110,
                            Status = 0,
                            UserId = 7
                        },
                        new
                        {
                            Id = 32,
                            CategoryId = 3,
                            Description = "Biography of a historical figure",
                            Name = "Biography Book",
                            Quantity = 120,
                            Status = 0,
                            UserId = 8
                        },
                        new
                        {
                            Id = 33,
                            CategoryId = 1,
                            Description = "Mechanical RGB gaming keyboard",
                            Name = "Gaming Keyboard",
                            Quantity = 130,
                            Status = 0,
                            UserId = 9
                        },
                        new
                        {
                            Id = 34,
                            CategoryId = 2,
                            Description = "Lightweight running shorts",
                            Name = "Running Shorts",
                            Quantity = 0,
                            Status = 2,
                            UserId = 10
                        },
                        new
                        {
                            Id = 35,
                            CategoryId = 4,
                            Description = "Bagless cyclone vacuum cleaner",
                            Name = "Vacuum Cleaner",
                            Quantity = 150,
                            Status = 0,
                            UserId = 11
                        },
                        new
                        {
                            Id = 36,
                            CategoryId = 3,
                            Description = "Guide to personal growth and productivity",
                            Name = "Self-Help Book",
                            Quantity = 160,
                            Status = 0,
                            UserId = 12
                        },
                        new
                        {
                            Id = 37,
                            CategoryId = 1,
                            Description = "High-definition USB webcam",
                            Name = "Webcam",
                            Quantity = 170,
                            Status = 0,
                            UserId = 13
                        });
                });

            modelBuilder.Entity("InventoryManagementSystem.Db.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "user1@example.com",
                            Password = "$2a$11$OE3EfWVFwUVI/a2sn.c/rukbV7vsRutAQ/DUA15dSYjt4u8tiHUvG",
                            Role = 0,
                            Username = "user1"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "user2@example.com",
                            Password = "$2a$11$JwpBhE0g6mouTilwuBvg2ena/qeijqz6QgdPb8lYYIIDCc7kA60gm",
                            Role = 0,
                            Username = "user2"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "user3@example.com",
                            Password = "$2a$11$dSgppSZyE3hTBcx0w9oKp.FGcxYcHeDWjILs3iJ/8wgikX6v4Q99.",
                            Role = 0,
                            Username = "user3"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "user4@example.com",
                            Password = "$2a$11$GrohEq30A5eFk2i.rYzQmuWdmuNvB3saBwK..FVnyBTBZ8867P0Pm",
                            Role = 0,
                            Username = "user4"
                        },
                        new
                        {
                            UserId = 5,
                            Email = "user5@example.com",
                            Password = "$2a$11$illGJHqhqPWWpVuCzUOyXO65MAwSB1aDqwSu5LbtJlnl3cJDK2.Ju",
                            Role = 0,
                            Username = "user5"
                        },
                        new
                        {
                            UserId = 6,
                            Email = "user6@example.com",
                            Password = "$2a$11$zlUwH5SkPcfktfUxrIuJCumKE.gsw3EIxNeiAcF28HYGxGxxutbuO",
                            Role = 0,
                            Username = "user6"
                        },
                        new
                        {
                            UserId = 7,
                            Email = "user7@example.com",
                            Password = "$2a$11$x5yiNkHkKNRyFwc1tUj8M.dNvgc6oXQ4CmouW7uSVF.GTxI6ICma.",
                            Role = 0,
                            Username = "user7"
                        },
                        new
                        {
                            UserId = 8,
                            Email = "user8@example.com",
                            Password = "$2a$11$iaC4jY69YPnnrNbZakm5N./bmHADf.b0ssQp84.o0xbG0W3Tichdi",
                            Role = 0,
                            Username = "user8"
                        },
                        new
                        {
                            UserId = 9,
                            Email = "user9@example.com",
                            Password = "$2a$11$4ECOPTkDIyLlF4WyeUOfJupqRHRAkTKWJMfblgGer1oUYQy1xtYiO",
                            Role = 0,
                            Username = "user9"
                        },
                        new
                        {
                            UserId = 10,
                            Email = "user10@example.com",
                            Password = "$2a$11$Pn7lkZjQbIt82aZzwyBJk.L8n4nCyEC6e2mr/hF7rIiyAZf5CvYla",
                            Role = 0,
                            Username = "user10"
                        },
                        new
                        {
                            UserId = 11,
                            Email = "user11@example.com",
                            Password = "$2a$11$Ac.1kMG6h.yffR1eWNfUY.j3ZPi6kfk694k/p89y1ntLSaT5iRLvW",
                            Role = 0,
                            Username = "user11"
                        },
                        new
                        {
                            UserId = 12,
                            Email = "user12@example.com",
                            Password = "$2a$11$hhWUFwITOVZYlylPtwPdNeNp3ItIrtFqibFGmisX0pwdiuOnBKLhO",
                            Role = 0,
                            Username = "user12"
                        },
                        new
                        {
                            UserId = 13,
                            Email = "user13@example.com",
                            Password = "$2a$11$14I01jrKO3cQemc0HnBCQeZOgJYhWqU8ChaI6nrc4Ajd/oF.ScU.K",
                            Role = 0,
                            Username = "user13"
                        },
                        new
                        {
                            UserId = 14,
                            Email = "user14@example.com",
                            Password = "$2a$11$yJrBmNKtfM9K88ARJhmGvO3HHfxHHFoxxCJCr1bVbBgaTnV.IHzmC",
                            Role = 0,
                            Username = "user14"
                        },
                        new
                        {
                            UserId = 15,
                            Email = "user15@example.com",
                            Password = "$2a$11$Nc4n74MZtnSnGa6nEolMye9wB0ulzQuaTOxwj8HypF3JZkN7WuMmG",
                            Role = 0,
                            Username = "user15"
                        },
                        new
                        {
                            UserId = 16,
                            Email = "user16@example.com",
                            Password = "$2a$11$vHiOJZQfZRiIDbFqB7InguAGm2Ds6shFVcUdDVYYOtrX0DvOmaQvy",
                            Role = 0,
                            Username = "user16"
                        },
                        new
                        {
                            UserId = 17,
                            Email = "user17@example.com",
                            Password = "$2a$11$u8RH.xYFUHoxBupDzDW0Wu0vEHRPxFspzwLDP1w.9cfZTthWBFI7e",
                            Role = 0,
                            Username = "user17"
                        },
                        new
                        {
                            UserId = 18,
                            Email = "user18@example.com",
                            Password = "$2a$11$uhsfPHkW4y34jkNVC8UhyOB4Al0UnPiuhcGCyxNjJg.u4y2GDAzY.",
                            Role = 0,
                            Username = "user18"
                        },
                        new
                        {
                            UserId = 19,
                            Email = "user19@example.com",
                            Password = "$2a$11$rIEz2dkhN8J4PtVjHGL68OZwvA/5STigm1ftGZ7mI8n5JWhAsU0c2",
                            Role = 0,
                            Username = "user19"
                        },
                        new
                        {
                            UserId = 20,
                            Email = "user20@example.com",
                            Password = "$2a$11$OnxIr2pUxnhTcuC59BdcD.sLFp2ap8P9W5p5/L1/ITQEMsF32GhYe",
                            Role = 0,
                            Username = "user20"
                        },
                        new
                        {
                            UserId = 21,
                            Email = "user21@example.com",
                            Password = "$2a$11$bVDRlZfgl3s52JyKkPDlBeHClh79iKCRKpI4XJr8h6ppoQwwqiPf.",
                            Role = 0,
                            Username = "user21"
                        },
                        new
                        {
                            UserId = 22,
                            Email = "user22@example.com",
                            Password = "$2a$11$Vj/CAxNc4ovpXdahO0mOI.0igLo50ESbiwXrw5hyWvUMWSQqr0c7y",
                            Role = 0,
                            Username = "user22"
                        },
                        new
                        {
                            UserId = 23,
                            Email = "user23@example.com",
                            Password = "$2a$11$OOa4jp2s4aQeVis0Fly2pefS9UDLJuLEsRPWul6ljqv7jaWtddFCC",
                            Role = 0,
                            Username = "user23"
                        },
                        new
                        {
                            UserId = 24,
                            Email = "user24@example.com",
                            Password = "$2a$11$7NI.8Ziz9MXpMcq/gBs9f.ZfSAu7bC6/qXeTcb9.oNDQv13Y5qgR2",
                            Role = 0,
                            Username = "user24"
                        },
                        new
                        {
                            UserId = 25,
                            Email = "user25@example.com",
                            Password = "$2a$11$P7vKcFCteCcpT6JzFc3y4OR8H6flmGs5GvQ2PRFh8xCJ/sevA90P6",
                            Role = 0,
                            Username = "user25"
                        },
                        new
                        {
                            UserId = 26,
                            Email = "user26@example.com",
                            Password = "$2a$11$BDirTnZK.lLRRaTzZYpRVubH6WVwU.zOrdgGd8KU.0jK25pRIxXj6",
                            Role = 0,
                            Username = "user26"
                        },
                        new
                        {
                            UserId = 27,
                            Email = "user27@example.com",
                            Password = "$2a$11$u5qJM90SLMDPPqgAGZC2peSXhMDv5F/YRWnArAX/oroI2vAZ01YnO",
                            Role = 0,
                            Username = "user27"
                        },
                        new
                        {
                            UserId = 28,
                            Email = "user28@example.com",
                            Password = "$2a$11$7SwesXhRljBaY7gUEMhYBu1zegIg6WH1LXbkHhmUk9urT.8tkpeyO",
                            Role = 0,
                            Username = "user28"
                        },
                        new
                        {
                            UserId = 29,
                            Email = "user29@example.com",
                            Password = "$2a$11$ZCvsTkmPC5/nE3ukKqsb6uO5GNVheVqpSzCUqCqS5hJj7LWUeGc36",
                            Role = 0,
                            Username = "user29"
                        },
                        new
                        {
                            UserId = 30,
                            Email = "user30@example.com",
                            Password = "$2a$11$ZlJ/sVQ9y8QE0FOK3QhPYu7zrAjgGTNZuXnWO7Nc5mwirxtc9QKRa",
                            Role = 0,
                            Username = "user30"
                        },
                        new
                        {
                            UserId = 31,
                            Email = "user31@example.com",
                            Password = "$2a$11$SPBBvQfUk9L4jZ6/WHmfeuMI3D.788JK2VTmRieVBFKieMg07I91e",
                            Role = 0,
                            Username = "user31"
                        },
                        new
                        {
                            UserId = 32,
                            Email = "user32@example.com",
                            Password = "$2a$11$yDXsnX0CjtNum.Tto5RYJ.MgOWPMZ82eivL292NpyTUZhIbPYFVNy",
                            Role = 0,
                            Username = "user32"
                        },
                        new
                        {
                            UserId = 33,
                            Email = "user33@example.com",
                            Password = "$2a$11$O3iz/Cc37qI8RuNT6R58kOQGisOFUfxTw/lAA5vRiaeMnDvDhRmtO",
                            Role = 0,
                            Username = "user33"
                        },
                        new
                        {
                            UserId = 34,
                            Email = "user34@example.com",
                            Password = "$2a$11$JwboA75ynlvsK7FdgGvKeOxtiPU5SG7AG3xTh/8OAFi0Fc/7dQ6T2",
                            Role = 0,
                            Username = "user34"
                        },
                        new
                        {
                            UserId = 35,
                            Email = "user35@example.com",
                            Password = "$2a$11$s0tqgaLPPodVmRsIFK1Mu.7KkCQ.AThIOMX8z8i.IK/asUp6m17z2",
                            Role = 0,
                            Username = "user35"
                        },
                        new
                        {
                            UserId = 36,
                            Email = "user36@example.com",
                            Password = "$2a$11$7mtRwj/21ZY0pF/VGh.GIeeEWTeDN7yKyi2gmDP8SPhr0rrgQ2.46",
                            Role = 0,
                            Username = "user36"
                        },
                        new
                        {
                            UserId = 37,
                            Email = "user37@example.com",
                            Password = "$2a$11$Qp.c8XQdv3IUDGAjRP8WMuuVxZhrOWfvyY9riO8aICE2WOCydL.ii",
                            Role = 0,
                            Username = "user37"
                        },
                        new
                        {
                            UserId = 38,
                            Email = "user38@example.com",
                            Password = "$2a$11$jNXjvXpyCyaNyugovdG/VOW/0IvgGbjR.v4FNUwcCh9E8KCCXYIoi",
                            Role = 0,
                            Username = "user38"
                        },
                        new
                        {
                            UserId = 39,
                            Email = "user39@example.com",
                            Password = "$2a$11$ticcliD1qsWLZ4WHp2KhOOLCSGN2CQfXVZbgYXI4t7BaSIy9gB75m",
                            Role = 0,
                            Username = "user39"
                        },
                        new
                        {
                            UserId = 40,
                            Email = "user40@example.com",
                            Password = "$2a$11$0oigwFAVoyeP8CiKWa08HuYCSvzUbiPg6eyA.nqH1nUkyibWXv9Qu",
                            Role = 0,
                            Username = "user40"
                        },
                        new
                        {
                            UserId = 41,
                            Email = "user41@example.com",
                            Password = "$2a$11$DRYDCCIvX54qUIHEuwgjj.e.RbpOwyKOTX6zQ1yiU79yInCI2b3Qi",
                            Role = 0,
                            Username = "user41"
                        },
                        new
                        {
                            UserId = 42,
                            Email = "user42@example.com",
                            Password = "$2a$11$DljAHdDIhBlCkmC57a2ytu0hygZrsFjwMrKMcrDhKRvbK.RYdhSxa",
                            Role = 0,
                            Username = "user42"
                        },
                        new
                        {
                            UserId = 43,
                            Email = "user43@example.com",
                            Password = "$2a$11$ezk9zSYXgF8/lOdLf/2KBuLzHl.bgh8Xa.WFWX/WV77HtEFbR3T.W",
                            Role = 0,
                            Username = "user43"
                        },
                        new
                        {
                            UserId = 44,
                            Email = "user44@example.com",
                            Password = "$2a$11$yCOEDpRza3csrjQQ9s3SoeEGqs8XblRRtHMK0rd3x63JDNJD4Adbe",
                            Role = 0,
                            Username = "user44"
                        },
                        new
                        {
                            UserId = 45,
                            Email = "user45@example.com",
                            Password = "$2a$11$l0CokZpJ8t3PsHpz302r6.SeX/DIrcPFbkGU.G0ZXYb7XndVpOZWi",
                            Role = 0,
                            Username = "user45"
                        },
                        new
                        {
                            UserId = 46,
                            Email = "user46@example.com",
                            Password = "$2a$11$c2qNsaZL2FiFHol5MrJriupjCKk///KJnKrIx3/ka19AKv567U80.",
                            Role = 0,
                            Username = "user46"
                        },
                        new
                        {
                            UserId = 47,
                            Email = "user47@example.com",
                            Password = "$2a$11$vJ8PboIZVH7HYpD8tpXMj.1w2Vunng8ivvrIDq5.BzCgl5D5BLEEK",
                            Role = 0,
                            Username = "user47"
                        },
                        new
                        {
                            UserId = 48,
                            Email = "user48@example.com",
                            Password = "$2a$11$IcvZMNCeGiUBJKD0GmqJbOU69uX3/.XlDeejUQhhwjCQhP8E4ZTcq",
                            Role = 0,
                            Username = "user48"
                        },
                        new
                        {
                            UserId = 49,
                            Email = "user49@example.com",
                            Password = "$2a$11$SfhT21Ua7yjqHCp.mD96zO7p40hgg4H76/6.yWeoCidLqDj/oobHu",
                            Role = 0,
                            Username = "user49"
                        },
                        new
                        {
                            UserId = 50,
                            Email = "user50@example.com",
                            Password = "$2a$11$Lx4irD.OnGi8TCOItxIUau2goaLxffmqhdeDx0o/J2MiGJRY7dTaK",
                            Role = 0,
                            Username = "user50"
                        },
                        new
                        {
                            UserId = 100,
                            Email = "admin1@example.com",
                            Password = "$2a$11$G9RzLZRZtPyDPUuODbem1emfRQxxLAj/.URBaKZCGhMZY2cDpVz4C",
                            Role = 1,
                            Username = "admin1"
                        },
                        new
                        {
                            UserId = 200,
                            Email = "admin2@example.com",
                            Password = "$2a$11$4RdXLuldsfInZFG2uoKiPOa8/xbUlwiD9Ff1r27Wqq2slqZVI1zkG",
                            Role = 1,
                            Username = "admin2"
                        });
                });

            modelBuilder.Entity("InventoryManagementSystem.Db.Models.Item", b =>
                {
                    b.HasOne("InventoryManagementSystem.Db.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryManagementSystem.Db.Models.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InventoryManagementSystem.Db.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("InventoryManagementSystem.Db.Models.User", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
