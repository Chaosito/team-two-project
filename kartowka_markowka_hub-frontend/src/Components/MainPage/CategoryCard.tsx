import './../../Styles/MainPage/CategoryCard.css';
import { useNavigate } from 'react-router';
import { Button } from '@mui/material';

interface PropsCategoryCard {
    buttonText: string;
    imageUrl: string;
}

function CategoryCard({buttonText, imageUrl}: PropsCategoryCard) {
    const navigate = useNavigate();

    return <div className='category-card' style={{backgroundImage: `url(${imageUrl})`, backgroundSize: 'cover'}}>
        <Button className='category-card__button' variant='contained' onClick={() => navigate('/products')}>{buttonText}</Button>
    </div>
}

export default CategoryCard;