// import { useState, useEffect } from 'react';
// import axios from 'axios';

import '../../assets/css/Home.css';
import '../../assets/css/global.css';


import Header from '../../components/header/header.jsx';
import Footer from '../../components/footer/footer.jsx';

export default function ListagemAnuncio() {
    // const [anuncio, setAnuncio] = useState([]);

    // function buscarAnuncio() {
    //     axios('https://62059c4d161670001741bc7d.mockapi.io/Anuncio/2').then(response => {
    //         console.log(response)
    //         if (response.status === 200) {
    //             setAnuncio(response.data);
    //         }
    //     }).catch(erro => console.log(erro))
    // }

    // useEffect(buscarAnuncio, []);

    return (
        <div>
            <Header />

            <section className='conteudo__section'>
                <section className='section__anuncios container'>
                    {/* {
                        anuncio.map(anuncio => {
                            return (
                                <article className='box__anuncio' key={anuncio.id}>
                                    <img src={anuncio.imgCarro} alt='imagem_do_carro'></img>
                                    <span className='titulo__anuncio'>{anuncio.tituloAnuncio}</span>
                                    <span>Estado: {anuncio.estado}</span>
                                    <span>Ano: {Intl.DateTimeFormat("pt-BR",
                                        {
                                            year: 'numeric'
                                        }
                                    ).format(new Date(anuncio.anoVeiculo))}</span>
                                    <span>R$ {anuncio.preco}</span>
                                </article>
                            )
                        })
                    } */}
                </section>
            </section>
            <Footer />
        </div>
    );
}
