import './../Styles/ProductCard.css';
import { Button } from '@mui/material';
import LocalGroceryStoreOutlinedIcon from '@mui/icons-material/LocalGroceryStoreOutlined';

interface PropsProductCard {
    imageUrl: string; 
    width?: number;
    height?: number;
    buyHandler?(): any;
    basketHandler?(): any;
}

const ProductCard = ({imageUrl = '', width = 270, height = 150, buyHandler, basketHandler}: PropsProductCard) => {
    return <div className="product-card" style={{backgroundImage: `url(${imageUrl})`, backgroundSize: 'cover', width:`${width}px`, height:`${height}px`}}>
        <Button className='product-card__button product-card__button--buy' onClick={buyHandler} variant='contained' >Купить</Button>
        <Button className='product-card__button product-card__button--basket' onClick={basketHandler} variant='contained'>{<LocalGroceryStoreOutlinedIcon/>}</Button>        
    </div>
}

export default ProductCard;