import React from 'react';
import './App.css';
import Menu from './Components/Menu';
import Serarch from './Components/Search';
import Footer from './Components/Footer';
//import Login from './Components/AuthPage/Login';
//import MainPage from './Components/MainPage/MainPage';
import ProductsPage from './Components/ProductsPage/ProductsPage';

function App() {
  return (
    <div className='app'>
      <div>
        <Menu/>
        <Serarch/>
      </div>
      <ProductsPage/>
      <Footer/>
    </div>
  );
}

export default App;
