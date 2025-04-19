$(document).ready(function () {
    const $viewerForm = $("#viewerForm");
    const $viewerNameInput = $("#viewerName");
    const $viewerEmailInput = $("#viewerEmail");
    const $viewersList = $("#viewersList");

    function getViewers() {
        return JSON.parse(localStorage.getItem("viewers")) || [];
    }

    function saveViewers(viewers) {
        localStorage.setItem("viewers", JSON.stringify(viewers));
    }

    function renderViewers() {
        const viewers = getViewers();
        $viewersList.empty();

        if (viewers.length === 0) {
            $viewersList.html('<li class="list-group-item text-muted">No viewers available.</li>');
            return;
        }

        viewers.forEach((viewer, index) => {
            const $viewerItem = $("<li>")
                .addClass("list-group-item d-flex justify-content-between align-items-center")
                .html(`
                    <span><strong>${viewer.name}</strong> - ${viewer.email}</span> 
                    <button class="btn btn-danger btn-sm delete-viewer" data-index="${index}">Delete</button>
                `);
            $viewersList.append($viewerItem);
        });
    }

    $viewerForm.on("submit", function (e) {
        e.preventDefault();
        const viewerData = {
            name: $viewerNameInput.val(),
            email: $viewerEmailInput.val()
        };

        fetch("http://localhost:5031/api/viewer", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(viewerData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Network response was not ok");
                }
                return response.json();
            })
            .then(data => {
                alert("Viewer added successfully!");
                console.log("Created:", data);
                $viewerForm[0].reset();
            })
            .catch(error => {
                console.error("Error:", error);
                alert("An error occurred while adding the viewer.");
            });
    });

});
