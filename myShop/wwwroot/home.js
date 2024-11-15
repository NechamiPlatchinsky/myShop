
const visibleRegister = () => {
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
        if (!responsePost.ok)
           return alert("משהו השתבש")
            alert("נוסף בהצלחה")
    }
    catch (error) {
        console.log(error)
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
            query: { Email: user.Email,Password:user.Password }
        })
        if (responsePost.status == 204)
            return alert("משתמש לא מזוהה")
        const dataPost = await responsePost.json();
        sessionStorage.setItem('user', dataPost.userId)
        sessionStorage.setItem('nameUser', dataPost.firstName)
        window.location.href="update.html"
    }
    catch (error) {
        console.log(error)
    }

}
const updateDitailse = async() => {
    const user = getDitails();
    try {
        const responsePut = await fetch(`api/users/${sessionStorage.getItem("user")}`, {
            method: 'PUT',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        
        //const dataPut = await responsePut.json();
        //console.log(dataPut)
        //sessionStorage.setItem('user', dataPost.userId)
        if (!responsePut.ok)
            alert("משהו השתבש")
        else
            alert("הפרטים עודכנו במערכת ")
    }
    catch (error) {
        console.log(error)
        
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
        /*if (responsePost.status == 204)*/
        const dataPost = await responsePost.json();
        alert(dataPost)
        console.log(dataPost)
        viewLevel(dataPost)

        /*const dataPost = await responsePost.json();*/
    }
    catch (error) {
        console.log(error)
    }
}
const viewLevel = (dataPost) => {
    const password = document.querySelector(".level")
    password.value =dataPost
}