using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosSoft.CapaDominio.Entidades
{
    public class Usuario
    {
        private string nickname;
        private string password;
        private int tipo;

        //private Persona persona;

        public string Nickname { get => nickname; set => nickname = value; }
        public string Password { get => password; set => password = value; }
        //public Persona Persona { get => persona; set => persona = value; }
        public int Tipo { get => tipo; set => tipo = value; }

        public bool EsUsuarioValido(string nickname, string password)
        {
            return (this.nickname.Equals(nickname) && this.password.Equals(password)) ? true : false;
        }
    }
}
