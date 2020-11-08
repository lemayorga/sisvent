import axios from 'axios';

/**
 * Config global for axios/django
 */
const axios_ = axios.create({
    baseURL: 'https://localhost:5001/api' ,//'http://localhost:5000/api', //'http://localhost:8080/api',
    responseType: 'json',
    headers: authHeader()
});

export default axios_;

const Get = ({url, parameters = {} , callbackSucess = null, callbackError = null }) => {   
    return axios_.get(url, parameters)
        .then(response => {  if (typeof callbackSucess === 'function') { callbackSucess(response); }  })
        .catch((error) => { if (typeof callbackError === 'function') { callbackError(error); } else { throw(error); }  });
}

const Post = ({url, parameters = {} , callbackSucess = null,callbackError = null }) => {    
    return axios_.post(url, parameters)
        .then(response => {  if (typeof callbackSucess === 'function') { callbackSucess(response); }  })
        .catch((error) => {  if (typeof callbackError === 'function') { callbackError(error); }  else { throw(error); }  });
}   

const Delete = ({url, parameters = {} , callbackSucess = null,callbackError = null }) => {    
    return axios_.delete(url, parameters)
        .then(response => {  if (typeof callbackSucess === 'function') { callbackSucess(response); }  })
        .catch((error) => {  if (typeof callbackError === 'function') { callbackError(error); } else { throw(error); } });
}

const Put = ({url, parameters = {} , callbackSucess = null,callbackError  = null}) => {    
    return axios_.put(url, parameters)
        .then(response => {   if (typeof callbackSucess === 'function') { callbackSucess(response); } })
        .catch((error) => {  if (typeof callbackError === 'function') { callbackError(error); } else { throw(error); } });
}

const get = (url, parameters = {}) => {   
    return axios_.get(url, parameters)
}

const post = (url, parameters = {}) => {    
    return axios_.post(url, parameters)
}   


function authHeader() {
    const user = JSON.parse(localStorage.getItem('user'));
  
    if (user && user.token){
        return {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + user.token 
        }
    }
    else {
        return {
            "Content-Type": "application/json"
        } 
    }
  }
    
export  {
    Get,
    Post,
    Delete,
    Put,
    post,
    get
};