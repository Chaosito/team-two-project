import './../Styles/Footer.css';

function Footer() {
    return <div className="footer">
        <div className='footer__ref'>
            <a href='./'>О проекте</a>
            <a href='./'>Исходный код</a>
            <a href='./'>Социальные сети</a>            
        </div>
        <div className='footer__info'>
            <span>Учебный проект Otus 2024</span>
            <span>Dream2Team</span>
        </div>
    </div>
}

export default Footer;