import './../../Styles/MainPage/CategoryCard.css';
import { Button } from '@mui/material';

interface PropsCategoryCard {
    buttonText: string;
}

function CategoryCard({buttonText}: PropsCategoryCard) {
    return <div className='category-card'>
        <Button className='category-card__button' variant='contained'>{buttonText}</Button>
    </div>
}

export default CategoryCard;