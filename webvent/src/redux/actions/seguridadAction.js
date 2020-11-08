import {  post } from '../config';


/****************************************************************
 *  CONSTANTES 
 ***************************************************************/
export const LOGEAR_EXITOSO = 'LOGEAR_EXITOSO';
export const LOGEAR_FALLIDO = 'LOGEAR_FALLIDO';

export function LogeoExitos(response){ return { type: LOGEAR_EXITOSO, data : response.data }; }
export function LogeoFallido(){ return { type: LOGEAR_FALLIDO }; }

/****************************************************************
 *  ACCIONES
 ***************************************************************/

export const Logear = (datos)  => {
        return post('/Login/',datos)
};
         
    

