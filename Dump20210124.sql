-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: possystem_db
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `items_tbl`
--

DROP TABLE IF EXISTS `items_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `items_tbl` (
  `Item_Code` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Item_Name` varchar(45) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `Unit_Price` decimal(10,0) DEFAULT NULL,
  `Stocks_On_Hand` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Item_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items_tbl`
--

LOCK TABLES `items_tbl` WRITE;
/*!40000 ALTER TABLE `items_tbl` DISABLE KEYS */;
INSERT INTO `items_tbl` VALUES ('20001','Logitech G102','Gaming Mice',1000,'50'),('20002','Logitech G Pro','Gaming Headset',9000,'20'),('20003','Logitech Artic Pro','Gaming Headset',3000,'25'),('20004','Logitech G900','Gaming Streering Wheel',100000,'10'),('20005','Logitech G200','Bright Light',1000,'20'),('20006','Logitech G Pro Keyboard','Gaming Keyboard',8900,'30'),('20007','Logitech G504','Gaming Wireless Mouse',2500,'20'),('20008','Logitech G507','Gaming Chair',4250,'10');
/*!40000 ALTER TABLE `items_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `position_tbl`
--

DROP TABLE IF EXISTS `position_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `position_tbl` (
  `No` int NOT NULL AUTO_INCREMENT,
  `Position` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `position_tbl`
--

LOCK TABLES `position_tbl` WRITE;
/*!40000 ALTER TABLE `position_tbl` DISABLE KEYS */;
INSERT INTO `position_tbl` VALUES (1,'Admin'),(2,'Cashier'),(6,'Bagger'),(7,'Janitor');
/*!40000 ALTER TABLE `position_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction_tbl`
--

DROP TABLE IF EXISTS `transaction_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction_tbl` (
  `Quantity` int NOT NULL,
  `ItemCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ItemNo` int DEFAULT NULL,
  `ItemDescription` varchar(45) DEFAULT NULL,
  `Price` decimal(10,0) DEFAULT NULL,
  `Discount` int DEFAULT NULL,
  PRIMARY KEY (`Quantity`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction_tbl`
--

LOCK TABLES `transaction_tbl` WRITE;
/*!40000 ALTER TABLE `transaction_tbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaction_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_tbl`
--

DROP TABLE IF EXISTS `user_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_tbl` (
  `ID_No` int NOT NULL AUTO_INCREMENT,
  `Last_name` varchar(45) DEFAULT NULL,
  `First_name` varchar(45) DEFAULT NULL,
  `Middle_Initial` varchar(45) DEFAULT NULL,
  `Position` varchar(45) DEFAULT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID_No`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_tbl`
--

LOCK TABLES `user_tbl` WRITE;
/*!40000 ALTER TABLE `user_tbl` DISABLE KEYS */;
INSERT INTO `user_tbl` VALUES (1,'Sta.Ana','Wesley','Contreras','Admin','admin','admin'),(2,'Lim','Marcelo','Gomez','admin','admin','admin'),(3,'Abdul','Jabar','Agik','Bagger','Cashier','cashier'),(4,'test','test','test','Janitor','Bagger','bagger'),(5,'Kennedy','John','F','Janitor','Janitor','janitor'),(6,'Popoy','Basha','C','Janitor','Guard','guard'),(7,'sales','sales','sales','Cashier','Sales','sales'),(8,'brodie','brodie','brodie','Cashier','brodie','brodie'),(9,'test','test','test','Bagger','test','test'),(10,'test','test','test','Cashier','test','test'),(11,'test','test','test','Cashier','test','test'),(12,'qweq','qweq','qweq','Cashier','qweqw','qweqw'),(13,'test','test','test','Bagger','test','test'),(14,'test','test','test','Bagger','test','test'),(15,'test','test','test','Cashier','test','test'),(16,'test','test','test','Cashier','test','test'),(17,'Sta.Ana','Wesley','Contreras','admin','admin','admin');
/*!40000 ALTER TABLE `user_tbl` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-24  4:27:05
