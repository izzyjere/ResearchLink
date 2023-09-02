function showErrorMessage(message) {
    $('#e-message').removeClass("d-none")
    $('#e-message-content').text(message)
}

function downloadFile(fileModel) {
    var link = document.createElement("a");
    link.download = fileModel.fileName;
    link.href = fileModel.blob;
    link.click();
    link.remove();
}
