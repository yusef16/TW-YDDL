const btndarkmode = document.getElementById("btndarkmode");
//const btn = document.querySelector(".btndarkmode");


const btn = document.getElementById("btndarkmode");

const nav = document.getElementById("navigation1")


const body = document.getElementById("darklight");
let darkMode = localStorage.getItem("dark-mode");




function enable_dark_mode() {

        body.classList.remove('section');
    body.classList.add('section_d');

    nav.classList.remove("navigation");
    nav.classList.add("navigation_dark");


    btn.textContent = "LightMode"

    localStorage.setItem("dark-mode", "dark");

}


function disable_dark_mode() {
        body.classList.remove('section_d');
    body.classList.add('section');

    nav.classList.remove("navigation_dark");
    nav.classList.add("navigation");

    btn.textContent = "DarkMode"

    localStorage.setItem("dark-mode","light");


}

if (darkMode == 'dark') {
    enable_dark_mode();
}

btn.addEventListener('click', (e) => {
    darkMode = localStorage.getItem("dark-mode");

    if (darkMode === 'dark') {
        disable_dark_mode();
    }
    else {
        enable_dark_mode();
    }


})
    
   
        
        





