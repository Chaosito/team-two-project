import './../Styles/ProductCard.css';
import { Product } from '../Redux/Store';
import { Card, CardMedia, CardActions, Button, CardContent, Typography } from '@mui/material';
import LocalGroceryStoreOutlinedIcon from '@mui/icons-material/LocalGroceryStoreOutlined';
import vegetables from './../Images/vegetables.jpg';

interface PropsProductCard {
    product: Product;
    productName?: string;
    imageUrl?: string;
    width?: number;
    height?: number;
    buyHandler?: (product:Product)=>void;
}



const ProductCard = ({ product, productName = '', imageUrl = '', width = 270, height = 150, buyHandler = ()=>{} }: PropsProductCard) => {
    const basketUrl = process.env.REACT_APP_BASKET_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';

    function basketHandler() {
        if(savedToken !== '') {
            fetch(basketUrl + '/api/Basket', {
                method: 'POST',
                headers: {
                    "Authorization": "Bearer " + savedToken,
                     "Content-Type": "application/json"
                },
                body: JSON.stringify({ ProductId: product.id })             
            })
            .catch((error) => console.error(error));
        }
    }
    
    return <div className="product-card">
        <Card sx={{ maxWidth: 300 }}>
            <CardMedia
                sx={{ width: { width }, height: { height } }}
                image={vegetables}
                title={productName}
            />
            <CardContent>
                <Typography variant='h5' >
                    {productName}
                </Typography>
            </CardContent>
            <CardActions>
                <Button 
                    size='small' 
                    variant='contained' 
                    onClick={ () => buyHandler(product) } 
                    className='product-card__button product-card__button--buy'
                >Купить
                </Button>
                <Button
                    size='small'
                    variant='contained'
                    onClick={basketHandler}
                    className='product-card__button'
                >{<LocalGroceryStoreOutlinedIcon />}
                </Button>
            </CardActions>
        </Card>
    </div>
}

export default ProductCard;