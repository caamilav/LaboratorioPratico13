using PraticandoPOO.ModuloDisciplina;
using System.Collections.Generic;

namespace PraticandoPOO.Repositorio.ModuloDisciplina
{
    public class RepositorioDisciplina
    {
        private readonly List<Disciplina> _disciplinas;

        public RepositorioDisciplina()
        {
            _disciplinas = new List<Disciplina>();
        }

        public void Inserir(Disciplina disciplina)
        {
            _disciplinas.Add(disciplina);
        }

        public List<Disciplina> SelecionarTodos()
        {
            return _disciplinas;
        }

        public Disciplina SelecionarDisciplinaPorIndice(int indice)
        {
            if(indice >= 0 && indice <= _disciplinas.Count)
                return _disciplinas[indice];

            return null;
        }
    }
}
