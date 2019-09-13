-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 12, 2019 at 01:00 PM
-- Server version: 5.7.24
-- PHP Version: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `queuesystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
CREATE TABLE IF NOT EXISTS `province` (
  `provinceid` int(200) NOT NULL AUTO_INCREMENT,
  `province` varchar(200) NOT NULL,
  PRIMARY KEY (`provinceid`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `province`
--

INSERT INTO `province` (`provinceid`, `province`) VALUES
(1, 'Gauteng'),
(2, 'Mpumalanga'),
(3, 'Eastern-Cape'),
(4, 'Free-State'),
(5, 'KwaZulu-Natal'),
(6, 'Limpopo'),
(7, 'Northern Cape'),
(8, 'North West'),
(9, 'Western Cape');

-- --------------------------------------------------------

--
-- Table structure for table `regorgs`
--

DROP TABLE IF EXISTS `regorgs`;
CREATE TABLE IF NOT EXISTS `regorgs` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `orgname` varchar(200) NOT NULL,
  `password` varchar(50) NOT NULL,
  `email` varchar(80) NOT NULL,
  `regdate` varchar(15) NOT NULL,
  `orgimage` blob NOT NULL,
  `serviceid` int(200) NOT NULL,
  `province` varchar(200) DEFAULT NULL,
  `city` varchar(200) DEFAULT NULL,
  `suburb` varchar(200) DEFAULT NULL,
  `distance` int(200) DEFAULT NULL,
  `provinceid` int(200) NOT NULL,
  `lng` varchar(100) NOT NULL,
  `lat` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=623469 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `regorgs`
--

INSERT INTO `regorgs` (`ID`, `orgname`, `password`, `email`, `regdate`, `orgimage`, `serviceid`, `province`, `city`, `suburb`, `distance`, `provinceid`, `lng`, `lat`) VALUES
(1, 'medibay', 'med', 'med@health.co.za', '', '', 1, 'Gauteng', 'Pretoria', 'MenloPark', 60, 1, '28.2583', '-25.7646'),
(623456, 'org1', 'org1', 'org1@gmail.com', '', '', 5, 'Mpumalanga', 'Witbank', 'ReynoRIdge', 139, 2, '29.24205', '-25.91169'),
(123, 'hospital', '1234', 'hospital@gmail.com', '', '', 1, 'Western Cape', 'Stellenbosche', 'Bottelary Hills', 1369, 9, '39.833332', '-98.583336'),
(124235, 'Absa', 'banker1', 'bank@gmail.com', '', '', 2, 'Western Cape', 'CapeTown', 'Helderberg Rural', 1399, 9, '18.820076', '-34.079370'),
(623457, 'waterpark', 'waterfun', 'waterpark@gmail.com', '', 0x89504e470d0a1a0a0000000d494844520000003d000000250806000000f1e7e11f0000043d49444154780162f0c92c04b4630e30b22c51188e870f6bdbf6eeb36d06cfb66ddbc6b56ddbd1b56d866bef4cce3dff66abd353b7773253b3de4ef22753a74ffd555f692ad52322a2d056a28bdadae82a595de1df4c94dee2a2a75a5df49a2c3957fb617b61ea9db6e7a71c61915ed6e72657d99f9d54801ceb73533e0d7a66ca052ac059a36bc7393edfee727cb29164a15db41f0870f698ba238e2fb693a1ff7393db58df68d01af06b0bc8fef10624d12593eabe75fe59b3d0fed996bab756373d46444edb735346dadf5e4ed617676df5b753f1c36b47c117f519d0532f4c23b48bf655c11386d51ef4c91fe002dafefae2e3a8c49d1b89e5464491cd4499ad449769c0efac24e4387e3e35d7df4e39bed8891926db471bb688187c9b8852b172d02ebea31f2ad08e2f77a26f806bd4f94730cbb5d6e727c6250caf3dd0fefd8dc52e0d5acc3077221165ebf3937f154b5a0f8cd9c760f8db29d95f16e2f88e3c9455fd314946df11d7fc05340290068c65fccadc6adec333030496fcfdc851f0bf6556fd878eaff69e11650865c445d910fa8619f5b7612f6354ecefadf500e643edd1be0c6db4af5146dc2b34f61a0e2f80cbc0bc276840ceb41e3cfcff9aa96249031839bd0dadee2f418bd1c1ffb0d1e98ab81835954ec9feb202f6ff7a8f1bf5435f9db14ebe00a18c38be234f83be624afd3bdefee7c4be409e42a7baddffca2975f37df1471ef2b51b93e17e90f605f2143ad5edfeb891dd3cb361a998715988e33bf290efd3dd1871d50e05ee1ff8dd1b71012ca0078d4ce8412513da8436a14d6813da8436a14d6871f7665dc4ba4a5617f9a7b39e62bd26ab53e8a8a8a83b594758a457646464554c4c4c0172f8f7a74141414aefde4f3ef9e4b8f2f27257494909c942bb683f1060f63f525151419df8b771dfb5776f0d382929890a0b0b0949afbefaeab7b7dd76dbc2b2b2b2ba214386b4bf7b73cec8f4f4748a8d8df5fbddfba1871e1a055fd49707950794d02eda57057ff0c1070ffae20f700d3a3535f5382a71e5911d4b2e9295c9ba4c006765651172aebbee3abfdfbd790630c3545c5cecf1eecd4ac5ca41bbf88e7ea8405f74d14584fa4545451eefdeac6ba3a3a3e3d8ff4087bf4b8316334c44891dcbf857b1a4f5c0987d52780696fd65218eefc85381d6add0f1d2b9f11af6f9a79f7e3a4df86bd008400238333393e2e3e3abf9f7cc0081257f851c3ffc3ffae8a30f2fb9e49233a20c71d9cdf1a5a26c08fdde7befdd86bdcc4b857272723c8079101eedcbd046fb1a65c4bd4263afe1f002b80c9c9292427d7ca6976266a5993e8315e0155a0f7efffdf74f154b1ac0c8e9cbd0f7de7bef1fe2bf5ab7af2fbaf8e28bbf3f075aec03fc0f1b9dae888b5153e994ec2fab0bfcdd3efabb35e8b7de7aeb1d6fff73625f204fa1533de1bfc717ff37df7cd3f3dddbe8e493f785c2336d4ff95770fd83ec237b7b9ce024bf7b7bbb1b93fabb744ffa57b0be61fd6570ff7e4a004367010a9dd4ecccaf02480000000049454e44ae426082, 3, 'Gauteng', 'Johannesburg', 'AucklandPark', 2, 1, '28.240690', '-26.161145'),
(623468, 'Nedbank', 'banker2', 'bank2@gmail.com', '', '', 2, 'Gauteng', 'Johannesburg', 'HillBrow', 13, 1, '28.047899', '-26.189626'),
(623466, 'proper', 'proper', 'proper@gmail.com', '', '', 5, 'Mpumalanga', 'Middleburg', 'Groenkol', 166, 2, '18.699736', '-32.110294'),
(623467, 'anglo', 'agnlo', 'anglo@gmail.com', '07/07/2019', '', 5, 'Mpumalanga', 'Middleburg', 'Eastdene', 170, 2, '29.485150', '-25.769371');

-- --------------------------------------------------------

--
-- Table structure for table `reguser`
--

DROP TABLE IF EXISTS `reguser`;
CREATE TABLE IF NOT EXISTS `reguser` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `username` varchar(200) NOT NULL,
  `name` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `birthdate` varchar(15) NOT NULL,
  `gender` varchar(8) NOT NULL,
  `email` varchar(200) NOT NULL,
  `password` varchar(50) NOT NULL,
  `verified` int(11) DEFAULT NULL,
  `code` varchar(200) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `email` (`email`)
) ENGINE=MyISAM AUTO_INCREMENT=7657399 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reguser`
--

