-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: dnbsndb
-- ------------------------------------------------------
-- Server version	5.5.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `dnbsndb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `dnbsndb` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `dnbsndb`;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contact` (
  `id` varchar(100) NOT NULL,
  `name` varchar(145) NOT NULL,
  `mobile` varchar(45) DEFAULT 'N/A',
  `homePhone` varchar(45) DEFAULT 'N/A',
  `officePhone` varchar(45) DEFAULT 'N/A',
  `email` varchar(75) DEFAULT 'N/A',
  `address` varchar(45) DEFAULT 'N/A',
  `faxNumber` varchar(45) DEFAULT 'N/A',
  `remark` varchar(245) DEFAULT 'N/A',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
/*!40000 ALTER TABLE `contact` DISABLE KEYS */;
INSERT INTO `contact` VALUES ('41357.0306937384','Amit Paul','9804567830','033-09871381','033-48768767','amit.paul23@gmail.com','Kolkata','033-02287698','Friends'),('41362.7815689005','Anirban','jkkk','kkk','kk','k','k','kk','k');
/*!40000 ALTER TABLE `contact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `note`
--

DROP TABLE IF EXISTS `note`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `note` (
  `id` varchar(100) NOT NULL,
  `note` varchar(10005) NOT NULL,
  `date` datetime DEFAULT NULL,
  `sharedWith` varchar(45) DEFAULT '"N/A''',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `note`
--

LOCK TABLES `note` WRITE;
/*!40000 ALTER TABLE `note` DISABLE KEYS */;
INSERT INTO `note` VALUES ('41356.9970790625','Buy a Wrist Watch  ','2013-03-23 00:00:00','\"N/A\''),('41362.53521875','hi all ','2013-03-29 00:00:00','\"N/A\'');
/*!40000 ALTER TABLE `note` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `password`
--

DROP TABLE IF EXISTS `password`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `password` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `password` varchar(45) NOT NULL,
  `email` varchar(100) NOT NULL,
  `userId` varchar(100) DEFAULT 'N/A',
  `secretQuestion` varchar(200) DEFAULT 'N/A',
  `secretAnswer` varchar(200) DEFAULT 'N/A',
  `otherInfo` varchar(200) DEFAULT 'N/A',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `password`
--

LOCK TABLES `password` WRITE;
/*!40000 ALTER TABLE `password` DISABLE KEYS */;
INSERT INTO `password` VALUES ('41357.0330223032','Google Mail','idanir34ban','anirban.nandy38@gmail.com','anirban.nandy38','Nick Name','Suman','NOthing');
/*!40000 ALTER TABLE `password` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `task` (
  `taskId` varchar(100) NOT NULL,
  `priority` varchar(45) DEFAULT NULL,
  `details` varchar(545) NOT NULL,
  `status` varchar(45) DEFAULT 'N/A',
  PRIMARY KEY (`taskId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task`
--

LOCK TABLES `task` WRITE;
/*!40000 ALTER TABLE `task` DISABLE KEYS */;
/*!40000 ALTER TABLE `task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` varchar(100) NOT NULL,
  `userid` varchar(45) DEFAULT NULL,
  `hints` varchar(45) DEFAULT NULL,
  `passwrd` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('41339.6946734259','1','erter','1'),('41342.4463346528','anirban','anirban','anirban'),('41356.7146045718','fgjhf','2232','123');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-03-29 19:01:28
