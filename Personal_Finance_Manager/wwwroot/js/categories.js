document.addEventListener("DOMContentLoaded", function () {
    document.querySelector("#search-button").addEventListener("click", async function () {
        var input = document.querySelector("#search-field").value;

        document.querySelector("#message").innerHTML = "";

        if (input === "") {
            console.log("Search field is empty. No action taken.");
            return;
        }

        var response = await fetch(`Categories/search/${input}`);

        if (response.ok) {
            var categories = await response.text();

            if (categories.trim() === "") {
                document.querySelector("#message").innerHTML = "Nothing found!";
            } else {
                document.querySelector("#categories-body").innerHTML = categories;
                document.getElementById('back-to-list').style.display = "inline";
            }
        } else {
            console.error("Error fetching categories:", response.statusText);
        }

    });
});
