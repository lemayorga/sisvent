import 'bootstrap/dist/css/bootstrap.min.css';
import "../assets/css/atlantis.min.css";
import '../assets/css/demo.css';
import '../assets/css/customer.css';

import 'bootstrap';
import '../assets/css/fonts.css';
import '../assets/js/atlantis.js';
import '../assets/js/setting_demo.js';
import 'antd/dist/antd.css';

import React from 'react';	
import Footer from '../layouts/Footer';
import Header from '../layouts/Header';
import SideBar from '../layouts/SideBar';
import CustomTheme from '../layouts/CustomTheme';	
import AppRouter from '../routers/AppRouter';


function Layout(){
	return(
	<div className="wrapper">
		<Header />
		<SideBar />
		<div className="main-panel">
			<div className="content">
				<div className="page-inner">
					{/* <div className="page-header"></div> */}
					<AppRouter />
				</div>		
			</div>
			<Footer />
		</div>
		<CustomTheme />
	</div>
	)
}

export default Layout;