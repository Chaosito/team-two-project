import './../../Styles/MainPage/NewProducts.css';
import ProductCard from '../ProductCard';
import { Store } from '../../Redux/Store';
import { useSelector } from 'react-redux';

function NewProducts() {
    type RootState = ReturnType<typeof Store.getState>;
    const products = useSelector((state: RootState) => state.products.products);
    const topProducts = products.slice(-5);

    return <div className="new-products">
        <h3 className='new-products__title'>Свежие продукты</h3>
        <div className="new-products__box">
            {
                topProducts.map(p => (
                    <ProductCard key={p.id} product={p} productName={p.name + ' ' + p.price} imageUrl={''} height={120} />
                ))
            }
        </div>
    </div>
}

export default NewProducts;