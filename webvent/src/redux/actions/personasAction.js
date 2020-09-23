import {  Get, Post, Delete, Put } from '../config';
// import history from '../../../history';
// import routes from '../../../routers/routes';


/****************************************************************
 *  CONSTANTES 
 ***************************************************************/
export const LISTAR_PERSONAS = 'LISTAR_PERSONAS';
export const OBTENER_PERSONA = 'OBTENER_PERSONA';
export const NUEVA_PERSONA = 'NUEVA_PERSONA';
export const AGREGAR_PERSONA = 'AGREGAR_PERSONA';
export const ACTUALIZAR_PERSONA = 'ACTUALIZAR_PERSONA';
export const ELIMINAR_PERSONA = 'ELIMINAR_PERSONA';

/****************************************************************
 *  DISPATCHES
 ***************************************************************/

export function dispathAllPersonas(response){ return { type: LISTAR_PERSONAS, personas : response.data }; }
export function dispathAddPersonas(response){ return { type: AGREGAR_PERSONA, persona : response.data };  }
export function dispathGetPersona(response){ return { type: OBTENER_PERSONA, persona : response.data };  }
export function dispathUpdatePersona(response){ return { type: ACTUALIZAR_PERSONA, persona : response.data };  }
export function dispathDeletePersona(response){ return { type: ELIMINAR_PERSONA, persona : response.data };  }
export function dispathNewPersona(){ return { type: NUEVA_PERSONA };  }

/****************************************************************
 *  ACCIONES
 ***************************************************************/

/**
 * GET
 * action de mostrar todos las personas
 * esta action solo sirve todos los datos
 */
export const getAllPersonas = () => {
    return dispatch => {
        return  Get({
                url: '/persona/',
                parameters:{},
                callbackSucess: function(response){ 
                        dispatch(dispathAllPersonas(response));  
                },
                callbackError: function(error){
                        throw(error); 
                }
        });
     }
}
    
/**
  * DELETE
  * action para borrar un registro de persona
  * @param {*} id esta action recibe como parametro un id de la persona a borrar 
  * @param {*} callbackSucess 
  * @param {*} callbackError 
*/
export const deletePersona = (id, callbackSucess, callbackError) => {
        return dispatch => {
             return  Delete({ url: `/persona/${id}`,
                     parameters: {},
                     callbackSucess: function(response){  
                             dispatch(dispathDeletePersona(response));
                             if (typeof callbackSucess === 'function') callbackSucess(response); 
                     },
                     callbackError: function(error){
                             if (typeof callbackError === 'function') callbackSucess(error); 
                             throw(error); 
                     }
             });
        }
};  

/**
 * POST
 * action para agregar persona
 * @param {*} datos 
 * @param {*} callbackSucess 
 * @param {*} callbackError 
 */ 
export const addPersona = (datos, callbackSucess, callbackError) => {
   return dispatch => {
        return  Post({
                url: '/persona/',
                parameters: datos,
                callbackSucess: function(response){  
                        dispatch(dispathAddPersonas(response));
                        if (typeof callbackSucess === 'function') callbackSucess(response); 
                },
                callbackError: function(error){
                        if (typeof callbackError === 'function') callbackSucess(error); 
                        throw(error); 
                }
        });
     }
  };
    
/**
 * GET
 * action para mostrar un solo dato
 * @param {*} id esta action recibe como parametro un id del get a mostrar
 * @param {*} callbackSucess 
 * @param {*} callbackError 
 */ 
export const getPersona = (id, callbackSucess, callbackError) => {
        return dispatch => {
             return  Get({ 
                     url: `/persona/${id}`,
                     parameters: {},
                     callbackSucess: function(response){  
                             dispatch(dispathGetPersona(response));
                             if (typeof callbackSucess === 'function') callbackSucess(response); 
                     },
                     callbackError: function(error){
                             if (typeof callbackError === 'function') callbackSucess(error); 
                             throw(error); 
                     }
             });
        }
};
     
/**
 * PUT
 * action para actualizar una persona
 * @param {*} datos esta action recibe el objeto con todos los datos
 * @param {*} callbackSucess 
 * @param {*} callbackError 
 */
export const updatePersona = (datos, callbackSucess, callbackError) => {
        return dispatch => {
             return  Put({url: `/persona/`,
                     parameters: datos,
                     callbackSucess: function(response){  
                             dispatch(dispathUpdatePersona(response));
                             if (typeof callbackSucess === 'function') callbackSucess(response); 
                     },
                     callbackError: function(error){
                             if (typeof callbackError === 'function') callbackSucess(error); 
                             throw(error); 
                     }
             });
        }
};