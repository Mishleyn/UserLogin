﻿namespace UserLogin.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public long ConfirmationCode { get; set; }
    }
}
