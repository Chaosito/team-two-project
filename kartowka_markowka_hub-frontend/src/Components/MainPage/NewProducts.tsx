import './../../Styles/MainPage/NewProducts.css';
import ProductCard from '../ProductCard';
import vegetables from './../../Images/vegetables.jpg';
import apples from './../../Images/apples.jpg';
import milk from './../../Images/milk.jpg';
import honey from './../../Images/honey.jpg';

function NewProducts() {
    return <div className="new-products">
        <h3 className='new-products__title'>Свежие продукты</h3>
        <div className="new-products__box">
            <ProductCard imageUrl={vegetables} />
            <ProductCard imageUrl={apples} />
            <ProductCard imageUrl={milk} />
            <ProductCard imageUrl={honey} />
            <ProductCard imageUrl={vegetables} />
        </div>
    </div>
}

export default NewProducts;