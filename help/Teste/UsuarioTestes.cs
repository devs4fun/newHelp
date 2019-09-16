using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using Moq;
using help.Models;

namespace Teste
{
    public class UsuarioTestes : Tests
    {
        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Salvar Professor Chamando O Repository Uma Vez")]
        public void DeveriaSalvarProfessorChamandoORepositoryUmaVez()
        {
            //arrange
            CriarMock();

            //act
            CriarUsuarioController();
            //sut.Cadastrar("Robson", "Junior", "robsonjunior@mail.com", "123456789", "123456789");

            //assert
            usuarioRepositoryMock.Verify(x => x.Cadastrar(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
