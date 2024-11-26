import React from 'react';
import './App.css';
import Menu from './Components/Menu';
import Serarch from './Components/Search';
import Footer from './Components/Footer';
import Login from './Components/AuthPage/Login';
import MainPage from './Components/MainPage/MainPage';
import ProductsPage from './Components/ProductsPage/ProductsPage';
import { BrowserRouter, Routes, Route } from 'react-router';

function App() {  
  return (
    <div className='app'>
      <div>
        <Menu/>
        <Serarch/>
      </div>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<MainPage/>} />
          <Route path='/login' element={<Login/>} />
          <Route path='/products' element={<ProductsPage/>} />
        </Routes>
      </BrowserRouter>      
      <Footer/>
    </div>
  );
}

export default App;