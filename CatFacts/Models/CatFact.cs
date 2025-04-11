﻿using SQLite;

namespace CatFacts.Models
{
    public class CatFact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Fact { get; set; }
        public int Length { get; set; }

        public CatFact(string fact, int length)
        {
            Fact = fact;
            Length = length;
        }
    }
}