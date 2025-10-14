const table = document.getElementById("ventaTable");
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

// 🔹 Actualiza los índices de todos los inputs según su posición
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
            if (input.name.includes("DistribuidorId"))
                input.name = `ProductosSeleccionados[${i}].DistribuidorId`;
            if (input.name.includes("DistribuidorNombre"))
                input.name = `ProductosSeleccionados[${i}].DistribuidorNombre`;
            if (input.name.includes("ClienteId"))
                input.name = `ProductosSeleccionados[${i}].ClienteId`;
            if (input.name.includes("ClienteNombre"))
                input.name = `ProductosSeleccionados[${i}].ClienteNombre`;
            if (input.name.includes("EmpleadoId"))
                input.name = `ProductosSeleccionados[${i}].EmpleadoId`;
            if (input.name.includes("EmpleadoNombre"))
                input.name = `ProductosSeleccionados[${i}].EmpleadoNombre`;
        });
    });
}

// 🔹 Añade eventos a una fila
function agregarEventosFila(fila) {
    fila.querySelector(".cantidad").addEventListener("input", recalcularTotales);
    fila.querySelector(".precio").addEventListener("input", recalcularTotales);
    fila.querySelector(".btn-delete").addEventListener("click", () => {
        fila.remove();
        actualizarIndices();
        recalcularTotales();
    });
}

// 🔹 Inicializa las filas existentes (por si vienen cargadas)
table.querySelectorAll("tbody tr").forEach(fila => agregarEventosFila(fila));

// 🔹 Agrega una nueva fila de producto
agregarFilaBtn.addEventListener("click", () => {
    const tbody = table.querySelector("tbody");
    const nuevaFila = document.createElement("tr");

    const index = tbody.querySelectorAll("tr").length;

    nuevaFila.innerHTML = `
        <td>
            <input type="hidden" name="ProductosSeleccionados[${index}].ProductoId" value="0" />
            0
        </td>
        <td>
            <input type="text" name="ProductosSeleccionados[${index}].NombreProducto" value="" />
        </td>
        <td>
            <input type="number" name="ProductosSeleccionados[${index}].CantidadProducto" value="1" min="1" class="cantidad" />
        </td>
        <td>
            <input type="number" name="ProductosSeleccionados[${index}].PrecioUnitario" value="0" step="0.01" class="precio" />
        </td>
        <td class="subtotal">$0</td>
        <td>
            <button type="button" class="btn btn-delete btn-danger">Eliminar</button>
        </td>
    `;

    tbody.appendChild(nuevaFila);
    agregarEventosFila(nuevaFila);
    actualizarIndices();
    recalcularTotales();
});

// 🔹 Calcular totales iniciales
recalcularTotales();
