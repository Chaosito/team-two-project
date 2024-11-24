import './../../Styles/MainPage/CategoryCard.css';
import { Button } from '@mui/material';

function CategoryCard() {
    return <div className='category-card'>
        <Button className='category-card__button' variant='contained'>Овощи</Button>
    </div>
}

export default CategoryCard;