INSERT INTO `reguser` (`ID`, `username`, `name`, `surname`, `birthdate`, `gender`, `email`, `password`, `verified`, `code`) VALUES
(7657367, 'new', 'new', 'new', '2014-04-30', 'Male', 'new@gmail.com', 'new', 0, ''),
(7657368, 'test', 'test', 'test', '02/07/2019', 'Female', 'test@gmail.com', 'test', 0, ''),
(7657369, 'matter', 'matter', 'werner', '19/04/1996', 'Male', 'matter@gmail.com', 'matter', 0, ''),
(7657370, 'Shane', 'shane', 'shane', '24/04/2000', 'male', 'shane@gmail.com', 'shane', 0, ''),
(7657373, 'wwww', 'wwww', 'wwww', '02/09/2019', 'Other', 'wwww@gmail.com', 'wwww', 0, ''),
(7657396, 'mike', 'mike', 'toll', '03/09/2019', 'Male', 'michaeltollemache73@gmail.com', 'mike', 0, '9be3c564bff6b41f8f3fd3bc0199c808'),
(7657395, 'shane', 'Shane', 'toll', '02/09/2019', 'Female', 'sjtollemache@gmail.com', 'windy', 1, '19eafdd53ec14cb53bdee635f4a07346'),
(7657397, 'matter', 'matter', 'werner', '02/09/2019', 'Other', 'Matthewwerner45@gmail.com', 'matter', 0, '65201550e055450f0937fbe6ab80a1e4'),
(7657398, 'ujacc', 'ujacc', 'ujacc', '03/09/2019', 'Other', '215010657@student.uj.ac.za', 'ujacc', 1, '9fc4a9cd2486c9cb5cca90972164f6ee');

