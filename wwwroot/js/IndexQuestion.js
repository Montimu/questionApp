// Votre fichier IndexQuestion.js

document.addEventListener("DOMContentLoaded", function () {
    // Appel à l'API pour récupérer les données
    fetch("/Question/IndexQuestionData")
        .then(response => response.json())
        .then(data => {
            // Appel de la fonction pour afficher les questions dans la table
            displayQuestions(data);
        });
});

// Fonction pour afficher les questions dans la table
function displayQuestions(questions) {
    const tableBody = document.querySelector(".table tbody");

    // Parcours des questions et ajout des lignes à la table
    questions.forEach(question => {
        const row = tableBody.insertRow();
        const cell1 = row.insertCell(0);
        const cell2 = row.insertCell(1);
        const cell3 = row.insertCell(2);

        // Remplissage des cellules avec les données de la question
        cell1.textContent = question.questionText;

        // Création du menu déroulant (select) pour les options
        const selectElement = document.createElement("select");
        selectElement.className = "form-control";
        selectElement.onchange = function () {
            showSelectedOption(selectElement);
        };

        // Ajout d'une option par défaut
        const defaultOption = document.createElement("option");
        defaultOption.value = "";
        defaultOption.textContent = "Select an option";
        selectElement.appendChild(defaultOption);

        // Ajout des options à partir des données de la question
        question.options.forEach(option => {
            const optionElement = document.createElement("option");
            optionElement.value = option.optionText;
            optionElement.textContent = option.optionText;
            selectElement.appendChild(optionElement);
        });

        // Ajout du menu déroulant à la cellule
        cell2.appendChild(selectElement);

        // Ajout des liens d'action à la troisième cellule
        cell3.innerHTML = `<a href="/Question/Edit/${question.questionId}">Edit</a> | <a href="/Question/Details/${question.questionId}">Details</a> | <a href="/Question/Delete/${question.questionId}">Delete</a>`;
    });
}

// Fonction pour afficher l'option sélectionnée
function showSelectedOption(selectElement) {
    const selectedOption = selectElement.value;
    alert("Selected Option: " + selectedOption);
}
