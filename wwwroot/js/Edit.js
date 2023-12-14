document.addEventListener('DOMContentLoaded', function () {
    const editForm = document.querySelector('form');

    editForm.addEventListener('submit', function (event) {
        event.preventDefault();

        // Récupérer les données du formulaire
        const formData = new FormData(editForm);
        const questionId = formData.get('QuestionId');
        const questionText = formData.get('QuestionText');

        // Vérifier si la questionText est vide
        if (!questionText) {
            alert('Veuillez saisir une question.');
            return;
        }

        // Configuration de la requête fetch
        fetch(`/Question/Edit/${questionId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: new URLSearchParams(formData).toString(),
        })
            .then(response => {
                // Vérifier si la requête a réussi (statut 200)
                if (response.ok) {
                    alert('Question mise à jour avec succès.');
                    // Rediriger vers la liste après la mise à jour
                    window.location.href = '/Question/Index';
                } else {
                    alert('Erreur lors de la mise à jour de la question.');
                }
            })
            .catch(error => {
                console.error('Erreur fetch:', error);
            });
    });
});
