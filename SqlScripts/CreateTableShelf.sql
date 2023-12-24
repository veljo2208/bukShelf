CREATE TABLE Shelf (
    ShelfId SERIAL PRIMARY KEY,
    VrstaPolice VARCHAR(20) NOT NULL,
    NazivOblasti VARCHAR(100) NOT NULL,
    Povrsina DECIMAL NOT NULL,
    BrojKnjiga INT NOT NULL,
    Status VARCHAR(20) NOT NULL
);