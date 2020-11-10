import { createStore, applyMiddleware, compose} from 'redux';
import thunk from 'redux-thunk';
import promise from "redux-promise";
import logger from 'redux-logger';
import rootReducer from '../reducers/';

const composeSetup = process.env.NODE_ENV !== 'production' && typeof window === 'object' &&
    window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ ?
    window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ : compose


const store = createStore(
      rootReducer,
      //  compose(
      //        applyMiddleware(thunk,logger),
      //      /// applyMiddleware(thunk,promise),
      //       window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__() 
      // )
      composeSetup(applyMiddleware(thunk,promise))
);


export default store;