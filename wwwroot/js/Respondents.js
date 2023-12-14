const url = "/api/ReponseAPI";
let $reponses = $("#reponses");
getReponses();
function getReponses() {
fetch(url)
.then(response => response.json())
.then(data => data.forEach(reponse => {
let template = `<tr>
<td>${reponse.ReponseId}</td>
<td>${reponse.RepondentName}</td>
<td>${reponse.OptionId}</td>
<td>${reponse.Option}</td>
<td>
<a href="/Movies/Edit/${movie.id}">Edit</a> |
<a href="/Movies/Delete/${movie.id}">Delete</a>
</td>
</tr>`;
$reponses.append($(template));
}))
.catch(error => alert("Erreur API"));
}
const connection = new signalR.HubConnectionBuilder().withUrl("/reponseHub").build();
connection.start()
.catch(function (err) { return console.error(err.tostring()) })
connection.on("MovieChange", function () {
$reponses.empty();
getReponses();
});