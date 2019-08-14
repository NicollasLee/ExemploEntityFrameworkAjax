using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories{
    public class ComputadorPecaRepository : IComputadorPecaRepository
    {
        private SistemaContext context;
        public ComputadorPecaRepository(SistemaContext context)
        {
            this.context = context;

        }

        public bool Apagar(int idComputadorPeca)
        {
            var computadorPeca = context.ComputadorPecas.FirstOrDefault(x => x.IdComputador == idComputadorPeca);
            computadorPeca.RegistroAtivo = false;
            context.Update(computadorPeca);
            return context.SaveChanges() == 1;
        }

        public ComputadorPeca ObterpeloId(int id)
        {
            return context.ComputadorPecas.FirstOrDefault(x => x.Id == id);
        }

        public List<ComputadorPeca> ObterTodosPeloIdComputador(int idComputador)
        {
            return context.ComputadorPecas.Where(x => x.IdComputador == idComputador).ToList();
        }

        public int Relacionar(ComputadorPeca computadorPeca)
        {
            context.ComputadorPecas.Add(computadorPeca);
            context.SaveChanges();
            return computadorPeca.Id;
        }
    }
}
