console.log("Productos desde API:", productos);

document.addEventListener("DOMContentLoaded", () => {
    const tbody = document.querySelector("#pedidoTable tbody");
    const productosContainer = document.getElementById("productosContainer");
    const totalGeneral = document.getElementById("totalGeneral");
    const agregarFilaBtn = document.getElementById("agregarFila");
    const formOrden = document.getElementById("formOrden");

    function actualizarTotales() {
        let total = 0;
        tbody.querySelectorAll("tr").forEach(row => {
            const cantidad = parseFloat(row.querySelector(".cantidadInput").value || 0);
            const precio = parseFloat(row.querySelector(".precioUnitario").dataset.precio || 0);
            const subtotal = cantidad * precio;
            row.querySelector(".subtotal").textContent = "$" + subtotal.toFixed(2);
            total += subtotal;
        });
        totalGeneral.textContent = "$" + total.toFixed(2);
    }

    function generarInputsHidden() {
        productosContainer.innerHTML = "";
        tbody.querySelectorAll("tr").forEach((row, index) => {
            const prodId = row.querySelector(".productoSelect").value;
            const cantidad = row.querySelector(".cantidadInput").value;

            if (prodId && cantidad > 0) {
                productosContainer.innerHTML +=
                    `<input type="hidden" name="ProductosSeleccionados[${index}].ProductoId" value="${prodId}" />` +
                    `<input type="hidden" name="ProductosSeleccionados[${index}].CantidadProducto" value="${cantidad}" />`;
            }
        });
    }

    function agregarFila() {
        const tr = document.createElement("tr");

        let options = '<option value="">--Seleccione--</option>';
        if (productos && productos.length > 0) {
            productos.forEach(p => {
                options += `<option value="${p.Id}" data-precio="${p.PrecioProducto}">${p.Nombre}</option>`;
            });
        } else {
            options += `<option disabled>No hay productos disponibles</option>`;
        }

        tr.innerHTML = `
            <td><select class="form-control productoSelect">${options}</select></td>
            <td><input type="number" class="form-control cantidadInput" value="1" min="1"></td>
            <td class="precioUnitario" data-precio="0">$0.00</td>
            <td class="subtotal">$0.00</td>
            <td><button type="button" class="btn btn-danger eliminarFila">X</button></td>
        `;

        tbody.appendChild(tr);

        const select = tr.querySelector(".productoSelect");
        const cantidadInput = tr.querySelector(".cantidadInput");
        const precioTd = tr.querySelector(".precioUnitario");

        select.addEventListener("change", () => {
            const precio = parseFloat(select.selectedOptions[0].dataset.precio || 0);
            precioTd.dataset.precio = precio;
            precioTd.textContent = "$" + precio.toFixed(2);
            actualizarTotales();
        });

        cantidadInput.addEventListener("input", actualizarTotales);

        tr.querySelector(".eliminarFila").addEventListener("click", () => {
            tr.remove();
            actualizarTotales();
        });
    }

    agregarFilaBtn.addEventListener("click", agregarFila);
    formOrden.addEventListener("submit", () => generarInputsHidden());
    agregarFila();
});
