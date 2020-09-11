import 'bootstrap/dist/css/bootstrap.min.css';
import "./assets/css/atlantis.min.css";
import './assets/css/demo.css';
import './assets/css/customer.css';

import 'bootstrap';
// import '@fortawesome/fontawesome-free/js/all.js';
import './assets/css/fonts.css';
import './assets/js/atlantis.js';
import './assets/js/setting_demo.js';

import React from 'react';
import Footer from './layouts/Footer';
import Header from './layouts/Header';
import SideBar from './layouts/SideBar';
import CustomTheme from './layouts/CustomTheme';	

function App1() {
    return (
    <div className="wrapper">
		<Header />
		<SideBar />
		<div className="main-panel">
			<div className="content">
			</div>
			<Footer />
		</div>
    
        <CustomTheme />
	</div>
    );
}

export default App1;