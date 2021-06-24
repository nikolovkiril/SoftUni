using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
            
        }
        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terrorists = players.Where(x => x.GetType().Name == "Terrorist").ToList();
            List<IPlayer> counterTerrorists = players.Where(x => x.GetType().Name == "CounterTerrorist").ToList();
            while (terrorists.Any(t=>t.IsAlive) && counterTerrorists.Any(c=>c.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            if (counterTerrorist.IsAlive)
                            {
                                counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                            }
                        }
                    }
                }
                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.IsAlive)
                            {
                                terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                            }
                        }
                    }
                }
            }

            if (terrorists.Any(t=>t.IsAlive))
            {
                return "Terrorist wins!";
            }

            return "Counter Terrorist wins!";

        }
    }
}
