// import { useState, useEffect } from 'react';
// import axios from 'axios';

import '../../assets/css/Home.css';
import '../../assets/css/global.css';

import fireMatch from '../../assets/img/Vectorfire.png';

import Header from '../../components/header/header.jsx';

function App() {
  // const [listaAnuncios, setListaAnuncios] = useState([]);
  // let history = useHistory();

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

      <span>Recomendados para você</span>

      <section>

      </section>

    </div>
  );
}

export default App;
