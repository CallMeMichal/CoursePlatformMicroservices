﻿namespace SharedModels.Models.LoginRegisterModels.Request
{
    public class RegisterRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; } // Dodanie daty urodzenia
    }
}