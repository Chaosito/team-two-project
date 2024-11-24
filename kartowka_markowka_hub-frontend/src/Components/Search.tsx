import './../Styles/Search.css';
import { TextField, Button } from '@mui/material';


function Serarch() {
    return <div className='search'>
        <div className='search__input-cover'>
            <TextField className='search__input' variant='outlined'/>
            <Button variant='contained'>Найти</Button>
        </div>       
        
        <span className='search__city'>Усть-Каменогорск</span>
    </div>
}

export default Serarch;