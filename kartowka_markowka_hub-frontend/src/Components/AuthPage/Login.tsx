import { useState } from 'react';
import './../../Styles/AuthPage/Login.css';
import { TextField, Button } from '@mui/material';

interface LoginData {
    login: string;
    password: string;
}

function Login() {
    const [name, setName] = useState('Wower');
    const [password, setPassword] = useState('123123');

    function loginButtonHandler() {
        let requestData: LoginData = {
            login: name,
            password: password
        }
     
        fetch('https://localhost:7035/api/Account/Login', {
            method: 'POST',
            body: JSON.stringify(requestData),
            headers: {
                "Content-Type": "application/json",
            },        
            })
            .then(response => response.json())
            .then(data => {
                localStorage.setItem("myAccessToken", data.accessToken);
                console.log(data);
            })
            .catch((error) => console.error(error));
          
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