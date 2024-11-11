CREATE TABLE SearchResult (
    Id SERIAL PRIMARY KEY,
    SearchedValue VARCHAR(255) NOT NULL,
    SearchDate TIMESTAMP,
    Title VARCHAR(255) NOT NULL,
    Instructor VARCHAR(255),
    Duration VARCHAR(10),
    Description VARCHAR(255)
);