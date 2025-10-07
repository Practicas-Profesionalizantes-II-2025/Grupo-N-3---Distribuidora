document.addEventListener("DOMContentLoaded", function () {
    const inputBuscar = document.getElementById("searchInput");

    if (inputBuscar) {
        inputBuscar.addEventListener("keyup", function () {
            const valor = inputBuscar.value.toLowerCase().trim();
            const filas = document.querySelectorAll("table tbody tr");

            filas.forEach(fila => {
                const id = fila.cells[0].textContent.toLowerCase();
                const fecha = fila.cells[1].textContent.toLowerCase();
                const empleado = fila.cells[2].textContent.toLowerCase();

                if (valor === "" || id.includes(valor) || fecha.includes(valor) || empleado.includes(valor)) {
                    fila.style.display = "";
                } else {
                    fila.style.display = "none";
                }
            });
        });
    }
});
