using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public class Cadastro
    {
        public string Empresa {set; get;}

        public string Cargo {set; get;}

        public string Plataforma {set; get;}

        public string Status {set; get;}
        public DateTime DataCandidatura{set; get;}
        public string Link {set; get;}

        public string Observacoes {set; get;}
        
    }
}