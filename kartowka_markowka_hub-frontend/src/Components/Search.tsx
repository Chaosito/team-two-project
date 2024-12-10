import React from 'react';
import './../Styles/Search.css';
import { TextField, Button } from '@mui/material';
import { useDispatch } from 'react-redux';
import { type AppDispatch } from '../Redux/Store';
import { productsSlice } from '../Redux/ProductSlice';
import { useNavigate } from 'react-router';


function Serarch() {
    const dispatch = useDispatch<AppDispatch>();
    const { setFilter } = productsSlice.actions;
    const navigate = useNavigate();
    let [productName, setproductName] = React.useState('');

    function searchHandler() {
        dispatch(setFilter(productName));
        navigate('/products');
    }

    return <div className='search'>
        <div className='search__input-cover'>
            <TextField className='search__input' variant='outlined' onChange={t => setproductName(t.target.value)}/>
            <Button variant='contained' onClick={searchHandler}>Найти</Button>
        </div>       
    </div>
}

export default Serarch;