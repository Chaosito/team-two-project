import React from 'react';
import './App.css';
import Menu from './Components/Menu';
import Serarch from './Components/Search';
import Footer from './Components/Footer';
import Login from './Components/Login';
import MainPage from './Components/MainPage/MainPage';

function App() {
  return (
    <div>
      <Menu/>
      <Serarch/>
      <MainPage/>
      <Footer/>
    </div>
  );
}

export default App;
