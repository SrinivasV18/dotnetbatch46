CREATE TABLE products (
    [id] INT identity(1,1) NOT NULL PRIMARY KEY,
    [name] VARCHAR(255) NOT NULL,
    price INT
)

INSERT INTO products(name, price) VALUES('Laptop', 52642);
INSERT INTO products(name, price) VALUES('Mouse', 57127);
INSERT INTO products(name, price) VALUES('Chair', 9000);
INSERT INTO products(name, price) VALUES('Sofa', 29000);
INSERT INTO products(name, price) VALUES('Printer', 350000);
INSERT INTO products(name, price) VALUES('Oven', 21000);
INSERT INTO products(name, price) VALUES('Cooler', 41400);
INSERT INTO products(name, price) VALUES('Refrigirator', 21600);