
import logger from 'redux-logger';
import { createStore, applyMiddleware, compose} from 'redux';
import thunk from 'redux-thunk';
import rootReducer from '../reducers/';

const store = createStore(
      rootReducer,
      applyMiddleware(thunk,logger),
      window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__() 
);


export default store;