alert("ggfhghjfhg")
const productList = addEventListener("load", async () => {
    GetproductList()
})
const filterProducts = () => {
    GetproductList()
}
const getAllFilter = () => {
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
    //const url = `api / product /?position=${filterItems.position}&skip=${filterItems.skip}`
    //if (filterItems.desc != undefined)
    //    url += `&desc=${filterItems.desc}`
    //if (filterItems.minPrice != undefined)
    //    url += `&minPrice=${filterItems.minPrice}`
    //if (filterItems.maxPrice != undefined)
    //    url += `&maxPrice=${filterItems.maxPrice}`
    //if (filterItems.categoryIds != undefined)
    //    url += `&categoryIds=${filterItems.categoryIds}`
    try {
        console.log(filterItems)
        const responseGet = await fetch(`api/product/?position=${filterItems.position}&skip=${filterItems.skip}&desc=${filterItems.desc}&minPrice=${filterItems.minPrice}&maxPrice=${filterItems.maxPrice}&categoryIds=${filterItems.categoryIds}`, {
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
    }
    catch (error) {
        console.log(error)
    }
}
