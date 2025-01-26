const productList = addEventListener("load", async () => {
    GetproductList()
    GetCategoriesList()
    let categoryIdArr = [];
    let myCartArr = JSON.parse(sessionStorage.getItem("cart")) || [];
    sessionStorage.setItem("categoryIds", JSON.stringify(categoryIdArr))
    sessionStorage.setItem("cart", JSON.stringify(myCartArr))
    //sessionStorage.setItem("count")
    document.querySelector("#ItemsCountText").innerHTML = getItemsCountText(myCartArr);
})
const getItemsCountText = (myCartArr) => {
    let sum = 0;
    myCartArr.map((item) => {
        sum+=item.quantity
    })
    return sum;
}
const filterProducts = () => {
    GetproductList()
}
const getAllFilter = () => {
    document.getElementById("PoductList").innerHTML = ''

    const filter = {
        minPrice: document.querySelector("#minPrice").value,
        maxPrice: document.querySelector("#maxPrice").value,
        desc: document.querySelector("#nameSearch").value,
        categoryIds: JSON.parse(sessionStorage.getItem("categoryIds"))||[],
        position: 0,
        skip:0
    }
    return filter
}
const GetproductList = async ()=>  {
    const filterItems = getAllFilter()// build url in a different function
    let url = `api/product/?position=${filterItems.position}&skip=${filterItems.skip}`
    if (filterItems.desc != '')
        url += `&desc=${filterItems.desc}`
    if (filterItems.minPrice != '')
        url += `&minPrice=${filterItems.minPrice}`
    if (filterItems.maxPrice != '')
        url += `&maxPrice=${filterItems.maxPrice}`
    if (filterItems.categoryIds != '')
        for (let i = 0; i < filterItems.categoryIds.length; i++) {//map is nicer
               url += `&categoryIds=${filterItems.categoryIds[i]}`
        }
        
    try {
        console.log(filterItems)
        const responseGet = await fetch(url, {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            },
            query: {
                 position: filterItems.position, skip: filterItems.skip, desc: filterItems.desc,
                 minPrice: filterItems.minPrice, maxPrice: filterItems.maxPrice, categoryIds: filterItems.categoryIds
             }
        })
        //if (responseGet.status == 204)
        //    return alert("משתמש לא מזוהה")
        const dataPost = await responseGet.json();
        console.log(dataPost)
        //window.location.href = "Products.html"
        showAllProducts(dataPost);
    }
    catch (error) {
        console.log(error)
    }
}
const showAllProducts = async (products) => {
    for (let i = 0; i < products.length; i++) {//map
        showOneProduct(products[i]);
    }
}

const showOneProduct = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./Images/" + product.image
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const addToCart = (product) => {
    if (sessionStorage.getItem("user")) {
        
        let myCart = JSON.parse(sessionStorage.getItem("cart"))
        let flag = 0;
        myCart.map((item) => {
            if (item.productId == product.id) {
                item.quantity++;
                flag = 1
            }
            return item
        })
        if (flag == 0) { 
            let obj = { productId: product.id,quantity:1 }
        myCart.push(obj)}
        sessionStorage.setItem("cart", JSON.stringify(myCart))
        
        document.querySelector("#ItemsCountText").innerHTML = JSON.parse(document.querySelector("#ItemsCountText").innerHTML) + 1;
    }
    else {
        alert("אינך רשום")
        window.location.href = "home.html"
    }
    
}
const GetCategoriesList = async () => {
    try {
        const responseGet = await fetch("api/category", {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            },
            //query: {
            //}
        })
        const dataGet = await responseGet.json();
        console.log(dataGet)
        showAllCategories(dataGet);
    }
    catch (error) {
        console.log(error)
    }
}

const showAllCategories = async (categories) => {
    for (let i = 0; i < categories.length; i++) {
        showOneCategory(categories[i]);
    }
}
const showOneCategory = async (category) => {
    let tmp = document.getElementById("temp-category");
    let cloneCategory = tmp.content.cloneNode(true)
    cloneCategory.querySelector(".OptionName").textContent = category.name
    cloneCategory.querySelector(".opt").addEventListener('change', () => { addCategory(category.id) })
    document.getElementById("categoryList").appendChild(cloneCategory)
}

const addCategory = async (id) => {
    let categories = JSON.parse(sessionStorage.getItem("categoryIds"))
    let index = categories.indexOf(id)
    index == -1 ? categories.push(id) : categories.splice(index, 1)
    sessionStorage.setItem("categoryIds", JSON.stringify(categories))
    console.log(categories)
    GetproductList()
}
