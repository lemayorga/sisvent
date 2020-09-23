import axios from 'axios';

/**
 * Config global for axios/django
 */
const axios_ = axios.create({
    baseURL: 'http://localhost:8080/api',
    responseType: 'json',
    headers: {
        "Content-Type": "application/json"
    }
});

export default axios_;

const Get = ({url, parameters = {} , callbackSucess, callbackError }) => {   
    return axios_.get(url, parameters)
        .then(response => { callbackSucess(response) })
        .catch((error) => { callbackError(error) });
}

const Post = ({url, parameters = {} , callbackSucess,callbackError }) => {    
    return axios_.post(url, parameters)
        .then(response => { callbackSucess(response) })
        .catch((error) => { callbackError(error) });
}    

const Delete = ({url, parameters = {} , callbackSucess,callbackError }) => {    
    return axios_.delete(url, parameters)
        .then(response => { callbackSucess(response) })
        .catch((error) => { callbackError(error) });
}

const Put = ({url, parameters = {} , callbackSucess,callbackError }) => {    
    return axios_.put(url, parameters)
        .then(response => { callbackSucess(response) })
        .catch((error) => { callbackError(error) });
}

export  {
    Get,
    Post,
    Delete,
    Put
};