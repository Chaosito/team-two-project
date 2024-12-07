import { Store } from "../../Redux/Store";
import { useSelector } from 'react-redux';
import { TableContainer, Table, TableHead, TableBody, TableRow, TableCell, Paper, Button } from '@mui/material';

function OrderAddPage() {
    type RootState = ReturnType<typeof Store.getState>;
    const products = useSelector((state: RootState) => state.products.products);

    return <div className="order-add-page">  
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
        <div className="order-add-page__buttons">
            <Button variant="contained">Заказать</Button>
        </div>
        
    </div>
}

export default OrderAddPage;