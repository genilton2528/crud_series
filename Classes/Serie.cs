using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero _genero;
        private string _titulo;
        private string _descricao;
        private int _ano;

        public string Titulo 
        {
            get{ return this._titulo; }
        }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this._genero = genero;
            this._titulo = titulo;
            this._descricao = descricao;
            this._ano = ano;
        }

        public override string ToString()
		{
            var retorno = "";
            retorno += "Gênero: " + this._genero + Environment.NewLine;
            retorno += "Titulo: " + this._titulo + Environment.NewLine;
            retorno += "Descrição: " + this._descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this._ano + Environment.NewLine;
            //retorno += "Excluido: " + this.Excluido;
			return retorno;
		}
    }
}