import axios from 'axios';

/**
 * Config global for axios/django
 */
const axios_ = axios.create({
    baseURL:  'http://localhost:5000/api', //'http://localhost:8080/api',
    responseType: 'json',
    headers: {
        "Content-Type": "application/json"
    }
});

export default axios_;

const Get = ({url, parameters = {} , callbackSucess, callbackError }) => {   
    return axios_.get(url, parameters)
        .then(response => {  if (typeof callbackSucess === 'function') { callbackSucess(response); }  })
        .catch((error) => { if (typeof callbackError === 'function') { callbackError(error); } else { throw(error); }  });
}

const Post = ({url, parameters = {} , callbackSucess,callbackError }) => {    
    return axios_.post(url, parameters)
        .then(response => {  if (typeof callbackSucess === 'function') { callbackSucess(response); } })
        .catch((error) => {  if (typeof callbackError === 'function') { callbackError(error); } else { throw(error); } });
}    

const Delete = ({url, parameters = {} , callbackSucess,callbackError }) => {    
    return axios_.delete(url, parameters)
        .then(response => {  if (typeof callbackSucess === 'function') { callbackSucess(response); }  })
        .catch((error) => {  if (typeof callbackError === 'function') { callbackError(error); } else { throw(error); } });
}

const Put = ({url, parameters = {} , callbackSucess,callbackError }) => {    
    return axios_.put(url, parameters)
        .then(response => {   if (typeof callbackSucess === 'function') { callbackSucess(response); } })
        .catch((error) => {  if (typeof callbackError === 'function') { callbackError(error); } else { throw(error); } });
}

export  {
    Get,
    Post,
    Delete,
    Put
};