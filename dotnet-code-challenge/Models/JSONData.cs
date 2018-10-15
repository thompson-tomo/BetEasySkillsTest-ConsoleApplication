using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Models
{
    public class JSONData
    {
        public string FixtureId { get; set; }
        public DateTime Timestamp { get; set; }
        public RawData RawData { get; set; }
    }

    public class RawData
    {
        public string FixtureName { get; set; }
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Sequence { get; set; }
        public Tags Tags { get; set; }
        public List<Market> Markets { get; set; }
        public List<Participant> Participant { get; set; }
    }

    public class Tags
    {
        public string CourseType { get; set; }
        public string Distance { get; set; }
        public string Going { get; set; }
        public string Runners { get; set; }
        public string MeetingCode { get; set; }
        public string TrackCode { get; set; }
        public string Sport { get; set; }
        public string Places { get; set; }
        public string Type { get; set; }
        public string Participant { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Drawn { get; set; }
        public string Jockey { get; set; }
        public string Number { get; set; }
        public string Trainer { get; set; }
    }

    public class Market
    {
        public string Id { get; set; }
        public List<Selection> Selections { get; set; }
        public Tags Tags { get; set; }
    }

    public class Selection
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public Tags Tags { get; set; }
    }

    public class Participant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Tags Tags { get; set; }
    }
}