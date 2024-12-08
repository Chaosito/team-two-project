import './../Styles/ProductCard.css';
import { productForOrderSlice, type Product } from '../Redux/ProductForOrderSlice';
import { Card, CardMedia, CardActions, Button, CardContent, Typography } from '@mui/material';
import LocalGroceryStoreOutlinedIcon from '@mui/icons-material/LocalGroceryStoreOutlined';
import vegetables from './../Images/vegetables.jpg';
import { useNavigate } from 'react-router';
import { useDispatch } from 'react-redux';
import { type AppDispatch } from '../Redux/Store';


interface PropsProductCard {
    product: Product;
    productName?: string;
    imageUrl?: string;
    width?: number;
    height?: number;
}

const ProductCard = ({ product, productName = '', imageUrl = '', width = 270, height = 150 }: PropsProductCard) => {
    const basketUrl = process.env.REACT_APP_BASKET_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    const navigate = useNavigate();
    const dispatch = useDispatch<AppDispatch>();
    const { add, clear } = productForOrderSlice.actions;

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

    function buyHandler(product: Product) {
        dispatch(clear());
        dispatch(add(product));
        navigate('/order-add');
    }
    
    return <div className="product-card">
        <Card sx={{ maxWidth: 300 }}>
            <CardMedia
                sx={{ width: { width }, height: { height } }}
                image={vegetables}
                title={productName}
            />
            <CardContent>
                <Typography variant='h6' >
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