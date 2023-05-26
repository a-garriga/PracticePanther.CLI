using System;
namespace PracticePanther
{
	public class ProjectCRUD
	{
		public static void Create(List<Project> x, List<Client> y)
		{
            Console.WriteLine("Enter the Project Id: ");
            var id = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Enter the Short Name: ");
            var sname = Console.ReadLine() ?? "CONFIDENTIAL";

            Console.WriteLine("Enter the Long Name: ");
            var lname = Console.ReadLine() ?? "CONFIDENTIAL";

            Console.WriteLine("Enter the Client Id: ");
            var cID = int.Parse(Console.ReadLine() ?? "0");

            var CL = y.FirstOrDefault(s => s.Id == cID);

            while (CL == null) // while no valid Client with Client.Id = cID or new Client not Created
            {
                Console.WriteLine("There is no Client with that ID.");

                Console.WriteLine("Would you like to create a new Client? (Y or N)");
                var active = Console.ReadLine() ?? "Y";
                if (active.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientCRUD.Create(y, cID);
                    CL = y.FirstOrDefault(s => s.Id == cID); // CL = new Client using ClientCrud.Create()
                }                             // passing cID to replace default -1
                else
                {
                    Console.WriteLine("Enter the Client Id: "); // attempts to update CL with new Client
                    cID = int.Parse(Console.ReadLine() ?? "0"); // given by new cID
                    CL = y.FirstOrDefault(s => s.Id == cID);
                }
            }

            x.Add(
                new Project()
                {
                    Id = id,
                    OpenDate = DateTime.Now,
                    IsActive = true,
                    ShortName = sname,
                    LongName = lname,
                    ClientId = cID,
                    ProjectClient = CL
                } );
        }
        public static void Read(List<Project> x)
        {
            x.ForEach(Console.WriteLine);
        }
        public static void Update(List<Project> x)
        {
            Console.WriteLine("Enter the ID of the Project to be Updated.");
            x.ForEach(Console.WriteLine);

            var update = int.Parse(Console.ReadLine() ?? "0");
            var pUp = x.FirstOrDefault(s => s.Id == update);

            if (pUp != null)
            {
                Console.WriteLine("What is the updated Short Name?");
                pUp.ShortName = Console.ReadLine() ?? pUp.ShortName;

                Console.WriteLine("What is the updated Long Name?");
                pUp.LongName = Console.ReadLine() ?? pUp.LongName;

                Console.WriteLine("Is this Project still active? (Y or N)");
                var active = Console.ReadLine() ?? "Y";
                if (active.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    pUp.IsActive = true;
                } else if (active.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                    pUp.IsActive = false;
                    pUp.ClosedDate = DateTime.Now;
                }
            }

        }
        public static void Delete(List<Project> x)
        {
            Console.WriteLine("Enter the ID of the Project to be deleted.");
            x.ForEach(Console.WriteLine);

            var delete = int.Parse(Console.ReadLine() ?? "0");
            var clr = x.FirstOrDefault(s => s.Id == delete);

            if (clr != null)
            {
                x.Remove(clr);
            }
        }
    }
}

