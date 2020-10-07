import React from "react";
import { Router, Route, Switch  } from 'react-router-dom';
import history from '../history';
import routes from './routes';
import PrivateRoute from './PrivateRoute';
import PublicRoute from './PublicRoute';
import LayoutMain from '../layouts/LayoutMain';
import LayoutSegurity from '../layouts/LayoutSegurity';

import HomePage from '../pages/HomePage';
import PersonasPage from '../pages/PersonasPage';
import Login from '../pages/authentication/Login';
import Dashboard from '../pages/Dashboard';
import PageNotFoundPage from '../pages/status/PageNotFoundPage';

 const AppRouter = () =>( 
    <Router history={ history }>
        <Switch>
          <PublicRoute restricted={true} component={Login} path={routes.login} exact />
  
          <Route path='/admin/:path?' exact>
            <LayoutSegurity>
              <Switch>
              </Switch>
            </LayoutSegurity>
          </Route>
  
          <Route>
            <LayoutMain>
              <Switch>
                {/* <PublicRoute restricted={false} component={HomePage} path={routes.home} exact /> */}
                <PrivateRoute component={HomePage} path={routes.home} exact />
                <PrivateRoute component={Dashboard} path={routes.dashboard}  /> 
                <PrivateRoute component={PersonasPage} path={routes.personas} /> 
              </Switch>
            </LayoutMain>
          </Route>
          
          <Route  path='/pages/:path?'>
            <LayoutSegurity>
              <Switch>
                <Route path='*' component={PageNotFoundPage }/>
              </Switch>
            </LayoutSegurity>
          </Route>

        </Switch>
    </Router>   
)

export default AppRouter;
