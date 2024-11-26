import './../../Styles/ProductsPage/ProductsPage.css';
import ProductCard from './../ProductCard';
import vegetables from './../../Images/vegetables.jpg';
import { Grid2} from '@mui/material';

interface Product {
    id: number,
    productName: string,
    image: string
}

let products: Product[] = []

for(let i = 0; i < 20; i++) 
    products.push({id: i, productName: 'Картошка ' + i, image: vegetables});

function ProductsPage() {
    return <div className='products-page'>
        <Grid2 container spacing={5} alignItems='center' justifyContent='center'>
            {
                products.map((p) => (
                    <Grid2 key={p.id}>
                        <ProductCard productName={p.productName} imageUrl={p.image} />
                    </Grid2>
                ))
            }
        </Grid2>     
    </div>
}

export default ProductsPage;