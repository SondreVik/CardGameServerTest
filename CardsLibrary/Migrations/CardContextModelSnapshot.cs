﻿// <auto-generated />
using CardsLibrary;
using CardsLibrary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CardsLibrary.Migrations
{
    [DbContext(typeof(CardContext))]
    partial class CardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CardsLibrary.Model.Card", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CardIndex");

                    b.Property<string>("DeckID");

                    b.Property<Guid?>("DeckID1");

                    b.Property<int>("Type");

                    b.Property<int>("Value");

                    b.Property<bool>("Visible");

                    b.HasKey("ID");

                    b.HasIndex("DeckID1");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("CardsLibrary.Model.Deck", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Column");

                    b.Property<int>("HiddenCards");

                    b.Property<string>("PlayerID");

                    b.Property<Guid?>("PlayerID1");

                    b.Property<int>("Row");

                    b.Property<string>("TableID");

                    b.Property<Guid?>("TableID1");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID1");

                    b.HasIndex("TableID1");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("CardsLibrary.Model.Game", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("CardsLibrary.Model.LoggedInUser", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LoggedIn");

                    b.Property<string>("Token");

                    b.Property<string>("UserID");

                    b.Property<Guid?>("UserID1");

                    b.HasKey("ID");

                    b.HasIndex("UserID1");

                    b.ToTable("LoggedInUser");
                });

            modelBuilder.Entity("CardsLibrary.Model.Move", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FromCol");

                    b.Property<string>("FromPlayerID");

                    b.Property<Guid?>("FromPlayerID1");

                    b.Property<int>("FromRow");

                    b.Property<int?>("MoveIndex");

                    b.Property<string>("TableID");

                    b.Property<Guid?>("TableID1");

                    b.Property<int>("ToCol");

                    b.Property<string>("ToPlayerID");

                    b.Property<Guid?>("ToPlayerID1");

                    b.Property<int>("ToRow");

                    b.Property<int>("TypeOfMove");

                    b.HasKey("ID");

                    b.HasIndex("FromPlayerID1");

                    b.HasIndex("TableID1");

                    b.HasIndex("ToPlayerID1");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("CardsLibrary.Model.Player", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TableID");

                    b.Property<Guid?>("TableID1");

                    b.Property<Guid?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("TableID1");

                    b.HasIndex("UserID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CardsLibrary.Model.Table", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameID");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("CardsLibrary.Model.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Alias");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CardsLibrary.Model.Card", b =>
                {
                    b.HasOne("CardsLibrary.Model.Deck")
                        .WithMany("Cards")
                        .HasForeignKey("DeckID1");
                });

            modelBuilder.Entity("CardsLibrary.Model.Deck", b =>
                {
                    b.HasOne("CardsLibrary.Model.Player")
                        .WithMany("Decks")
                        .HasForeignKey("PlayerID1");

                    b.HasOne("CardsLibrary.Model.Table")
                        .WithMany("Decks")
                        .HasForeignKey("TableID1");
                });

            modelBuilder.Entity("CardsLibrary.Model.LoggedInUser", b =>
                {
                    b.HasOne("CardsLibrary.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID1");
                });

            modelBuilder.Entity("CardsLibrary.Model.Move", b =>
                {
                    b.HasOne("CardsLibrary.Model.Player", "FromPlayer")
                        .WithMany()
                        .HasForeignKey("FromPlayerID1");

                    b.HasOne("CardsLibrary.Model.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableID1");

                    b.HasOne("CardsLibrary.Model.Player", "ToPlayer")
                        .WithMany()
                        .HasForeignKey("ToPlayerID1");
                });

            modelBuilder.Entity("CardsLibrary.Model.Player", b =>
                {
                    b.HasOne("CardsLibrary.Model.Table")
                        .WithMany("Players")
                        .HasForeignKey("TableID1");

                    b.HasOne("CardsLibrary.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("CardsLibrary.Model.Table", b =>
                {
                    b.HasOne("CardsLibrary.Model.Game")
                        .WithMany("Tables")
                        .HasForeignKey("GameID");
                });
#pragma warning restore 612, 618
        }
    }
}
