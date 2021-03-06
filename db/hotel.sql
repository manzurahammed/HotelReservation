-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.25-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.4.0.5174
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for hotel
CREATE DATABASE IF NOT EXISTS `hotel` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */;
USE `hotel`;

-- Dumping structure for table hotel.customer
CREATE TABLE IF NOT EXISTS `customer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `full_name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `contact` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `address` text COLLATE utf8_unicode_ci,
  `due` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table hotel.customer: ~2 rows (approximately)
DELETE FROM `customer`;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` (`id`, `full_name`, `email`, `contact`, `address`, `due`) VALUES
	(1, 'asd', 'asd', '3435', 'sdas sds', 0.00),
	(3, 'asd', 'asd@tet.com', '3435', 'sdas sds', 80.00);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;

-- Dumping structure for table hotel.payment
CREATE TABLE IF NOT EXISTS `payment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cu_id` int(11) NOT NULL,
  `amount` decimal(10,2) NOT NULL DEFAULT '0.00',
  `p_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table hotel.payment: ~4 rows (approximately)
DELETE FROM `payment`;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` (`id`, `cu_id`, `amount`, `p_date`) VALUES
	(1, 3, 24.00, '2018-03-05 02:05:13'),
	(2, 3, 2.50, '2018-03-05 02:05:13'),
	(3, 2, 20.00, '2018-03-05 02:17:07'),
	(4, 3, 200.00, '2018-03-05 02:23:07');
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;

-- Dumping structure for table hotel.reservation
CREATE TABLE IF NOT EXISTS `reservation` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL DEFAULT '0',
  `chcek_in` date NOT NULL,
  `check_out` date NOT NULL,
  `adult` int(11) DEFAULT '0',
  `child` int(11) DEFAULT '0',
  `total` decimal(10,2) NOT NULL DEFAULT '0.00',
  `r_date` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table hotel.reservation: ~1 rows (approximately)
DELETE FROM `reservation`;
/*!40000 ALTER TABLE `reservation` DISABLE KEYS */;
INSERT INTO `reservation` (`id`, `customer_id`, `chcek_in`, `check_out`, `adult`, `child`, `total`, `r_date`) VALUES
	(1, 3, '2018-03-05', '2018-03-06', 2, 0, 323.56, '2018-03-05 01:36:00');
/*!40000 ALTER TABLE `reservation` ENABLE KEYS */;

-- Dumping structure for table hotel.room
CREATE TABLE IF NOT EXISTS `room` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `room_number` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '0',
  `floor` int(11) NOT NULL DEFAULT '0',
  `bed` int(11) NOT NULL DEFAULT '0',
  `quality` int(11) NOT NULL DEFAULT '0',
  `tv` tinyint(4) NOT NULL DEFAULT '0',
  `rf` tinyint(4) NOT NULL DEFAULT '0',
  `ac` tinyint(4) NOT NULL DEFAULT '0',
  `price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `book` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table hotel.room: ~2 rows (approximately)
DELETE FROM `room`;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` (`id`, `room_number`, `floor`, `bed`, `quality`, `tv`, `rf`, `ac`, `price`, `book`) VALUES
	(1, 'a-331', 1, 2, 2, 1, 0, 1, 23.56, 0),
	(3, 'a-45', 2, 1, 1, 0, 0, 1, 300.00, 1);
/*!40000 ALTER TABLE `room` ENABLE KEYS */;

-- Dumping structure for table hotel.room_res
CREATE TABLE IF NOT EXISTS `room_res` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `res_id` int(11) NOT NULL,
  `room_number` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `check_out` date NOT NULL,
  `price` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table hotel.room_res: ~2 rows (approximately)
DELETE FROM `room_res`;
/*!40000 ALTER TABLE `room_res` DISABLE KEYS */;
INSERT INTO `room_res` (`id`, `res_id`, `room_number`, `check_out`, `price`) VALUES
	(1, 1, 'a-331', '2018-03-06', 23.56),
	(2, 1, 'a-45', '2018-03-06', 300.00);
/*!40000 ALTER TABLE `room_res` ENABLE KEYS */;

-- Dumping structure for table hotel.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `last_name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `role` int(11) NOT NULL,
  `contact_number` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table hotel.users: ~3 rows (approximately)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id`, `first_name`, `last_name`, `password`, `email`, `role`, `contact_number`) VALUES
	(1, 'asd', 'asdasd', 'e10adc3949ba59abbe56e057f20f883e', 'manzur@gmail.com', 1, NULL),
	(2, 'sadfasd', 'manzyr', 'd2762f79d9ec16dba82af6ba40a8f264', 'sdfsdf12@gmail.com', 2, '122343445'),
	(3, 'manzujdf', 'asdfsd', 'e10adc3949ba59abbe56e057f20f883e', 'sdfsdf@gmail.com', 2, '0234324');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
