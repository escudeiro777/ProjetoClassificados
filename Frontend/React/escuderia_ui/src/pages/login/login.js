import { Component } from "react";
import api from "../../services/api";
import { parseJwt } from "../../services/auth";
import '../../assets/css/login.css';
import Header from '../../components/header/header.jsx';
import axios from "axios";

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: "murillo@email.com",
            senha: "12345678",
            mensagemDeErro: '',
            carregando: false,
        };
    }
    login = (evento) => {
        evento.preventDefault();
        console.log(this.state.email);
        this.setState({ mensagemDeErro: "", carregando: true })
        
        
        api.post("/login", {
            email : this.state.email,
            senha : this.state.senha
        })

        .then((resposta) => {
                if (resposta.status === 200) {
                    localStorage.setItem('usuario-login', resposta.data.token);
                    this.setState({ carregando: false });

                    if (parseJwt().role === '2') {
                        this.props.history.push('/')
                    } else if (parseJwt().role === '1') {
                        this.props.history.push('/')
                    }

                }
            })
            .catch(() => {
                this.setState({
                    mensagemDeErro: "Dados Inválidos",
                    carrergando: false
                });
            });
    };
    atualizaStateCampo = (campo) => {
        this.setState({
            [campo.target.name]: campo.target.value })
    }

    render() 
    {
        return(
            <div>
            <Header/>
            <section className = "containerLogin" >
            <p> ACESSE JÁ SUA CONTA! </p> <div className = "formLogin" >
            
            <form onSubmit = { this.login }
            className = "formulario" >
            <p className = "loginSenha" > Email: </p> <input value = { this.state.email }
            onChange = { this.atualizaStateCampo }
            name = 'email'
            placeholder = "   Insira seu E-mail"
            type = "email" >
            </input> 
            <p className = "loginSenha" > Senha: </p> 
            <input value = { this.state.senha }
            onChange = { this.atualizaStateCampo }
            name = 'senha'
            placeholder = "   Insira sua senha"
            type = "password" > 
            </input>
            <p className = "mensagemDeErro"
            style = {{ color: 'red' }} > { this.state.mensagemDeErro } </p> 
            {
                this.state.carregando === true && (<button className = "btn"
                    type = "submit"
                    disabled id = "btnLogin" >
                    carregando... </button>)} {
                        this.state.carregando === false && ( <button className = "btn"
                            type = "submit"
                            disabled = {
                                this.state.email === '' || this.state.senha === '' ?
                                'none' :
                                    ''
                            }
                            id = "btnLogin" >
                            logar </button>
                        )
                    } 
                    </form> 
                    </div> 
                    </section> 
                    <main >
                    </main> 
                    </div>

        )
    }
} 