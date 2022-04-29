var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

// API Method Get Triangle Coordinates from Row and Column
app.MapGet("/geometriclayout/rowcolumn/{row},{column}", (char row, int column) =>
{
    int rowInt = (int)Convert.ToChar(row) - 64;  // Convert character to integer (A-F = 1-6) for calculations below
    var triangle = new GeometricLayout
       (
            row,  // Create record with row, column from user entry, calculated coordinates
            column,
            5 * (column - (column % 2)),
            (10 * rowInt) - (1 - (column % 2)) * 10,
            ((column % 2) + column) * 5 - 10,
            10 * rowInt - 10,
            ((column % 2) + column) * 5,
            10 * rowInt

       );
    return triangle;  // return record result
});

// API Method Get Triangle Row and Column from Coordinates
app.MapGet("/geometriclayout/coordinates/{V1x},{V1y},{V2x},{V2y},{V3x},{V3y}", (int V1x, int V1y, int V2x, int V2y, int V3x, int V3y) =>
{
    int rowInt = V3y / 10;
    char row = Convert.ToChar(rowInt + 64);
    int column = (V1y / (10 * rowInt)) + 2 * (V1x / 10);
    var triangle = new GeometricLayout
       (
           row,  // Create record with coordinates from user entry, calculated row and column
           column,
           V1x,
           V1y,
           V2x,
           V2y,
           V3x,
           V3y
       );
    return triangle;  // return record result
});

app.Run();

internal record GeometricLayout(char Row, int Column, int V1x, int V1y, int V2x, int V2y, int V3x, int V3y)
{
    
}