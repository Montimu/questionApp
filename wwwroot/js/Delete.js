document.addEventListener('DOMContentLoaded', function () {
    const deleteButton = document.getElementById('deleteButton');

    if (deleteButton) {
        deleteButton.addEventListener('click', function () {
            const questionId = document.getElementById('questionId').value;

            // Configuration de la requête fetch
            fetch('/Question/Delete', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: 'QuestionId=' + encodeURIComponent(questionId),
            })
                .then(response => {
                    // Vérifier si la requête a réussi (statut 200)
                    if (response.ok) {
                        alert('Question supprimée avec succès!');
                        // Rediriger ou effectuer d'autres actions si nécessaire
                        window.location.href = '/Question/Index';
                    } else {
                        alert('Une erreur s\'est produite lors de la suppression de la question.');
                    }
                })
                .catch(error => {
                    console.error('Erreur fetch:', error);
                    alert('Une erreur s\'est produite lors de la suppression de la question.');
                });
        });
    }
});
