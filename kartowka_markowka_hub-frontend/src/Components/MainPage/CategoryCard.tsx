import './../../Styles/MainPage/CategoryCard.css';
import { Button } from '@mui/material';

interface PropsCategoryCard {
    buttonText: string;
    imageUrl: string;
}

function CategoryCard({buttonText, imageUrl}: PropsCategoryCard) {
    return <div className='category-card' style={{backgroundImage: `url(${imageUrl})`, backgroundSize: 'cover'}}>
        <Button className='category-card__button' variant='contained'>{buttonText}</Button>
    </div>
}

export default CategoryCard;