﻿using AlmocoAPI.Models;
using AlmocoAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public interface IEnqueteRepository : IRepository<Enquete>
    {
        //Boolean EncerraEnquete(int idEnquete);
    }
}