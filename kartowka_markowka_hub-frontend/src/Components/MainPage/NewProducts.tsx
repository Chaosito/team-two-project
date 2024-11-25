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
            <ProductCard imageUrl={vegetables} width={270} height={150} />
            <ProductCard imageUrl={apples} width={270} height={150} />
            <ProductCard imageUrl={milk} width={270} height={150} />
            <ProductCard imageUrl={honey} width={270} height={150} />
            <ProductCard imageUrl={vegetables} width={270} height={150} />
        </div>
    </div>
}

export default NewProducts;