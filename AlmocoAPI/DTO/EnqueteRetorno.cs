using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.DTO
{
    public class EnqueteRetorno
    {
        public int EnqueteId { get; set; }

        public int GrupoId { get; set; }

        public bool Status { get; set; }
        public EnqueteRetorno()
        {

        }
    }
}