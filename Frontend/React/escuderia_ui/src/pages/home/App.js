import { useState, useEffect } from 'react';
import axios from 'axios';

import '../../assets/css/Home.css';
import '../../assets/css/global.css';

import fireMatch from '../../assets/img/Vectorfire.png';

import Header from '../../components/header/header.jsx';

function App() {
  const [listaAnuncios, setListaAnuncios] = useState([]);
  // let history = useHistory();

  function buscarAnuncios() {
    axios('https://62059c4d161670001741bc7d.mockapi.io/Anuncio').then(response => {
      console.log(response)
      if (response.status === 200) {
        setListaAnuncios(response.data);
      }
    }).catch(erro => console.log(erro))
  }

  useEffect(buscarAnuncios, []);

  return (
    <div>
      <Header />
      <section className='home__banner'>
        <p>Dê 'match' com seu carro ideal!</p>
        <button
          type='submit'
          className='banner__btn'>
          <img src={fireMatch} alt='' className='btn__img' />
          <div className='btn__text'>
            Ir pro
            <span>Match</span>
          </div>
        </button>
      </section>

      <div className='div__Recomendados'>
        <p className='container'>Recomendados para você</p>
      </div>

      <section className='section__anuncios container'>
          {
            listaAnuncios.slice(1, 7).map((anuncio) => {
              return (
                <article className='box__anuncio' key={anuncio.id}>
                  <img src={anuncio.imgCarro} alt='imagem_do_carro'></img>
                  <span className='titulo__anuncio'>{anuncio.tituloAnuncio}</span>
                  <span>{anuncio.idEstadoNavigation.nomeEstado}</span>
                  <span>Ano: {Intl.DateTimeFormat("pt-BR",
                    {
                      year: 'numeric'
                    }
                  ).format(new Date(anuncio.anoVeiculo))}</span>
                  <span>R$ {anuncio.preco}</span>
                  <button type='submit'>Ver anúncio</button>
                </article>
              )
            })
          }
      </section>

    </div>
  );
}

export default App;
