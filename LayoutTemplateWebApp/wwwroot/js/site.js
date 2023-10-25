// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
document.addEventListener("DOMContentLoaded", function () {
    // Inicializar el Carousel
    const eventCarousel = new bootstrap.Carousel(document.getElementById("eventCarousel"));

    // Obtener el elemento del modal
    const eventModal = new bootstrap.Modal(document.getElementById("eventModal"));

    // Función para mostrar el modal con los datos del evento seleccionado
    function showPopup(eventID) {
        // Configura los datos del evento en el modal (reemplaza esto con tus datos reales)
        const eventTitle = "Título del Evento";
        const eventDescription = "Descripción del evento";
        const eventTime = "Hora del evento";

        const modalTitle = document.getElementById("eventModalLabel");
        const modalBody = document.querySelector(".modal-body");

        modalTitle.textContent = eventTitle;
        modalBody.innerHTML = `<p><strong>Título:</strong> ${eventDescription}</p><p><strong>Hora:</strong> ${eventTime}</p>`;

        // Muestra el modal
        eventModal.show();
    }

    // Agregar un evento de clic a cada evento para mostrar el modal
    const events = document.querySelectorAll(".event");
    events.forEach((event) => {
        event.addEventListener("click", function () {
            const eventID = event.dataset.eventId; // Obtén el ID del evento (ajusta según tu estructura)
            showPopup(eventID);
        });
    });
});

    $(document).ready(function () {
        $('#openInstallationModal').click(function () {
            $('#installationModal').modal('show');
        });

    // Handle the "Seleccionar" button within the modal
    $('#selectInstallation').click(function () {
            // Get the selected installation from the dropdown
            var selectedInstallation = $('#installationDropdown').val();

    // Add your logic to do something with the selected installation
    // For example, update the "selectedInstallationId" input
    $('#selectedInstallationId').val(selectedInstallation);

    // Close the modal
    $('#installationModal').modal('hide');
        });
    });

        $(document).ready(function () {
            // Cuando se cambia el valor del dropdown
            $('#buildingTypeDropdown').change(function () {
                var selectedTypeId = $(this).val();
                $('#selectedInstallationId').val(selectedTypeId); // Actualizar el input oculto

                // Ocultar todas las filas de la tabla
                $('#buildingGrid tr').hide();

                // Mostrar solo las filas correspondientes al tipo seleccionado
                $('#buildingGrid tr[data-type="' + selectedTypeId + '"]').show();
            });
        });

        $(document).ready(function () {
            var selectedInstallationName = null; // Variable para guardar el nombre de la instalación seleccionada

            // Cuando se hace clic en "Seleccionar" en el modal
            $('.select-building').click(function () {
                // Obtener el nombre del edificio seleccionado
                var selectedBuildingRow = $(this).closest('tr');
                var selectedInstallationName = selectedBuildingRow.find('td:first').text(); // Obtener el texto de la primera celda (nombre del edificio)

                // Mostrar el nombre de la instalación seleccionada en el campo correspondiente
                $('#selectedInstallationId').val(selectedInstallationName);

                // Ocultar el modal
                $('#installationModal').modal('hide');
            });
        });



function getSessionStorageValues() {
    invertedColors = sessionStorage.getItem('invertedColors') ? sessionStorage.getItem('invertedColors') : false;
    yellowBlack = sessionStorage.getItem('yellowBlack') ? sessionStorage.getItem('yellowBlack') : false;
    grayBlack = sessionStorage.getItem('grayBlack') ? sessionStorage.getItem('grayBlack') : false;
    invertedColors = JSON.parse(invertedColors)
    yellowBlack = JSON.parse(yellowBlack)
    grayBlack = JSON.parse(grayBlack)
}


var tamaniosOriginales = {};
var value = sessionStorage.getItem('value') ? parseFloat(sessionStorage.getItem('value')) : 1;
var invertedColors;
var yellowBlack;
var grayBlack;
getSessionStorageValues()


//check if high contrast is enabled
function checkHighContrast() {
    if (invertedColors) {
        toggleInvertedColors();
    }
    if (yellowBlack) {
        toggleYellowBlack();
    }
    if (grayBlack) {
        toggleGrayBlack();
    }
}

window.addEventListener('DOMContentLoaded', function () {
    //check for high contrast value
    checkHighContrast();
    guardarTamaniosOriginales();
    aplicarZoomActual();
});


function zoomIn() {
    value *= 1.05;
    sessionStorage.setItem('value', value);
    aplicarZoomActual();
}

function zoomOut() {
    value *= 0.95;
    sessionStorage.setItem('value', value);
    aplicarZoomActual();

}

function guardarTamaniosOriginales() {
    var elementos = document.getElementsByTagName('*');
    for (var i = 0; i < elementos.length; i++) {
        var elemento = elementos[i];
        var estilo = window.getComputedStyle(elemento, null);
        var fontSize = parseFloat(estilo.getPropertyValue('font-size'));
        tamaniosOriginales[elemento] = fontSize;
    }
}
function aplicarZoomActual() {
    var elementos = document.getElementsByTagName('*');
    for (var i = 0; i < elementos.length; i++) {
        var elemento = elementos[i];
        var fontSizeOriginal = tamaniosOriginales[elemento];
        var nuevoFontSize = fontSizeOriginal * value;
        elemento.style.fontSize = nuevoFontSize + 'px';
    }
}

function toggleYellowBlack() {
    var body = document.body;

    if (body.classList.contains('yellow-black')) {
        body.classList.remove('yellow-black');
    } else {
        body.classList.add('yellow-black');
    }
}

function toggleInvertedColors() {
    var body = document.body;

    if (body.classList.contains('inverted-colors')) {
        body.classList.remove('inverted-colors');
    } else {
        body.classList.add('inverted-colors');
    }
}
function toggleGrayBlack() {
    var body = document.body;

    if (body.classList.contains('gray-black')) {
        body.classList.remove('gray-black');
    } else {
        body.classList.add('gray-black');
    }
}


function applyHighContrast() {
    getSessionStorageValues()
    if (invertedColors) {
        toggleInvertedColors() // remove the inverted colors
        toggleYellowBlack() // apply yellow black
        sessionStorage.setItem('invertedColors', false);
        sessionStorage.setItem('yellowBlack', true);
    }
    else if (yellowBlack) {
        toggleYellowBlack() // remove the yellow black
        toggleGrayBlack()   // apply gray black
        sessionStorage.setItem('yellowBlack', false);
        sessionStorage.setItem('grayBlack', true);
    }
    else if (grayBlack) {
        toggleGrayBlack() // remove the gray black
        sessionStorage.setItem('grayBlack', false);
    } else {
        toggleInvertedColors()
        sessionStorage.setItem('invertedColors', true);
    }

}
