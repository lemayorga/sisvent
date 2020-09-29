    
import React from "react";
import {  Router, Route, Switch  } from 'react-router-dom';
import history from '../history';
import routes from './routes';
import HomePage from '../pages/HomePage';
import PersonasPage from '../pages/PersonasPage';
import Login from '../pages/authentication/Login';
import PageNotFoundPage from '../pages/status/PageNotFoundPage';

 const AppRouter = () =>( 
    // <Router history={ history }>
        <Switch>
            <Route exact path={routes.home} component={HomePage} />
            <Route  path={routes.personas} component={PersonasPage} />
            <Route  path={routes.login} component={Login} />
            <Route path="*" component={PageNotFoundPage} />
          </Switch>
    //  </Router>    
)

export default AppRouter;