-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 17, 2021 at 04:11 AM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 7.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `contato`
--

-- --------------------------------------------------------

--
-- Table structure for table `pessoa`
--

CREATE TABLE `pessoa` (
  `idPessoa` int(11) NOT NULL,
  `nomePessoa` varchar(150) CHARACTER SET utf8 NOT NULL,
  `telefonePessoa` varchar(20) CHARACTER SET utf8 NOT NULL,
  `redeSocialPessoa` varchar(150) CHARACTER SET utf8 NOT NULL,
  `ativoPessoa` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pessoa`
--

INSERT INTO `pessoa` (`idPessoa`, `nomePessoa`, `telefonePessoa`, `redeSocialPessoa`, `ativoPessoa`) VALUES
(1, 'Alex Luciano Roesler Rese', '47 9 9601 9526', 'alexrese', 0),
(2, 'HUGO SILVA DE SOUZA', '47 99622-9744', 'hugonoid1', 1),
(3, 'João Carlo Vieira', '48 988504214', 'http://www.facebook.com/JoaoCarlosVieira', 1),
(4, 'BRUNA BRENDA MAFRA', '48 99958-1568', '@brubsmafra', 1),
(5, 'TIAGO BERLANDA', '47 99218-277', '@berlandatiago', 1),
(6, 'Gabriel Seidel Nunes\r\n\r\n', '47 9 9922-6050', '@gaseines', 1),
(7, 'Alexandre Fedrizzi', '48 99127-7555', 'https://github.com/AleFedrizzi', 1),
(8, 'Alexandre F Souza ', '47 984733549', '#facebook.com/alefran2000', 1),
(9, 'Evandro Orlandini', '47 9923 8104', 'facebook.com/evan.orlandini', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pessoa`
--
ALTER TABLE `pessoa`
  ADD PRIMARY KEY (`idPessoa`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pessoa`
--
ALTER TABLE `pessoa`
  MODIFY `idPessoa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
