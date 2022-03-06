import React from 'react'
import { Link } from 'react-router-dom';

import '../../assets/css/footer.css';
import '../../assets/css/global.css';

import logo from '../../assets/img/logonovo-white.png';

export default function Header() {

    return (
        <div>
            <footer>
                <div className='footer__conteudo container'>
                <Link to='/'><img src={logo} alt='logo-Escuderia' className='footer__logo' /></Link>
                    <span>Todos os direitos reservados®</span>
                </div>
            </footer>
        </div>
    )
}