-- --------------------------------------------------------

--
-- Table structure for table `tickets`
--

DROP TABLE IF EXISTS `tickets`;
CREATE TABLE IF NOT EXISTS `tickets` (
  `ticketnumber` int(60) NOT NULL AUTO_INCREMENT,
  `orgname` varchar(205) NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `ID` int(200) DEFAULT NULL,
  PRIMARY KEY (`ticketnumber`)
) ENGINE=MyISAM AUTO_INCREMENT=146 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tickets`
--

INSERT INTO `tickets` (`ticketnumber`, `orgname`, `date`, `ID`) VALUES
(1, 'medibay', '2019-08-30 14:53:59', 7657370),
(2, 'waterpark', '2019-08-30 14:53:29', 7657369),
(130, 'medibay', '2019-08-30 14:54:05', 7657370),
(129, 'waterpark', '2019-08-30 14:54:10', 7657370),
(128, 'org1', '2019-08-30 14:53:35', 7657369),
(131, 'Absa', '2019-09-01 11:38:55', 7657370),
(132, 'Nedbank', '2019-09-01 11:38:58', 7657370),
(133, 'proper', '2019-09-01 11:38:59', 7657370),
(134, 'anglo', '2019-09-01 11:39:00', 7657370),
(135, 'hospital', '2019-09-01 11:39:02', 7657370),
(136, 'Nedbank', '2019-09-01 11:39:03', 7657370),
(137, 'medibay', '2019-09-01 12:16:07', 7657370),
(138, 'proper', '2019-09-01 12:16:14', 7657369),
(139, 'waterpark', '2019-09-01 12:36:00', 7657370),
(140, 'Absa', '2019-09-01 12:45:43', NULL),
(141, 'Absa', '2019-09-01 12:46:01', NULL),
(142, 'Absa', '2019-09-01 12:46:31', NULL),
(143, 'Absa', '2019-09-01 13:00:34', NULL),
(144, 'hospital', '2019-09-01 13:21:59', NULL),
(145, 'hospital', '2019-09-12 05:58:41', 7657370);

-- --------------------------------------------------------

--
-- Table structure for table `typeofservices`
--

DROP TABLE IF EXISTS `typeofservices`;
CREATE TABLE IF NOT EXISTS `typeofservices` (
  `serviceid` int(200) NOT NULL AUTO_INCREMENT,
  `typeofservice` varchar(200) NOT NULL,
  PRIMARY KEY (`serviceid`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `typeofservices`
--

INSERT INTO `typeofservices` (`serviceid`, `typeofservice`) VALUES
(1, 'medical'),
(2, 'bank'),
(3, 'park'),
(4, 'repairs'),
(5, 'other');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
