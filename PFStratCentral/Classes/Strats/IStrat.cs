using PFStratCentral.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFStratCentral.Classes.Strats
{
    public interface IStrat
    {
        public Guid Id { get; }
        public EncounterId EncounterId { get; }
        public string Name { get; }
        public string Details { get; }
    }

}
