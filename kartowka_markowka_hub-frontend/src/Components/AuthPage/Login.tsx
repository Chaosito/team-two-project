import { useState } from 'react';
import './../../Styles/AuthPage/Login.css';
import { TextField, Button } from '@mui/material';
import { useNavigate } from 'react-router';

interface LoginData {
    login: string;
    password: string;
}

interface PropsLogin {
    userName: string
    setUserName: any
}

function Login({ setUserName, userName = '' } : PropsLogin) {
    const baseUrl = process.env.REACT_APP_BASE_URL;
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    function sendLoginRequest() {
        let requestData: LoginData = {
            login: name,
            password: password
        }
     
        fetch(baseUrl + '/api/Account/Login', {
            method: 'POST',
            body: JSON.stringify(requestData),
            headers: {
                "Content-Type": "application/json",
            },        
            })
            .then(response => response.json())
            .then(data => {
                localStorage.setItem("myAccessToken", data.accessToken);
                localStorage.setItem("userLogin", data.login);
                setUserName(data.login);
                navigate('/');
            })
            .catch((error) => console.error(error));
    }

    function loginButtonHandler() {
        if(userName === '')
            sendLoginRequest();

        navigate('/');
    }

    return <div className='login'>
        <div className='login__box'>
            <TextField className='login__field'
                variant='outlined' 
                label='Логин' 
                defaultValue={name} 
                onChange={(e) => setName(e.target.value)}
            />
            <TextField className='login__field'
                variant='outlined' 
                label='Пароль' 
                defaultValue={password} 
                onChange={(e) => setPassword(e.target.value)} 
            />
            <Button className='login__button'
                variant='contained' 
                size='large' 
                onClick={loginButtonHandler}
            >Войти</Button>
        </div>      
    </div>
}

export default Login;