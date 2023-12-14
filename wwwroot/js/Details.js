document.addEventListener('DOMContentLoaded', function () {
    // Sélection des boutons d'édition et de retour à la liste
    const editButton = document.querySelector('.btn-primary');
    const backButton = document.querySelector('.btn-secondary');

    // Écouteur d'événement pour le bouton d'édition
    editButton.addEventListener('click', function (event) {
        event.preventDefault();

        // Récupérer l'ID de la question
        const questionId = editButton.getAttribute('asp-route-id');

        // Rediriger vers la page d'édition
        window.location.href = `/Question/Edit/${questionId}`;
    });

    // Écouteur d'événement pour le bouton de retour à la liste
    backButton.addEventListener('click', function (event) {
        event.preventDefault();

        // Rediriger vers la liste des questions
        window.location.href = '/Question/Index';
    });
});
