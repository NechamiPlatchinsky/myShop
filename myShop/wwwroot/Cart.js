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
const ifLogin = () => {
    if (JSON.parse(sessionStorage.getItem("user")) == undefined) { 
    alert("יש להכנס לפני סגירת הזמנה")
    //sessionStorage.setItem("buy", JSON.stringify("yes"))
        window.location.href = 'home.html';
        return false;
    }
    return true;
}
const placeOrder = () => {
    if (!ifLogin())
        return;
    if (!checkCart()) { 
        alert("אין מוצרים בעגלה")
    return window.location.href = "Products.html"}
    //generateDate()
    orderPost()
}
const getOrderPostObj = () => {
    
        objOrderItem ={
            "userId": JSON.parse(sessionStorage.getItem('user')),
            "orderDate":  new Date(),
            "orderSum":JSON.parse(document.getElementById("totalAmount").innerHTML),
            "orderItems": JSON.parse(sessionStorage.getItem("cart")),
            "userFirstName": "string",
            "userLastName": "string"
    
    }
    return objOrderItem;
}
const checkCart = () =>
{
    const cart = JSON.parse(sessionStorage.getItem("cart"))
    if (cart.length == 0)
        return false;
    return true;
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
        if (dataPost.status == 400) {
            throw("משהו השתבש")
        }
        /*console.log(dataPost)*/
        alert(" הזמנה מספר" + dataPost.orderId + "✔ בוצעה בהצלחה ")
        removeCart();
        //sessionStorage.setItem('user', dataPost.userId)
        //if (!responsePut.ok)
        //    alert("משהו השתבש")
        //else
        //    alert("aaaaaaaaaaaaaaa ")
    }
    catch (error) {
        //console.log(error)
        alert(error)

    }
}
const removeCart = () => {
    sessionStorage.setItem("cart", JSON.stringify([]))
    window.location.href = "Products.html"
}
