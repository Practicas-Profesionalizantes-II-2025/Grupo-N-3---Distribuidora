document.addEventListener("DOMContentLoaded", function () {
    const inputBuscar = document.getElementById("searchInput");

    if (inputBuscar) {
        inputBuscar.addEventListener("keyup", function () {
            const valor = inputBuscar.value.toLowerCase().trim();
            const filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                const texto = fila.textContent.toLowerCase();
                fila.style.display = valor === "" ? "" : (texto.includes(valor) ? "" : "none");
            });
        });
    }
});