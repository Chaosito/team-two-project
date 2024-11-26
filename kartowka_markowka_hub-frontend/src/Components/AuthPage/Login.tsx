import './../../Styles/AuthPage/Login.css';
import { TextField, Button } from '@mui/material';

function Login() {
    return <div className='login'>
        <div className='login__box'>
            <TextField className='login__field' variant='outlined' label='Почта' />
            <TextField className='login__field' variant='outlined' label='Пароль' />
            <Button className='login__button' variant='contained' size='large'>Войти</Button>
        </div>      
    </div>
}

export default Login;