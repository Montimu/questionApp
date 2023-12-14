document.addEventListener('DOMContentLoaded', function () {
    const addOptionButton = document.getElementById('addOption');
    const optionsContainer = document.getElementById('optionsContainer');

    let optionIndex = 1;

    addOptionButton.addEventListener('click', function () {
        // Créer un nouvel élément d'option
        const newOption = document.createElement('div');
        newOption.classList.add('option');

        // Créer le label
        const label = document.createElement('label');
        label.setAttribute('for', `options[${optionIndex}].OptionText`);
        label.textContent = 'Option Text:';
        newOption.appendChild(label);

        // Créer l'input
        const input = document.createElement('input');
        input.setAttribute('type', 'text');
        input.setAttribute('name', `options[${optionIndex}].OptionText`);
        newOption.appendChild(input);

        // Créer le span pour les messages d'erreur
        const errorSpan = document.createElement('span');
        errorSpan.classList.add('text-danger');
        newOption.appendChild(errorSpan);

        // Ajouter l'élément d'option au conteneur
        optionsContainer.appendChild(newOption);

        // Incrémenter l'index pour le prochain ajout
        optionIndex++;
    });

    const createForm = document.querySelector('form');

    createForm.addEventListener('submit', function (event) {
        event.preventDefault();

        // Récupérer les données du formulaire
        const formData = new FormData(createForm);

        // Configuration de la requête fetch
        fetch('/Question/CreateQuestionAndOptions', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: new URLSearchParams(formData).toString(),
        })
            .then(response => {
                // Vérifier si la requête a réussi (statut 200)
                if (response.ok) {
                    alert('Question et options créées avec succès.');
                    // Rediriger ou effectuer d'autres actions si nécessaire
                    window.location.href = '/Question/Index';
                } else {
                    alert('Erreur lors de la création de la question et des options.');
                }
            })
            .catch(error => {
                console.error('Erreur fetch:', error);
            });
    });
});
