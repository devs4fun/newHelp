using help.Controllers;
using help.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Teste
{
    public class Tests
    {
        internal UsuarioController sut;
        internal Mock<IUsuarioRepository> usuarioRepositoryMock;
        //internal Mock<ITempDataDictionary> tempDataMock;


        public void CriarMock()
        {
            this.usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            //this.tempDataMock = new Mock<ITempDataDictionary>();
        }

        public void CriarUsuarioController()
        {
            sut = new UsuarioController(usuarioRepositoryMock.Object)
            {

            };
        }
    }
}
