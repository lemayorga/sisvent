import * as type from '../actions/seguridadAction';

const estadoInicial = { 
 autenticacion:{}
}

export default function seguridadReducer(state = estadoInicial,action){
    switch (action.type) {
        case type.LOGEAR_EXITOSO:
                return {
                    ...state,
                    autenticacion: action
                }
            break;    
        default:
            return state;
    }
}
