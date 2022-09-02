using CadastroClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroClientes.Test
{
    public class ClientTest
    {
        [Fact]
        public void Idade_VinteAnosDepois_RetornaVinte()
        {
            //Arrange
            Cliente cliente = new Cliente("Jose da Silva", DateTime.Now.AddYears(-20), "jsilva@gmail.com");

            //Act
            var idade = cliente.Idade();

            //Assert
            Assert.Equal(20, idade);
        }

        [Fact]
        public void Idade_VinteAnosEUmDia_RetornaVinte()
        {
            //Arrange
            Cliente cliente = new Cliente("Jose da Silva", DateTime.Now.AddYears(-20).AddDays(-1), "jsilva@gmail.com");

            //Act
            var idade = cliente.Idade();

            //Assert
            Assert.Equal(20, idade);
        }

        [Fact]
        public void Idade_VinteAnosEUmDia_RetornaDezenove()
        {
            //Arrange
            Cliente cliente = new Cliente("Jose da Silva", DateTime.Now.AddYears(-20).AddDays(1), "jsilva@gmail.com");

            //Act
            var idade = cliente.Idade();

            //Assert
            Assert.Equal(19, idade);
        }

        [Theory]
        [InlineData("joão", "2010-05-14", "Joao@uol.com")]

        public void AtualizadaDados_Alteranome_AlteraData_AlteraEmail(string nome, DateTime nascimento, string email)
        {
            //arrange
            Cliente Cliente = new Cliente("pardal", DateTime.Now.AddYears(-20).AddDays(-1), "jsilva@mail.com");
            //act
            Cliente.AtualizaDados(nome, email, nascimento);
            //Assert
            Assert.Equal(Cliente.Nome, nome);
            Assert.Equal(Cliente.Nascimento, nascimento);
            Assert.Equal(Cliente.Email, email);
        }
    }
}
