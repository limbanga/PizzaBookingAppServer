function getTempURL(fileId) {
    const fileInput = document.getElementById(fileId)
    return URL.createObjectURL(fileInput.files[0])
}