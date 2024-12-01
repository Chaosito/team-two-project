import './../Styles/Nav.css';
import { useNavigate } from 'react-router';

function Nav() {
    const navigate = useNavigate();

    return <div className="nav-box">
        <div className='nav-box__item' onClick={ () => navigate('/products') }>
            <span>Продукция</span>
        </div>
        <div className='nav-box__item'>
            <span>Корзина</span>
        </div>
        <div className='nav-box__item'>
            <span>Мои заказы</span>
        </div>       
    </div>
}

export default Nav;