using System;

namespace Scorponok.IB.Domain.Models.Members
{
    public class Member
    {
        public string Name { get; set; }

        public string NameFather { get; set; }

        public string NameMother { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfBaptism { get; set; }

        public DateTime DateOfUnion { get; set; }

        
    }
}