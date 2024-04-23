using PFStratCentral.Classes.StratManager.Interface;
using PFStratCentral.Classes.StratProvider.Interface;
using PFStratCentral.Classes.Strats;
using PFStratCentral.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFStratCentral.Classes.StratManager
{
    public class StratManager : IStratManager
    {
        private readonly IStratProvider stratProvider;

        public StratManager(IStratProvider stratProvider)
        {
            this.stratProvider = stratProvider;
        }


        public async Task<IEnumerable<IStrat>> GetStrats(EncounterId encounterId)
        {
            //where clause is temporary
            IEnumerable<IStrat> stratList = (await stratProvider.GetFromSourceAsync(encounterId));

            return stratList;
        }
    }
}
