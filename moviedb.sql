-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 05. 21:10
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `moviedb`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `genre`
--

CREATE TABLE `genre` (
  `GenreID` varchar(10) NOT NULL,
  `GenreName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `genre`
--

INSERT INTO `genre` (`GenreID`, `GenreName`) VALUES
('AC', 'Action'),
('AN', 'Animation'),
('CO', 'Comedy'),
('DR', 'Drama'),
('SF', 'Science Fiction'),
('TH', 'Thriller');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `movie`
--

CREATE TABLE `movie` (
  `MovieID` varchar(10) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Year` int(11) DEFAULT NULL,
  `Rating` float DEFAULT NULL CHECK (`Rating` >= 0 and `Rating` <= 10),
  `GenreID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `movie`
--

INSERT INTO `movie` (`MovieID`, `Title`, `Year`, `Rating`, `GenreID`) VALUES
('M001', 'Inception', 2010, 8.8, 'SF'),
('M002', 'Barbie', 2023, 7.2, 'CO'),
('M003', 'The Dark Knight', 2008, 9, 'TH'),
('M004', 'La La Land', 2016, 8, 'DR'),
('M005', 'Spirited Away', 2001, 8.6, 'AN'),
('M006', 'Black Swan', 2010, 8, 'DR'),
('M007', 'Iron Man', 2008, 7.9, 'AC'),
('M008', 'Avengers: Endgame', 2019, 8.4, 'AC'),
('M009', 'Pulp Fiction', 1994, 8.9, 'TH'),
('M010', 'Oppenheimer', 2023, 8.6, 'DR'),
('M011', 'Interstellar', 2014, 8.6, 'SF'),
('M012', 'The Martian', 2015, 8, 'SF'),
('M013', 'Dune', 2021, 8.1, 'SF'),
('M014', 'Wonder Woman', 2017, 7.4, 'AC'),
('M015', 'Mission: Impossible - Fallout', 2018, 7.7, 'AC'),
('M016', 'John Wick', 2014, 7.4, 'TH'),
('M017', 'Matrix', 1999, 8.7, 'SF'),
('M018', 'Ford v Ferrari', 2019, 8.1, 'DR'),
('M019', 'Tenet', 2020, 7.3, 'SF'),
('M020', 'Little Women', 2019, 7.8, 'DR'),
('M021', 'Blade Runner 2049', 2017, 8, 'SF'),
('M022', 'Arrival', 2016, 7.9, 'SF'),
('M023', 'The Prestige', 2006, 8.5, 'TH'),
('M024', 'Catch Me If You Can', 2002, 8.1, 'DR'),
('M025', 'Edge of Tomorrow', 2014, 7.9, 'SF');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `movie_actor`
--

CREATE TABLE `movie_actor` (
  `PersonID` varchar(10) NOT NULL,
  `MovieID` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `movie_actor`
--

INSERT INTO `movie_actor` (`PersonID`, `MovieID`) VALUES
('P002', 'M001'),
('P003', 'M001'),
('P005', 'M002'),
('P006', 'M001'),
('P006', 'M003'),
('P007', 'M001'),
('P007', 'M010'),
('P008', 'M004'),
('P008', 'M006'),
('P009', 'M002'),
('P009', 'M004'),
('P009', 'M008'),
('P011', 'M003'),
('P012', 'M006'),
('P013', 'M007'),
('P013', 'M008'),
('P013', 'M010'),
('P014', 'M007'),
('P014', 'M008'),
('P015', 'M009'),
('P016', 'M012'),
('P016', 'M018'),
('P017', 'M011'),
('P017', 'M020'),
('P018', 'M024'),
('P019', 'M013'),
('P020', 'M013'),
('P021', 'M020'),
('P021', 'M025'),
('P022', 'M015'),
('P022', 'M025'),
('P023', 'M016'),
('P023', 'M017'),
('P024', 'M014'),
('P025', 'M014');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `movie_director`
--

CREATE TABLE `movie_director` (
  `PersonID` varchar(10) NOT NULL,
  `MovieID` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `movie_director`
--

INSERT INTO `movie_director` (`PersonID`, `MovieID`) VALUES
('P001', 'M001'),
('P001', 'M003'),
('P001', 'M008'),
('P001', 'M010'),
('P001', 'M011'),
('P001', 'M012'),
('P001', 'M013'),
('P001', 'M018'),
('P001', 'M019'),
('P001', 'M024'),
('P001', 'M025'),
('P004', 'M002'),
('P004', 'M004'),
('P004', 'M006'),
('P004', 'M020'),
('P010', 'M005'),
('P010', 'M021'),
('P010', 'M022'),
('P015', 'M007'),
('P015', 'M009'),
('P015', 'M014'),
('P015', 'M016'),
('P015', 'M017'),
('P015', 'M023'),
('P022', 'M025');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `person`
--

CREATE TABLE `person` (
  `PersonID` varchar(10) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Nationality` varchar(50) DEFAULT NULL,
  `BirthDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `person`
--

INSERT INTO `person` (`PersonID`, `FirstName`, `LastName`, `Nationality`, `BirthDate`) VALUES
('P001', 'Christopher', 'Nolan', 'British-American', '1970-07-30'),
('P002', 'Leonardo', 'DiCaprio', 'American', '1974-11-11'),
('P003', 'Joseph', 'Gordon-Levitt', 'American', '1981-02-17'),
('P004', 'Greta', 'Gerwig', 'American', '1983-08-04'),
('P005', 'Margot', 'Robbie', 'Australian', '1990-07-02'),
('P006', 'Tom', 'Hardy', 'British', '1977-09-15'),
('P007', 'Cillian', 'Murphy', 'Irish', '1976-05-25'),
('P008', 'Emma', 'Stone', 'American', '1988-11-06'),
('P009', 'Ryan', 'Gosling', 'Canadian', '1980-11-12'),
('P010', 'Hayao', 'Miyazaki', 'Japanese', '1941-01-05'),
('P011', 'Christian', 'Bale', 'British', '1974-01-30'),
('P012', 'Natalie', 'Portman', 'Israeli-American', '1981-06-09'),
('P013', 'Robert', 'Downey Jr.', 'American', '1965-04-04'),
('P014', 'Scarlett', 'Johansson', 'American', '1984-11-22'),
('P015', 'Quentin', 'Tarantino', 'American', '1963-03-27'),
('P016', 'Matt', 'Damon', 'American', '1970-10-08'),
('P017', 'Anne', 'Hathaway', 'American', '1982-11-12'),
('P018', 'Denzel', 'Washington', 'American', '1954-12-28'),
('P019', 'Zendaya', '', 'American', '1996-09-01'),
('P020', 'Timothée', 'Chalamet', 'American', '1995-12-27'),
('P021', 'Florence', 'Pugh', 'British', '1996-01-03'),
('P022', 'Tom', 'Cruise', 'American', '1962-07-03'),
('P023', 'Keanu', 'Reeves', 'Canadian', '1964-09-02'),
('P024', 'Harrison', 'Ford', 'American', '1942-07-13'),
('P025', 'Gal', 'Gadot', 'Israeli', '1985-04-30');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `genre`
--
ALTER TABLE `genre`
  ADD PRIMARY KEY (`GenreID`);

--
-- A tábla indexei `movie`
--
ALTER TABLE `movie`
  ADD PRIMARY KEY (`MovieID`),
  ADD KEY `GenreID` (`GenreID`);

--
-- A tábla indexei `movie_actor`
--
ALTER TABLE `movie_actor`
  ADD PRIMARY KEY (`PersonID`,`MovieID`),
  ADD KEY `MovieID` (`MovieID`);

--
-- A tábla indexei `movie_director`
--
ALTER TABLE `movie_director`
  ADD PRIMARY KEY (`PersonID`,`MovieID`),
  ADD KEY `MovieID` (`MovieID`);

--
-- A tábla indexei `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`PersonID`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `movie`
--
ALTER TABLE `movie`
  ADD CONSTRAINT `movie_ibfk_1` FOREIGN KEY (`GenreID`) REFERENCES `genre` (`GenreID`);

--
-- Megkötések a táblához `movie_actor`
--
ALTER TABLE `movie_actor`
  ADD CONSTRAINT `movie_actor_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `person` (`PersonID`),
  ADD CONSTRAINT `movie_actor_ibfk_2` FOREIGN KEY (`MovieID`) REFERENCES `movie` (`MovieID`);

--
-- Megkötések a táblához `movie_director`
--
ALTER TABLE `movie_director`
  ADD CONSTRAINT `movie_director_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `person` (`PersonID`),
  ADD CONSTRAINT `movie_director_ibfk_2` FOREIGN KEY (`MovieID`) REFERENCES `movie` (`MovieID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
