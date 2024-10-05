document.querySelector("#search-button").addEventListener("click", async function() {
    var input = document.querySelector("#search-field").value;
    console.log(input);

    if (input === "") {
        console.log("Search field is empty. No action taken.");
        return;
    }

    var response = await fetch(`Categories/search/${input}`);

    if (response.ok) {
        var categories = await response.text();
        document.querySelector("#categories-body").innerHTML = categories;
    } else {
        console.error("Error fetching categories:", response.statusText);
    }

});