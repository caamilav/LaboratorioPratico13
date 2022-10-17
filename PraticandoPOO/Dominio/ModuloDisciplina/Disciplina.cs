using PraticandoPOO.ModuloAluno;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PraticandoPOO.ModuloDisciplina
{
    public class Disciplina 
    {
        public Disciplina(string nomeCurso, string nomeDisciplina)
        {
            NomeCurso = nomeCurso;
            NomeDisciplina = nomeDisciplina;
        }

        public string NomeCurso { get; set; }
        public string NomeDisciplina { get; set; }
        public List<Aluno> Alunos
        {
            get { return _alunos;  }
            set { _alunos = value; }
        }

        private List<Aluno> _alunos = new List<Aluno>();

        public decimal CalcularMediaTurma()
        {
            decimal somadorMedia = 0;

            foreach(var a in Alunos)
            {
                somadorMedia += CalcularMediaAluno(a);
            }

            var m = Math.Round(somadorMedia / Alunos.Count, 1);

            return m;
        }

        public decimal CalcularMediaAluno(Aluno aluno)
        {
            var m = Math.Round(aluno.Notas.Sum() / aluno.Notas.Count(), 1);
            return m;
        }



    }
}
