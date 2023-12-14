document.addEventListener('DOMContentLoaded', function () {
    // Fonction pour supprimer un répondant
    function deleteResponse(responseId) {
        // Configuration de la requête fetch pour la suppression
        fetch(`/Option/DeleteResponse/${responseId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then(response => {
                // Vérifier si la requête a réussi (statut 200)
                if (response.ok) {
                    alert('Répondant supprimé avec succès.');
                    // Recharger la page pour mettre à jour la liste des répondants
                    window.location.reload();
                } else {
                    alert('Erreur lors de la suppression du répondant.');
                }
            })
            .catch(error => {
                console.error('Erreur fetch:', error);
            });
    }

    // Ajouter des écouteurs d'événements aux boutons de suppression si nécessaire
    const deleteButtons = document.querySelectorAll('.delete-response');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            const responseId = event.target.getAttribute('data-response-id');
            deleteResponse(responseId);
        });
    });
});
