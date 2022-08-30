using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Models
{
    public class Cliente
    {
        public Cliente(string nome, DateTime nascimento, string email)
        {
            Nome = nome;
            Nascimento = nascimento;
            Email = email;
        }

        public int id { get; private set; }
        [Required(ErrorMessage ="Você deve informar um Nome !")]
        [Display(Name ="Nome do Cliente")]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "Você deve informar a data de Nascimento !")]
        [Display(Name = "Data de Nascimento")]
        public DateTime Nascimento { get; private set; }
        [Required(ErrorMessage = "Você deve informar o E-mail !")]
        public string Email { get; private set; }

        public int Idade()
        {
            int idade = DateTime.Now.Year-Nascimento.Year;

            if (DateTime.Now.DayOfYear < Nascimento.DayOfYear)
            {
                idade--;
            }

            return idade;
        }

        public void AtualizaDados(string nome, string email, DateTime nascimento)
        {
            Nome = nome;
            Nascimento = nascimento;
            Email = email;
        }
    }
}
