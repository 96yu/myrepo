using PFStratCentral.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFStratCentral.Classes.Strats
{
    public class Strat : IStrat
    {
        public Guid Id { get; }

        public EncounterId EncounterId { get; }

        public string Name { get; }

        public string Details { get; }

        public Strat(Guid id, EncounterId encounterId, string name, string details)
        {
            Id = id;
            EncounterId = encounterId;
            Name = name;
            Details = details;
        }
    }
}
