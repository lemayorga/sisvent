import  * as type from '../../actions/seguridadAction'

const initialState = {
    usuario:{}
}

export default function seguridadReducer(state= initialState, action){
    switch(action.type){
        case type.LOGGIN_USER:   
        return { 
            ...state, 
            usuario: action.usuario 
        }     
        default: 
            return state;
    }

    return state;
};