import './../Styles/ProductCard.css';
import { Button } from '@mui/material';
//import ShoppingBasketOutlinedIcon from '@mui/icons-material/ShoppingBasketOutlined';

interface PropsProductCard {
    imageUrl: string; 
    width: number;
    height: number;
}

function ProductCard({imageUrl = '', width = 270, height = 150}: PropsProductCard) {
    return <div className="product-card" style={{backgroundImage: `url(${imageUrl})`, backgroundSize: 'cover', width:`${width}px`, height:`${height}px`}}>
        <Button className='product-card__button product-card__button--buy' variant='contained'>Купить</Button>
        <Button className='product-card__button product-card__button--basket' variant='contained'>корзина</Button>
    </div>
}

export default ProductCard;