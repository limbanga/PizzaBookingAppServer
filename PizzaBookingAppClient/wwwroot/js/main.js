function createTempUrl(fileInputId) {
    console.log("file id" + fileInputId)
    let fileInput = document.getElementById(fileInputId);
    let file = fileInput.files[0]
    let url = URL.createObjectURL(file)
    console.log("temp url")
    console.log(url)
    return url
}
 