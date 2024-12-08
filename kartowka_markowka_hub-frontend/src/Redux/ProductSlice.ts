import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import Product from './IProduct';

interface ProductData extends Product {
    image: string;
}

type ProductsState = {
    products: ProductData[];
    filter: string;
}

const initialStateProducts: ProductsState = {
    products: [],
    filter: '',
}

const productsSlice = createSlice({
    name: 'productsSlice',
    initialState: initialStateProducts,
    reducers: {
        clear: (state) => {
            state.products = []; 
            return state;
        },
        set: (state, action: PayloadAction<ProductData[]>) => {
            state.products = action.payload;
            return state;
        },
        setFilter: (state, action: PayloadAction<string>) => {
            state.filter = action.payload;
            return state;
        },
    }
})

export { productsSlice, type ProductData }