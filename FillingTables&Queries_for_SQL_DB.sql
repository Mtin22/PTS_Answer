---Create the Tables---

CREATE TABLE authors_tbl(
    author_id INTEGER PRIMARY KEY,
    author_name VARCHAR(100)
);


CREATE TABLE borrowers_tbl(
    borrower_id INTEGER PRIMARY KEY,
    borrower_name VARCHAR(100)
);


CREATE TABLE books_tbl(
    book_id INTEGER PRIMARY KEY,
    book_title VARCHAR(100),
    book_publishing_date DATE,
    author_id INTEGER,
    FOREIGN KEY (author_id) REFERENCES authors_tbl(author_id)
);


CREATE TABLE borrowed_books_tbl(
    borrow_id INT PRIMARY KEY,
    borrow_date DATE,
    borrow_due_date DATE,
    borrow_return_date DATE,
    book_id INT,
    borrower_id INT,
    FOREIGN KEY (book_id) REFERENCES books_tbl(book_id),
    FOREIGN KEY (borrower_id) REFERENCES borrowers_tbl(borrower_id)
);


---Insert Data into the Tables---

INSERT INTO authors_tbl VALUES (1, 'Peter M');
INSERT INTO authors_tbl VALUES (2, 'Anna I');
INSERT INTO authors_tbl VALUES (3, 'Ross B');
INSERT INTO authors_tbl VALUES (4, 'Mike W');

INSERT INTO borrowers_tbl VALUES (1, 'Matt');
INSERT INTO borrowers_tbl VALUES (2, 'Josh');
INSERT INTO borrowers_tbl VALUES (3, 'Ingrid');
INSERT INTO borrowers_tbl VALUES (4, 'Jason');

INSERT INTO books_tbl VALUES (1, 'Historic Battles', '2020-03-06', 2);
INSERT INTO books_tbl VALUES (2, 'Airplanes', '2018-07-28', 4);
INSERT INTO books_tbl VALUES (3, 'Wild Life', '2015-04-30', 3);
INSERT INTO books_tbl VALUES (4, 'The Magic of Painting', '2001-12-01', 3);
INSERT INTO books_tbl VALUES (5, 'Quantum Computing', '2023-08-19', 1);
INSERT INTO books_tbl VALUES (6, 'Flowers', '2021-06-22', 3);
INSERT INTO books_tbl VALUES (7, 'Complexity of Economics', '2024-10-10', 2);

INSERT INTO borrowed_books_tbl VALUES (1, '2020-01-22', '2020-02-22', '2020-02-20', 1, 1);
INSERT INTO borrowed_books_tbl VALUES (2, '2018-03-08', '2018-04-08', '2018-04-10', 2, 4);
INSERT INTO borrowed_books_tbl VALUES (3, '2020-06-29', '2020-07-29', '2020-07-30', 7, 3);
INSERT INTO borrowed_books_tbl VALUES (4, '2015-03-05', '2015-04-05', '2015-04-04', 4, 2);
INSERT INTO borrowed_books_tbl VALUES (5, '2017-08-16', '2017-09-16', '2017-09-16', 6, 2);
INSERT INTO borrowed_books_tbl VALUES (6, '2019-09-09', '2019-10-09', '2019-10-19', 3, 1);
INSERT INTO borrowed_books_tbl VALUES (7, '2023-05-14', '2023-06-14', '2023-06-10', 5, 3);


---Queries for the Tables---

SELECT * 
FROM books_tbl
WHERE book_publishing_date > '2020-01-01'

SELECT *
FROM authors_tbl authors
JOIN books_tbl books ON authors.author_id = books.author_id
WHERE authors.author_id = (
    SELECT authors.author_id
    FROM authors_tbl authors
    JOIN books_tbl books ON authors.author_id = books.author_id
    GROUP BY authors.author_id
    ORDER BY COUNT(books.book_id) DESC
    LIMIT 1
);

SELECT * 
FROM borrowed_books_tbl 
WHERE borrow_due_date < borrow_return_date;



---Delete the Tables (if Required)---

DROP TABLE authors_tbl;
DROP TABLE borrowers_tbl;
DROP TABLE books_tbl;
DROP TABLE borrowed_books_tbl;