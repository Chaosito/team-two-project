import './../Styles/Nav.css';
import { useNavigate } from 'react-router';

function Nav() {
    const navigate = useNavigate();

    return <div className="nav-box">
        <span onClick={ () => navigate('/products') }>Продукция</span>
        <span>Корзина</span>
        <span>Мои заказы</span>
    </div>
}

export default Nav;