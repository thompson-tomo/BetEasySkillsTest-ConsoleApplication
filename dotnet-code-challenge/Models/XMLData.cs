using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Models
{
    public class XMLData
    {
        public string Date { get; set;}
        public string MeetingType { get; set;}
        public Track Track { get; set; }
        public string MeetingId { get; set; }
        public List<Race> Races { get; set; }
    }

    public class Track
    {
        public string Condition { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Club { get; set; }
        public string TranslatedName { get; set; }
        public string Name { get; set; }
    }

    public class Race
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Number { get; set; }
        public string NumberOfRunners { get; set; }
        public string Start_time { get; set; }
        public string Distance_Meters { get; set; }
        public List<Horse> Horses { get; set; }
        public List<Price> Prices { get; set; }
    }

    public class Horse
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Foaling_Date { get; set; }
        public string Colour { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Number { get; set; }
        public Trainer Trainer { get; set; }
        public string Training_Location { get; set; }
        public string Owners { get; set; }
        public string Colours { get; set; }
        public string Current_Blinker_Ind { get; set; }
        public string Prizemoney_Won { get; set; }
        public string Last_Four_Starts { get; set; }
        public string Last_Ten_Starts { get; set; }
        public Jockey Jockey { get; set; }
        public string Barrier { get; set; }
        public Weight Weight { get; set; }
    }

    public class Trainer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Statistics> Statistics { get; set; }
    }

    public class Jockey
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Statistics> Statistics { get; set; }
    }

    public class Statistics
    {
        public string Thirds { get; set; }
        public string Seconds { get; set; }
        public string Firsts { get; set; }
        public string Total { get; set; }
        public string Type { get; set; }
    }

    public class Weight
    {
        public string Total { get; set; }
        public string Allocated { get; set; }
    }

    public class Price
    {
        public string PriceType { get; set; }
        public List<Runners> Horses { get; set; }
    }

    public class Runners
    {
        public string Number { get; set; }
        public string Price { get; set; }
    }
}
