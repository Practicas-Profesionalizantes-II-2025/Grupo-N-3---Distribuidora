// crearPedido.js

document.addEventListener("DOMContentLoaded", () => {
    const pedidoTable = document.getElementById("pedidoTable").getElementsByTagName("tbody")[0];
    const totalGeneralEl = document.getElementById("totalGeneral");
    const agregarFilaBtn = document.getElementById("agregarFila");

    // Función para recalcular subtotal y total general
    function recalcularTotal() {
        let totalGeneral = 0;
        const filas = pedidoTable.querySelectorAll("tr");

        filas.forEach(fila => {
            const cantidad = parseFloat(fila.querySelector(".cantidad").value) || 0;
            const precio = parseFloat(fila.querySelector(".precio").value) || 0;
            const subtotal = cantidad * precio;
            fila.querySelector(".subtotal").textContent = `$${subtotal.toLocaleString()}`;
            totalGeneral += subtotal;
        });

        totalGeneralEl.textContent = `$${totalGeneral.toLocaleString()}`;
    }

    // Función para crear una nueva fila
    function crearFila(id = "", nombre = "", cantidad = 1, precio = 0) {
        const fila = document.createElement("tr");

        fila.innerHTML = `
      <td><input type="text" name="id[]" value="${id}"></td>
      <td><input type="text" name="nombre[]" value="${nombre}"></td>
      <td><input type="number" name="cantidad[]" value="${cantidad}" min="1" class="cantidad"></td>
      <td><input type="number" name="precio[]" value="${precio}" step="0.01" class="precio"></td>
      <td class="subtotal">$${(cantidad * precio).toLocaleString()}</td>
      <td><button type="button" class="btn btn-delete">Eliminar</button></td>
    `;

        // Eventos para recalcular al cambiar cantidad o precio
        fila.querySelector(".cantidad").addEventListener("input", recalcularTotal);
        fila.querySelector(".precio").addEventListener("input", recalcularTotal);

        // Evento para eliminar fila
        fila.querySelector(".btn-delete").addEventListener("click", () => {
            fila.remove();
            recalcularTotal();
        });

        pedidoTable.appendChild(fila);
        recalcularTotal();
    }

    // Botón agregar fila
    agregarFilaBtn.addEventListener("click", () => {
        crearFila();
    });

    // Evento submit del formulario
    document.getElementById("pedidoForm").addEventListener("submit", (e) => {
        e.preventDefault();
        alert("Pedido guardado correctamente!");
        // Aquí podrías enviar los datos al servidor con fetch/AJAX
    });

    // Opcional: agregar una fila inicial
    crearFila();
});
