// import React from 'react';



// const Toggle = () => {

//     const toggle_customSidebar = false;
//     const custom_open = 0;


//     const toggleClick = e =>{
//         var toggle_customSidebar = false,
//         custom_open = 0;
        
//         if(!toggle_customSidebar) {
//             var toggle = $('.custom-template .custom-toggle');
        
//             console.log('click en toggle');
                
//             if (custom_open == 1){
//                 $('.custom-template').removeClass('open');
//                 toggle.removeClass('toggled');
//                 custom_open = 0;
//             }  else {
//                 $('.custom-template').addClass('open');
//                 toggle.addClass('toggled');
//                 custom_open = 1;
//             }
//     }


//     return(


//     <>
//         <button className="navbar-toggler sidenav-toggler ml-auto" type="button" data-toggle="collapse" data-target="collapse" aria-expanded="false" aria-label="Toggle navigation">
//             <span className="navbar-toggler-icon">
//                 <i className="icon-menu"></i>
//             </span>
//         </button>
//         <button className="topbar-toggler more">
//             <i className="icon-options-vertical"></i>
//         </button>
//         <div className="nav-toggle">
//             <button className="btn btn-toggle toggle-sidebar">
//                 <i className="icon-menu"></i>
//             </button>
//         </div>    
//     </>
//     )
// }

// export default Toggle;