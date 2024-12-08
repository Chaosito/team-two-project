import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import Product from './IProduct';

type ProductsState = {
    products: Product[]
}

const initialStateProducts: ProductsState = {
    products: []
}

const productForOrderSlice = createSlice({
    name: 'productForOrderSlice',
    initialState: initialStateProducts,
    reducers: {
        add: (state, action: PayloadAction<Product>) => {
            state.products.push(action.payload); 
            return state;
        },
        clear: (state) => {
            state.products = []; 
            return state;
        },
        set: (state, action: PayloadAction<Product[]>) => {
            state.products = action.payload;
            return state;
        },
    }
})

export { productForOrderSlice, type Product }