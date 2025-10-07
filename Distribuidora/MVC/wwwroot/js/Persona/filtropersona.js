document.addEventListener("DOMContentLoaded", function () {
    const inputBuscar = document.getElementById("searchInput");

    if (inputBuscar) {
        inputBuscar.addEventListener("keyup", function () {
            const valor = inputBuscar.value.toLowerCase().trim();
            const filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                // Tomamos los valores de ID, DNI y Nombre completo de la fila
                const id = fila.cells[0].textContent.toLowerCase();
                const nombre = fila.cells[1].textContent.toLowerCase();
                const dni = fila.cells[2].textContent.toLowerCase();

                // Mostrar fila si coincide con alguno de los campos
                if (valor === "" || id.includes(valor) || nombre.includes(valor) || dni.includes(valor)) {
                    fila.style.display = "";
                } else {
                    fila.style.display = "none";
                }
            });
        });
    }
});
