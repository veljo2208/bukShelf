﻿CREATE TABLE Book (
    BookId SERIAL PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(100) NOT NULL,
    Weight DECIMAL NOT NULL,
    Size DECIMAL NOT NULL
);