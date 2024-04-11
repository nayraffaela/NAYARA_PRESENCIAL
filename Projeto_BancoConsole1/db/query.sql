DROP TABLE Cliente;
DROP TABLE Conta;


CREATE DATABASE SafiraBank;


GO

USE SafiraBank;

CREATE TABLE Cliente (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    cpf VARCHAR(14) UNIQUE,
    senha VARCHAR(12),
    nome VARCHAR(255),
    dataNascimento DATE
);

CREATE TABLE Conta (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    numero VARCHAR(255),
    saldo DECIMAL(10, 2),
    tipo VARCHAR(100),
    taxa DECIMAL(5, 2),
    clienteId BIGINT FOREIGN KEY REFERENCES Cliente(id)
);


select * from Cliente;

select * from Conta;