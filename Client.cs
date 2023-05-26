using System;
namespace PracticePanther
{
	public class Client 
	{
        public int Id
        { get; set; }
        public DateTime OpenDate
        { get;  set; }
        public DateTime ClosedDate
        { get; set; }
        public Boolean IsActive
        { get; set; }
        public string? Name
        { get; set; }
        public string? Notes
        { get; set; }
        public override string ToString()
        {
            return $"Client Id: {Id} Client Name: {Name}";
        }
    }


}

