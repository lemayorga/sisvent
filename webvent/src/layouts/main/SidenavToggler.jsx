import React , { useState, useEffect } from 'react';

function SidenavToggler(){


    const [toggle_sidebar,setToggle_sidebar] = useState(false);
    const [toggle_quick_sidebar,setToggle_quick_sidebar] = useState(false);
    const [toggle_topbar,setToggle_topbar] = useState(false);
    const [minimize_sidebar,setMinimize_sidebar] = useState(false);
    const [toggle_page_sidebar, setToggle_page_sidebar] = useState(false);
    const [toggle_overlay_sidebar,setToggle_overlay_sidebar] = useState(false);
    const [nav_open, setNav_open] = useState(0);
    const [quick_sidebar_open, setQuick_sidebar_open] = useState(0);
    const [topbar_open,setTopbar_open] = useState(0); 
    const [mini_sidebar,setMini_sidebar] = useState(0); 
    const [page_sidebar_open,setPage_sidebar_open] = useState(0); 
    const [overlay_sidebar_open,setOverlay_sidebar_open] = useState(0); 

    useEffect(() => {
        console.log('useEffect')
        // OnLoad();
    },[]);



    function OnLoad(){

        if(!toggle_sidebar) { 
            // const sidenav_toggle = document.getElementsByClassName("sidenav-toggler")[0]; 
            setToggle_sidebar(true);
            OnClickSidenavToggler
        }

        // if(!quick_sidebar_open) {
    
        //     const wrapper = document.getElementsByClassName("wrapper")[0]; 
        //     wrapper.addEventListener('mouseup', function(e){
                
        //          const quick_sidebar = document.getElementsByClassName("quick-sidebar")[0]; 

        //          if(e.target.className != quick_sidebar.getAttribute('class') && !document.querySelectorAll('.quick-sidebar > .page-inner').length)
        //          {
        //             const html = document.getElementsByTagName("html")[0];
        //             const quick_sidebar_toggler = document.getElementsByClassName("quick-sidebar-toggler")[0];
        //             const quick_sidebar_overlay = document.getElementsByClassName("quick-sidebar-overlay")[0];

        //             html.classList.remove('quick_sidebar_open');
        //             quick_sidebar_toggler.classList.remove('toggled');
        //             quick_sidebar_overlay.parentNode.removeChild(quick_sidebar_overlay);
        //             setQuick_sidebar_open(0);
        //          }
        //     });

        //     setQuick_sidebar_open(true);
        // }
    

        if (!minimize_sidebar) {
            const minibutton = document.getElementsByClassName("toggle-sidebar")[0]; 
            const wrapper = document.getElementsByClassName("wrapper")[0];
            if(wrapper.classList.contains('sidebar_minimize')){
                setMini_sidebar(1);
                minibutton.classList.add('toggled');
                minibutton.innerHTML = '<i class="icon-options-vertical"></i>';
            }
           //OnClickToggleSidebar
           setMinimize_sidebar(true);
        }


        console.log('OnInit')
    }


    function OnClickSidenavToggler(){
        if (nav_open == 1){
            const html = document.getElementsByTagName("html")[0];
            const sidenav_toggler = document.getElementsByClassName("sidenav-toggler")[0];

            html.classList.remove('nav_open');
            sidenav_toggler.classList.remove('toggled');
            setNav_open(0);

        }  else {
            const html = document.getElementsByTagName("html")[0];
            const sidenav_toggler = document.getElementsByClassName("sidenav-toggler")[0];

            if(html != undefined && sidenav_toggler != undefined){
                html.classList.add('nav_open');
                sidenav_toggler.classList.add('toggled');
                setNav_open(1);
            }
        }
    }


    function OnClickToggleSidebar(){
        if (mini_sidebar == 1) {
            const wrapper = document.getElementsByClassName("wrapper")[0];
            const minibutton = document.getElementsByClassName("toggle-sidebar")[0]; 

            wrapper.classList.remove('sidebar_minimize');
            minibutton.classList.remove('toggled');
            minibutton.innerHTML = '<i class="icon-menu"></i>';
            setMini_sidebar(0);

        } else {

            const wrapper = document.getElementsByClassName("wrapper")[0];
            const minibutton = document.getElementsByClassName("toggle-sidebar")[0]; 

            if(wrapper != undefined && minibutton != undefined){
                wrapper.classList.add('sidebar_minimize');
                minibutton.classList.add('toggled');
                minibutton.innerHTML = '<i class="icon-options-vertical"></i>';
                setMini_sidebar(1);
            }
        }
        window.addEventListener("resize", function(){  
            console.log('resize');
        });
    }

    return(
    <div className="logo-header" data-background-color="blue">
        <a href="index.html" className="logo">
            <img src="./assets/img/logo.svg" alt="navbar brand" className="navbar-brand" />		
        </a>
        <button className="navbar-toggler sidenav-toggler ml-auto" type="button"      
            data-target="collapse" aria-expanded="false" aria-label="Toggle navigation" onClick={OnClickSidenavToggler}>
            <span className="navbar-toggler-icon">
                <i className="icon-menu"></i>
            </span>
        </button>
        <button className="topbar-toggler more">
            <i className="icon-options-vertical"></i>
        </button>
        <div className="nav-toggle">
            <button className="btn btn-toggle toggle-sidebar" onClick={OnClickToggleSidebar}>
                <i className="icon-menu"></i>
            </button>
        </div>
    </div>
    ); 
}

export default SidenavToggler;