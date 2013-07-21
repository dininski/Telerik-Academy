CREATE DATABASE ConcertsWithPartitioning;

USE ConcertsWithPartitioning;

DROP TABLE IF EXISTS Concerts;

CREATE TABLE `ConcertsWithPartitioning`.`Concerts` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Performer` VARCHAR(45) NULL ,
  `Concert_Date` DATETIME ,
  PRIMARY KEY (`Id`, `Concert_Date`)
 ) PARTITION BY RANGE(YEAR(Concert_Date)) (
		PARTITION p0 VALUES LESS THAN (1990),
		PARTITION p1 VALUES LESS THAN (2000),
		PARTITION p2 VALUES LESS THAN (2010),
		PARTITION p3 VALUES LESS THAN MAXVALUE
);

DELIMITER $$
DROP PROCEDURE IF EXISTS insert_million_rows $$

CREATE PROCEDURE insert_million_rows () 
BEGIN
DECLARE crs INT DEFAULT 0;

WHILE crs < 1000000 DO
INSERT INTO `Concerts`(`Performer`, `Concert_Date`)
	VALUES (substring(MD5(RAND()), -8), DATE_ADD('1990-01-01', INTERVAL 365*33*rand() DAY));
	SET crs = crs + 1;
END WHILE;
END $$

DELIMITER ;

CALL insert_million_rows();

SELECT COUNT(*) FROM Concerts
	WHERE YEAR(Concert_Date) > 1990 AND YEAR(Concert_Date) < 1999;

EXPLAIN PARTITIONS SELECT * FROM Concerts;

SELECT * FROM `Concerts` partition (p0);

SELECT * FROM `Concerts`;