import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import fakeAuth   from '../utils/fakeAuth';
import Login from '../pages/authentication/Login';
import routes from './routes';

const PrivateRoute = ({component: Component, ...rest}) => {
    return (
        <Route {...rest} 
            render={props => (
                fakeAuth.isAuthenticated 
                ? <Component {...props} />
                : <Redirect to={routes.login} />
            )} 
       />
    );
};

export default PrivateRoute;