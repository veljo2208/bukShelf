CREATE TABLE Shelf (
    Id SERIAL PRIMARY KEY,
    Shelf_Type VARCHAR(20) NOT NULL,
    Surface DECIMAL NOT NULL,
    Book_Count INT NOT NULL,
    Current_Weight_Load DECIMAL NOT NULL,
    Material VARCHAR(10) NOT NULL,
    Shelf_Status VARCHAR(20) NOT NULL
);

