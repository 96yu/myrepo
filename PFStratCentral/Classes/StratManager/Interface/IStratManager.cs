using PFStratCentral.Classes.Strats;
using PFStratCentral.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFStratCentral.Classes.StratManager.Interface
{
    public interface IStratManager
    {
        public Task<IEnumerable<IStrat>> GetStrats(EncounterId encounter);

    }
}
