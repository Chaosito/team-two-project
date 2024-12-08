import React from 'react';
import './../../Styles/BasketPage/BasketPage.css';
import { useNavigate } from 'react-router';
import { type AppDispatch, productSlice, type Product } from '../../Redux/Store';
import { useDispatch } from 'react-redux';
import { List, ListItem, ListItemButton, ListItemIcon, ListItemText, Checkbox, Button } from '@mui/material';

function BasketPage() {
    const basketUrl = process.env.REACT_APP_BASKET_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    const navigate = useNavigate();
    const dispatchProducts = useDispatch<AppDispatch>();
    const { set, clear } = productSlice.actions;
    let [products, setProducts] = React.useState<Product[]>([]);
    let [checkedProducts, setCheckedProducts] = React.useState<Product[]>([]);

    React.useEffect(() => {
        if(savedToken !== '') {
            fetch(basketUrl + '/api/Basket', {
                method: 'GET',
                headers: {
                    "Authorization": "Bearer " + savedToken
                },        
            })
            .then(response => response.json())
            .then(data => {
                setProducts(data.products);
            })
            .catch((error) => console.error(error));
        }
    }, [savedToken, basketUrl]); 

    const handleToggle = (product: Product) => () => {       
        const currentIndex = checkedProducts.find(p => p.id === product.id);
        let newChecked = [...checkedProducts];

        if (currentIndex === undefined) {
            newChecked.push(product);
        } else {
            newChecked = newChecked.filter(p => p.id !== currentIndex.id);
        }
 
        setCheckedProducts(newChecked);
    };

    function openOrderHandler() {
        dispatchProducts(clear());
        dispatchProducts(set(checkedProducts));
        navigate('/order-add');
    }

    return <div className='basket-page'>
        <div className='basket-page__box-card'>
            <List sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>            
            {
                products.map((product, index) => (
                    <ListItem key={index}>
                        <ListItemButton role={undefined} onClick={handleToggle(product)} dense>
                            <ListItemIcon>
                                <Checkbox
                                edge="start"
                                checked={checkedProducts.includes(product)}
                                tabIndex={-1}
                                disableRipple
                                />
                            </ListItemIcon>
                            <ListItemText id={'itemlist'+index} primary={product.name} secondary={`цена: ${product.price}`} />
                            </ListItemButton>
                    </ListItem>
                ))
            }
            </List>            
        </div> 
        <div className='basket-page__buttons'>
            <Button variant='contained' onClick={openOrderHandler}>Заказать</Button>
        </div>      
    </div>
}

export default BasketPage;