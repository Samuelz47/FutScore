using FutScore.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Data
{
    public class DAL<T> where T : class
    {
        private readonly FutScoreDbContext context;

        public DAL(FutScoreDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();                                   //Criando uma lista através do banco de dados (usando Entity)
        }
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);                                       //Adicionando objeto no banco de dados
        }                                                                    
        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);                                   //Atualizando objeto no banco de dados
        }
        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);                                   //Removendo objeto no banco de dados
        }
        public void Salvar()
        {
            context.SaveChanges();
        }
        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }
    }
}

