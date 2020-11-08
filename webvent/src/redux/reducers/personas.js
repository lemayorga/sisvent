import  * as type from '../actions/personasAction'

const initialState = {
    personas:[],
    persona:{}
}

export default function personasReducer(state= initialState, action){
    switch(action.type){
        case type.LISTAR_PERSONAS:   
            return {  
                ...state, 
                personas: action.personas,
                persona: {
                    personaId: 0,
                    nombres: '',
                    apellidos: '',
                    sexo: '',
                    tipoPersona: 'N'
                }
            }
       case type.NUEVA_PERSONA:
           return {
               ...state,
               persona: {
                    nombres: '',
                    apellidos: '',
                    sexo: '',
                    tipoPersona: 'N'
                }
           }
        case type.AGREGAR_PERSONA:
            return {
                    ...state,
                    personas: [action.persona, ...state.personas]
            }
        
        case type.OBTENER_PERSONA:   
            return { 
                 ...state, 
                 persona: action.persona 
            }     
     
        case type.ACTUALIZAR_PERSONA:   
            return {  
                ...state, 
                personas: state.personas.map((elemento) => 
                    elemento.personaId == action.persona.personaId
                    ? (elemento = action.persona)
                    : elemento
                )  
            }

        case type.ELIMINAR_PERSONA:
            return { 
                 ...state, 
                 personas: state.personas.filter(pers => pers.personaId != action.persona)
            } 

        default: 
            return state;
    }

    return state;
};