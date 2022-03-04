import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Routes
} from 'react-router-dom';

import './index.css';

import App from '../src/pages/home/App';

import reportWebVitals from './reportWebVitals';
import Login from './pages/login/login';
import ListagemAnuncio from './pages/listagemProdutos/paginaAnuncio';

const routing = (
  <Router>
    <div>
      <Routes>
        <Route exact path = '/' element = {<App/>}/>
        <Route path = '/login' element = {<Login/>}/>
        <Route path = '/anuncio' element = {<ListagemAnuncio/>}/>
      </Routes>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
