const cartList = addEventListener("load", async () => {
    getCart()
    document.getElementById("totalAmount").innerHTML = 0;
    document.getElementById("itemCount").innerHTML = 0;

})

const getCart = async () => {
    
    arrCart = JSON.parse(sessionStorage.getItem("cart"));
    arrCart.map((item) => {
         getCartFromDB(item.productId,item.quantity)
    })
}
const getCartFromDB = async (productId,quantity) => {
    try {
        const responseGet = await fetch(`api/product/${productId}`, {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            },
        })
        const dataGet = await responseGet.json();
        console.log(dataGet)
        await showProduct(dataGet, quantity)
    }
    catch (error) {
        console.log(error)
    }
}

const showProduct = async (product, quantity) => {
    let tmp = document.getElementById("temp-row");
    let cloneProduct = tmp.content.cloneNode(true)
    let url = `./Images/${product.image}`
    cloneProduct.querySelector(".image").style.backgroundImage = `url(${url})`
    cloneProduct.querySelector(".itemName").innerText = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".amount").innerText = quantity
    cloneProduct.querySelector(".expandoHeight").addEventListener('click', () => { deleteProduct(product, quantity) })
    document.getElementById("items").appendChild(cloneProduct)
    let sum = JSON.parse(document.getElementById("totalAmount").innerHTML)
    sum += product.price*quantity
    document.getElementById("totalAmount").innerHTML = sum
    document.getElementById("itemCount").innerHTML = JSON.parse(document.getElementById("itemCount").innerHTML) + quantity
}
const deleteProduct = async (product) => {
    let cart = JSON.parse(sessionStorage.getItem("cart"))
    let arr = cart.filter((item) => product.id == item.productId)
    console.log(arr)
    if (arr[0].quantity == 1) {
        cart = cart.filter((item) => item.productId != product.id)
    }
    else {
        cart = cart.map((item) => {
            if (product.id == item.productId) {
                item.quantity = item.quantity - 1;
                item.productId = item.productId//?
            }
            else {
                item = item//?
            }
            return item
        })
        console.log("ddddd" + cart)
    }
    sessionStorage.setItem("cart", JSON.stringify(cart))
    document.getElementById("totalAmount").innerHTML = 0;
    document.getElementById("itemCount").innerHTML = 0
    document.getElementById("items").innerHTML = ''
    window.location.href = "ShoppingBag.html"
}
const placeOrder = () => {
    generateDate()
    orderPost()
}
const getOrderPostObj = () => {
    generateDate()
        objOrderItem ={
            "userId": JSON.parse(sessionStorage.getItem('user')),
            "orderDate": "2025-01-05",
            "orderSum": JSON.parse(document.getElementById("totalAmount").innerHTML),
            "orderItems": JSON.parse(sessionStorage.getItem("cart")),
            "userFirstName": "string",
            "userLastName": "string"
    
    }
    return objOrderItem;
}
const orderPost =async () => {
    const orderPostObj = getOrderPostObj()
    try {
        const responsePost = await fetch(`api/order/`, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(orderPostObj)
        })
        const dataPost = await responsePost.json();
        console.log(dataPost)
        //sessionStorage.setItem('user', dataPost.userId)
        //if (!responsePut.ok)
        //    alert("משהו השתבש")
        //else
        //    alert("aaaaaaaaaaaaaaa ")
    }
    catch (error) {
        console.log(error)
        alert("lmhgyf")

    }
}
const generateDate = () => {
    //const date = new DateTime();

    //let day = date.getDate();
    //let month = date.getMonth() + 1;
    //let year = date.getFullYear();
    //let currentDate = `${year}-${month}-${day}`;
    //console.log("currentDate    " + currentDate)
    ////return currentDate.toString()
    ////return date.getDate()
    //DateTime dt = new DateTime(); 
    
    var currentTime = new Date();
    const currentDate = `${currentTime.getFullYear()}-${currentTime.getMonth()}-${currentTime.getDay()}`;
    console.log("lllll       " + currentDate)
}