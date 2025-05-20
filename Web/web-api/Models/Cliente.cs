using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public enum Status
    {
        Ativo, Inativo, Excluido
    }

    public class Cliente
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; }
        public Status Status { get; set; }

       
        private int cpf { get; set; }




        public Cliente()
        {
        }
    }
}