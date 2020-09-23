    
import React from "react";
import {  Router, Route, Switch  } from 'react-router-dom';
import history from '../history';
import routes from './routes';
import HomePage from '../pages/HomePage';
import PersonasPage from '../pages/PersonasPage';

 const AppRouter = () =>( 
    // <Router history={ history }>
        <Switch>
            <Route exact path={routes.home} component={HomePage} />
            <Route  path={routes.personas} component={PersonasPage} />
          </Switch>
    //  </Router>    
)

export default AppRouter;