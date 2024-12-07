import './../../Styles/ProductsPage/ProductAddPage.css';
import { Button, TextField } from "@mui/material";
import { useState } from 'react';
import { useNavigate } from 'react-router';

interface ProductAdd {
    Name: string,
    Price: number
}

function ProductAddPage() {

    let [productName, setProductName] = useState('');
    let [productPrice, setProductPrice] = useState(0);
    let navigate = useNavigate();

    function saveProductHandler() {
        const baseUrl = process.env.REACT_APP_BASE_URL;
        const savedToken = localStorage.getItem("myAccessToken") ?? '';

        const product: ProductAdd = {
            Name: productName,
            Price: productPrice
        }

        fetch(baseUrl + '/api/Product', {
            method: 'POST',
            headers: {
                "Authorization": "Bearer " + savedToken,
                "Content-Type": "application/json"
            },
            body: JSON.stringify(product)        
        })
        .then(response => navigate('/products'))
        .catch((error) => console.error(error));
    }

    return <div className="product-add-page">
        <div className="product-add-page__box">
            <TextField variant='outlined' label='название' onChange={(e) => setProductName(e.target.value)} />
            <TextField variant='outlined' label='цена' type='number' onChange={(e) => setProductPrice(Number(e.target.value))} />
            <Button variant="outlined" onClick={saveProductHandler}>Сохранить</Button>
        </div>        
    </div>
}

export default ProductAddPage;