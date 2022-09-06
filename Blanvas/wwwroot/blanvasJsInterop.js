// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}


export function fillStyle(id) {
    let ctx = document.getElementById(id).getContext('2d');
    ctx.fillStyle = 'rgb(200, 0, 0)';
    //ctx.fillStyle = 'rgba(0, 0, 200, 0.5)';
}
export function drawRect(id, x, y, width, height) {
    let ctx = document.getElementById(id).getContext('2d');
    ctx.fillRect(x, y, width, height);
}