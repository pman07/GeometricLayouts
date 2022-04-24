// Function to call coordinates API with row and column entries
function getCoordinates() {
    row = document.getElementById("row").value;
    column = document.getElementById("column").value;
    fetch(`/geometriclayout/rowcolumn/${row},${column}`)
        .then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error("NETWORK RESPONSE ERROR");
            }
        })
        .then(data => {
            console.log(data);
            _displayItems(data)
        })
        .catch((error) => console.error("FETCH ERROR:", error));

}

// Function to call row column API with coordinate entries
function getRowColumn() {
    x1 = document.getElementById("x1").value;
    y1 = document.getElementById("y1").value;
    x2 = document.getElementById("x2").value;
    y2 = document.getElementById("y2").value;
    x3 = document.getElementById("x3").value;
    y3 = document.getElementById("y3").value;
    fetch(`/geometriclayout/coordinates/${x1},${y1},${x2},${y2},${x3},${y3}`)
        .then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error("NETWORK RESPONSE ERROR");
            }
        })
        .then(data => {
            console.log(data);
            _displayItems(data)
        })
        .catch((error) => console.error("FETCH ERROR:", error));

}

// Function to display results
function _displayItems(data) {
    const tBody = document.getElementById('triangle');
    tBody.innerHTML = data.row + data.column + ": (" + data.v1x + "," + data.v1y + "),(" + data.v2x + "," + data.v2y + "),(" + data.v3x + "," +  data.v3y + ")";

}