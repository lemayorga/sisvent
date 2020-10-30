import {  Post } from '../config';


/****************************************************************
 *  CONSTANTES 
 ***************************************************************/
export const LOGEAR = 'LOGEAR';

export function dispathLogear(response){ return { type: LOGEAR, data : response.data }; }

/****************************************************************
 *  ACCIONES
 ***************************************************************/
export const Logear = (data, callbackSucess,callbackError) => {
    return dispatch => {
       return Post(
        {   
            url: '/Login', 
            parameters: data,
            callbackSucess: callbackSucess, 
            callbackError : callbackError 
        })
    } 
}