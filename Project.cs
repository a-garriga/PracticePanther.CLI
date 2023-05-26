using System;
using System.Xml.Linq;

namespace PracticePanther
{
        public class Project
        {
            public int Id
            { get; set; }
            public DateTime OpenDate
            { get; set; }
            public DateTime ClosedDate
            { get; set; }
            public Boolean IsActive
            { get; set; }
            public string? ShortName
            { get; set; }
            public string? LongName
            { get; set;  }
            public int ClientId
            { get; set; }
            public Client? ProjectClient
            { get; set; }
            public string Status()
            {
                if (IsActive == true )
                {
                    return "Active";
                }
                return "Inactive";
            }
            public override string ToString()
            {
                return $"Project Id: {Id} Project Name: {ShortName}\n" +
                    $"   Client Id: {ClientId} Client Name: {ProjectClient.Name}\n" +
                    $"   Status: " + Status();
            }
        }
}

 