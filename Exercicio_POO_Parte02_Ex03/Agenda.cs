using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex03
{
    internal class Agenda
    {
        public List<Contato> Contatos { get; set; }
        public int Numero { get; set; }
        public string BloqueioContatos { get; set; }
       

        public Agenda(List<Contato> contatos, int numero, string configuracao, string bloqueioContatos)
        {
            Contatos = contatos;
            Numero = numero;
            BloqueioContatos = bloqueioContatos;
        }

        public string EditarContato(string nome, string novoNumero)
        {
            Contato contatoParaEditar = Contatos.FirstOrDefault(c => c.Nome == nome);
            if (contatoParaEditar != null)
            {
                contatoParaEditar.Numero = novoNumero;
                return $"Contato '{nome}' editado com sucesso.";
            }
            else
            {
                return $"Contato '{nome}' não encontrado.";
            }
        }

        public string EditarNumero(string nome, string novoNumero)
        {
            Contato contatoParaEditar = Contatos.FirstOrDefault(c => c.Nome == nome);
            if (contatoParaEditar != null)
            {
                contatoParaEditar.Numero = novoNumero;
                return $"Número do contato '{nome}' editado com sucesso.";
            }
            else
            {
                return $"Contato '{nome}' não encontrado.";
            }
        }

        public List<Contato> BuscarContato(string termoBusca, TipoBusca tipo)
        {
            List<Contato> contatosEncontrados = new List<Contato>();

            if (tipo == TipoBusca.PorNome)
            {
                contatosEncontrados = Contatos.Where(c => c.Nome.ToLower().Contains(termoBusca.ToLower())).ToList();
            }
            else if (tipo == TipoBusca.PorNumero)
            {
                contatosEncontrados = Contatos.Where(c => c.Numero.Contains(termoBusca)).ToList();
            }

            return contatosEncontrados;
        }

        internal class Contato
        {
            public string Nome { get; set; }
            public string Numero { get; set; }
            public bool Bloqueado { get; set; }
        }

        public enum TipoBusca
        {
            PorNome,
            PorNumero
        }
    }
}
