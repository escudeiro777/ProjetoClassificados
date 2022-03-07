import { useState, useEffect } from 'react';
import axios from 'axios';

import '../../assets/css/Home.css';
import '../../assets/css/global.css';

import fireMatch from '../../assets/img/Vectorfire.png';

import Header from '../../components/header/header.jsx';
import Footer from '../../components/footer/footer.jsx';
import { Link } from 'react-router-dom';

export default function Home() {
  const [listaAnuncios, setListaAnuncios] = useState([]);
  const [listaFotos, setListaFotos] = useState([]);
  // let history = useHistory();

  function buscarAnuncios() {
    axios('http://localhost:5000/api/Anuncios', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      }
    }).then(response => {
      console.log(response)
      if (response.status === 200) {
        setListaAnuncios(response.data);
      }
    }).catch(erro => console.log(erro))
  }

  async function buscarFotos() {
    await buscarAnuncios();
    setListaFotos(listaAnuncios.map((a) => {
      axios('http://localhost:5000/api/FotosProdutos/' + a.idAnuncio, {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      }
    }).then(response => {
      console.log(response)
      if (response.status === 200) {
        console.log(a);
        console.log(listaFotos);
        setListaFotos(response.data);
      }
    }).catch(erro => console.log(erro))
    }))
    
  }

  //useEffect(buscarAnuncios, []);
  useEffect(buscarFotos, []);

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
      <section className='conteudo__section'>
        <section className='section__anuncios container'>
          {
            listaAnuncios !== 0 ?
              listaAnuncios.slice(0, 5).map((anuncio) => {
                
                return (
                  <article className='box__anuncio' key={anuncio.idAnuncio}>
                    {console.log(listaFotos[0])}
                    
                    <img src={`http://localhost:5000/staticfiles/fotos_produtos/` + anuncio.idAnuncio + ".png"} alt="imagem_do_carro" /> 
                    {/* <img src={listaFotos[0]} alt='imagem_do_carro'></img> */}
                    {/* <img src={instanceOfFileReader.readAsText(blob[listaFotos[0], encoding]);} /> */}
                    
                    {/* <img src={atob(listaFotos[0])} alt='imagem_do_carro'></img> */}
                    
                    <span className='titulo__anuncio'>{anuncio.tituloAnuncio}</span>
                    <span className='situacao__anuncio'>Situação: {anuncio.idSituacaoNavigation.tituloSituacao}</span>
                    <span>Ano: {anuncio.anoVeiculo}</span>
                    <span>Estado: {anuncio.idEstadoNavigation.nomeEstado}</span>
                    <span>R$ {anuncio.preco}</span>
                    <Link to='/anuncio'>Ver anúncio</Link>
                  </article>
                )
              })
              : <section className='box__anunciosEmpty container'><p>Não há anúncios para mostrar</p></section>
          }
        </section>
      </section>
      <Footer />
    </div>
  );
}
