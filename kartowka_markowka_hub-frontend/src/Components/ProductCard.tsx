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
    basketHandler?(): any;
}

const ProductCard = ({ product, productName = '', imageUrl = '', width = 270, height = 150, buyHandler = ()=>{}, basketHandler }: PropsProductCard) => {
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