
import { configureStore, createSlice, PayloadAction } from '@reduxjs/toolkit';


type ProductsState = {
    products: string[]
}

const initialStateProducts: ProductsState = {
    products: []
}

const productSlice = createSlice({
    name: 'productSlice',
    initialState: initialStateProducts,
    reducers: {
        add: (state, action: PayloadAction<string>) => {
            state.products.push(action.payload); 
            return state;
        },
        clear: (state) => {
            state.products = []; 
            return state;
        },
    }
})

const Store = configureStore({
    reducer: {
        products: productSlice.reducer
    }
});

type AppDispatch = typeof Store.dispatch;

export { Store, type AppDispatch, productSlice }