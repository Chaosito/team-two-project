import './../Styles/Menu.css';
import Nav from './Nav';

function Menu() {
    return <div className='menu'>
        <div className='menu__box-name'>
            <span><b>KartowkaMarkawkaHub</b></span>
        </div>
        <Nav/>
        <div className='menu__box-login'>
            <span>Регистрация</span>
            <span>Войти</span>
        </div>
    </div>
}

export default Menu;