﻿document.addEventListener("DOMContentLoaded", function () {
    const categorySelector = document.querySelector("#category-selector");

    if (categorySelector) {
        console.log("Category selector found!");

        categorySelector.addEventListener("change", async function () {
            var selectedCategory = categorySelector.value;
            var filterBy = 'Category';

            console.log(`Selected category: ${selectedCategory}`);

            try {
                var response = await fetch(`Transactions/filter-by/${filterBy}/${selectedCategory}`);

                if (response.ok) {
                    console.log("Response received successfully");
                    var transactions = await response.text();
                    document.querySelector("#transactions-body").innerHTML = transactions;

                    document.getElementById("back-to-list").style.display = "inline";
                } else {
                    console.error("Error fetching transactions:", response.statusText);
                }
            } catch (error) {
                console.error("Fetch error:", error);
            }
        });
    } else {
        console.error("Category selector not found!");
    }
});
