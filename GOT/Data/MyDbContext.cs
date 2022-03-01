using GOT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigTurysta(modelBuilder);

            ConfigPrzodownik(modelBuilder);

            ConfigDaneUzytkownika(modelBuilder);

            ConfigKsiazeckaGOT(modelBuilder);

            ConfigWpis(modelBuilder);

            ConfigWeryfikacja(modelBuilder);

            ConfigWycieczka(modelBuilder);

            ConfigTrasa(modelBuilder);

            ConfigOdcinekTrasy(modelBuilder);

            ConfigOdcinek(modelBuilder);

            ConfigPunktGeograficzny(modelBuilder);

            ConfigZdjecieWpisu(modelBuilder);

            ConfigGrupaGorska(modelBuilder);

        }

        private int GetPointsForEntry(int entryIdentifier)
        {
            var result = Wpis.Include(w => w.Wycieczka)
                .Where(w => w.Numer == entryIdentifier)
                .Select(w => w.Wycieczka)
                .Select(w => w.Trasa)
                .Select(t => t.OdcinekTrasy)
                .SelectMany(o => o.Select(oT => oT))
                .Select(oT => oT.Odcinek)
                .Sum(o => o.Punkty);

            return result;
        }

        public DbSet<Turysta> Turysta { get; set; }

        public DbSet<Przodownik> Przodownik { get; set; }

        public DbSet<DaneUzytkownika> DaneUzytkownika { get; set; }

        public DbSet<KsiazeckaGOT> KsiazeckaGOT { get; set; }

        public virtual DbSet<Wpis> Wpis { get; set; }

        public virtual DbSet<Weryfikacja> Weryfikacja { get; set; }

        public DbSet<Wycieczka> Wycieczka { get; set; }

        public DbSet<Trasa> Trasa { get; set; }

        public DbSet<OdcinekTrasy> OdcinekTrasy { get; set; }

        public DbSet<Odcinek> Odcinek { get; set; }

        public DbSet<PunktGeograficzny> PunktGeograficzny { get; set; }

        public DbSet<ZdjecieWpisu> ZdjecieWpisu { get; set; }

        public DbSet<GrupaGorska> GrupaGorska { get; set; }

        private void ConfigTurysta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turysta>()
                .HasOne(t => t.DaneUzytkownika)
                .WithOne(d => d.Turysta)
                .HasForeignKey<Turysta>(t => t.Login);

            modelBuilder.Entity<Turysta>()
                .HasData
                (
                    new Turysta
                    {
                        Login = "kacper1134",
                        Liczba_Punktow = 0
                    },

                    new Turysta
                    {
                        Login = "jakub1134",
                        Liczba_Punktow = 0
                    }
                ); ;
        }

        private void ConfigPrzodownik(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Przodownik>()
                .HasOne(p => p.DaneUzytkownika)
                .WithOne(d => d.Przodownik)
                .HasForeignKey<Przodownik>(p => p.Login);

            modelBuilder.Entity<Przodownik>()
                .HasData
                (
                    new Przodownik
                    {
                        Login = "kacper1134",
                        Wyksztalcenie = Models.Enums.Wyksztalcenie.WYZSZE
                    }
                );
        }

        private void ConfigDaneUzytkownika(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaneUzytkownika>()
                .HasIndex(d => d.Adres_Email)
                .IsUnique();

            modelBuilder.Entity<DaneUzytkownika>()
               .HasData
               (
                   new DaneUzytkownika
                   {
                       Login = "kacper1134",
                       Haslo = "aaaaa",
                       Adres_Email = " abs@o2.pl",
                       Imie = "Kacper",
                       Nazwisko = "Kochański",
                       Data_Urodzenia = new DateTime(2000, 11, 15)
                   },

                   new DaneUzytkownika
                   {
                       Login = "jakub1134",
                       Haslo = "aaaaa",
                       Adres_Email = " absa@o2.pl",
                       Imie = "Jakub",
                       Nazwisko = "Kochański",
                       Data_Urodzenia = new DateTime(2000, 11, 15)
                   }
               );
        }

        private void ConfigKsiazeckaGOT(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KsiazeckaGOT>()
                .HasOne(k => k.DaneUzytkownika)
                .WithMany(d => d.KsiazeckaGOT)
                .HasForeignKey(k => k.Login);

            modelBuilder.Entity<KsiazeckaGOT>()
                .HasData
                (
                    new KsiazeckaGOT
                    {
                        Numer = 1,
                        Login = "kacper1134"
                    },

                    new KsiazeckaGOT
                    {
                        Numer = 2,
                        Login = "jakub1134"
                    }
                );
        }

        private void ConfigWpis(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wpis>()
               .HasOne(w => w.KsiazeckaGOT)
               .WithMany(k => k.Wpis)
               .HasForeignKey(w => w.Numer_Ksiazecki);

            modelBuilder.Entity<Wpis>()
                .HasOne(w => w.Wycieczka)
                .WithMany(w => w.Wpis)
                .HasForeignKey(w => w.Numer_Wycieczki);

            modelBuilder.Entity<Wpis>()
                .HasIndex(w => new { w.Numer_Ksiazecki, w.Numer_Wycieczki })
                .IsUnique();

            modelBuilder.Entity<Wpis>()
               .HasData
               (
                   new Wpis
                   {
                       Numer = 1,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 1,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 11, 14)
                   },

                   new Wpis
                   {
                       Numer = 2,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 2,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 10, 15)
                   },

                   new Wpis
                   {
                       Numer = 3,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 2,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 10, 17)
                   },

                   new Wpis
                   {
                       Numer = 4,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 1,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 11, 17)
                   },

                   new Wpis
                   {
                       Numer = 5,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 3,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 12, 19)
                   },

                   new Wpis
                   {
                       Numer = 6,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 4,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 8, 30)
                   },

                   new Wpis
                   {
                       Numer = 7,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 5,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 7, 18)
                   },

                   new Wpis
                   {
                       Numer = 8,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 4,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 8, 29)
                   },

                   new Wpis
                   {
                       Numer = 9,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 5,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 7, 17)
                   }
               );
        }

        private void ConfigWeryfikacja(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weryfikacja>()
                .HasKey(w => new { w.Login_Przodownika, w.Numer_Wpisu });

            modelBuilder.Entity<Weryfikacja>()
                .HasOne(w => w.Przodownik)
                .WithMany(p => p.Weryfikacja)
                .HasForeignKey(w => w.Login_Przodownika);

            modelBuilder.Entity<Weryfikacja>()
                .HasOne(w => w.Wpis)
                .WithOne(w => w.Weryfikacja)
                .HasForeignKey<Weryfikacja>(w => w.Numer_Wpisu);

            modelBuilder.Entity<Weryfikacja>()
                .HasData
                (
                    new Weryfikacja
                    {
                        Numer_Wpisu = 1,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "aaaa",
                        Status = Models.Enums.Status.Odrzucony
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 2,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 3,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Zweryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 4,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 5,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 6,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 7,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 8,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 9,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = Models.Enums.Status.Weryfikowany
                    }
                );
        }

        private void ConfigWycieczka(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wycieczka>()
                .HasOne(w => w.Trasa)
                .WithMany(t => t.Wycieczka)
                .HasForeignKey(w => w.Numer_Trasy);

            modelBuilder.Entity<Wycieczka>()
                .HasOne(w => w.Przodownik)
                .WithMany(p => p.Wycieczka)
                .HasForeignKey(w => w.Login_Przodownika);


            modelBuilder.Entity<Wycieczka>()
               .HasData
               (
                   new Wycieczka
                   {
                       Numer = 1,
                       Numer_Trasy = 1,
                       Login_Przodownika = "kacper1134",
                       Data_Zgloszenia = new DateTime(2021, 11, 12)
                   },

                   new Wycieczka
                   {
                       Numer = 2,
                       Numer_Trasy = 2,
                       Data_Zgloszenia = new DateTime(2021, 10, 12)
                   },

                   new Wycieczka
                   {
                       Numer = 3,
                       Numer_Trasy = 3,
                       Data_Zgloszenia = new DateTime(2021, 12, 17)
                   },

                   new Wycieczka
                   {
                       Numer = 4,
                       Numer_Trasy = 4,
                       Data_Zgloszenia = new DateTime(2021, 8, 27)
                   },

                   new Wycieczka
                   {
                       Numer = 5,
                       Numer_Trasy = 5,
                       Data_Zgloszenia = new DateTime(2021, 7, 15)
                   }
               );
        }

        private void ConfigTrasa(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trasa>()
                .HasData
                (
                    new Trasa
                    {
                        Numer = 1
                    },

                    new Trasa
                    {
                        Numer = 2
                    },

                    new Trasa
                    {
                        Numer = 3
                    },

                    new Trasa
                    {
                        Numer = 4
                    },

                    new Trasa
                    {
                        Numer = 5
                    },

                    new Trasa
                    {
                        Numer = 6
                    }
                );
        }

        private void ConfigOdcinekTrasy(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OdcinekTrasy>()
                .HasKey(o => new { o.Numer_Odcinka, o.Numer_Trasy });

            modelBuilder.Entity<OdcinekTrasy>()
                .HasOne(o => o.Trasa)
                .WithMany(t => t.OdcinekTrasy)
                .HasForeignKey(o => o.Numer_Trasy);

            modelBuilder.Entity<OdcinekTrasy>()
                .HasOne(o => o.Odcinek)
                .WithMany(o => o.OdcinekTrasy)
                .HasForeignKey(o => o.Numer_Odcinka);

            modelBuilder.Entity<OdcinekTrasy>()
                .HasData(
                    new OdcinekTrasy
                    {
                        Numer_Trasy = 1,
                        Numer_Odcinka = 2,
                        Numer_Odcinka_Trasy = 1
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 1,
                        Numer_Odcinka = 5,
                        Numer_Odcinka_Trasy = 2
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 1,
                        Numer_Odcinka = 6,
                        Numer_Odcinka_Trasy = 3
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 1,
                        Numer_Odcinka = 7,
                        Numer_Odcinka_Trasy = 4
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 2,
                        Numer_Odcinka = 10,
                        Numer_Odcinka_Trasy = 1
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 2,
                        Numer_Odcinka = 8,
                        Numer_Odcinka_Trasy = 2
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 2,
                        Numer_Odcinka = 7,
                        Numer_Odcinka_Trasy = 3
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 2,
                        Numer_Odcinka = 6,
                        Numer_Odcinka_Trasy = 4
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 2,
                        Numer_Odcinka = 5,
                        Numer_Odcinka_Trasy = 5
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 2,
                        Numer_Odcinka = 2,
                        Numer_Odcinka_Trasy = 6
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 3,
                        Numer_Odcinka = 11,
                        Numer_Odcinka_Trasy = 1
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 3,
                        Numer_Odcinka = 12,
                        Numer_Odcinka_Trasy = 2
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 3,
                        Numer_Odcinka = 13,
                        Numer_Odcinka_Trasy = 3
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 4,
                        Numer_Odcinka = 19,
                        Numer_Odcinka_Trasy = 1
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 4,
                        Numer_Odcinka = 18,
                        Numer_Odcinka_Trasy = 2
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 4,
                        Numer_Odcinka = 17,
                        Numer_Odcinka_Trasy = 3
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 5,
                        Numer_Odcinka = 14,
                        Numer_Odcinka_Trasy = 1
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 5,
                        Numer_Odcinka = 15,
                        Numer_Odcinka_Trasy = 2
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 5,
                        Numer_Odcinka = 16,
                        Numer_Odcinka_Trasy = 3
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 5,
                        Numer_Odcinka = 17,
                        Numer_Odcinka_Trasy = 4
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 6,
                        Numer_Odcinka = 25,
                        Numer_Odcinka_Trasy = 1
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 6,
                        Numer_Odcinka = 26,
                        Numer_Odcinka_Trasy = 2
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 6,
                        Numer_Odcinka = 27,
                        Numer_Odcinka_Trasy = 3
                    },

                    new OdcinekTrasy
                    {
                        Numer_Trasy = 6,
                        Numer_Odcinka = 28,
                        Numer_Odcinka_Trasy = 4
                    }

                );
        }

        private void ConfigOdcinek(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Odcinek>()
               .HasOne(o => o.Punkt_Poczatkowy)
               .WithMany(p => p.OdcinekPoczatkowy)
               .HasForeignKey(o => o.Numer_Punktu_Poczatkowego)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Odcinek>()
                .HasOne(o => o.Punkt_Koncowy)
                .WithMany(p => p.OdcinekKoncowy)
                .HasForeignKey(o => o.Numer_Punktu_Koncowego)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Odcinek>()
                .HasIndex(o => new { o.Numer_Punktu_Poczatkowego, o.Numer_Punktu_Koncowego })
                .IsUnique();

            modelBuilder.Entity<Odcinek>()
                .HasData
                (
                    new Odcinek
                    {
                        Numer = 1,
                        Zamkniety = false,
                        Dlugosc = 1800,
                        Podejscie = 30,
                        Numer_Punktu_Poczatkowego = 34,
                        Numer_Punktu_Koncowego = 33,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 3
                    },

                    new Odcinek
                    {
                        Numer = 2,
                        Zamkniety = false,
                        Dlugosc = 5200,
                        Podejscie = 189,
                        Numer_Punktu_Poczatkowego = 15,
                        Numer_Punktu_Koncowego = 16,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 5
                    },

                    new Odcinek
                    {
                        Numer = 3,
                        Zamkniety = false,
                        Dlugosc = 2400,
                        Podejscie = 130,
                        Numer_Punktu_Poczatkowego = 16,
                        Numer_Punktu_Koncowego = 12,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 4,
                        Zamkniety = true,
                        Dlugosc = 10000m,
                        Podejscie = 500m,
                        Numer_Punktu_Poczatkowego = 2,
                        Numer_Punktu_Koncowego = 4,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 5,
                        Zamkniety = false,
                        Dlugosc = 4300,
                        Podejscie = 184,
                        Numer_Punktu_Poczatkowego = 16,
                        Numer_Punktu_Koncowego = 11,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 6,
                        Zamkniety = false,
                        Dlugosc = 6500,
                        Podejscie = 142,
                        Numer_Punktu_Poczatkowego = 11,
                        Numer_Punktu_Koncowego = 14,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 7,
                        Zamkniety = false,
                        Dlugosc = 2700,
                        Podejscie = 201,
                        Numer_Punktu_Poczatkowego = 14,
                        Numer_Punktu_Koncowego = 6,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 8,
                        Zamkniety = false,
                        Dlugosc = 13600,
                        Podejscie = 320,
                        Numer_Punktu_Poczatkowego = 10,
                        Numer_Punktu_Koncowego = 6,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 15
                    },

                    new Odcinek
                    {
                        Numer = 9,
                        Zamkniety = false,
                        Dlugosc = 2300,
                        Podejscie = 38,
                        Numer_Punktu_Poczatkowego = 10,
                        Numer_Punktu_Koncowego = 17,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 10,
                        Zamkniety = false,
                        Dlugosc = 4600,
                        Podejscie = 235,
                        Numer_Punktu_Poczatkowego = 74,
                        Numer_Punktu_Koncowego = 10,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 11,
                        Zamkniety = false,
                        Dlugosc = 3800,
                        Podejscie = 52,
                        Numer_Punktu_Poczatkowego = 18,
                        Numer_Punktu_Koncowego = 25,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 5
                    },

                    new Odcinek
                    {
                        Numer = 12,
                        Zamkniety = false,
                        Dlugosc = 3400,
                        Podejscie = 183,
                        Numer_Punktu_Poczatkowego = 25,
                        Numer_Punktu_Koncowego = 47,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 13,
                        Zamkniety = false,
                        Dlugosc = 3400,
                        Podejscie = 512,
                        Numer_Punktu_Poczatkowego = 26,
                        Numer_Punktu_Koncowego = 47,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 11
                    },

                    new Odcinek
                    {
                        Numer = 14,
                        Zamkniety = false,
                        Dlugosc = 3900,
                        Podejscie = 294,
                        Numer_Punktu_Poczatkowego = 24,
                        Numer_Punktu_Koncowego = 19,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 15,
                        Zamkniety = false,
                        Dlugosc = 3500,
                        Podejscie = 716,
                        Numer_Punktu_Poczatkowego = 19,
                        Numer_Punktu_Koncowego = 7,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 12
                    },

                    new Odcinek
                    {
                        Numer = 16,
                        Zamkniety = false,
                        Dlugosc = 1900,
                        Podejscie = 209,
                        Numer_Punktu_Poczatkowego = 23,
                        Numer_Punktu_Koncowego = 7,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 17,
                        Zamkniety = false,
                        Dlugosc = 6400,
                        Podejscie = 518,
                        Numer_Punktu_Poczatkowego = 20,
                        Numer_Punktu_Koncowego = 23,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 14
                    },

                    new Odcinek
                    {
                        Numer = 18,
                        Zamkniety = false,
                        Dlugosc = 5600,
                        Podejscie = 168,
                        Numer_Punktu_Poczatkowego = 22,
                        Numer_Punktu_Koncowego = 20,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 19,
                        Zamkniety = false,
                        Dlugosc = 6800,
                        Podejscie = 300,
                        Numer_Punktu_Poczatkowego = 21,
                        Numer_Punktu_Koncowego = 22,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 10
                    },

                    new Odcinek
                    {
                        Numer = 20,
                        Zamkniety = false,
                        Dlugosc = 4300,
                        Podejscie = 78,
                        Numer_Punktu_Poczatkowego = 33,
                        Numer_Punktu_Koncowego = 35,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 21,
                        Zamkniety = false,
                        Dlugosc = 2800,
                        Podejscie = 106,
                        Numer_Punktu_Poczatkowego = 35,
                        Numer_Punktu_Koncowego = 48,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 5
                    },

                    new Odcinek
                    {
                        Numer = 22,
                        Zamkniety = false,
                        Dlugosc = 3120,
                        Podejscie = 117,
                        Numer_Punktu_Poczatkowego = 48,
                        Numer_Punktu_Koncowego = 49,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 23,
                        Zamkniety = false,
                        Dlugosc = 3450,
                        Podejscie = 144,
                        Numer_Punktu_Poczatkowego = 36,
                        Numer_Punktu_Koncowego = 48,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 24,
                        Zamkniety = false,
                        Dlugosc = 1100,
                        Podejscie = 120,
                        Numer_Punktu_Poczatkowego = 36,
                        Numer_Punktu_Koncowego = 37,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 25,
                        Zamkniety = false,
                        Dlugosc = 5100,
                        Podejscie = 12,
                        Numer_Punktu_Poczatkowego = 51,
                        Numer_Punktu_Koncowego = 50,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7,
                    },

                    new Odcinek
                    {
                        Numer = 26,
                        Zamkniety = false,
                        Dlugosc = 4870,
                        Podejscie = 28,
                        Numer_Punktu_Poczatkowego = 50,
                        Numer_Punktu_Koncowego = 36,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 27,
                        Zamkniety = false,
                        Dlugosc = 2600,
                        Podejscie = 118,
                        Numer_Punktu_Poczatkowego = 36,
                        Numer_Punktu_Koncowego = 38,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 5
                    },

                    new Odcinek
                    {
                        Numer = 28,
                        Zamkniety = false,
                        Dlugosc = 2100,
                        Podejscie = 2,
                        Numer_Punktu_Poczatkowego = 38,
                        Numer_Punktu_Koncowego = 39,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 29,
                        Zamkniety = false,
                        Dlugosc = 4700,
                        Podejscie = 238,
                        Numer_Punktu_Poczatkowego = 50,
                        Numer_Punktu_Koncowego = 52,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 30,
                        Zamkniety = false,
                        Dlugosc = 3900,
                        Podejscie = 20,
                        Numer_Punktu_Poczatkowego = 54,
                        Numer_Punktu_Koncowego = 52,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 31,
                        Zamkniety = false,
                        Dlugosc = 2840,
                        Podejscie = 290,
                        Numer_Punktu_Poczatkowego = 54,
                        Numer_Punktu_Koncowego = 55,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 32,
                        Zamkniety = false,
                        Dlugosc = 3450,
                        Podejscie = 390,
                        Numer_Punktu_Poczatkowego = 55,
                        Numer_Punktu_Koncowego = 46,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 10
                    },

                    new Odcinek
                    {
                        Numer = 33,
                        Zamkniety = false,
                        Dlugosc = 2720,
                        Podejscie = 30,
                        Numer_Punktu_Poczatkowego = 56,
                        Numer_Punktu_Koncowego = 46,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 5
                    },

                    new Odcinek
                    {
                        Numer = 34,
                        Zamkniety = false,
                        Dlugosc = 3054,
                        Podejscie = 302,
                        Numer_Punktu_Poczatkowego = 56,
                        Numer_Punktu_Koncowego = 4,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 9
                    },

                    new Odcinek
                    {
                        Numer = 35,
                        Zamkniety = false,
                        Dlugosc = 3968,
                        Podejscie = 320,
                        Numer_Punktu_Poczatkowego = 45,
                        Numer_Punktu_Koncowego = 56,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 10
                    },

                    new Odcinek
                    {
                        Numer = 36,
                        Zamkniety = false,
                        Dlugosc = 2345,
                        Podejscie = 265,
                        Numer_Punktu_Poczatkowego = 40,
                        Numer_Punktu_Koncowego = 41,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 37,
                        Zamkniety = false,
                        Dlugosc = 5120,
                        Podejscie = 280,
                        Numer_Punktu_Poczatkowego = 39,
                        Numer_Punktu_Koncowego = 40,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 9
                    },

                    new Odcinek
                    {
                        Numer = 38,
                        Zamkniety = false,
                        Dlugosc = 1620,
                        Podejscie = 145,
                        Numer_Punktu_Poczatkowego = 45,
                        Numer_Punktu_Koncowego = 41,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 39,
                        Zamkniety = false,
                        Dlugosc = 5220,
                        Podejscie = 437,
                        Numer_Punktu_Poczatkowego = 43,
                        Numer_Punktu_Koncowego = 4,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 11
                    },

                    new Odcinek
                    {
                        Numer = 40,
                        Zamkniety = false,
                        Dlugosc = 3650,
                        Podejscie = 292,
                        Numer_Punktu_Poczatkowego = 43,
                        Numer_Punktu_Koncowego = 42,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 41,
                        Zamkniety = false,
                        Dlugosc = 8125,
                        Podejscie = 293,
                        Numer_Punktu_Poczatkowego = 42,
                        Numer_Punktu_Koncowego = 44,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 13
                    },

                    new Odcinek
                    {
                        Numer = 42,
                        Zamkniety = false,
                        Dlugosc = 4320,
                        Podejscie = 212,
                        Numer_Punktu_Poczatkowego = 57,
                        Numer_Punktu_Koncowego = 4,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 43,
                        Zamkniety = false,
                        Dlugosc = 4835,
                        Podejscie = 189,
                        Numer_Punktu_Poczatkowego = 58,
                        Numer_Punktu_Koncowego = 57,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 9
                    },

                    new Odcinek
                    {
                        Numer = 44,
                        Zamkniety = false,
                        Dlugosc = 9850,
                        Podejscie = 345,
                        Numer_Punktu_Poczatkowego = 2,
                        Numer_Punktu_Koncowego = 58,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZOLTY,
                        Punkty = 14
                    },

                    new Odcinek
                    {
                        Numer = 45,
                        Zamkniety = false,
                        Dlugosc = 3140,
                        Podejscie = 260,
                        Numer_Punktu_Poczatkowego = 53,
                        Numer_Punktu_Koncowego = 52,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 46,
                        Zamkniety = false,
                        Dlugosc = 6540,
                        Podejscie = 380,
                        Numer_Punktu_Poczatkowego = 53,
                        Numer_Punktu_Koncowego = 29,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 11
                    },

                    new Odcinek
                    {
                        Numer = 47,
                        Zamkniety = false,
                        Dlugosc = 6850,
                        Podejscie = 584,
                        Numer_Punktu_Poczatkowego = 29,
                        Numer_Punktu_Koncowego = 2,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 14
                    },

                    new Odcinek
                    {
                        Numer = 48,
                        Zamkniety = false,
                        Dlugosc = 4130,
                        Podejscie = 13,
                        Numer_Punktu_Poczatkowego = 1,
                        Numer_Punktu_Koncowego = 75,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 5
                    },

                    new Odcinek
                    {
                        Numer = 49,
                        Zamkniety = false,
                        Dlugosc = 3985,
                        Podejscie = 268,
                        Numer_Punktu_Poczatkowego = 75,
                        Numer_Punktu_Koncowego = 29,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 50,
                        Zamkniety = false,
                        Dlugosc = 4120,
                        Podejscie = 335,
                        Numer_Punktu_Poczatkowego = 75,
                        Numer_Punktu_Koncowego = 28,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZIELONY,
                        Punkty = 9
                    },

                    new Odcinek
                    {
                        Numer = 51,
                        Zamkniety = false,
                        Dlugosc = 5460,
                        Podejscie = 67,
                        Numer_Punktu_Poczatkowego = 30,
                        Numer_Punktu_Koncowego = 28,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 52,
                        Zamkniety = false,
                        Dlugosc = 11760,
                        Podejscie = 240,
                        Numer_Punktu_Poczatkowego = 3,
                        Numer_Punktu_Koncowego = 58,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 18
                    },

                    new Odcinek
                    {
                        Numer = 53,
                        Zamkniety = false,
                        Dlugosc = 4850,
                        Podejscie = 40,
                        Numer_Punktu_Poczatkowego = 59,
                        Numer_Punktu_Koncowego = 3,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 10
                    },

                    new Odcinek
                    {
                        Numer = 54,
                        Zamkniety = false,
                        Dlugosc = 5120,
                        Podejscie = 355,
                        Numer_Punktu_Poczatkowego = 59,
                        Numer_Punktu_Koncowego = 60,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 11
                    },

                    new Odcinek
                    {
                        Numer = 55,
                        Zamkniety = false,
                        Dlugosc = 4870,
                        Podejscie = 143,
                        Numer_Punktu_Poczatkowego = 61,
                        Numer_Punktu_Koncowego = 60,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 56,
                        Zamkniety = false,
                        Dlugosc = 5640,
                        Podejscie = 132,
                        Numer_Punktu_Poczatkowego = 61,
                        Numer_Punktu_Koncowego = 32,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 9
                    },

                    new Odcinek
                    {
                        Numer = 57,
                        Zamkniety = false,
                        Dlugosc = 3890,
                        Podejscie = 64,
                        Numer_Punktu_Poczatkowego = 62,
                        Numer_Punktu_Koncowego = 61,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 6
                    },

                    new Odcinek
                    {
                        Numer = 58,
                        Zamkniety = false,
                        Dlugosc = 2980,
                        Podejscie = 299,
                        Numer_Punktu_Poczatkowego = 63,
                        Numer_Punktu_Koncowego = 62,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 59,
                        Zamkniety = false,
                        Dlugosc = 5860,
                        Podejscie = 441,
                        Numer_Punktu_Poczatkowego = 31,
                        Numer_Punktu_Koncowego = 63,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 12
                    },

                    new Odcinek
                    {
                        Numer = 60,
                        Zamkniety = false,
                        Dlugosc = 7530,
                        Podejscie = 642,
                        Numer_Punktu_Poczatkowego = 77,
                        Numer_Punktu_Koncowego = 32,
                        Dwukierunkowy = false,
                        Kolor = Models.Enums.Kolor.CZARNY,
                        Punkty = 17
                    },

                    new Odcinek
                    {
                        Numer = 61,
                        Zamkniety = false,
                        Dlugosc = 2140,
                        Podejscie = 65,
                        Numer_Punktu_Poczatkowego = 27,
                        Numer_Punktu_Koncowego = 77,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 62,
                        Zamkniety = false,
                        Dlugosc = 4310,
                        Podejscie = 146,
                        Numer_Punktu_Poczatkowego = 76,
                        Numer_Punktu_Koncowego = 60,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 63,
                        Zamkniety = false,
                        Dlugosc = 11650,
                        Podejscie = 64,
                        Numer_Punktu_Poczatkowego = 76,
                        Numer_Punktu_Koncowego = 69,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 15
                    },

                    new Odcinek
                    {
                        Numer = 64,
                        Zamkniety = false,
                        Dlugosc = 1860,
                        Podejscie = 62,
                        Numer_Punktu_Poczatkowego = 68,
                        Numer_Punktu_Koncowego = 69,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.ZOLTY,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 65,
                        Zamkniety = false,
                        Dlugosc = 5640,
                        Podejscie = 45,
                        Numer_Punktu_Poczatkowego = 70,
                        Numer_Punktu_Koncowego = 69,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 66,
                        Zamkniety = false,
                        Dlugosc = 5410,
                        Podejscie = 296,
                        Numer_Punktu_Poczatkowego = 70,
                        Numer_Punktu_Koncowego = 71,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 10
                    },

                    new Odcinek
                    {
                        Numer = 67,
                        Zamkniety = false,
                        Dlugosc = 4580,
                        Podejscie = 130,
                        Numer_Punktu_Poczatkowego = 72,
                        Numer_Punktu_Koncowego = 71,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 7
                    },

                    new Odcinek
                    {
                        Numer = 68,
                        Zamkniety = false,
                        Dlugosc = 1160,
                        Podejscie = 102,
                        Numer_Punktu_Poczatkowego = 72,
                        Numer_Punktu_Koncowego = 73,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 4
                    },

                    new Odcinek
                    {
                        Numer = 69,
                        Zamkniety = false,
                        Dlugosc = 6450,
                        Podejscie = 91,
                        Numer_Punktu_Poczatkowego = 73,
                        Numer_Punktu_Koncowego = 8,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 12
                    },
                    new Odcinek
                    {
                        Numer = 70,
                        Zamkniety = false,
                        Dlugosc = 16400,
                        Podejscie = 154,
                        Numer_Punktu_Poczatkowego = 8,
                        Numer_Punktu_Koncowego = 9,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.NIEBIESKI,
                        Punkty = 24
                    },

                    new Odcinek
                    {
                        Numer = 71,
                        Zamkniety = false,
                        Dlugosc = 6780,
                        Podejscie = 913,
                        Numer_Punktu_Poczatkowego = 5,
                        Numer_Punktu_Koncowego = 72,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 18
                    },

                    new Odcinek
                    {
                        Numer = 72,
                        Zamkniety = false,
                        Dlugosc = 7240,
                        Podejscie = 673,
                        Numer_Punktu_Poczatkowego = 5,
                        Numer_Punktu_Koncowego = 67,
                        Dwukierunkowy = false,
                        Kolor = Models.Enums.Kolor.CZARNY,
                        Punkty = 20
                    },

                    new Odcinek
                    {
                        Numer = 73,
                        Zamkniety = false,
                        Dlugosc = 5670,
                        Podejscie = 80,
                        Numer_Punktu_Poczatkowego = 66,
                        Numer_Punktu_Koncowego = 5,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 8
                    },

                    new Odcinek
                    {
                        Numer = 74,
                        Zamkniety = false,
                        Dlugosc = 11250,
                        Podejscie = 284,
                        Numer_Punktu_Poczatkowego = 64,
                        Numer_Punktu_Koncowego = 66,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 14
                    },

                    new Odcinek
                    {
                        Numer = 75,
                        Zamkniety = false,
                        Dlugosc = 18450,
                        Podejscie = 61,
                        Numer_Punktu_Poczatkowego = 65,
                        Numer_Punktu_Koncowego = 64,
                        Dwukierunkowy = true,
                        Kolor = Models.Enums.Kolor.CZERWONY,
                        Punkty = 19
                    }
               );
        }
    
        private void ConfigPunktGeograficzny(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PunktGeograficzny>()
                .Property(p => p.Dlugosc_Geograficzna)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PunktGeograficzny>()
                .Property(p => p.Szerokosc_Geograficzna)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PunktGeograficzny>()
                .HasIndex(p => p.Nazwa)
                .IsUnique();

            modelBuilder.Entity<PunktGeograficzny>()
                .HasIndex(p => new { p.Szerokosc_Geograficzna, p.Dlugosc_Geograficzna })
                .IsUnique();

            modelBuilder.Entity<PunktGeograficzny>()
                .HasOne(p => p.GrupaGorska)
                .WithMany(gg => gg.Punkty)
                .HasForeignKey(p => p.NazwaGrupyGorskiej);

            modelBuilder.Entity<PunktGeograficzny>()
                .HasData
                (
                    new PunktGeograficzny
                    {
                        Numer = 1,
                        Nazwa = "Dolina Strążyska",
                        Dlugosc_Geograficzna = 19.9325m,
                        Szerokosc_Geograficzna = 49.27027m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1029
                    },

                    new PunktGeograficzny
                    {
                        Numer = 2,
                        Nazwa = "Giewont",
                        Dlugosc_Geograficzna = 19.93411m,
                        Szerokosc_Geograficzna = 49.250972m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1894
                    },

                    new PunktGeograficzny
                    {
                        Numer = 3,
                        Nazwa = "Kasprowy Wierch",
                        Dlugosc_Geograficzna = 19.981555m,
                        Szerokosc_Geograficzna = 49.23183m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1987
                    },

                    new PunktGeograficzny
                    {
                        Numer = 4,
                        Nazwa = "Krzesanica",
                        Dlugosc_Geograficzna = 19.90947m,
                        Szerokosc_Geograficzna = 49.23166m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2122
                    },

                    new PunktGeograficzny
                    {
                        Numer = 5,
                        Nazwa = "Morskie Oko",
                        Dlugosc_Geograficzna = 20.070999m,
                        Szerokosc_Geograficzna = 49.201401m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1395
                    },

                    new PunktGeograficzny
                    {
                        Numer = 6,
                        Nazwa = "Śnieżka",
                        Dlugosc_Geograficzna = 15.7399m,
                        Szerokosc_Geograficzna = 50.7362m,
                        Zdjecie = "Śnieżka.jpg",
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1601
                    },

                    new PunktGeograficzny
                    {
                        Numer = 7,
                        Nazwa = "Babia Góra",
                        Dlugosc_Geograficzna = 19.5295m,
                        Szerokosc_Geograficzna = 49.5731m,
                        NazwaGrupyGorskiej = "Beskidy Zachodnie",
                        Wysokosc = 1725
                    },

                    new PunktGeograficzny
                    {
                        Numer = 8,
                        Nazwa = "Rysy",
                        Dlugosc_Geograficzna = 20.088m,
                        Szerokosc_Geograficzna = 49.1795m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2501
                    },

                    new PunktGeograficzny
                    {
                        Numer = 9,
                        Nazwa = "Gerlach",
                        Dlugosc_Geograficzna = 20.1340277m,
                        Szerokosc_Geograficzna = 49.1640277m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2655
                    },

                    new PunktGeograficzny
                    {
                        Numer = 10,
                        Nazwa = "Skalny Stół",
                        Dlugosc_Geograficzna = 15.7915m,
                        Szerokosc_Geograficzna = 50.7527m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1281
                    },

                    new PunktGeograficzny
                    {
                        Numer = 11,
                        Nazwa = "Stzecha Akademicka",
                        Dlugosc_Geograficzna = 15.7083m,
                        Szerokosc_Geograficzna = 50.7509m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1258
                    },

                    new PunktGeograficzny
                    {
                        Numer = 12,
                        Nazwa = "Pielgrzymy",
                        Dlugosc_Geograficzna = 15.6934m,
                        Szerokosc_Geograficzna = 50.7679m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1204
                    },

                    new PunktGeograficzny
                    {
                        Numer = 13,
                        Nazwa = "Słonecznik",
                        Dlugosc_Geograficzna = 15.6833m,
                        Szerokosc_Geograficzna = 50.7597m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1423
                    },

                    new PunktGeograficzny
                    {
                        Numer = 14,
                        Nazwa =  "Dom Śląski",
                        Dlugosc_Geograficzna = 15.7290m, 
                        Szerokosc_Geograficzna = 50.7395m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1400
                    },

                    new PunktGeograficzny
                    {
                        Numer = 15,
                        Nazwa = "Kościół Wang",
                        Dlugosc_Geograficzna = 15.7242m,
                        Szerokosc_Geograficzna = 50.7773m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 885
                    },

                    new PunktGeograficzny
                    {
                        Numer = 16,
                        Nazwa = "Polana KPN",
                        Dlugosc_Geograficzna = 15.7045m,
                        Szerokosc_Geograficzna = 50.7651m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1074
                    },

                    new PunktGeograficzny
                    {
                        Numer = 17,
                        Nazwa = "Dolina Płomnicy",
                        Dlugosc_Geograficzna = 15.7795m,
                        Szerokosc_Geograficzna = 50.7523m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 912
                    },

                    new PunktGeograficzny
                    {
                        Numer = 18,
                        Nazwa = "Sokolica",
                        Dlugosc_Geograficzna = 20.4407m,
                        Szerokosc_Geograficzna = 49.4175m,
                        NazwaGrupyGorskiej = "Pieniny",
                        Wysokosc = 747
                    },

                    new PunktGeograficzny
                    {
                        Numer = 19,
                        Nazwa = "Przełęcz Krowiarki",
                        Dlugosc_Geograficzna = 19.582m,
                        Szerokosc_Geograficzna = 49.5880m,
                        NazwaGrupyGorskiej = "Beskidy Zachodnie",
                        Wysokosc = 1009
                    },

                    new PunktGeograficzny
                    {
                        Numer = 20,
                        Nazwa = "Przełęcz Jałowiecka",
                        Dlugosc_Geograficzna = 19.4695m,
                        Szerokosc_Geograficzna = 49.5976m,
                        NazwaGrupyGorskiej = "Beskidy Zachodnie",
                        Wysokosc = 998
                    },

                    new PunktGeograficzny
                    {
                        Numer = 21,
                        Nazwa = "Przyborów",
                        Dlugosc_Geograficzna = 19.3872m,
                        Szerokosc_Geograficzna = 49.6208m,
                        NazwaGrupyGorskiej = "Beskidy Zachodnie",
                        Wysokosc = 530
                    },

                    new PunktGeograficzny
                    {
                        Numer = 22,
                        Nazwa = "Głuchaczki",
                        Dlugosc_Geograficzna = 19.4321m,
                        Szerokosc_Geograficzna = 49.5958m,
                        NazwaGrupyGorskiej = "Beskidy Zachodnie",
                        Wysokosc = 830
                    },

                    new PunktGeograficzny
                    {
                        Numer = 23,
                        Nazwa = "Mała Babia Góra",
                        Dlugosc_Geograficzna = 19.4997m,
                        Szerokosc_Geograficzna = 49.5812m,
                        NazwaGrupyGorskiej = "Beskidy Zachodnie",
                        Wysokosc = 1516
                    },

                    new PunktGeograficzny
                    {
                        Numer = 24,
                        Nazwa = "Zubrzyca Górna",
                        Dlugosc_Geograficzna = 19.6494m,
                        Szerokosc_Geograficzna = 49.5631m,
                        NazwaGrupyGorskiej = "Beskidy Zachodnie",
                        Wysokosc = 715
                    },

                    new PunktGeograficzny
                    {
                        Numer = 25,
                        Nazwa = "Zamek Pieniński",
                        Dlugosc_Geograficzna = 20.4206m,
                        Szerokosc_Geograficzna = 49.4203m,
                        NazwaGrupyGorskiej = "Pieniny",
                        Wysokosc = 799
                    },

                    new PunktGeograficzny
                    {
                        Numer = 26,
                        Nazwa = "Schronisko Trzy Korony",
                        Dlugosc_Geograficzna = 20.4112m,
                        Szerokosc_Geograficzna = 49.4052m,
                        NazwaGrupyGorskiej = "Pieniny",
                        Wysokosc = 470
                    },

                    new PunktGeograficzny
                    {
                        Numer = 27,
                        Nazwa = "Wielka Siklawa",
                        Dlugosc_Geograficzna = 20.0453m,
                        Szerokosc_Geograficzna = 49.2147m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1560
                    },

                    new PunktGeograficzny
                    {
                        Numer = 28,
                        Nazwa = "Sarnia Skała",
                        Dlugosc_Geograficzna = 19.9412m,
                        Szerokosc_Geograficzna = 49.2653m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1377
                    },

                    new PunktGeograficzny
                    {
                        Numer = 29,
                        Nazwa = "Przełęcz w Grzybowcu",
                        Dlugosc_Geograficzna = 19.9159m,
                        Szerokosc_Geograficzna = 49.2594m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1310
                    },

                    new PunktGeograficzny
                    {
                        Numer = 30,
                        Nazwa = "Szlak nad Reglami",
                        Dlugosc_Geograficzna = 19.9614m,
                        Szerokosc_Geograficzna = 49.2611m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1310
                    },

                    new PunktGeograficzny
                    {
                        Numer = 31,
                        Nazwa = "Dolina Gąsienicowa",
                        Dlugosc_Geograficzna = 20.0039m,
                        Szerokosc_Geograficzna = 49.2419m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1425
                    },

                    new PunktGeograficzny
                    {
                        Numer = 32,
                        Nazwa = "Kozi Wierch",
                        Dlugosc_Geograficzna = 20.0286m,
                        Szerokosc_Geograficzna = 49.2183m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2291
                    },

                    new PunktGeograficzny
                    {
                        Numer = 33,
                        Nazwa = "Dolina Lejowa",
                        Dlugosc_Geograficzna = 19.8497m,
                        Szerokosc_Geograficzna = 49.2775m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 940
                    },

                    new PunktGeograficzny
                    {
                        Numer = 34,
                        Nazwa = "Siwa Polana",
                        Dlugosc_Geograficzna = 19.8391m,
                        Szerokosc_Geograficzna = 49.2789m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 910
                    },

                    new PunktGeograficzny
                    {
                        Numer = 35,
                        Nazwa = "Huty Lejowe",
                        Dlugosc_Geograficzna = 19.8456m,
                        Szerokosc_Geograficzna = 49.2636m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1018
                    },

                    new PunktGeograficzny
                    {
                        Numer = 36,
                        Nazwa = "Dolina Kościeliska",
                        Dlugosc_Geograficzna = 19.8669m,
                        Szerokosc_Geograficzna = 49.2539m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 980
                    },

                    new PunktGeograficzny
                    {
                        Numer = 37,
                        Nazwa = "Jaskinia Mroźna",
                        Dlugosc_Geograficzna = 19.8701m,
                        Szerokosc_Geograficzna = 49.2523m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1100
                    },

                    new PunktGeograficzny
                    {
                        Numer = 38,
                        Nazwa = "Jaskinia Mylna",
                        Dlugosc_Geograficzna = 19.8622m,
                        Szerokosc_Geograficzna = 49.2394m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1098
                    },

                    new PunktGeograficzny
                    {
                        Numer = 39,
                        Nazwa = "Schronisko na Hali Ornak",
                        Dlugosc_Geograficzna = 19.8587m,
                        Szerokosc_Geograficzna = 49.2292m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1100
                    },

                    new PunktGeograficzny
                    {
                        Numer = 40,
                        Nazwa = "Wyżnia Polana Tomanowa",
                        Dlugosc_Geograficzna = 19.8906m,
                        Szerokosc_Geograficzna = 49.2228m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1380
                    },

                    new PunktGeograficzny
                    {
                        Numer = 41,
                        Nazwa = "Czerwony Żleb",
                        Dlugosc_Geograficzna = 19.8983m,
                        Szerokosc_Geograficzna = 49.2265m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1645
                    },

                    new PunktGeograficzny
                    {
                        Numer = 42,
                        Nazwa = "Tomanowy Wierch Polski",
                        Dlugosc_Geograficzna = 19.9023m,
                        Szerokosc_Geograficzna = 49.2133m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1977
                    },

                    new PunktGeograficzny
                    {
                        Numer = 43,
                        Nazwa = "Tomanowa Przełęcz",
                        Dlugosc_Geograficzna = 19.9048m,
                        Szerokosc_Geograficzna = 49.2196m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1685
                    },

                    new PunktGeograficzny
                    {
                        Numer = 44,
                        Nazwa = "Smreczyński Wierch",
                        Dlugosc_Geograficzna = 19.8839m,
                        Szerokosc_Geograficzna = 49.2041m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2070
                    },

                    new PunktGeograficzny
                    {
                        Numer = 45,
                        Nazwa = "Wysoki Grzbiet",
                        Dlugosc_Geograficzna = 19.8948m,
                        Szerokosc_Geograficzna = 49.2299m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1500
                    },

                    new PunktGeograficzny
                    {
                        Numer = 46,
                        Nazwa = "Chuda Przełączka",
                        Dlugosc_Geograficzna = 19.8955m,
                        Szerokosc_Geograficzna = 49.2381m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1850
                    },

                    new PunktGeograficzny
                    {
                        Numer = 47,
                        Nazwa = "Trzy Korony",
                        Dlugosc_Geograficzna = 20.4142m,
                        Szerokosc_Geograficzna = 49.4138m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 982
                    },

                    new PunktGeograficzny
                    {
                        Numer = 48,
                        Nazwa = "Przysłop Kominiarski",
                        Dlugosc_Geograficzna = 19.8561m,
                        Szerokosc_Geograficzna = 49.2570m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1124
                    },

                    new PunktGeograficzny
                    {
                        Numer = 49,
                        Nazwa = "Diabliniec",
                        Dlugosc_Geograficzna = 19.8447m,
                        Szerokosc_Geograficzna = 49.2564m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1241
                    },

                    new PunktGeograficzny
                    {
                        Numer = 50,
                        Nazwa = "Cudakowa Polana",
                        Dlugosc_Geograficzna = 19.8699m,
                        Szerokosc_Geograficzna = 49.2640m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 952
                    },

                    new PunktGeograficzny
                    {
                        Numer = 51,
                        Nazwa = "Parking TPN Kiry",
                        Dlugosc_Geograficzna = 19.8682m,
                        Szerokosc_Geograficzna = 49.2756m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 940
                    },

                    new PunktGeograficzny
                    {
                        Numer = 52,
                        Nazwa = "Przysłop Miętusi",
                        Dlugosc_Geograficzna = 19.8932m,
                        Szerokosc_Geograficzna = 49.2622m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1190
                    },

                    new PunktGeograficzny
                    {
                        Numer = 53,
                        Nazwa = "Dolina Małej Łąki",
                        Dlugosc_Geograficzna = 19.9006m,
                        Szerokosc_Geograficzna = 49.2658m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 930
                    },

                    new PunktGeograficzny
                    {
                        Numer = 54,
                        Nazwa = "Wyżnia Miętusia Rówień",
                        Dlugosc_Geograficzna = 19.8949m,
                        Szerokosc_Geograficzna = 49.2523m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1170
                    },

                    new PunktGeograficzny
                    {
                        Numer = 55,
                        Nazwa = "Turnia Piec",
                        Dlugosc_Geograficzna = 19.8865m,
                        Szerokosc_Geograficzna = 49.2486m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1460
                    },

                    new PunktGeograficzny
                    {
                        Numer = 56,
                        Nazwa = "Dolina Mułowa",
                        Dlugosc_Geograficzna = 19.9037m,
                        Szerokosc_Geograficzna = 49.2357m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1820
                    },

                    new PunktGeograficzny
                    {
                        Numer = 57,
                        Nazwa = "Małączniak",
                        Dlugosc_Geograficzna = 19.9191m,
                        Szerokosc_Geograficzna = 49.2358m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2096
                    },

                    new PunktGeograficzny
                    {
                        Numer = 58,
                        Nazwa = "Kondracka Kopa",
                        Dlugosc_Geograficzna = 19.9321m,
                        Szerokosc_Geograficzna = 49.2364m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2005
                    },

                    new PunktGeograficzny
                    {
                        Numer = 59,
                        Nazwa = "Przełęcz Liliowe",
                        Dlugosc_Geograficzna = 19.9923m,
                        Szerokosc_Geograficzna = 49.2252m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1947
                    },

                    new PunktGeograficzny
                    {
                        Numer = 60,
                        Nazwa = "Świnica",
                        Dlugosc_Geograficzna = 20.0092m,
                        Szerokosc_Geograficzna = 49.2194m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2302
                    },

                    new PunktGeograficzny
                    {
                        Numer = 61,
                        Nazwa = "Przełęcz Zawrat",
                        Dlugosc_Geograficzna = 20.0162m,
                        Szerokosc_Geograficzna = 49.2191m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2159
                    },

                    new PunktGeograficzny
                    {
                        Numer = 62,
                        Nazwa = "Kościelec",
                        Dlugosc_Geograficzna = 20.0146m,
                        Szerokosc_Geograficzna = 49.2254m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2155
                    },

                    new PunktGeograficzny
                    {
                        Numer = 63,
                        Nazwa = "Mały Kościelec",
                        Dlugosc_Geograficzna = 20.0113m,
                        Szerokosc_Geograficzna = 49.2314m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1866
                    },

                    new PunktGeograficzny
                    {
                        Numer = 64,
                        Nazwa = "Schronisko w Dolinie Roztoki",
                        Dlugosc_Geograficzna = 20.0955m,
                        Szerokosc_Geograficzna = 49.2337m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1031
                    },

                    new PunktGeograficzny
                    {
                        Numer = 65,
                        Nazwa = "Parking Łysa Polana",
                        Dlugosc_Geograficzna = 20.1151m,
                        Szerokosc_Geograficzna = 49.2641m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 970
                    },

                    new PunktGeograficzny
                    {
                        Numer = 66,
                        Nazwa = "Włosienica",
                        Dlugosc_Geograficzna = 20.0806m,
                        Szerokosc_Geograficzna = 49.2138m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1315
                    },

                    new PunktGeograficzny
                    {
                        Numer = 67,
                        Nazwa = "Mnich",
                        Dlugosc_Geograficzna = 20.0550m,
                        Szerokosc_Geograficzna = 49.1925m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2068
                    },

                    new PunktGeograficzny
                    {
                        Numer = 68,
                        Nazwa = "Szpiglasowa Przełęcz",
                        Dlugosc_Geograficzna = 20.0423m,
                        Szerokosc_Geograficzna = 49.1979m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2110
                    },

                    new PunktGeograficzny
                    {
                        Numer = 69,
                        Nazwa = "Szpiglasowy Wierch",
                        Dlugosc_Geograficzna = 20.0400m,
                        Szerokosc_Geograficzna = 49.1973m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2172
                    },

                    new PunktGeograficzny
                    {
                        Numer = 70,
                        Nazwa = "Ciemnosmreczyńska Turnia",
                        Dlugosc_Geograficzna = 20.0480m,
                        Szerokosc_Geograficzna = 49.1899m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2142
                    },

                    new PunktGeograficzny
                    {
                        Numer = 71,
                        Nazwa = "Mięguszowiecki Szczyt Wielki",
                        Dlugosc_Geograficzna = 20.0599m,
                        Szerokosc_Geograficzna = 49.1871m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2438
                    },

                    new PunktGeograficzny
                    {
                        Numer = 72,
                        Nazwa = "Przełęcz Pod Chłopkiem",
                        Dlugosc_Geograficzna = 20.0652m,
                        Szerokosc_Geograficzna = 49.1836m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2308
                    },

                    new PunktGeograficzny
                    {
                        Numer = 73,
                        Nazwa = "Mięguszowiecki Szczyt Czarny",
                        Dlugosc_Geograficzna = 20.0674m,
                        Szerokosc_Geograficzna = 49.1828m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2410
                    },

                    new PunktGeograficzny
                    {
                        Numer = 74,
                        Nazwa = "Schronisko Na Przełęczy Okraj",
                        Dlugosc_Geograficzna = 15.8242m,
                        Szerokosc_Geograficzna = 50.7471m,
                        NazwaGrupyGorskiej = "Karkonosze",
                        Wysokosc = 1046
                    },

                    new PunktGeograficzny
                    {
                        Numer = 75,
                        Nazwa = "Polana Strążyska",
                        Dlugosc_Geograficzna = 19.9298m,
                        Szerokosc_Geograficzna = 49.2622m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1042,
                    },

                    new PunktGeograficzny
                    {
                        Numer = 76,
                        Nazwa = "Walentkowy Wierch",
                        Dlugosc_Geograficzna = 20.0066m,
                        Szerokosc_Geograficzna = 49.2133m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 2156
                    },

                    new PunktGeograficzny
                    {
                        Numer = 77,
                        Nazwa = "Dolina Pięciu Stawów",
                        Dlugosc_Geograficzna = 20.0351m,
                        Szerokosc_Geograficzna = 49.2106m,
                        NazwaGrupyGorskiej = "Tatry",
                        Wysokosc = 1650
                    }
                );
        }
    
        private void ConfigZdjecieWpisu(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZdjecieWpisu>()
                .HasOne(z => z.Wpis)
                .WithMany(w => w.ZdjecieWpisu)
                .HasForeignKey(z => z.Numer_Wpisu);

            modelBuilder.Entity<ZdjecieWpisu>()
                .HasData(

                        new ZdjecieWpisu
                        {
                            Identyfikator = "giewont.jpg",
                            Numer_Wpisu = 1
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "BaraniaGóra.jpg",
                            Numer_Wpisu = 2
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "Ciemniak.jpg",
                            Numer_Wpisu = 3
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "HalaSzrenicka.jpg",
                            Numer_Wpisu = 4
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "Kasprowy.jpg",
                            Numer_Wpisu = 5
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "Rysy.jpg",
                            Numer_Wpisu = 6
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "MorskieOko.jpg",
                            Numer_Wpisu = 7
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "SuchaCzuba.jpg",
                            Numer_Wpisu = 8
                        },
                        new ZdjecieWpisu
                        {
                            Identyfikator = "Śnieżka.jpg",
                            Numer_Wpisu = 9
                        }
                );
        }

        private void ConfigGrupaGorska(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupaGorska>()
                .HasIndex(gg => gg.Nazwa);

            modelBuilder.Entity<GrupaGorska>()
                .HasData(
                    new GrupaGorska
                    {
                        Nazwa = "Tatry",
                        WPolsce = true
                    },
                    new GrupaGorska
                    {
                        Nazwa = "Beskidy Zachodnie",
                        WPolsce = true
                    },
                    new GrupaGorska
                    {
                        Nazwa = "Beskidy Wschodnie",
                        WPolsce = true
                    },
                    new GrupaGorska
                    {
                        Nazwa = "Sudety",
                        WPolsce = true
                    },
                    new GrupaGorska
                    {
                        Nazwa = "Góry Świętokrzyskie",
                        WPolsce = true
                    },
                    new GrupaGorska
                    {
                        Nazwa = "Karkonosze",
                        WPolsce = true
                    },
                    new GrupaGorska
                    {
                        Nazwa = "Pieniny",
                        WPolsce = true
                    }

                );
        }
    }
}
