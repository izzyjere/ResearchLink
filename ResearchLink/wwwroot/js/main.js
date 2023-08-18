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
