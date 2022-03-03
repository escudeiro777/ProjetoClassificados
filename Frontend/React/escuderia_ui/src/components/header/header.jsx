import React from 'react'

import '../../assets/css/header.css';
import '../../assets/css/global.css';

import { Link } from 'react-router-dom';

import { Icon } from '@iconify/react';

import logo from '../../assets/img/logonovo.png';
import logoVolksvagen from '../../assets/img/logoVolksvagen.png';
import logoChevrolet from '../../assets/img/logoChevrolet.png';
import logoRenault from '../../assets/img/logoRenault.png';
import logoNissan from '../../assets/img/logoNissan.png';

export default function Header() {
    return (
        <div>
            <header>
                <div className='header__conteudo container'>
                    <img src={logo} alt='logo-Escuderia' className='header__logo' />
                    <Link to='/login' className='btn__login'><Icon icon="fe:login" className='icon' /> Login</Link>
                </div>
            </header>
            <nav className='header__busca'>
                <div className='header__conteudo container'>
                    <label className='input__busca'>
                        <input type='search'></input><Icon icon="akar-icons:search" />
                    </label>
                    <img src={logoVolksvagen} alt='logo-Volksvagen' className='header__marcas' />
                    <img src={logoChevrolet} alt='logo-Chevrolet' className='header__marcas' />
                    <img src={logoRenault} alt='logo-Renault' className='header__marcas' />
                    <img src={logoNissan} alt='logo-Nissan' className='header__marcas' />
                </div>
            </nav>
        </div>
    )
}