document.querySelector("#category-selector").addEventListener("change", async function () {
    var selectedCategory = document.querySelector("#category-selector").value;
    console.log(selectedCategory);

    var response = await fetch(`Transactions/filter-by/category/${selectedCategory}`);

    if (response.ok) {
        var transactions = await response.text();
        document.querySelector("#transactions-body").innerHTML = transactions;
    } else {
        console.error("Error fetching transactions:", response.statusText);
    }

});