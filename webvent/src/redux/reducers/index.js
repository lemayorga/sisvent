
import { combineReducers } from 'redux';
import personasReducer from './personas';
import seguridadReducer from './segurida';

const rootReducer = combineReducers({
     personasReducer,
     seguridadReducer
});

export default rootReducer;
