import { useEffect, useState } from 'react';
import './../../Styles/ProductsPage/ProductsPage.css';
import ProductCard from './../ProductCard';
import { Grid2, Button } from '@mui/material';
import { useNavigate } from 'react-router';
import { type AppDispatch, productSlice } from '../../Redux/Store';
import { useDispatch } from 'react-redux';

interface Product {
    id: string;
    name: string;
    price: number;
    image: string;
}

function ProductsPage() {
    const baseUrl = process.env.REACT_APP_BASE_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    let [products, setProducts] = useState<Product[]>([]);
    let navigate = useNavigate();
    const dispatchProducts = useDispatch<AppDispatch>();
    const { add, clear } = productSlice.actions;

    function buyProductHandler(productId: string) {
        console.log('id: ' + productId);
        dispatchProducts(clear());
        dispatchProducts(add(productId));
        navigate('/order-add');
    }

    useEffect(() => {
        if(savedToken !== '') {
            fetch(baseUrl + '/api/Product', {
                method: 'GET',
                headers: {
                    "Authorization": "Bearer " + savedToken
                },        
            })
            .then(response => response.json())
            .then(data => {
                console.log(data.products);
                setProducts(data.products);
            })
            .catch((error) => console.error(error));
        }
    }, [savedToken]); 

    return <div className='products-page'>
        <div className='products-page__buttons'>
            <Button variant='outlined' onClick={() => navigate('/product-add')}>добавить</Button>
        </div>
        
        <div className='products-page__grid'>
            <Grid2 container spacing={5} alignItems='center' justifyContent='center'>
                {
                    products.map((p) => (
                        <Grid2 key={p.id}>
                            <ProductCard productId={p.id} productName={p.name + ' ' + p.price} imageUrl={''} buyHandler={buyProductHandler} />
                        </Grid2>
                    ))
                }
            </Grid2>  
        </div>           
    </div>
}

export default ProductsPage;