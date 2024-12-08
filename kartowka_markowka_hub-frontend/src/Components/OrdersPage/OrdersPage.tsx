import { useEffect, useState } from 'react';
import './../../Styles/OrdersPage/OrdersPage.css';
import { TableContainer, Table, TableHead, TableBody, TableRow, TableCell, Paper } from '@mui/material';

interface ProductDto {
    id: string;
    name: string;
    price: number;
}

interface Order {
    id: string;
    number: number;
    product: ProductDto;
    orderStatusName: string;
}

function OrdersPage() {
    const baseUrl = process.env.REACT_APP_BASE_URL;
    const savedToken = localStorage.getItem("myAccessToken") ?? '';
    let [orders, setOrders] = useState<Order[]>([]);
    let [triggerRead, settriggerRead] = useState(false);

    useEffect(() => {
        if(savedToken !== '') {
            fetch(baseUrl + '/api/Order', {
                method: 'GET',
                headers: {
                    "Authorization": "Bearer " + savedToken
                },        
            })
            .then(response => response.json())
            .then(data => {
                setOrders(data.orders);
            })
            .catch((error) => console.error(error));
        }
    }, [triggerRead, savedToken, baseUrl]); 


    function updateStatuHandler(orderId: string) {
        fetch(baseUrl + '/api/Order/UpdateStatus', {
            method: 'PUT',
            headers: {
                "Authorization": "Bearer " + savedToken,
                "Content-Type": "application/json"
            },
            body: JSON.stringify({'orderId': orderId})        
        })
        .then(response => settriggerRead(true))
        .catch((error) => console.error(error));
    }

    return <div className="orders-page">
        <div className='orders-page__table'>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                    <TableRow>
                        <TableCell>№ заказа</TableCell>
                        <TableCell align="right">Продукт</TableCell>
                        <TableCell align="right">Цена</TableCell>
                        <TableCell align="right">Статус заказа</TableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                    {
                        orders.map((order) => (
                            <TableRow
                                key={order.id}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                hover
                            >
                                <TableCell component="th" scope="row">
                                    {order.number}
                                </TableCell>
                                <TableCell align="right">{order.product.name}</TableCell>
                                <TableCell align="right">{order.product.price}</TableCell>
                                <TableCell align="right" onClick={() => updateStatuHandler(order.id)}>{order.orderStatusName}</TableCell>
                            </TableRow>
                        ))
                    }
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    </div>
}

export default OrdersPage;