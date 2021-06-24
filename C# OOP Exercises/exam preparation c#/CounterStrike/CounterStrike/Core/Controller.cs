using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            switch (type)
            {
                case "Pistol":
                    {
                        this.guns.Add(new Pistol(name, bulletsCount));

                        break;
                    }
                case "Rifle":
                    {
                        this.guns.Add(new Rifle(name, bulletsCount));
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(ExceptionMessages.InvalidGunType);
                        break;
                    }
            }
            return $"Successfully added gun {name}.";
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            switch (type)
            {
                case "Terrorist":
                    {
                        players.Add(new Terrorist(username, health, armor, gun));
                        break;
                    }
                case "CounterTerrorist":
                    {
                        players.Add(new CounterTerrorist(username, health, armor, gun));
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
                        break;
                    }
            }
            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);

        }

        public string StartGame()
        {
            return map.Start(players.Models.ToArray());
        }

        public string Report()
        {

            var sortedPlayers = this.players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username);
            var information = new StringBuilder();
            foreach (var player in sortedPlayers)
            {
                information.AppendLine(player.ToString());
            }
            return information.ToString().Trim();
        }
    }
}
