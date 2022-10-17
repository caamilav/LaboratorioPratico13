using PraticandoPOO.ModuloAluno;
using PraticandoPOO.ModuloDisciplina;
using PraticandoPOO.Repositorio.ModuloAluno;
using PraticandoPOO.Repositorio.ModuloDisciplina;
using System;
using System.Collections.Generic;

namespace PraticandoPOO
{
    internal class Program
    {
        private static readonly RepositorioDisciplina _repositorioDisciplina = new RepositorioDisciplina();
        private static readonly RepositorioAluno _repositorioAluno = new RepositorioAluno();

        static void Main(string[] args)
        {
            bool continuar = true;
            do
            {
                ExibirMensagem("\nLABORATÓRIO PRÁTICO #13", ConsoleColor.DarkCyan);

                Console.WriteLine("Disciplinas\n" +
                    "\t1 - Cadastrar nova disciplina\n" +
                    "\t2 - Visualizar disciplinas cadastradas\n" +
                    "\t3 - Visualizar média geral da turma por disciplina\n" +
                    "\t4 - Visualizar média dos alunos matriculados na disciplina");
                Console.WriteLine("Alunos\n" +
                    "\t5 - Cadastrar novo aluno\n" +
                    "\t6 - Visualizar alunos cadastrados\n");
                Console.WriteLine("\t0 - Sair");


                Console.Write("\nOpção: ");
                string opcaoSelecionada = Console.ReadLine();

                switch (opcaoSelecionada)
                {
                    case "0":
                        continuar = false;
                        break;

                    case "1":
                        ExibirMensagem("\tCadastrar nova disciplina", ConsoleColor.Blue);
                        Console.Write("Nome do curso: ");
                        string nomeCurso = Console.ReadLine();
                        Console.Write("Nome da disciplina: ");
                        string nomeDisciplina = Console.ReadLine();

                        var novaDisciplina = new Disciplina(nomeCurso, nomeDisciplina);

                        _repositorioDisciplina.Inserir(novaDisciplina);

                        ExibirMensagem("Disciplina cadastrada com sucesso!", ConsoleColor.Green);
                        break;

                    case "2":
                        ExibirMensagem("\tVisualizar disciplinas cadastradas", ConsoleColor.Blue);
                        var disciplinas = _repositorioDisciplina.SelecionarTodos();

                        if (disciplinas.Count == 0)
                            ExibirMensagem("Nenhuma disciplina cadastrada\n", ConsoleColor.Yellow);
                        else
                        {
                            int i = 0;
                            foreach (var d in disciplinas)
                            {
                                Console.WriteLine($"#{i}\nNome do curso: {d.NomeCurso}\nNome da disciplina: {d.NomeDisciplina}" +
                                    $"\nQuantidade de alunos matrículados: {d.Alunos.Count}");
                                i++;
                            }
                        }
                        break;

                    case "3":
                        ExibirMensagem("\tVisualizar média geral da turma por disciplina", ConsoleColor.Blue);
                        Console.Write("Informe o índice da disciplina: ");
                        var indiceDisciplina = int.Parse(Console.ReadLine());
                        var disciplinaSelecionada = _repositorioDisciplina.SelecionarDisciplinaPorIndice(indiceDisciplina);
                        if (disciplinaSelecionada == null)
                            ExibirMensagem("Índice inválido. Verifique as disciplinas cadastradas e tente novamente!", ConsoleColor.Red);
                        else
                        {
                            if (disciplinaSelecionada.Alunos.Count == 0)
                                ExibirMensagem("Não há alunos cadastrados na disciplina", ConsoleColor.Yellow);
                            else
                            {
                                var mediaTurma = disciplinaSelecionada.CalcularMediaTurma();
                                Console.WriteLine($"Média da turma: {mediaTurma}");
                            }
                        }
                        break;

                    case "4":
                        ExibirMensagem("\tVisualizar média dos alunos matriculados na disciplina", ConsoleColor.Blue);
                        Console.Write("Informe o índice da disciplina: ");
                        indiceDisciplina = int.Parse(Console.ReadLine());
                        disciplinaSelecionada = _repositorioDisciplina.SelecionarDisciplinaPorIndice(indiceDisciplina);
                        if (disciplinaSelecionada == null)
                            ExibirMensagem("Índice inválido. Verifique as disciplinas cadastradas e tente novamente!", ConsoleColor.Red);
                        else
                        {
                            if (disciplinaSelecionada.Alunos.Count == 0)
                                ExibirMensagem("Não há alunos cadastrados na disciplina", ConsoleColor.Yellow);
                            else
                            {
                                foreach (var a in disciplinaSelecionada.Alunos)
                                {
                                    var media = disciplinaSelecionada.CalcularMediaAluno(a);
                                    Console.WriteLine($"Aluno: {a.Nome}\nMatrícula: {a.Matricula}\nMédia: {media}\n");
                                }
                            }
                        }

                        break;
                    case "5":
                        ExibirMensagem("\tCadastrar novo aluno", ConsoleColor.Blue);
                        Console.Write("Informe o índice da disciplina: ");
                        indiceDisciplina = int.Parse(Console.ReadLine());
                        disciplinaSelecionada = _repositorioDisciplina.SelecionarDisciplinaPorIndice(indiceDisciplina);
                        if (disciplinaSelecionada == null)
                            ExibirMensagem("Índice inválido. Verifique as disciplinas cadastradas e tente novamente!", ConsoleColor.Red);
                        else
                        {

                            Console.Write("Nome do aluno: ");
                            string nomeAluno = Console.ReadLine();
                            Console.Write("Matrícula: ");
                            int matricula = int.Parse(Console.ReadLine());

                            Console.WriteLine("Notas na disciplina: ");
                            Console.Write("Nota 1: ");
                            decimal n1 = decimal.Parse(Console.ReadLine());
                            Console.Write("Nota 2: ");
                            decimal n2 = decimal.Parse(Console.ReadLine());
                            Console.Write("Nota 3: ");
                            decimal n3 = decimal.Parse(Console.ReadLine());

                            var notas = new List<decimal> { n1, n2, n3 };

                            var novoAluno = new Aluno(nomeAluno, matricula, notas);

                            _repositorioAluno.Inserir(novoAluno);

                            disciplinaSelecionada.Alunos.Add(novoAluno);

                            ExibirMensagem("Aluno cadastrado com sucesso!", ConsoleColor.Green);
                        }

                        break;

                    case "6":
                        ExibirMensagem("\tVisualizar alunos cadastrados", ConsoleColor.Blue);
                        var alunos = _repositorioAluno.SelecionarTodos();
                        if (alunos.Count == 0)
                            ExibirMensagem("Nenhum aluno cadastrado\n", ConsoleColor.Yellow);
                        else
                        {
                            int i = 0;
                            foreach (var a in alunos)
                            {
                                Console.WriteLine($"#{i}\nAluno: {a.Nome}\nMatrícula: {a.Matricula}");
                                i++;
                            }
                        }
                        break;

                    default:
                        ExibirMensagem("Ínvalido", ConsoleColor.DarkRed);
                        break;
                }

            } while (continuar);
        }


        private static void ExibirMensagem(string msg, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }


}
