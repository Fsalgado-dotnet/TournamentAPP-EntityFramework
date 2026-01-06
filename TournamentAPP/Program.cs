using System;
using System.Collections.Generic;
using TournamentAPP.Data;
using TournamentAPP.Models;
using TournamentAPP.Repositories.Implementations;
using TournamentAPP.Repositories.Interfaces;
using TournamentAPP.Services.Implementations;
using TournamentAPP.Services.Interfaces;

namespace TournamentAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            // --- TESTE DE CONEXÃO ---
            using (var testContext = new ApplicationDbContext())
            {
                try
                {
                    var users = testContext.Users.ToList();
                    Console.WriteLine("Users in DB: " + users.Count);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar com o banco: " + ex.Message);
                    return; // Sai do programa se não conseguir conectar
                }
            }

            // Repositories
            IRepository<Player> playerRepository = new Repository<Player>(context);
            IRepository<User> userRepository = new Repository<User>(context);
            IRepository<Tournament> tournamentRepository = new Repository<Tournament>(context);

            // Services
            IService<Player> playerService = new Service<Player>(playerRepository);
            IService<User> userService = new Service<User>(userRepository);
            IService<Tournament> tournamentService = new Service<Tournament>(tournamentRepository);

            // --- Cria admin inicial se não houver nenhum usuário ---
            if (userService.GetAll().Count == 0)
            {
                User initialAdmin = new User
                {
                    Username = "admin",
                    IsAdmin = true
                };
                userService.Add(initialAdmin);
                Console.WriteLine($"Initial admin created: Username = admin, ID = {initialAdmin.Id}");
                Console.WriteLine("Use this ID to login.");
            }

            // --- LOGIN ---
            User currentUser = null;
            while (currentUser == null)
            {
                Console.Write("Enter your User ID to login: ");
                int userId = Convert.ToInt32(Console.ReadLine());
                currentUser = userService.GetById(userId);
                if (currentUser == null)
                {
                    Console.WriteLine("User not found. Try again.");
                }
            }

            Console.WriteLine($"Welcome, {currentUser.Username}! Admin: {currentUser.IsAdmin}");

            // Evita que o console feche automaticamente (somente se estiver rodando direto no VS)
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();


            Console.WriteLine($"Welcome, {currentUser.Username}! Admin: {currentUser.IsAdmin}");

            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\n--- MAIN MENU ---");
                Console.WriteLine("1 - Manage Players");
                Console.WriteLine("2 - Manage Users");
                Console.WriteLine("3 - Manage Tournaments");
                Console.WriteLine("0 - Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        PlayerMenu(playerService);
                        break;
                    case "2":
                        UserMenu(userService, currentUser);
                        break;
                    case "3":
                        TournamentMenu(tournamentService);
                        break;
                    case "0":
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        // --- Player Menu ---
        private static void PlayerMenu(IService<Player> service)
        {
            Console.WriteLine("\n--- MANAGE PLAYERS ---");
            Console.WriteLine("1 - List Players");
            Console.WriteLine("2 - Add Player");
            Console.WriteLine("3 - Update Player");
            Console.WriteLine("4 - Delete Player");
            Console.Write("Choose: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                List<Player> players = service.GetAll();
                foreach (Player player in players)
                {
                    Console.WriteLine($"ID: {player.Id}, Name: {player.Player_Name}");
                }
            }
            else if (option == "2")
            {
                Player newPlayer = new Player();
                Console.Write("Player Name: ");
                newPlayer.Player_Name = Console.ReadLine();
                service.Add(newPlayer);
                Console.WriteLine("Player added!");
            }
            else if (option == "3")
            {
                Console.Write("ID of Player to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Player player = service.GetById(id);
                if (player != null)
                {
                    Console.Write("New Name: ");
                    player.Player_Name = Console.ReadLine();
                    service.Update(player);
                    Console.WriteLine("Player updated!");
                }
                else
                {
                    Console.WriteLine("Player not found.");
                }
            }
            else if (option == "4")
            {
                Console.Write("ID of Player to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Player player = service.GetById(id);
                if (player != null)
                {
                    service.Delete(player);
                    Console.WriteLine("Player deleted!");
                }
                else
                {
                    Console.WriteLine("Player not found.");
                }
            }
        }

        // --- User Menu ---
        private static void UserMenu(IService<User> service, User currentUser)
        {
            Console.WriteLine("\n--- MANAGE USERS ---");
            Console.WriteLine("1 - List Users");
            Console.WriteLine("2 - Add User");
            Console.WriteLine("3 - Update User");
            Console.WriteLine("4 - Delete User");
            Console.Write("Choose: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                List<User> users = service.GetAll();
                foreach (User user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Username: {user.Username}");
                }
            }
            else if (option == "2")
            {
                // Verifica se o usuário logado é admin
                if (!currentUser.IsAdmin)
                {
                    Console.WriteLine("Only admins can add new users!");
                    return; // sai do menu
                }

                User newUser = new User();
                Console.Write("Username: ");
                newUser.Username = Console.ReadLine();

                Console.Write("Is Admin? (yes/no): ");
                string isAdminInput = Console.ReadLine();

                // Só admins podem criar outro admin
                newUser.IsAdmin = (isAdminInput.ToLower() == "yes");

                service.Add(newUser);
                Console.WriteLine("User added!");
            }

            else if (option == "3")
            {
                Console.Write("ID of User to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                User user = service.GetById(id);
                if (user != null)
                {
                    Console.Write("New Username: ");
                    user.Username = Console.ReadLine();
                    Console.Write("Is Admin? (yes/no): ");
                    string updateIsAdmin = Console.ReadLine();
                    user.IsAdmin = (updateIsAdmin.ToLower() == "yes");
                    service.Update(user);
                    Console.WriteLine("User updated!");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else if (option == "4")
            {
                Console.Write("ID of User to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                User user = service.GetById(id);
                if (user != null)
                {
                    service.Delete(user);
                    Console.WriteLine("User deleted!");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
        }

        // --- Tournament Menu ---
        private static void TournamentMenu(IService<Tournament> service)
        {
            Console.WriteLine("\n--- MANAGE TOURNAMENTS ---");
            Console.WriteLine("1 - List Tournaments");
            Console.WriteLine("2 - Add Tournament");
            Console.WriteLine("3 - Update Tournament");
            Console.WriteLine("4 - Delete Tournament");
            Console.Write("Choose: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                List<Tournament> tournaments = service.GetAll();
                foreach (Tournament t in tournaments)
                {
                    Console.WriteLine($"ID: {t.Id}, Name: {t.Tournament_Name}");
                }
            }
            else if (option == "2")
            {
                Tournament newTournament = new Tournament();
                Console.Write("Tournament Name: ");
                newTournament.Tournament_Name = Console.ReadLine();
                service.Add(newTournament);
                Console.WriteLine("Tournament added!");
            }
            else if (option == "3")
            {
                Console.Write("ID of Tournament to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Tournament t = service.GetById(id);
                if (t != null)
                {
                    Console.Write("New Name: ");
                    t.Tournament_Name = Console.ReadLine();
                    service.Update(t);
                    Console.WriteLine("Tournament updated!");
                }
                else
                {
                    Console.WriteLine("Tournament not found.");
                }
            }
            else if (option == "4")
            {
                Console.Write("ID of Tournament to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Tournament t = service.GetById(id);
                if (t != null)
                {
                    service.Delete(t);
                    Console.WriteLine("Tournament deleted!");
                }
                else
                {
                    Console.WriteLine("Tournament not found.");
                }
            }
        }
    }
}
