import { useEffect } from 'react';
import './../../Styles/ProductsPage/ProductsPage.css';
import ProductCard from './../ProductCard';
import { Grid2, Button } from '@mui/material';
import { useNavigate } from 'react-router';
import { type AppDispatch} from '../../Redux/Store';
import { productForOrderSlice, type Product } from '../../Redux/ProductForOrderSlice';
import { useDispatch, useSelector } from 'react-redux';
import { productsSlice } from '../../Redux/ProductSlice';
import { Store } from '../../Redux/Store';

function ProductsPage() {
    const baseUrl = process.env.REACT_APP_BASE_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    const navigate = useNavigate();
    const dispatch = useDispatch<AppDispatch>();
    const { add, clear } = productForOrderSlice.actions;
    const { set } = productsSlice.actions;
    type RootState = ReturnType<typeof Store.getState>;
    const products = useSelector((state: RootState) => state.products.products);
    
    function buyProductHandler(product: Product) {
        dispatch(clear());
        dispatch(add(product));
        navigate('/order-add');
    }
    
    function loadProducts() {
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

    return <div className='products-page'>
        <div className='products-page__buttons'>
            <Button variant='outlined' onClick={() => navigate('/product-add')}>добавить</Button>
        </div>
        
        <div className='products-page__grid'>
            <Grid2 container spacing={5} alignItems='center' justifyContent='center'>
                {
                    products.map((p) => (
                        <Grid2 key={p.id}>
                            <ProductCard product={p} productName={p.name + ' ' + p.price} imageUrl={''} buyHandler={buyProductHandler} />
                        </Grid2>
                    ))
                }
            </Grid2>  
        </div>           
    </div>
}

export default ProductsPage;