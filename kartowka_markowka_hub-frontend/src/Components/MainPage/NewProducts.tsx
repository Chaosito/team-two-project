import './../../Styles/MainPage/NewProducts.css';
import ProductCard from '../ProductCard';
import { Store } from '../../Redux/Store';
import { useEffect } from 'react';
import { type AppDispatch} from '../../Redux/Store';
import { useDispatch, useSelector } from 'react-redux';
import { productsSlice } from '../../Redux/ProductSlice';

function NewProducts() {
    const baseUrl = process.env.REACT_APP_BASE_URL;
    let savedToken = localStorage.getItem("myAccessToken") ?? '';
    const dispatch = useDispatch<AppDispatch>();
    const { set } = productsSlice.actions;

    type RootState = ReturnType<typeof Store.getState>;
    const products = useSelector((state: RootState) => state.products.products);
    const topProducts = products.slice(-5);  

    function loadProducts() {      
        savedToken = localStorage.getItem("myAccessToken") ?? '';
        console.log('savedToken: ',savedToken);
        if(savedToken !== '' && products.length === 0) {
            fetch(baseUrl + '/api/Product', {
                method: 'GET',
                headers: {
                    "Authorization": "Bearer " + savedToken
                },        
            })
            .then(response => response.json())
            .then(data => {
                dispatch(set(data.products));
            })
            .catch((error) => console.error(error));
        }
    }

    useEffect(() => {
        loadProducts();
    }, [savedToken, baseUrl]); 

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