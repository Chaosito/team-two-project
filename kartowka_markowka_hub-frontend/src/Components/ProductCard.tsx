import './../Styles/ProductCard.css';
import { Card, CardMedia, CardActions, Button, CardContent, Typography } from '@mui/material';
import LocalGroceryStoreOutlinedIcon from '@mui/icons-material/LocalGroceryStoreOutlined';
import vegetables from './../Images/vegetables.jpg';

interface PropsProductCard {
    productId?: string;
    productName?: string;
    imageUrl?: string;
    width?: number;
    height?: number;
    buyHandler?: (id:string)=>void;
    basketHandler?(): any;
}

const ProductCard = ({ productId = '', productName = '', imageUrl = '', width = 270, height = 150, buyHandler = ()=>{}, basketHandler }: PropsProductCard) => {
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
                    onClick={ () => buyHandler(productId) } 
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