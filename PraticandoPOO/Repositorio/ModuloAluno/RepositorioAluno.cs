using PraticandoPOO.ModuloAluno;
using System.Collections.Generic;

namespace PraticandoPOO.Repositorio.ModuloAluno
{
    public class RepositorioAluno
    {
        private readonly List<Aluno> _alunos;

        public RepositorioAluno()
        {
            _alunos = new List<Aluno>();
        }

        public void Inserir(Aluno aluno)
        {
            _alunos.Add(aluno);
        }

        public List<Aluno> SelecionarTodos()
        {
            return _alunos;
        }

        public Aluno SelecionarAlunoPorIndice(int indice)
        {
            if (indice >= 0 && indice <= _alunos.Count)
                return _alunos[indice];

            return null;
        }
    }
}
