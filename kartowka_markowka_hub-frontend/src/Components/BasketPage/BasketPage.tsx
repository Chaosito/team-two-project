import React from 'react';
import './../../Styles/BasketPage/BasketPage.css';
import { List, ListItem, ListItemButton, ListItemIcon, ListItemText, Checkbox } from '@mui/material';

interface Product {
    Id: string;
    Name: string;
    Price: number;
}

interface Basket {
    Products: Product[]
}

function BasketPage() {

    const basket: Basket = {
        Products: [
            { Id: "1", Name: "Картошка", Price: 100 }, 
            { Id: "2", Name: "Морковка", Price: 80 }, 
            { Id: "3", Name: "Молоко", Price: 250 }, 
        ]
    }

    //const baseUrl = process.env.REACT_APP_BASE_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';

    /*React.useEffect(() => {
        if(savedToken !== '') {
            fetch(baseUrl + '/api/Basket', {
                method: 'GET',
                headers: {
                    "Authorization": "Bearer " + savedToken
                },        
            })
            .then(response => response.json())
            .then(data => {
                console.log(data);
            })
            .catch((error) => console.error(error));
        }
    }, [savedToken]); */

    return <div className='basket-page'>
        <div className='basket-page__box-card'>
            <List sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>            
            {
                basket.Products.map((product, index) => (
                    <ListItem key={index}>
                        <ListItemButton role={undefined} dense>
                            <ListItemIcon>
                                <Checkbox
                                edge="start"
                                tabIndex={-1}
                                disableRipple
                                />
                            </ListItemIcon>
                            <ListItemText id={'itemlist'+index} primary={product.Name} secondary={`цена: ${product.Price}`} />
                            </ListItemButton>
                    </ListItem>
                ))
            }
            </List>            
        </div>       
    </div>
}

export default BasketPage;