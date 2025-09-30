const table = document.getElementById("pedidoTable");
const totalGeneral = document.getElementById("totalGeneral");
const agregarFilaBtn = document.getElementById("agregarFila");

// Recalcula los subtotales y total general
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

// Añade eventos a una fila
function agregarEventosFila(fila) {
    fila.querySelector(".cantidad").addEventListener("input", recalcularTotales);
    fila.querySelector(".precio").addEventListener("input", recalcularTotales);
    fila.querySelector(".btn-delete").addEventListener("click", () => {
        fila.remove();
        recalcularTotales();
    });
}

// Inicializar eventos en filas existentes
table.querySelectorAll("tbody tr").forEach(fila => agregarEventosFila(fila));

// Agregar nueva fila
agregarFilaBtn.addEventListener("click", () => {
    const tbody = table.querySelector("tbody");
    const nuevaFila = document.createElement("tr");

    nuevaFila.innerHTML = `
    <td><input type="text" name="id[]" placeholder="ID"></td>
    <td><input type="text" name="nombre[]" placeholder="Producto"></td>
    <td><input type="number" name="cantidad[]" value="1" min="1" class="cantidad"></td>
    <td><input type="number" name="precio[]" value="0" step="0.01" class="precio"></td>
    <td class="subtotal">$0</td>
    <td><button type="button" class="btn btn-delete">Eliminar</button></td>
  `;

    tbody.appendChild(nuevaFila);
    agregarEventosFila(nuevaFila);
    recalcularTotales();
});

// Calcular totales al cargar
recalcularTotales();
