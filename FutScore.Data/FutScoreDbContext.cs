using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutScore.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FutScore.Data;

public class FutScoreDbContext : DbContext
{
    public DbSet<Campeonato> Campeonatos { get; set; }
    public DbSet<Time> Times { get; set; }  
    public DbSet<Jogador> Jogadores { get; set; }
    public DbSet<Partida> Partidas { get; set; }
    string connectionString = "Server=(localdb)\\mssqllocaldb;Database=FutScoreDB;Trusted_Connection=True;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurando a relação entre Partida e o Time da Casa
        modelBuilder.Entity<Partida>()
            .HasOne(p => p.Casa) // Uma Partida tem um Time da Casa
            .WithMany()         // Um Time pode ser o Time da Casa em muitas Partidas
            .OnDelete(DeleteBehavior.Restrict); // AQUI ESTÁ A MÁGICA! Isso se traduz em ON DELETE NO ACTION

        // Configurando a relação entre Partida e o Time de Fora
        modelBuilder.Entity<Partida>()
            .HasOne(p => p.Fora) // Uma Partida tem um Time de Fora
            .WithMany()        // Um Time pode ser o Time de Fora em muitas Partidas
            .OnDelete(DeleteBehavior.Restrict); // E AQUI TAMBÉM!

        // --- 2. SEED DE DADOS (O CONTEÚDO INICIAL) ---
        modelBuilder.Entity<Campeonato>().HasData(
            new Campeonato { Id = 1, Nome = "Cariocão" }
        );

        modelBuilder.Entity<Time>().HasData(
            new Time { Id = 1, Nome = "Vasco", Forca = 60, CampeonatoId = 1 },
            new Time { Id = 2, Nome = "Flamengo", Forca = 70, CampeonatoId = 1 },
            new Time { Id = 3, Nome = "Botafogo", Forca = 65, CampeonatoId = 1 },
            new Time { Id = 4, Nome = "Fluminense", Forca = 68, CampeonatoId = 1 }
        );

        modelBuilder.Entity<Jogador>().HasData(

            new Jogador { Id = 1, Nome = "Paulinho", Posicao = Posicao.Volante, TimeId = 1 },
            new Jogador { Id = 2, Nome = "Coutinho", Posicao = Posicao.MeioCampo, TimeId = 1 },
            new Jogador { Id = 3, Nome = "Vegetti", Posicao = Posicao.Centroavante, TimeId = 1 },
            new Jogador { Id = 4, Nome = "Léo Jardim", Posicao = Posicao.Goleiro, TimeId = 1 },
            new Jogador { Id = 5, Nome = "João Victor", Posicao = Posicao.Zagueiro, TimeId = 1 },
            new Jogador { Id = 6, Nome = "Nuno", Posicao = Posicao.Ponta, TimeId = 1 },
            new Jogador { Id = 7, Nome = "David", Posicao = Posicao.Ponta, TimeId = 1 },
            new Jogador { Id = 8, Nome = "Sforza", Posicao = Posicao.Volante, TimeId = 1 },
            new Jogador { Id = 9, Nome = "Lucas Freitas", Posicao = Posicao.Zagueiro, TimeId = 1 },
            new Jogador { Id = 10, Nome = "Lucas Piton", Posicao = Posicao.Lateral, TimeId = 1 },
            new Jogador { Id = 11, Nome = "Paulo Henrique", Posicao = Posicao.Lateral, TimeId = 1 },

            new Jogador { Id = 12, Nome = "Arrascaeta", Posicao = Posicao.MeioCampo, TimeId = 2 },
            new Jogador { Id = 13, Nome = "Pedro", Posicao = Posicao.Centroavante, TimeId = 2 },
            new Jogador { Id = 14, Nome = "Pulgar", Posicao = Posicao.Volante, TimeId = 2 },
            new Jogador { Id = 15, Nome = "Cebolinha", Posicao = Posicao.Ponta, TimeId = 2 },
            new Jogador { Id = 16, Nome = "Nico De La Cruz", Posicao = Posicao.Ponta, TimeId = 2 },
            new Jogador { Id = 17, Nome = "Léo Ortiz", Posicao = Posicao.Zagueiro, TimeId = 2 },
            new Jogador { Id = 18, Nome = "Léo Pereira", Posicao = Posicao.Zagueiro, TimeId = 2 },
            new Jogador { Id = 19, Nome = "Gerson", Posicao = Posicao.MeioCampo, TimeId = 2 },
            new Jogador { Id = 20, Nome = "Wesley", Posicao = Posicao.Lateral, TimeId = 2 },
            new Jogador { Id = 21, Nome = "Ayrton Lucas", Posicao = Posicao.Lateral, TimeId = 2 },
            new Jogador { Id = 22, Nome = "Rossi", Posicao = Posicao.Goleiro, TimeId = 2 },

            new Jogador { Id = 23, Nome = "John", Posicao = Posicao.Goleiro, TimeId = 3 },
            new Jogador { Id = 24, Nome = "Damián Suárez", Posicao = Posicao.Lateral, TimeId = 3 },
            new Jogador { Id = 25, Nome = "Bastos", Posicao = Posicao.Zagueiro, TimeId = 3 },
            new Jogador { Id = 26, Nome = "Lucas Halter", Posicao = Posicao.Zagueiro, TimeId = 3 },
            new Jogador { Id = 27, Nome = "Cuiabano", Posicao = Posicao.Lateral, TimeId = 3 },
            new Jogador { Id = 28, Nome = "Marlon Freitas", Posicao = Posicao.Volante, TimeId = 3 },
            new Jogador { Id = 29, Nome = "Danilo Barbosa", Posicao = Posicao.Volante, TimeId = 3 },
            new Jogador { Id = 30, Nome = "Luiz Henrique", Posicao = Posicao.Ponta, TimeId = 3 },
            new Jogador { Id = 31, Nome = "Júnior Santos", Posicao = Posicao.Ponta, TimeId = 3 },
            new Jogador { Id = 32, Nome = "Tiquinho Soares", Posicao = Posicao.Centroavante, TimeId = 3 },
            new Jogador { Id = 33, Nome = "Eduardo", Posicao = Posicao.MeioCampo, TimeId = 3 },

            new Jogador { Id = 34, Nome = "Fábio", Posicao = Posicao.Goleiro, TimeId = 4 },
            new Jogador { Id = 35, Nome = "Samuel Xavier", Posicao = Posicao.Lateral, TimeId = 4 },
            new Jogador { Id = 36, Nome = "Felipe Melo", Posicao = Posicao.Zagueiro, TimeId = 4 },
            new Jogador { Id = 37, Nome = "Marlon", Posicao = Posicao.Zagueiro, TimeId = 4 },
            new Jogador { Id = 38, Nome = "Marcelo", Posicao = Posicao.Lateral, TimeId = 4 },
            new Jogador { Id = 39, Nome = "André", Posicao = Posicao.Volante, TimeId = 4 },
            new Jogador { Id = 40, Nome = "Martinelli", Posicao = Posicao.Volante, TimeId = 4 },
            new Jogador { Id = 41, Nome = "Ganso", Posicao = Posicao.MeioCampo, TimeId = 4 },
            new Jogador { Id = 42, Nome = "Jhon Arias", Posicao = Posicao.MeioCampo, TimeId = 4 },
            new Jogador { Id = 43, Nome = "Keno", Posicao = Posicao.Ponta, TimeId = 4 },
            new Jogador { Id = 44, Nome = "Germán Cano", Posicao = Posicao.Centroavante, TimeId = 4 }
        );

        base.OnModelCreating(modelBuilder);
    }
}
