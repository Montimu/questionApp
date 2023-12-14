const url = "/api/MoviesAPI";
const connection = new signalR.HubConnectionBuilder().withUrl("/movieHub").build();
connection.start()
.catch(function (err) { return console.error(err.tostring()) })
document.getElementById("createbt").addEventListener("click", function (event) {
var title = document.getElementById("title").value;
var releasedate = document.getElementById("releasedate").value;
var genre = document.getElementById("genre").value;
var price = document.getElementById("price").value;
const movie =
{
id:0, title: title, releasedate: releasedate, genre: genre, price: price
};
fetch(url, {
method:"POST",
headers:{
'Accept': 'application/json',
'Content-Type': 'application/json'
},
body: JSON.stringify(movie)
})
.then(response => response.json())
.then(() => {
connection.invoke("SendMessage").catch(function (err) {
return console.error(err.toString());
});
})
.catch(error => alert("Erreur API"));
event.preventDefault();
});