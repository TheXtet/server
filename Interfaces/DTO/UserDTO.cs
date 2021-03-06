﻿using System.Collections.Generic;

namespace Interfaces.DTO
{
    public class UserDTO
    {
        public UserDTO(string login, string name, string surName, string position, byte[] profileImage, bool isAdmin, double sallary, List<CriteriaDTO> criterias)
        {
            Login = login;
            Name = name;
            SurName = surName;
            Position = position;
            ProfileImage = profileImage;
            IsAdmin = isAdmin;
            Sallary = sallary;
            Criterias = criterias;
        }

        public string Login { get; set; }
        public string Name { get; set; }
        public string SurName { get; internal set; }
        public string Position { get; set; }
        public byte[] ProfileImage { get; set; }
        public bool IsAdmin { get; internal set; }
        public double Sallary { get; internal set; }
        public List<CriteriaDTO> Criterias { get; set; }
    }
}