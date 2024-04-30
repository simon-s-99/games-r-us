﻿namespace games_r_us_source.Models
{
    public class Account
    {
        public int ID { get; set; }

        public string OpenIDIssuer { get; set; }

        public string OpenIDSubject { get; set; }

        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}