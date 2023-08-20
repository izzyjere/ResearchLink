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
function downloadFile(fileModel) {
    var link = document.createElement("a");
    link.download = fileModel.fileName;
    link.href = fileModel.blob;
    link.click();
    link.remove();
}
