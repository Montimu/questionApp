// wwwroot/js/index.js

document.addEventListener("DOMContentLoaded", function () {
    // Get the elements you want to animate
    var welcomeText = document.querySelector(".display-4");
    var descriptionText = document.querySelector("p");

    // Add a class to initiate the animations
    welcomeText.classList.add("animate-welcome");
    descriptionText.classList.add("animate-description");
});
