﻿using Microsoft.AspNetCore.Http;
using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface IAnuncioRepository
    {
        Anuncio BuscarAnuncioPorId(int idAnuncio);
        void Deletar(int id);
        List<Anuncio> Listar();

        void CadastrarAnuncio(Anuncio novoAnuncio);
        string CarregarFotoDiretorio(int idUsuario);
        void SalvarFotoAnuncio(IFormFile fotoAnuncio, int idAnuncio);

    }
}
