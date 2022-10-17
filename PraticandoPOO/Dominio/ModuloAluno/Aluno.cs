using System.Collections.Generic;

namespace PraticandoPOO.ModuloAluno
{
    public class Aluno 
    {
        public Aluno(string nome, int matricula, List<decimal> notas)
        {
            Nome = nome;
            Matricula = matricula;
            Notas = notas;
        }

        public string Nome { get; set; }
        public int Matricula { get; set; }
        public List<decimal> Notas { get; set; }
    }
}
