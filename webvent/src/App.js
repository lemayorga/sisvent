import 'bootstrap/dist/css/bootstrap.min.css';
import "./assets/css/atlantis.min.css";
import './assets/css/demo.css';
import './assets/css/customer.css';

import 'bootstrap';
import './assets/css/fonts.css';
import './assets/js/atlantis.js';
import './assets/js/setting_demo.js';
import 'antd/dist/antd.css';

import React from 'react';	
import Footer from './layouts/Footer';
import Header from './layouts/Header';
import SideBar from './layouts/SideBar';
import CustomTheme from './layouts/CustomTheme';	

import { BrowserRouter } from 'react-router-dom';
import AppRouter from './routers/AppRouter';
import { Provider } from 'react-redux';
import store from './redux/stores/configStores';


import Login from './pages/authentication/Login';

function App() {
    return (
		<Provider store={store} > 
			<BrowserRouter>
				{/* <Layout /> */}
				<Login />
			</BrowserRouter>   
		</Provider>
	);
}

export default App;


const Layout = ()  => (
		<div className="wrapper">
			<Header />
			<SideBar />
			<div className="main-panel">
				<div className="content">
					<div className="page-inner">
						<AppRouter />
					</div>		
				</div>
				<Footer />
			</div>
			<CustomTheme />
		</div>
	)