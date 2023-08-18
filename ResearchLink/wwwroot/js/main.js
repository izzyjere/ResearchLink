function showErrorMessage(message) {
    $('#e-message').removeClass("d-none")
    $('#e-message-content').text(message)
}
function triggerInput(element) {
    $(element).click()
}
function focusDrag(element, enter) {
    if (enter) {
        $(element).addClass("focus")
    } else {
        $(element).removeClass("focus")
    }
}
function previewDocument(blob) {
    $("#dViewer").prop("src", blob);
    $("#documentPreview").removeClass("d-none");
}
function onDragAreaDrop(dragEvent, inputFile) {
    let files = dragEvent.dataTransfer.files;
    if (files.length > 0) {
        $(inputFile).prop("files", files);
    }
}