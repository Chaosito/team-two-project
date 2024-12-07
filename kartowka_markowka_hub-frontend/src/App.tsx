import React from 'react';
import './App.css';
import Menu from './Components/Menu';
import Serarch from './Components/Search';
import Footer from './Components/Footer';
import Login from './Components/AuthPage/Login';
import MainPage from './Components/MainPage/MainPage';
import ProductsPage from './Components/ProductsPage/ProductsPage';
import BasketPage from './Components/BasketPage/BasketPage';
import { BrowserRouter, Routes, Route } from 'react-router';
import ProductAddPage from './Components/ProductsPage/ProductAddPage';

function App() {  
  const savedUserLogin = localStorage.getItem("userLogin") ?? '';
  let [userName, setUserName] = React.useState(savedUserLogin);

  return (
    <div className='app'>
      <BrowserRouter>
      <div>
        <Menu setUserName={setUserName} userName={userName}/>
        <Serarch/>
      </div>      
        <Routes>
          <Route path='/' element={<MainPage/>} />
          <Route path='/login' element={<Login setUserName={setUserName} userName={userName}/>} />
          <Route path='/products' element={<ProductsPage/>} />
          <Route path='/product-add' element={<ProductAddPage/>} />   
          <Route path='/basket' element={<BasketPage/>} />          
        </Routes>
      <Footer/>
      </BrowserRouter>  
    </div>
  );
}

export default App;