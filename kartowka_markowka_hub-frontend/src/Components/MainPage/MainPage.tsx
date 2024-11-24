import './../../Styles/MainPage/MainPage.css';
import Categories from "./Categories";
import NewProducts from "./NewProducts";

function MainPage() {
    return <div className="main-page">
        <Categories/>
        <NewProducts/>
    </div>
}

export default MainPage;