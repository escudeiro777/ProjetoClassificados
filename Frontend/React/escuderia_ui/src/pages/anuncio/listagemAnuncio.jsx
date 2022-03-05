import { useState, useEffect } from 'react';
import axios from 'axios';

import '../../assets/css/Home.css';
import '../../assets/css/global.css';

import Header from '../../components/header/header.jsx';
import Footer from '../../components/footer/footer.jsx';

import imgCarro from '../../assets/img/carrotop.jpg'

import { Link } from 'react-router-dom';

export default function ListagemAnuncio() {
  const [anuncio, setAnuncios] = useState([]);
  // let history = useHistory();

  function buscarAnuncio() {
    axios('http://localhost:5000/api/Anuncios', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      }
    }).then(response => {
      console.log(response)
      if (response.status === 200) {
        setAnuncios(response.data);
      }
    }).catch(erro => console.log(erro))
  }

  useEffect(buscarAnuncio, []);

  return (
    <div>
      <Header />

      <div className='div__Recomendados'>
        <p className='container'>Recomendados para você</p>
      </div>
      <section className='conteudo__section'>
        <section className='section__anuncios container'>
          {
            anuncio.map((anuncio) => {
              return (
                <article className='box__anuncio' key={anuncio.idAnuncio}>
                  <img src={imgCarro} alt='imagem_do_carro'></img>
                  <span className='titulo__anuncio'>{anuncio.tituloAnuncio}</span>
                  <span className='situacao__anuncio'>Situação: {anuncio.idSituacaoNavigation.tituloSituacao}</span>
                  <span>Ano: {anuncio.anoVeiculo}</span>
                  <span>Estado: {anuncio.idEstadoNavigation.nomeEstado}</span>
                  <span>R$ {anuncio.preco}</span>
                  <Link to='/anuncio'>Ver anúncio</Link>
                </article>
              )
            })
          }
        </section>
      </section>
      <Footer />
    </div>
  );
}
