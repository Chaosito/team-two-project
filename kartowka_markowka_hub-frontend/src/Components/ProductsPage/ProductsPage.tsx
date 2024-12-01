import { useEffect, useState } from 'react';
import './../../Styles/ProductsPage/ProductsPage.css';
import ProductCard from './../ProductCard';
import { Grid2 } from '@mui/material';

interface Product {
    id: number;
    name: string;
    price: number;
    image: string;
}

function ProductsPage() {
    const baseUrl = process.env.REACT_APP_BASE_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    let [products, setProducts] = useState<Product[]>([]);

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
        <Grid2 container spacing={5} alignItems='center' justifyContent='center'>
            {
                products.map((p) => (
                    <Grid2 key={p.id}>
                        <ProductCard productName={p.name + ' ' + p.price} imageUrl={''} />
                    </Grid2>
                ))
            }
        </Grid2>     
    </div>
}

export default ProductsPage;