document.getElementById("categoryForm").addEventListener("submit", function(event) {
    event.preventDefault();

    const category = {
        totalComputers: document.getElementById("totalComputers").value,
        computersInOfficeC: document.getElementById("computersInOfficeC").value,
        offices: document.getElementById("offices").value,
        accessPointsPerOffice: document.getElementById("accessPointsPerOffice").value
    };

    fetch("http://localhost:5113/api/category", {  // Atualizado aqui
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(category)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error("Error adding category");
        }
        return response.json();
    })
    .then(data => {
        fetchCategories();
    })
    .catch(error => {
        console.error("Error:", error);
    });
});

// Função para calcular Scenario I
document.getElementById("calculateScenarioI").addEventListener("click", function() {
    const category = {
        totalComputers: document.getElementById("totalComputers").value,
        computersInOfficeC: document.getElementById("computersInOfficeC").value,
        offices: document.getElementById("offices").value,
        accessPointsPerOffice: document.getElementById("accessPointsPerOffice").value
    };

    fetch("http://localhost:5113/api/category/scenarioI", {  // Atualizado aqui
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(category)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error("Error calculating Scenario I");
        }
        return response.json();
    })
    .then(result => {
        console.log("Scenario I result:", result); // Debug
        document.getElementById("resultScenarioI").textContent = result; // Exibir o resultado do Scenario I
    })
    .catch(error => {
        console.error("Error:", error);
    });
});

// Função para calcular Scenario II e Probability C
document.getElementById("calculateScenarioII").addEventListener("click", function() {
    const category = {
        totalComputers: document.getElementById("totalComputers").value,
        computersInOfficeC: document.getElementById("computersInOfficeC").value,
        offices: document.getElementById("offices").value,
        accessPointsPerOffice: document.getElementById("accessPointsPerOffice").value
    };

    fetch("http://localhost:5113/api/category/scenarioII", {  // Atualizado aqui
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(category)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error("Error calculating Scenario II and Probability C");
        }
        return response.json();
    })
    .then(result => {
        console.log("Scenario II result:", result); // Debug
        document.getElementById("resultScenarioII").textContent = result.scenarioII; // Exibir o resultado do Scenario II
        document.getElementById("resultProbabilityC").textContent = result.probabilityC + "%"; // Exibir a probabilidade C
    })
    .catch(error => {
        console.error("Error:", error);
    });
});

function fetchCategories() {
    fetch("http://localhost:5113/api/category") // Atualizado aqui
    .then(response => response.json())
    .then(categories => {
        const categoriesList = document.getElementById("categoriesList");
        categoriesList.innerHTML = "";
        categories.forEach(category => {
            const listItem = document.createElement("li");
            listItem.textContent = `Total Computers: ${category.totalComputers}, Offices: ${category.offices}`;
            categoriesList.appendChild(listItem);
        });
    });
}

fetchCategories();
