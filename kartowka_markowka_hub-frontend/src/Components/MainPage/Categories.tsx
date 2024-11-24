import './../../Styles/MainPage/Categories.css';
import CategoryCard from './CategoryCard';

function Categories() 
{
    return <div className="categories">
        <div className="categories__box">
            <CategoryCard buttonText="Овощи"/>
            <CategoryCard buttonText="Фрукты"/>
            <CategoryCard buttonText="Молочка"/>
            <CategoryCard buttonText="Мёд"/>
        </div>
    </div>
}

export default Categories;