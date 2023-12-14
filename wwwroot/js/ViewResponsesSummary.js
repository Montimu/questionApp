document.addEventListener('DOMContentLoaded', function () {
    // Fonction pour récupérer et afficher les réponses pour une option
    function viewOptionResponses(optionId) {
        // Configuration de la requête fetch pour récupérer les réponses
        fetch(`/Question/GetOptionResponses/${optionId}`)
            .then(response => response.json())
            .then(data => {
                // Afficher les réponses dans une boîte de dialogue ou une autre manière appropriée
                if (data && data.length > 0) {
                    alert(`Réponses pour l'option:\n\n${data.map(response => response.RepondentName).join('\n')}`);
                } else {
                    alert('Aucune réponse disponible pour cette option.');
                }
            })
            .catch(error => {
                console.error('Erreur fetch:', error);
            });
    }

    // Ajouter des écouteurs d'événements aux liens "Voir les réponses" si nécessaire
    const viewResponsesLinks = document.querySelectorAll('.view-responses');

    viewResponsesLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            const optionId = link.getAttribute('data-option-id');
            viewOptionResponses(optionId);
        });
    });
});
