using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioViajaNet.WebAPI.Seed
{
    public class InitDB
    {

        private readonly DesafioViajaNetDbContext _context;

        public InitDB(DesafioViajaNetDbContext context) => _context = context;

        private readonly ISet<Estado> _estados = new HashSet<Estado>()
        {
            new Estado()
            {
                Descricao = "São Paulo",
                Cidades = new List<Cidade>
                {
                    new Cidade(){ Descricao = "Campos do Jordão"},
                    new Cidade(){ Descricao = "São Luis do Paraitinga"},
                    new Cidade(){ Descricao = "Cunha"},
                    new Cidade(){ Descricao = "Holambra"},
                    new Cidade(){ Descricao = "Itu"},
                }
            },

            new Estado()
            {
                Descricao = "Rio de Janeiro",
                Cidades = new List<Cidade>
                {
                    new Cidade(){ Descricao = "Rio de Janeiro"},
                    new Cidade(){ Descricao = "Petrópolis"},
                    new Cidade(){ Descricao = "Teresópolis"},
                    new Cidade(){ Descricao = "Nova Friburgo"},
                    new Cidade(){ Descricao = "Cabo Frio"}
                }
            },

            new Estado()
            {
                Descricao = "Minas Gerais",
                Cidades = new List<Cidade>
                {
                    new Cidade(){ Descricao = "Poços de Caldas"},
                    new Cidade(){ Descricao = "São Tomé das Letras"},
                    new Cidade(){ Descricao = "Sabará"},
                    new Cidade(){ Descricao = "Santana dos Montes"},
                    new Cidade(){ Descricao = "Gonçalves"},
                }
            }
        };

        public void Seed()
        {
            _context.Database.Migrate();
            if (!_context.Estados.Any())
            {
                _context.AddRange(_estados);
                _context.SaveChanges();
            }
            if (_context.Cidades.Any() && (!_context.Viagens.Any()))
            {
                _context.Viagens.Add(
                    new Viagem()
                    {
                        Origem = _context.Cidades.Find(1L),
                        Destino = _context.Cidades.Find(15L),
                        Voos = new List<Voo>()
                        {
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 1, 08, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 1, 10, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 1, 13, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 1, 15, 00, 00),
                                Preco = 1000,
                            }
                        }
                    });
                _context.Viagens.Add(
                    new Viagem()
                    {
                        Origem = _context.Cidades.Find(2L),
                        Destino = _context.Cidades.Find(14L),
                        Voos = new List<Voo>()
                        {
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 2, 10, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 2, 12, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 3, 10, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 3, 12, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 4, 10, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 4, 12, 00, 00),
                                Preco = 1200,
                            }
                        }
                    });
                _context.Viagens.Add(
                    new Viagem()
                    {
                        Origem = _context.Cidades.Find(3L),
                        Destino = _context.Cidades.Find(13L),
                        Voos = new List<Voo>()
                        {
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 3, 06, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 3, 09, 00, 00),
                                Preco = 1200,
                            }
                        }
                    });
                _context.Viagens.Add(
                    new Viagem()
                    {
                        Origem = _context.Cidades.Find(4L),
                        Destino = _context.Cidades.Find(12L),
                        Voos = new List<Voo>()
                        {
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 4, 18, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 4, 22, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 4, 22, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 4, 23, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 5, 00, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 5, 03, 00, 00),
                                Preco = 1200,
                            }
                        }
                    });
                _context.Viagens.Add(
                    new Viagem()
                    {
                        Origem = _context.Cidades.Find(5L),
                        Destino = _context.Cidades.Find(11L),
                        Voos = new List<Voo>()
                        {
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 5, 22, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 5, 23, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 6, 22, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 6, 23, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 7, 22, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 7, 23, 00, 00),
                                Preco = 1200,
                            },
                            new Voo()
                            {
                                DataHoraDesembarque = new DateTime(2019, 06, 8, 22, 00, 00),
                                DataHoraEmbarque = new DateTime(2019, 06, 8, 23, 00, 00),
                                Preco = 1200,
                            }
                        }
                    });
                _context.SaveChanges();
            }
        }

    }
}
