import './../Styles/Menu.css';
import Nav from './Nav';
import { useNavigate } from 'react-router';

interface PropsMenu {
    userName : string;
    setUserName : any;
}

function Menu({ setUserName, userName = '' } : PropsMenu) {
    const navigate = useNavigate();

    function logOut() {
        setUserName('');
        localStorage.removeItem("myAccessToken");
        localStorage.removeItem("userLogin");
    }

    return <div className='menu'>
        <div className='menu__box-name' onClick={ () => navigate('/') }>
            <span><b>KartowkaMarkawkaHub</b></span>
        </div>
        <Nav/>
        <div className='menu__box-login'>            
            {
                userName.trim() === '' 
                ? (
                    <>
                        <span onClick={ () => navigate('/') } >Регистрация</span>
                        <span onClick={ () => navigate('/login') } >Войти</span>
                    </>                    
                ) 
                : (
                    <>
                        <span>{ userName }</span>
                        <span onClick={ logOut }>Выйти</span>
                    </>                   
                )                 
            }            
        </div>
    </div>
}

export default Menu;