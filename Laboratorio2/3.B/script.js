function agregar() {
  //Busca el elemnto en el DOM
  let lista = document.getElementById("lista");
  // Obtiene la cantidad actual en lista
  let contadorLista = lista.getElementsByTagName("li").length + 1;
  //crea uno nuevo
  let nuevoElemento = document.createElement("li");
  nuevoElemento.textContent = "Elemento" + contadorLista;
  //lo añade al DOM
  lista.appendChild(nuevoElemento);
}

function borrar() {
  let lista = document.getElementById("lista");
  //Elimina el ultimo
  if (lista.hasChildNodes()) {
      lista.removeChild(lista.lastElementChild);
  }
}

function cambiarFondo() {
  let body = document.body;
  if (body.style.backgroundColor === "white" || body.style.backgroundColor === "") {
      body.style.backgroundColor = "#8662af" ;
  } else {
      body.style.backgroundColor = "white";
  }
}


