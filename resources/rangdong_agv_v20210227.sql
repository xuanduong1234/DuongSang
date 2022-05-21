-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: rangdong_agv
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `agv_info`
--

DROP TABLE IF EXISTS `agv_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_info` (
  `id` varchar(50) NOT NULL,
  `agv_id` int DEFAULT NULL,
  `zone_id` int DEFAULT NULL,
  `parking_lot` int DEFAULT NULL,
  `manufacturing_date` varchar(100) DEFAULT NULL,
  `operation_start_date` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `total_active_hour` float DEFAULT NULL,
  `total_inactive_hour` float DEFAULT NULL,
  `material_history_material_code` varchar(100) NOT NULL,
  `agv_statistics_id` varchar(50) NOT NULL,
  `agv_params_id` varchar(50) NOT NULL,
  `agv_params_latest_id` varchar(100) NOT NULL,
  PRIMARY KEY (`id`,`material_history_material_code`,`agv_statistics_id`,`agv_params_id`,`agv_params_latest_id`),
  KEY `fk_agv_info_material_history1_idx` (`material_history_material_code`),
  KEY `fk_agv_info_agv_statistics1_idx` (`agv_statistics_id`),
  KEY `fk_agv_info_agv_params1_idx` (`agv_params_id`),
  KEY `fk_agv_info_agv_params_latest1_idx` (`agv_params_latest_id`),
  CONSTRAINT `fk_agv_info_agv_params1` FOREIGN KEY (`agv_params_id`) REFERENCES `agv_params` (`id`),
  CONSTRAINT `fk_agv_info_agv_params_latest1` FOREIGN KEY (`agv_params_latest_id`) REFERENCES `agv_params_latest` (`id`),
  CONSTRAINT `fk_agv_info_agv_statistics1` FOREIGN KEY (`agv_statistics_id`) REFERENCES `agv_statistics` (`id`),
  CONSTRAINT `fk_agv_info_material_history1` FOREIGN KEY (`material_history_material_code`) REFERENCES `material_history` (`material_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agv_info`
--

LOCK TABLES `agv_info` WRITE;
/*!40000 ALTER TABLE `agv_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agv_params`
--

DROP TABLE IF EXISTS `agv_params`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_params` (
  `id` varchar(50) NOT NULL,
  `timestamp` timestamp NULL DEFAULT NULL,
  `speed` float DEFAULT NULL,
  `v_batt` float DEFAULT NULL,
  `batt_capacity` int DEFAULT NULL,
  `state` varchar(100) DEFAULT NULL,
  `shelf1` varchar(100) DEFAULT NULL,
  `shelf2` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agv_params`
--

LOCK TABLES `agv_params` WRITE;
/*!40000 ALTER TABLE `agv_params` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_params` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agv_params_latest`
--

DROP TABLE IF EXISTS `agv_params_latest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_params_latest` (
  `id` varchar(100) NOT NULL,
  `timestamp` timestamp NULL DEFAULT NULL,
  `speed` float DEFAULT NULL,
  `v_batt` float DEFAULT NULL,
  `batt_capacity` int DEFAULT NULL,
  `state` varchar(100) DEFAULT NULL,
  `shelf1` varchar(100) DEFAULT NULL,
  `shelf2` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agv_params_latest`
--

LOCK TABLES `agv_params_latest` WRITE;
/*!40000 ALTER TABLE `agv_params_latest` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_params_latest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agv_statistics`
--

DROP TABLE IF EXISTS `agv_statistics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_statistics` (
  `id` varchar(50) NOT NULL,
  `date` varchar(45) DEFAULT NULL,
  `active_hour` double DEFAULT NULL,
  `inactive_hour` double DEFAULT NULL,
  `delivery_failures` int DEFAULT NULL,
  `distance` double DEFAULT NULL,
  `total_load` int DEFAULT NULL,
  `trip_number` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agv_statistics`
--

LOCK TABLES `agv_statistics` WRITE;
/*!40000 ALTER TABLE `agv_statistics` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_statistics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `material_history`
--

DROP TABLE IF EXISTS `material_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `material_history` (
  `material_code` varchar(100) NOT NULL,
  `delivery_station` varchar(100) DEFAULT NULL,
  `collection_time` datetime DEFAULT NULL,
  `agv_fullid` varchar(45) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `weight` int DEFAULT NULL,
  PRIMARY KEY (`material_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material_history`
--

LOCK TABLES `material_history` WRITE;
/*!40000 ALTER TABLE `material_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `material_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rfid_tags`
--

DROP TABLE IF EXISTS `rfid_tags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rfid_tags` (
  `tag_id` int NOT NULL,
  `tag_label` varchar(100) DEFAULT NULL,
  `zone_id` int DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,
  `tag_layout_tag_id` int NOT NULL,
  PRIMARY KEY (`tag_id`,`tag_layout_tag_id`),
  KEY `fk_rfid_tags_tag_layout_idx` (`tag_layout_tag_id`),
  CONSTRAINT `fk_rfid_tags_tag_layout` FOREIGN KEY (`tag_layout_tag_id`) REFERENCES `tag_layout` (`tag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rfid_tags`
--

LOCK TABLES `rfid_tags` WRITE;
/*!40000 ALTER TABLE `rfid_tags` DISABLE KEYS */;
/*!40000 ALTER TABLE `rfid_tags` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tag_layout`
--

DROP TABLE IF EXISTS `tag_layout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tag_layout` (
  `tag_id` int NOT NULL,
  `neighbor` int DEFAULT NULL,
  `direction` int DEFAULT NULL,
  `distance` int DEFAULT NULL,
  PRIMARY KEY (`tag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tag_layout`
--

LOCK TABLES `tag_layout` WRITE;
/*!40000 ALTER TABLE `tag_layout` DISABLE KEYS */;
/*!40000 ALTER TABLE `tag_layout` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-27 19:02:05
