import React from 'react'

import '../../assets/css/footer.css';
import '../../assets/css/global.css';

import logo from '../../assets/img/logonovo-white.png';

export default function Header() {


    return (
        <div>
            <footer>
                <div className='footer__conteudo container'>
                    <img src={logo} alt='logo-Escuderia' className='footer__logo' />
                    <span>Todos os direitos reservados®</span>
                </div>
            </footer>
        </div>
    )
}