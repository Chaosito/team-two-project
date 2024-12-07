import { useEffect, useState } from 'react';
import './../../Styles/ProductsPage/ProductsPage.css';
import ProductCard from './../ProductCard';
import { Grid2, Button } from '@mui/material';
import { useNavigate } from 'react-router';
import { type AppDispatch, productSlice, type Product } from '../../Redux/Store';
import { useDispatch } from 'react-redux';

interface ProductData extends Product {
    image: string;
}

function ProductsPage() {
    const baseUrl = process.env.REACT_APP_BASE_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    let [products, setProducts] = useState<ProductData[]>([]);
    let navigate = useNavigate();
    const dispatchProducts = useDispatch<AppDispatch>();
    const { add, clear } = productSlice.actions;

    function buyProductHandler(product: Product) {
        dispatchProducts(clear());
        dispatchProducts(add(product));
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