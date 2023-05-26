using System;


namespace PracticePanther // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void ClientMenu(List<Client> ClientList, List<Project> ProjectList)
        {
            while (true)
            {
                Console.WriteLine("C. Create a Client");
                Console.WriteLine("R. Read Clients");
                Console.WriteLine("U. Update a Client");
                Console.WriteLine("D. Delete a Client");
                Console.WriteLine("M. Main Menu");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientCRUD.Create(ClientList);
                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientCRUD.Read(ClientList);
                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientCRUD.Update(ClientList, ProjectList);
                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientCRUD.Delete(ClientList, ProjectList);
                }
                else if (choice.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That functionality is not supported.");
                }

            }

        }

        static void ProjectMenu(List<Project> ProjectList, List<Client> ClientList)
        {
            while (true)
            {
                Console.WriteLine("C. Create a Project");
                Console.WriteLine("R. Read Projects");
                Console.WriteLine("U. Update a Project");
                Console.WriteLine("D. Delete a Project");
                Console.WriteLine("M. Main Menu");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectCRUD.Create(ProjectList, ClientList);
                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectCRUD.Read(ProjectList);
                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectCRUD.Update(ProjectList);
                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectCRUD.Delete(ProjectList);
                }
                else if (choice.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That functionality is not supported.");
                }
            }

        }
        static void Main(string[] args)
        {
            var ProjectList = new List<Project>();
            var ClientList = new List<Client>();

            while(true)
            {
                Console.WriteLine("Enter C (Client Menu), P (Project Menu), or Q (Quit).");
                var choice = Console.ReadLine() ?? "Q";

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientMenu(ClientList, ProjectList);
                }
                else if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectMenu(ProjectList, ClientList);
                }
                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That functionality is not supported. Try Again.");
                }
            }


        }
    }
}