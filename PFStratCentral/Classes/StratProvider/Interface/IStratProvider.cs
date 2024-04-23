using PFStratCentral.Classes.Strats;
using PFStratCentral.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFStratCentral.Classes.StratProvider.Interface
{
    public interface IStratProvider
    {
        public Task<IEnumerable<IStrat>> GetFromSourceAsync(EncounterId encounterId);
    }
}
