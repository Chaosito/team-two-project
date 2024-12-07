import { Store, type AppDispatch } from "../../Redux/Store";
import { useSelector, useDispatch } from 'react-redux';

function OrderAddPage() {
    const dispatchProducts = useDispatch<AppDispatch>();
    type RootState = ReturnType<typeof Store.getState>;
    const products = useSelector((state: RootState) => state.products.products);
    
    console.log(products);

    return <div className="order-add-page">  
        <p>{ products[0] }</p>
    </div>
}

export default OrderAddPage;