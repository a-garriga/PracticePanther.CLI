using System;
namespace PracticePanther
{
	public class ClientCRUD
	{
		public static void Create(List<Client> x, int id = -1)
		{
            if (id == -1) // -1 if called in menu
            {            // only != -1 if called in ProjectCRUD.Create()
                Console.WriteLine("Enter the Client Id: ");
                id = int.Parse(Console.ReadLine() ?? "0");
            }

            Console.WriteLine("Enter the Client Name: ");
            var name = Console.ReadLine() ?? "John Doe";

            Console.WriteLine("Enter the Client Notes: ");
            var notes = Console.ReadLine() ?? string.Empty;

            x.Add(
                new Client()
                {
                    Id = id,
                    OpenDate = DateTime.Now,
                    IsActive = true,
                    Name = name,
                    Notes = notes
                }
                );
        }

        public static void Read(List<Client> x)
        {
            x.ForEach(Console.WriteLine);
        }

        public static void Update(List<Client> x, List<Project> y)
        {
            Console.WriteLine("Enter the ID of the Client to be Updated.");
            x.ForEach(Console.WriteLine);

            var update = int.Parse(Console.ReadLine() ?? "0");
            var cUp = x.FirstOrDefault(s => s.Id == update);

            if (cUp != null)
            {
                Console.WriteLine("What is the updated Name?");
                cUp.Name = Console.ReadLine() ?? cUp.Name;

                Console.WriteLine("What are the updated Notes?");
                cUp.Notes = Console.ReadLine() ?? cUp.Notes;

                Console.WriteLine("Is this Client still active? (Y or N)");
                var active = Console.ReadLine() ?? "Y";
                if(active.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    cUp.IsActive = true;
                } else if (active.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {                               
                    cUp.IsActive = false;
                    cUp.ClosedDate = DateTime.Now;
                    foreach (var proj in y)
                    {
                        if (proj.ClientId == update)
                        {
                            proj.IsActive = false;
                            proj.ClosedDate = DateTime.Now;
                        }
                    }
                }
            }
        }

        public static void Delete(List<Client> x, List<Project> y)
        {
            Console.WriteLine("Enter the ID of the Client to be deleted.");
            x.ForEach(Console.WriteLine);

            var delete = int.Parse(Console.ReadLine() ?? "0");
            var clr = x.FirstOrDefault(s => s.Id == delete);

            if(clr != null)
            {
                x.Remove(clr);
                foreach(var proj in y)
                {
                    if(proj.ClientId == delete)
                    {
                        proj.IsActive = false;
                        proj.ClosedDate = DateTime.Now;
                    }
                }
            }
        }
    }
}

