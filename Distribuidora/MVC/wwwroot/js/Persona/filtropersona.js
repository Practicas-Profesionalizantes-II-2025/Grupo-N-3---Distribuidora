document.addEventListener("DOMContentLoaded", () => {
    const searchInput = document.getElementById('searchInput');
    const tableRows = document.querySelectorAll('.tabla-empleados tbody tr');

    function filtrarClientes() {
        const filtro = searchInput.value.toLowerCase();

        tableRows.forEach(row => {
            const id = row.cells[0].textContent.toLowerCase();
            const nombre = row.cells[1].textContent.toLowerCase();
            const dni = row.cells[2].textContent.toLowerCase();
            const estado = row.cells[7].textContent.toLowerCase();

            if (filtro === '') {
                // Por defecto: solo mostrar Activos
                row.style.display = (estado === 'activo') ? '' : 'none';
            } else {
                // Durante la búsqueda: mostrar cualquier coincidencia, sin importar estado
                const coincide = id.includes(filtro) || nombre.includes(filtro) || dni.includes(filtro);
                row.style.display = coincide ? '' : 'none';
            }
        });
    }

    // Evento input en tiempo real
    searchInput.addEventListener('input', filtrarClientes);

    // Inicializa la tabla ocultando inactivos al cargar
    filtrarClientes();
});