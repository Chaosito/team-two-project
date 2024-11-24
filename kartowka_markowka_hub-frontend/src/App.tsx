import React from 'react';
import './App.css';
import Menu from './Components/Menu';
import Serarch from './Components/Search';
import Footer from './Components/Footer';

function App() {
  return (
    <div>
      <Menu/>
      <Serarch/>
      <h1>App</h1>
      <Footer/>
    </div>
  );
}

export default App;
