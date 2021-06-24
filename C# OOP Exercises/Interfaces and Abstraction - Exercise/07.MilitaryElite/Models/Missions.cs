using System;
using System.Text;
using System.Collections.Generic;
using MilitaryElite.Enumerators;
using MilitaryElite.MilitaryInterfaces;
using System.ComponentModel.DataAnnotations;
using MilitaryElite.Exeptions;

namespace MilitaryElite.Models
{
    public class Missions : IMissions
    {
        public Missions(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }
        public string CodeName { get; private set; }
        public State State { get; private set; }
        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompleateExeption();
            }

            this.State = State.Finished;
        }

        private State TryParseState(string states)
        {
            State state;
            bool parsed = Enum.TryParse(states, out state);

            if (!parsed)
            {
                throw new InvalidMissionCompleateExeption();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}