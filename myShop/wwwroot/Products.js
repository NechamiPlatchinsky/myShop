alert("ggfhghjfhg")
const productList = addEventListener("load", async () => {
    GetproductList()
})
const filterProducts = () => {
    GetproductList()
}
const getAllFilter = () => {
    document.getElementById("PoductList").innerHTML = ''
    const filter = {
        minPrice: document.querySelector("#minPrice").value,
        maxPrice: document.querySelector("#maxPrice").value,
        desc: document.querySelector("#nameSearch").value,
        categoryIds: [],
        position: 0,
        skip:0
    }
    return filter
}
const GetproductList = async ()=>  {
    const filterItems = getAllFilter()
    let url = `api/product/?position=${filterItems.position}&skip=${filterItems.skip}`
    if (filterItems.desc != '')
        url += `&desc=${filterItems.desc}`
    if (filterItems.minPrice != '')
        url += `&minPrice=${filterItems.minPrice}`
    if (filterItems.maxPrice != '')
        url += `&maxPrice=${filterItems.maxPrice}`
    if (filterItems.categoryIds != '')
        url += `&categoryIds=${filterItems.categoryIds}`
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
const showAllProducts =async (products) => {
    for (let i = 0; i < products.length; i++) {
        showOneProduct(products[i]);
    }
}

const showOneProduct = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./images/" + product.image
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    //cloneProduct.querySelector(".button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const addToCart = () => {

}

