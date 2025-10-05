const table = document.getElementById("pedidoTable");
const totalGeneral = document.getElementById("totalGeneral");
const agregarFilaBtn = document.getElementById("agregarFila");

function recalcularTotales() {
    let total = 0;
    const rows = table.querySelectorAll("tbody tr");

    rows.forEach(row => {
        const cantidad = parseFloat(row.querySelector(".cantidad").value) || 0;
        const precio = parseFloat(row.querySelector(".precio").value) || 0;
        const subtotal = cantidad * precio;
        row.querySelector(".subtotal").textContent = `$${subtotal.toLocaleString("es-AR")}`;
        total += subtotal;
    });

    totalGeneral.textContent = `$${total.toLocaleString("es-AR")}`;
}

// Actualiza los índices de todos los inputs de la tabla
function actualizarIndices() {
    const rows = table.querySelectorAll("tbody tr");
    rows.forEach((row, i) => {
        row.querySelectorAll("input").forEach(input => {
            if (input.name.includes("ProductoId"))
                input.name = `ProductosSeleccionados[${i}].ProductoId`;
            if (input.name.includes("NombreProducto"))
                input.name = `ProductosSeleccionados[${i}].NombreProducto`;
            if (input.name.includes("CantidadProducto"))
                input.name = `ProductosSeleccionados[${i}].CantidadProducto`;
            if (input.name.includes("PrecioUnitario"))
                input.name = `ProductosSeleccionados[${i}].PrecioUnitario`;
        });
    });
}

// Añade eventos a una fila
function agregarEventosFila(fila) {
    fila.querySelector(".cantidad").addEventListener("input", recalcularTotales);
    fila.querySelector(".precio").addEventListener("input", recalcularTotales);
    fila.querySelector(".btn-delete").addEventListener("click", () => {
        fila.remove();
        actualizarIndices();
        recalcularTotales();
    });
}

// Inicializar filas existentes
table.querySelectorAll("tbody tr").forEach(fila => agregarEventosFila(fila));

// Agregar nueva fila
agregarFilaBtn.addEventListener("click", () => {
    const tbody = table.querySelector("tbody");
    const nuevaFila = document.createElement("tr");

    nuevaFila.innerHTML = `
        <td><input type="hidden" name="ProductosSeleccionados[].ProductoId" value="0" />0</td>
        <td><input type="text" name="ProductosSeleccionados[].NombreProducto" value="" /></td>
        <td><input type="number" name="ProductosSeleccionados[].CantidadProducto" value="1" min="1" class="cantidad" /></td>
        <td><input type="number" name="ProductosSeleccionados[].PrecioUnitario" value="0" step="0.01" class="precio" /></td>
        <td class="subtotal">$0</td>
        <td><button type="button" class="btn btn-delete">Eliminar</button></td>
    `;

    tbody.appendChild(nuevaFila);
    agregarEventosFila(nuevaFila);
    actualizarIndices();
    recalcularTotales();
});

recalcularTotales();
