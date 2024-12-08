import { configureStore } from '@reduxjs/toolkit';
import { productForOrderSlice } from './ProductForOrderSlice';
import { productsSlice } from './ProductSlice';

const Store = configureStore({
    reducer: {
        productForOrder: productForOrderSlice.reducer,
        products: productsSlice.reducer
    }
});

type AppDispatch = typeof Store.dispatch;

export { Store, type AppDispatch }