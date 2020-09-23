
import { combineReducers } from 'redux';
import personasReducer from '../reducers/personas/';

const rootReducer = combineReducers({
    personasStore : personasReducer
});

export default rootReducer;
