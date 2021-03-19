using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace RollIT
{
    class RNP
    {
        public string WelcomeMessage = @"
     #############################################################
     #      _____   ____  _      _            _____ _______      #
     #     |  __ \ / __ \| |    | |          |_   _|__   __|     #
     #     | |__) | |  | | |    | |  ______    | |    | |        #
     #     |  _  /| |  | | |    | | |______|   | |    | |        #
     #     | | \ \| |__| | |____| |____       _| |_   | |        #
     #     |_|  \_\\____/|______|______|     |_____|  |_|        #
     #                                                           #
     #############################################################

               Welcome Message - Skriv 'Hjelp' for info.";
        public string CommandPrompt = "";
        public static List<Person> People;
        public static Random Rnd = new Random();
        public RNP(params Person[] elever)
        {
            People = new List<Person>(elever);
        }
        public string HandleCommand(string command)
        {
            var input = command.ToLower();
            if (input == "hjelp")
            {
                return HjelpCommand();
            }
            else if (input == "liste")
            {
                return ListeCommand(People);
            }
            else if (input.Contains("vis "))
            {
                return VisCommand(input, People);
            }
            else if (input == "kommando")
            {
                return KommandoCommand();
            }
            else if (input.Contains("roll team "))
            {
                return RollTeamCommand(input);
            }
            else if (input.Contains("roll person "))
            {
                return RollPersonCommand(input);
            }
            else if (input == "clear")
            {
                Console.Clear();
                Console.WriteLine(WelcomeMessage);
            }
            else if (input == "exit" || input == "x")
            {
                Environment.Exit(0);
            }
            else
            {
                return "Ugyldig kommando";
            }
            return "";
        }
        private static string HjelpCommand()
        {
            return @"
Kommando - Viser de tilgjengelige kommandoene.
Liste - Viser en liste med de tilgjengelige elevene.
Exit - Lukker programmet.
";
        }
        private static string ListeCommand(List<Person> People)
        {
            string tekst = "";
            for (int i = 0; i < People.Count; i++)
            {
                tekst += People[i].GetDescription() + "\n";
            }

            return tekst;
        }
        private static string VisCommand(string input, List<Person> People)
        {
            int ID = Int32.Parse(input.Substring(input.IndexOf(" ") + 1));
            string tekst = "";
            foreach (var t in People)
            {
                if (t.Id != ID) continue;
                tekst += t.GetDescription();
            }
            return tekst;
        }
        private static string KommandoCommand()
        {
            return @"
Roll Team 1-5 (Skriver ut rekkefølge x-x-x-x-x)
Roll Person X (X=Modul 1,2,3) Y (Y=Hvor manage alternativer man ønsker skrivd ut)
";
        }
        public string RollTeamCommand(string input)
        {
            int tall = Int32.Parse(input.Substring(10));
            var Teams = new List<int>();
            string tekst = "";
            for (var i = 0; i < tall; i++)
            {
                Teams.Add(i+1);
            }
            while (Teams.Count != 0)
            {
                var num = Rnd.Next(1, tall + 1);
                for (var i = 0; i < Teams.Count; i++)
                {
                    if (Teams[i] == num)
                    {
                        tekst += "Team " +Teams[i]+", ";
                        Teams.Remove(num);
                    }
                }
            }
            return tekst;
        }
        // Roll person (tall.modul) (tall2.antall) hvodan den er splittet under.
        private static string RollPersonCommand(string input)
        {
            var Deathrow = new List<Person>();
            var split = input.Substring(12).Split(" ");
            int tall = Int32.Parse(split[0]);
            int tall2 = Int32.Parse(split[1]);
            foreach (var t in People)
            {
                if (t.Modul == tall)
                {
                    Deathrow.Add(t);
                }
            }
            while (Deathrow.Count > tall2)
            {
                var Alivepersone = Rnd.Next(Deathrow.Count);
                Deathrow.RemoveAt(Alivepersone);
            }
            var Deadpeople = "";
            for (var i = 0; i < Deathrow.Count; i++)
            {
                Deadpeople += "navn: " + Deathrow[i].FirstName + "\n";
            }
            return Deadpeople;
        }
    }
}
