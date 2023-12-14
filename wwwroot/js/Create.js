document.addEventListener('DOMContentLoaded', function () {
    const createForm = document.querySelector('form');

    createForm.addEventListener('submit', function (event) {
        event.preventDefault();

        // Récupérer les données du formulaire
        const formData = new FormData(createForm);
        const questionText = formData.get('QuestionText');

        // Vérifier si la questionText est vide
        if (!questionText) {
            alert('Veuillez saisir une question.');
            return;
        }

        // Configuration de la requête fetch
        fetch('/Question/Create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: new URLSearchParams(formData).toString(),
        })
            .then(response => {
                // Vérifier si la requête a réussi (statut 200)
                if (response.ok) {
                    alert('Question créée avec succès.');
                    // Rediriger vers la liste après la création
                    window.location.href = '/Question/Index';
                } else {
                    alert('Erreur lors de la création de la question.');
                }
            })
            .catch(error => {
                console.error('Erreur fetch:', error);
            });
    });
});
