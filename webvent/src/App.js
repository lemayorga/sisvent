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
import { BrowserRouter } from 'react-router-dom';
import AppRouter from './routers/AppRouter';
import { Provider } from 'react-redux';
import store from './redux/stores/configStores';

function App() {
   return (
		<Provider store={store} > 
			<BrowserRouter>
				<AppRouter />
			</BrowserRouter>   
		</Provider>
	);
}

export default App;

