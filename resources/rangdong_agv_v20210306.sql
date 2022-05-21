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
-- Table structure for table `agv_daily_statistics`
--

DROP TABLE IF EXISTS `agv_daily_statistics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_daily_statistics` (
  `date` date NOT NULL,
  `id` varchar(10) NOT NULL,
  `active_hour` double DEFAULT NULL,
  `inactive_hour` double DEFAULT NULL,
  `delivery_failures` int DEFAULT NULL,
  `distance` double DEFAULT NULL,
  `total_load` int DEFAULT NULL,
  `trip_quantity` int DEFAULT NULL,
  `delivery_success` int DEFAULT NULL,
  KEY `date_index` (`date`) /*!80000 INVISIBLE */,
  KEY `date_id_index` (`date`,`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agv_info`
--

DROP TABLE IF EXISTS `agv_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_info` (
  `id` varchar(10) NOT NULL COMMENT 'agv full id (zone_id + agv_id',
  `agv_id` int NOT NULL,
  `zone_id` int NOT NULL,
  `parking_lot` int NOT NULL,
  `model` varchar(45) DEFAULT NULL,
  `manufacturing_date` varchar(45) DEFAULT NULL,
  `operation_start_date` varchar(45) DEFAULT NULL,
  `state` varchar(45) DEFAULT NULL,
  `total_active_hour` double DEFAULT NULL,
  `total_inactive_hour` double DEFAULT NULL,
  `control_mode` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_inidex` (`id`,`agv_id`) /*!80000 INVISIBLE */
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agv_material`
--

DROP TABLE IF EXISTS `agv_material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_material` (
  `trip_id` int NOT NULL,
  `id` int NOT NULL COMMENT 'agv full id (zone_id + agv_id)',
  `timestamp` bigint NOT NULL,
  `shelf_material1` varchar(45) DEFAULT NULL COMMENT 'material_code if carrying material; 1 if empty tray; 0 if no load',
  `shelf_quantity1` int DEFAULT NULL,
  `shelf_material2` varchar(45) DEFAULT NULL COMMENT 'material_code if carrying material; 1 if empty tray; 0 if no load',
  `shelf_quantity2` int DEFAULT NULL,
  `trip_state` int DEFAULT NULL COMMENT 'state of the trip: 1 - wait for starting; 2 - in progress; 3 - completed; 4 - incomplete error (cannot complete); 5 - reserved',
  `timeCall` bigint DEFAULT NULL COMMENT 'optional\n',
  `timeStart` bigint DEFAULT NULL COMMENT 'optional\\n',
  `timeCollect` bigint DEFAULT NULL COMMENT 'optional\\n',
  `timeDeliver` bigint DEFAULT NULL COMMENT 'optional\\n',
  `timeCompelete` bigint DEFAULT NULL COMMENT 'optional\\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agv_params`
--

DROP TABLE IF EXISTS `agv_params`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_params` (
  `id` varchar(50) NOT NULL,
  `timestamp` timestamp NOT NULL,
  `state` varchar(45) DEFAULT NULL,
  `speed` int DEFAULT NULL,
  `v_batt` int DEFAULT NULL,
  `batt_capacity` int DEFAULT NULL,
  `position` int DEFAULT NULL,
  KEY `index_time` (`timestamp`) /*!80000 INVISIBLE */,
  KEY `index_id` (`id`) /*!80000 INVISIBLE */,
  KEY `index_id_time` (`id`,`timestamp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agv_params_latest`
--

DROP TABLE IF EXISTS `agv_params_latest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_params_latest` (
  `id` varchar(45) NOT NULL COMMENT 'full id',
  `timestamp` bigint NOT NULL,
  `state` varchar(45) DEFAULT NULL,
  `speed` int DEFAULT NULL,
  `v_batt` int DEFAULT NULL,
  `batt_capacity` int DEFAULT NULL,
  `position` int DEFAULT NULL,
  `shelf1` varchar(45) DEFAULT NULL COMMENT 'material_code if carrying material; 1 if empty tray; 0 if no load',
  `shelf2` varchar(45) DEFAULT NULL COMMENT 'material_code if carrying material; 1 if empty tray; 0 if no load',
  `control_mode` int DEFAULT NULL,
  KEY `index_id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agv_system_daily_summary`
--

DROP TABLE IF EXISTS `agv_system_daily_summary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_system_daily_summary` (
  `date` date NOT NULL,
  `zone_id` int NOT NULL,
  `agv_quantity` int DEFAULT NULL,
  `total_active_hour` double DEFAULT NULL,
  `total_inactive_hour` double DEFAULT NULL,
  `total_load` int DEFAULT NULL,
  `trip_quantity` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agv_system_summary`
--

DROP TABLE IF EXISTS `agv_system_summary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agv_system_summary` (
  `zone_id` int NOT NULL,
  `agv_quantity` int DEFAULT NULL,
  `total_active_hour` double DEFAULT NULL,
  `total_inactive_hour` double DEFAULT NULL,
  `total_load` int DEFAULT NULL,
  `trip_quantity` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `material_history`
--

DROP TABLE IF EXISTS `material_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `material_history` (
  `material_code` varchar(45) NOT NULL,
  `delivery_station` varchar(45) DEFAULT NULL,
  `collection_time` bigint DEFAULT NULL,
  `delivery_time` bigint DEFAULT NULL,
  `id` varchar(10) NOT NULL COMMENT 'agv_full id',
  `quantity` int DEFAULT NULL,
  `weight` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `rfid_tags`
--

DROP TABLE IF EXISTS `rfid_tags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rfid_tags` (
  `tag_id` int NOT NULL,
  `tag_label` varchar(45) DEFAULT NULL,
  `zone_id` int NOT NULL,
  `location` varchar(45) NOT NULL,
  `line_id` int NOT NULL,
  `branch_id` int NOT NULL,
  PRIMARY KEY (`tag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tag_layout`
--

DROP TABLE IF EXISTS `tag_layout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tag_layout` (
  `tn_id` varchar(10) NOT NULL,
  `tag_id` int NOT NULL,
  `neighbor` int NOT NULL,
  `direction` int DEFAULT NULL,
  `distance` int DEFAULT NULL,
  `command` int NOT NULL,
  `neighbor_command` int NOT NULL,
  PRIMARY KEY (`tn_id`),
  KEY `tag_id_index` (`tag_id`),
  KEY `neighbor_index` (`neighbor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-03-06 17:22:55
