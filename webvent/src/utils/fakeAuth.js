const fakeAuth = {
    isAuthenticated: false,
    authenticate(data,function_callback) {
      fakeAuth.isAuthenticated = true;
      localStorage.setItem("user", JSON.stringify(data));

      if (typeof function_callback === 'function') 
        setTimeout(function_callback, 100); 
    },
    signout(function_callback) {
      fakeAuth.isAuthenticated = false;
      
      if(localStorage.getItem("user"))
         localStorage.removeItem("user");

      if (typeof function_callback === 'function') 
        setTimeout(function_callback, 100); 
    },
    getToken(){ return localStorage.getItem("user") || null }
  };
  

  export default fakeAuth;