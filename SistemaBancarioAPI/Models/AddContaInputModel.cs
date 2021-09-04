using SistemaBancarioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Models
{
    public class AddContaInputModel
    {
        public string TipoNomeConta { get; set; }
        public AddTitularInputModel Titular { get; set; }

    }
}
