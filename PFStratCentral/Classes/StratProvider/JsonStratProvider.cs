using Dalamud.Configuration;
using Dalamud.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PFStratCentral.Classes.StratProvider.Interface;
using PFStratCentral.Classes.Strats;
using PFStratCentral.Enums;
using PFStratCentral.Exceptions;
using SamplePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PFStratCentral.Classes.StratProvider
{
    public class JsonStratProvider : IStratProvider
    {
        public Configuration Configuration { get; set; }


        public JsonStratProvider(PfStratCentralPlugin plugin)
        {
            Configuration = plugin.Configuration;
        }

        public async Task<IEnumerable<IStrat>> GetFromSourceAsync(EncounterId encounterId)
        {
            Uri uri = new Uri(Configuration.StratJsonUrl);
            List<IStrat> strats = new List<IStrat>();

            var client = new HttpClient();
            var request = await client.GetAsync(uri);
            if (request.IsSuccessStatusCode) 
            {
                string content = await request.Content.ReadAsStringAsync();

                if (!content.IsNullOrWhitespace())
                {
                    JObject jObj;
                    try
                    {
                        jObj = JObject.Parse(content);
                    }
                    catch (JsonReaderException ex)
                    {
                        Console.WriteLine($"JSON parsing error: {ex.Message}");
                        return new List<Strat>();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"No fucking IDEA what happened here. {ex.Message}");
                        return new List<Strat>();
                    }

                    foreach (var prop in jObj.Properties())
                    {
                        bool isValidEncounter = Enum.TryParse(prop.Name, true, out EncounterId resultEncounter);

                        if (isValidEncounter)
                        {
                            bool isIntendedEncounter = resultEncounter == encounterId;

                            if (isIntendedEncounter)
                            {
                                if (prop.Value is JArray encounterStrats)
                                {
                                    foreach (JObject jStrat in encounterStrats)
                                    {
                                        Guid stratId = Guid.Parse(jStrat["id"]?.ToString() ?? throw new JsonReaderException($"Failed to parse ID from strat. Target object was {JsonConvert.SerializeObject(jStrat)}."));
                                        EncounterId encId = resultEncounter;
                                        string name = jStrat["name"]?.ToString() ?? throw new JsonReaderException($"Failed to parse name from strat. Target object was {JsonConvert.SerializeObject(jStrat)}.");
                                        string details = jStrat["details"]?.ToString() ?? throw new JsonReaderException($"Failed to parse details from strat. Target object was {JsonConvert.SerializeObject(jStrat)}.");

                                        var strat = new Strat(stratId, encId, name, details);

                                        strats.Add(strat);
                                    }
                                }
                            }
                            else
                                continue;
                        }
                        else
                            throw new InvalidStrategyException($"Found invalid encounter ID in source. ID found was {prop.Name}.");
                    }
                    return strats;
                }
                else
                {
                    Console.WriteLine($"Didn't find any strats in the source.");
                    return strats;
                }
            }
            else
            {
                Console.WriteLine($"Failed to reach the source.");
                return strats;
            }
        }
    }
}
