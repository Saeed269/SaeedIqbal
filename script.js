window.onload = function () {
    let boton1 = document.querySelector('#boton1');
    boton1.addEventListener('click', clickizquierdo);

    let boton2 = document.querySelector('#boton2');
    boton2.addEventListener('contextmenu', clickderecho);

    let boton3 = document.querySelector('#boton3');
    boton3.addEventListener('mouseover', ratonencima);

    let boton4 = document.querySelector('#boton4');
    boton4.addEventListener('mousedown', botonG);

    let crear = document.querySelector('#crear');
    crear.addEventListener('click', creacion);

    // let tarjetaCreada = document.querySelector('#crearTarjeta');
    // tarjetaCreada.addEventListener('click', tarjetaCreada);
}


let user = {
    nombre: 'Roberto',
    apellido: 'Heras',
    edad: 35,
    aficiones: ['Gym', 'Futbol']
}

function tarjetacreada(){

    let tarjetaCreada = document.querySelector('#crearTarjeta');
    tarjetaCreada.addEventListener('click', tarjetaCreada);
    
    let tarjeta = document.createElement('div');
    tarjeta.classList.add('tarjeta');
    let body = document.querySelector('.body');
    body.append(tarjeta);

    let nombre = document.createElement('h1');
    nombre.innerHTML = user.nombre + ' ' + user.apellido;
    tarjeta.append(nombre);

    let edad = document.createElement('p');
    edad.innerHTML = 'Edad: ' + user.edad;
    tarjeta.append(edad);

    let adiciones = document.createElement('ul');
    adiciones.innerHTML = '<strong>Aficiones:</strong>';
    tarjeta.append(adiciones); 

    user.aficiones.forEach(function(aficion) {  
        let li = document.createElement('li');
        li.innerHTML = aficion;
        adiciones.append(li);
    });
}

let numeroElemento = 0;
let clickderechocontador = 0;
let botonGcontador = 0;

function botonG(event) {
    let naranja = document.querySelector('#boton4');
    naranja.innerHTML = botonGcontador++;
}

function clickizquierdo(event) {
    let red = document.querySelector('#boton1');
    red.innerHTML++;
}

function ratonencima(event) {
    let verde = document.querySelector('#boton3');
    event.target.classList.toggle('activo');
    verde.innerHTML++;
}

function ultimatecla(event) {
    let amarillo = document.querySelector('#boton5');
    amarillo.innerHTML = event.key;
    console(event.key);
}

function clickderecho(event) {
    event.preventDefault();
    clickderechocontador++;
    document.getElementById('boton2').textContent = clickderechocontador;
}

function creacion() {
    let nuevoElemento = document.createElement('li');
    nuevoElemento.innerHTML = "Aquest és l’element 1 de la llista "
    nuevoElemento.id = `elemento${numeroElemento}`;
    numeroElemento = numeroElemento + 1;
    nuevoElemento.classList.add('elemento');
    let lista = document.querySelector('#lista');
    lista.append(nuevoElemento);
}

