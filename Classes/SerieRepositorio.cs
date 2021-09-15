using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> _listSeries = new List<Serie>();
        public List<Serie> Lista()
        {
            return _listSeries;
        }

        public Serie RetornaPorId(int id)
        {
            return _listSeries[id];
        }

        public void Insere(Serie entidade)
        {
            _listSeries.Add(entidade);
        }

        public void Exclui(int id)
        {
            _listSeries[id].Excluir();
        }

        public void Atualiza(int id, Serie entidade)
        {
            _listSeries[id] = entidade;
        }

        public int ProximoId()
        {
            return _listSeries.Count;
        }
    }
}