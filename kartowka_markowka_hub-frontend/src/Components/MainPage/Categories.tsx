import './../../Styles/MainPage/Categories.css';
import CategoryCard from './CategoryCard';
import vegetables from './../../Images/vegetables.jpg';
import apples from './../../Images/apples.jpg';
import milk from './../../Images/milk.jpg';
import honey from './../../Images/honey.jpg';

function Categories() 
{
    return <div className="categories">
        <div className="categories__box">
            <CategoryCard buttonText="Овощи" imageUrl={vegetables} />
            <CategoryCard buttonText="Фрукты" imageUrl={apples}/>
            <CategoryCard buttonText="Молочка" imageUrl={milk}/>
            <CategoryCard buttonText="Мёд" imageUrl={honey}/>
        </div>
    </div>
}

export default Categories;