using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP03
{
    public class PacoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<PacoteModel> _pacotes;
        private PacoteModel _pacote;

        public List<PacoteModel> Pacotes
        {
            get { return _pacotes; }
            set
            {
                _pacotes = value;
                OnPropertyChanged();
            }
        }

        public PacoteModel Pacote
        {
            get { return _pacote; }
            set
            {
                _pacote = value;
                OnPropertyChanged();
            }
        }

        public PacoteViewModel()
        {
            _pacotes = new List<PacoteModel>
            {
                new PacoteModel
                {
                    PacoteId = "123",
                    Status = "Em trânsito",
                    DataEnvio = DateTime.Now.AddDays(-3),
                    DataPrevistaEntrega = DateTime.Now.AddDays(2),
                    HistoricoEventos = new List<string>
                    {
                        "Pacote recebido no centro de distribuição.",
                        "Pacote em trânsito para o destino.",
                        "Pacote saiu para entrega."
                    }
                },
                new PacoteModel
                {
                    PacoteId = "456",
                    Status = "Aguardando retirada",
                    DataEnvio = DateTime.Now.AddDays(-5),
                    DataPrevistaEntrega = DateTime.Now.AddDays(1),
                    HistoricoEventos = new List<string>
                    {
                        "Pacote recebido no centro de distribuição.",
                        "Pacote disponível para retirada."
                    }
                },
                new PacoteModel
                {
                    PacoteId = "789",
                    Status = "Entregue",
                    DataEnvio = DateTime.Now.AddDays(-7),
                    DataPrevistaEntrega = DateTime.Now.AddDays(-1),
                    HistoricoEventos = new List<string>
                    {
                        "Pacote recebido no centro de distribuição.",
                        "Pacote em trânsito para o destino.",
                        "Pacote saiu para entrega.",
                        "Pacote entregue ao destinatário."
                    }
                },
            };
        }

        public async Task BuscarInformacoesPacoteAsync(string codigoRastreamento)
        {
            var pacoteEncontrado = _pacotes.FirstOrDefault(p => p.PacoteId == codigoRastreamento);

            if (pacoteEncontrado != null)
            {
                Pacote = pacoteEncontrado;
            }
            else
            {
                Pacote = null;
                await Application.Current.MainPage.DisplayAlert("Pacote não encontrado", "Desculpe! O pacote não foi encontrado. Verifique o código digitado e tente novamente.", "Ok");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
