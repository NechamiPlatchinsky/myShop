﻿const visibleRegister = () => {
    const ragisterDiv = document.querySelector(".unVisible")
    ragisterDiv.classList.remove("unVisible")
} 
const visibleElement = () => {
    const ragisterDiv = document.querySelector(".unVisible")
    ragisterDiv.classList.remove("unVisible")
}
const getDitails = () => {
    const user = {
        Email: document.querySelector(".email").value,
        Password: document.querySelector(".password").value,
        FirstName: document.querySelector(".firstName").value,
        LastName: document.querySelector(".lastName").value
    }
    
    return user
}
const getDitailsToLogin = () => {
    const user = {
        Email: document.querySelector(".emailLogin").value,
        Password: document.querySelector(".passwordLogin").value
    }
    return user
}
const getPassword = () => {
    return document.querySelector(".password").value 
}
const registerUser = async () => {
    const newUser = getDitails()
    if (!newUser.Email || !newUser.Password || !newUser.FirstName || !newUser.LastName ) {
        return alert("כל השדות חובה");
    }
    if ( newUser.LastName.length > 20 || newUser.LastName.length < 2) {
        return alert("שם המשפחה חייב לכלול לפחות 2 אותיות");
    }
    
    try {
        const responsePost = await fetch("https://localhost:7032/api/users", {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newUser)
        })
        if (responsePost.ok) {
            const dataPost = await responsePost.json();
            console.log('POST Data:', dataPost);
            alert(`hello ${dataPost.firstName}`);
        } else {
            if (responsePost.status == 409 || responsePost.status == 422) {
                const errorText = await responsePost.text();
                alert(errorText)
            }
            else  {
                const errorResponse = await responsePost.json();
                for (const key in errorResponse.errors) {
                    if (errorResponse.errors.hasOwnProperty(key)) {
                        const errors = errorResponse.errors[key];
                        errors.forEach(error => {
                            alert(error);
                        });
                    }
                }
            } 
        }
    }
    catch (error) {
        console.log(error)
        alert(error);
    }
    
}
const login = async () => {
    const user = getDitailsToLogin()
    if (!user.Email || !user.Password ) {
        return alert("כל השדות חובה");
    }
    try {
        const responsePost = await fetch(`api/users/login/?Email=${user.Email}&Password=${user.Password}`, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            query: { Email: user.Email, Password: user.Password }
        })
        if (responsePost.status == 404) {
            const message = await responsePost.text();
            alert(message)
        }
        const dataPost = await responsePost.json();
        sessionStorage.setItem('user', dataPost.userId)
        sessionStorage.setItem('nameUser', dataPost.firstName)
        sessionStorage.setItem("fullUser", JSON.stringify(dataPost))
        const cart = JSON.parse(sessionStorage.getItem("cart"))||[];
         if (cart.length == 0) {
            window.location.href = "Products.html";
            return;
        }
        window.location.href = "ShoppingBag.html"
    }
    catch (error) {
        console.log(error)
    }

}
const getDitailsToUpdate = () => {
    const u = JSON.parse(sessionStorage.getItem('fullUser')); 
    const user = {
        Email: document.querySelector(".email").value || u.Email,
        Password: document.querySelector(".password").value,
        FirstName: document.querySelector(".firstName").value||u.firstName,
        LastName: document.querySelector(".lastName").value||u.lastName
    }

    return user
}
const updateDitailse = async() => {
    const user = getDitailsToUpdate();
    try {
        const responsePut = await fetch(`api/users/${sessionStorage.getItem("user")}`, {
            method: 'PUT',
            headers: { 
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        
        if (responsePut.ok) {
            alert(`הפרטים עודכנו במערכת`);
            window.location.href='home.html'
        } else {

            if (responsePut.status == 409 || responsePut.status == 422) {
                const errorText = await responsePut.text();
                alert(errorText)
            }
            else {
                const errorResponse = await responsePut.json();
                for (const key in errorResponse.errors) {
                    if (errorResponse.errors.hasOwnProperty(key)) {
                        const errors = errorResponse.errors[key];
                        errors.forEach(error => {
                            alert(error);
                        });
                    }
                }
            } 
        }
    }
    catch (error) {
        console.log(error)
        alert(error);
    }
}
const checkPassword = async() => {
    const password = getPassword();
    try {
        const responsePost = await fetch(`api/users/password`, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(password)
        })
        const dataPost = await responsePost.json();
        console.log(dataPost)
            viewLevel(dataPost)
    }

    catch (error) {
        console.log(error)
    }
}
const viewLevel = (dataPost) => {
    const password = document.querySelector(".level")
    password.value =dataPost
}
const update = () => {
    if (sessionStorage.getItem("fullUser") == undefined)
        return alert("אין אפשרות לשנות פרטים לפני הכניסה")
    window.location.href='update.html'
}