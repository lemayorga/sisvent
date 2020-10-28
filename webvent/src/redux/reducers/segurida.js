import * as type from '../actions/seguridaAction';

const estadoInicial = { 
 autenticacion:{}
}

export default function seguridadReducer(state = estadoInicial,action){
    switch (action.type) {
        case type.LOGEAR:
                return {
                    ...state,
                    autenticacion: action.data
                }
            break;    
        default:
            return state;
    }
}
