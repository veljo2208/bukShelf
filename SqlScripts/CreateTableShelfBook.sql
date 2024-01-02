CREATE TABLE ShelfBook (
    ShelfId INT REFERENCES Shelf(Id),
    BookId INT REFERENCES Book(Id),
    PRIMARY KEY (ShelfId, BookId)
);
