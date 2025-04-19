
$(document).ready(function () {
    const $hallForm = $("#hallForm");
    const $hallNameInput = $("#hallName");
    const $seatsInput = $("#seats");
    const $hallsList = $("#hallsList");

    function getHalls() {
        return JSON.parse(localStorage.getItem("halls")) || [];
    }

    function saveHalls(halls) {
        localStorage.setItem("halls", JSON.stringify(halls));
    }

    function renderHalls() {
       
        const halls = getHalls();
        $hallsList.empty();
        
        if (halls.length === 0) {
            $hallsList.html('<li class="list-group-item text-muted">No halls available.</li>');
            return;
        }

        halls.forEach((hall, index) => {
            const $hallItem = $("<li>") 
                .addClass("list-group-item d-flex justify-content-between align-items-center")
                .html(`
                    <span><strong>${hall.name}</strong> - ${hall.seatCount} seats</span> 
                    <button class="btn btn-danger btn-sm delete-hall" data-index="${index}">Delete</button>
                `);
            $hallsList.append($hallItem);
        });
    }

    $hallForm.on("submit", function (e) {
        e.preventDefault();
        const hallData = {
            name: $hallNameInput.val(),
            seatCount: parseInt($seatsInput.val())
        };
    
        fetch("http://localhost:5031/api/hall", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(hallData)
        })
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            return response.json();
        })
        .then(data => {
            alert("Salla u shtua me sukses!");
            console.log("Created:", data);
            $hallForm[0].reset();
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Ndodhi një gabim gjatë shtimit të sallës.");
        });
    });
    
});

