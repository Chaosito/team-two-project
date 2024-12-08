import './../../Styles/MainPage/NewProducts.css';
import ProductCard from '../ProductCard';
import { Product } from '../../Redux/Store';
import vegetables from './../../Images/vegetables.jpg';
import apples from './../../Images/apples.jpg';
import milk from './../../Images/milk.jpg';
import honey from './../../Images/honey.jpg';

function NewProducts() {
    const product: Product = {
        id: "",
        name: "",
        price: 0
    }

    return <div className="new-products">
        <h3 className='new-products__title'>Свежие продукты</h3>
        <div className="new-products__box">
            <ProductCard product={product} imageUrl={vegetables} height={150} />
            <ProductCard product={product} imageUrl={apples} height={150} />
            <ProductCard product={product} imageUrl={milk} height={150} />
            <ProductCard product={product} imageUrl={honey} height={150} />
            <ProductCard product={product} imageUrl={vegetables} height={150} />
        </div>
    </div>
}

export default NewProducts;