import { Store } from "../../Redux/Store";
import { useSelector } from 'react-redux';
import './../../Styles/OrdersPage/OrderAddPage.css';
import { useNavigate } from 'react-router';
import { TableContainer, Table, TableHead, TableBody, TableRow, TableCell, Paper, Button } from '@mui/material';

function OrderAddPage() {
    type RootState = ReturnType<typeof Store.getState>;
    const products = useSelector((state: RootState) => state.productForOrder.products);
    const baseUrl = process.env.REACT_APP_BASE_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    const navigate = useNavigate();

    function orderAddHandler() {
        if(products.length === 0)
            return;

        if(savedToken !== '') {         
            Promise.all(
                products.map(product => {
                    const order = {
                        Number: Math.round(Math.random() * (1000 - 1) + 1),
                        ProductId: product.id
                    }

                    return fetch(baseUrl + '/api/Order', {
                        method: 'POST',
                        headers: {
                            "Authorization": "Bearer " + savedToken,
                            "Content-Type": "application/json"
                        },    
                        body: JSON.stringify(order)          
                    })
                    .catch((error) => console.error(error));
                })                
            ).then(response => navigate('/orders'));
        } 
    }

    return <div className="order-add-page">  
        <div className="order-add-page__table">
            <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                <TableRow>
                    <TableCell>Продукт</TableCell>
                    <TableCell >Цена</TableCell>
                </TableRow>
                </TableHead>
                <TableBody>
                {
                    products.map((product) => (
                        <TableRow
                            key={product.id}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            hover
                        >
                            <TableCell component="th" scope="row">
                                {product.name}
                            </TableCell>
                            <TableCell >{product.price}</TableCell>
                        </TableRow>
                    ))
                }
                </TableBody>
            </Table>
            </TableContainer>
        </div>
        
        <div className="order-add-page__buttons">
            <Button variant="contained" onClick={orderAddHandler}>Заказать</Button>
        </div>
        
    </div>
}

export default OrderAddPage;