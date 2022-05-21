-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: rangdong_agv_test2
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
-- Dumping data for table `agv_daily_statistics`
--

LOCK TABLES `agv_daily_statistics` WRITE;
/*!40000 ALTER TABLE `agv_daily_statistics` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_daily_statistics` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `agv_info`
--

LOCK TABLES `agv_info` WRITE;
/*!40000 ALTER TABLE `agv_info` DISABLE KEYS */;
INSERT INTO `agv_info` VALUES ('0101',1,1,1,'HUS01',NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `agv_info` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `agv_material`
--

LOCK TABLES `agv_material` WRITE;
/*!40000 ALTER TABLE `agv_material` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_material` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `agv_params_latest`
--

LOCK TABLES `agv_params_latest` WRITE;
/*!40000 ALTER TABLE `agv_params_latest` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_params_latest` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `agv_system_daily_summary`
--

LOCK TABLES `agv_system_daily_summary` WRITE;
/*!40000 ALTER TABLE `agv_system_daily_summary` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_system_daily_summary` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `agv_system_summary`
--

LOCK TABLES `agv_system_summary` WRITE;
/*!40000 ALTER TABLE `agv_system_summary` DISABLE KEYS */;
/*!40000 ALTER TABLE `agv_system_summary` ENABLE KEYS */;
UNLOCK TABLES;

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
  `tag_label` varchar(45) DEFAULT NULL,
  `zone_id` int NOT NULL,
  `location` varchar(45) NOT NULL,
  `line_id` int NOT NULL,
  `branch_id` int NOT NULL,
  PRIMARY KEY (`tag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rfid_tags`
--

LOCK TABLES `rfid_tags` WRITE;
/*!40000 ALTER TABLE `rfid_tags` DISABLE KEYS */;
INSERT INTO `rfid_tags` VALUES (1,NULL,1,'On route',0,0),(2,NULL,1,'On route',0,0),(3,NULL,1,'On route',0,0),(4,NULL,1,'On route',0,0),(5,NULL,1,'On route',0,5),(6,NULL,1,'On route',0,0),(7,NULL,1,'On route',0,0),(8,NULL,1,'On route',0,8),(9,NULL,1,'On route',0,0),(10,NULL,1,'On route',0,0),(11,NULL,1,'On route',0,11),(12,NULL,1,'On route',0,0),(13,NULL,1,'On route',0,0),(14,NULL,1,'On route',0,14),(15,NULL,1,'On route',0,0),(16,NULL,1,'On route',0,0),(17,NULL,1,'On route',0,17),(18,NULL,1,'On route',0,0),(19,NULL,1,'On route',0,0),(20,NULL,1,'On route',0,20),(21,NULL,1,'On route',0,0),(22,NULL,1,'On route',0,22),(23,NULL,1,'On route',0,23),(24,NULL,1,'On route',0,5),(25,NULL,1,'On route',0,8),(26,NULL,1,'On route',0,8),(27,NULL,1,'On route',0,8),(28,NULL,1,'On route',0,8),(29,NULL,1,'On route',0,8),(30,NULL,1,'On route',0,8),(31,NULL,1,'On route',0,8),(32,NULL,1,'On route',0,11),(33,NULL,1,'On route',0,14),(34,NULL,1,'On route',0,14),(35,NULL,1,'On route',0,14),(36,NULL,1,'On route',0,14),(37,NULL,1,'On route',0,14),(38,NULL,1,'On route',0,14),(39,NULL,1,'On route',0,14),(40,NULL,1,'On route',0,17),(41,NULL,1,'On route',0,20),(42,NULL,1,'On route',0,20),(43,NULL,1,'On route',0,20),(44,NULL,1,'On route',0,20),(45,NULL,1,'On route',0,20),(46,NULL,1,'On route',0,20),(47,NULL,1,'On route',0,20),(48,NULL,1,'On route',0,23),(49,NULL,1,'On route',0,22),(50,NULL,1,'On route',0,22),(51,NULL,1,'On route',0,22),(52,NULL,1,'On route',0,22),(53,NULL,1,'On route',0,22),(54,NULL,1,'On route',0,22),(55,NULL,1,'On route',0,22),(115,NULL,1,'Parking',0,115),(116,NULL,1,'Parking',0,116),(117,NULL,1,'Parking',0,117),(145,NULL,1,'Delivery station',1,5),(146,NULL,1,'Delivery station',1,8),(147,NULL,1,'Delivery station',1,8),(148,NULL,1,'Delivery station',1,8),(149,NULL,1,'Delivery station',1,8),(150,NULL,1,'Delivery station',1,8),(151,NULL,1,'Delivery station',1,8),(152,NULL,1,'Delivery station',1,8),(153,NULL,1,'Delivery station',2,11),(154,NULL,1,'Delivery station',2,14),(155,NULL,1,'Delivery station',2,14),(156,NULL,1,'Delivery station',2,14),(157,NULL,1,'Delivery station',2,14),(158,NULL,1,'Delivery station',2,14),(159,NULL,1,'Delivery station',2,14),(160,NULL,1,'Delivery station',2,14),(161,NULL,1,'Delivery station',3,17),(162,NULL,1,'Delivery station',3,20),(163,NULL,1,'Delivery station',3,20),(164,NULL,1,'Delivery station',3,20),(165,NULL,1,'Delivery station',3,20),(166,NULL,1,'Delivery station',3,20),(167,NULL,1,'Delivery station',3,20),(168,NULL,1,'Delivery station',3,20),(169,NULL,1,'Delivery station',4,23),(170,NULL,1,'Delivery station',4,22),(171,NULL,1,'Delivery station',4,22),(172,NULL,1,'Delivery station',4,22),(173,NULL,1,'Delivery station',4,22),(174,NULL,1,'Delivery station',4,22),(175,NULL,1,'Delivery station',4,22),(176,NULL,1,'Delivery station',4,22),(245,NULL,1,'Feeding station',0,0),(246,NULL,1,'Feeding station',0,0),(247,NULL,1,'Feeding station',0,0),(248,NULL,1,'Feeding station',0,0);
/*!40000 ALTER TABLE `rfid_tags` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `station_info`
--

DROP TABLE IF EXISTS `station_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `station_info` (
  `tag_id` int NOT NULL,
  `name` varchar(45) NOT NULL,
  `line_id` int NOT NULL,
  `last_delivery_time` bigint DEFAULT NULL,
  `material_code` varchar(255) DEFAULT NULL,
  `quantity` int NOT NULL,
  `status` int NOT NULL,
  PRIMARY KEY (`tag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `station_info`
--

LOCK TABLES `station_info` WRITE;
/*!40000 ALTER TABLE `station_info` DISABLE KEYS */;
INSERT INTO `station_info` VALUES (145,'Delivery station',1,NULL,NULL,0,0),(146,'Delivery station',1,NULL,NULL,0,0),(147,'Delivery station',1,NULL,NULL,0,0),(148,'Delivery station',1,NULL,NULL,0,0),(149,'Delivery station',1,NULL,NULL,0,0),(150,'Delivery station',1,NULL,NULL,0,0),(151,'Delivery station',1,NULL,NULL,0,0),(152,'Delivery station',1,NULL,NULL,0,0),(153,'Delivery station',2,NULL,NULL,0,0),(154,'Delivery station',2,NULL,NULL,0,0),(155,'Delivery station',2,NULL,NULL,0,0),(156,'Delivery station',2,NULL,NULL,0,0),(157,'Delivery station',2,NULL,NULL,0,0),(158,'Delivery station',2,NULL,NULL,0,0),(159,'Delivery station',2,NULL,NULL,0,0),(160,'Delivery station',2,NULL,NULL,0,0),(161,'Delivery station',3,NULL,NULL,0,0),(162,'Delivery station',3,NULL,NULL,0,0),(163,'Delivery station',3,NULL,NULL,0,0),(164,'Delivery station',3,NULL,NULL,0,0),(165,'Delivery station',3,NULL,NULL,0,0),(166,'Delivery station',3,NULL,NULL,0,0),(167,'Delivery station',3,NULL,NULL,0,0),(168,'Delivery station',3,NULL,NULL,0,0),(169,'Delivery station',4,NULL,NULL,0,0),(170,'Delivery station',4,NULL,NULL,0,0),(171,'Delivery station',4,NULL,NULL,0,0),(172,'Delivery station',4,NULL,NULL,0,0),(173,'Delivery station',4,NULL,NULL,0,0),(174,'Delivery station',4,NULL,NULL,0,0),(175,'Delivery station',4,NULL,NULL,0,0),(176,'Delivery station',4,NULL,NULL,0,0),(245,'Feeding station',0,NULL,NULL,0,0),(246,'Feeding station',0,NULL,NULL,0,0),(247,'Feeding station',0,NULL,NULL,0,0),(248,'Feeding station',0,NULL,NULL,0,0);
/*!40000 ALTER TABLE `station_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tag_layout`
--

DROP TABLE IF EXISTS `tag_layout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tag_layout` (
  `tn_id` varchar(12) NOT NULL,
  `tag_id` int NOT NULL,
  `neighbor` int NOT NULL,
  `direction` int DEFAULT NULL,
  `distance` int DEFAULT NULL,
  `command` int NOT NULL,
  `neighbor_command` int NOT NULL,
  PRIMARY KEY (`tn_id`),
  KEY `tag_id_index` (`tag_id`),
  KEY `neighbor_index` (`neighbor`),
  KEY `command_index` (`command`),
  KEY `neighbor_command_index` (`neighbor_command`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tag_layout`
--

LOCK TABLES `tag_layout` WRITE;
/*!40000 ALTER TABLE `tag_layout` DISABLE KEYS */;
INSERT INTO `tag_layout` VALUES ('000115',0,115,NULL,NULL,0,12),('000116',0,116,NULL,NULL,0,12),('000117',0,117,NULL,NULL,0,12),('001002',1,2,1,NULL,0,2),('002056',2,56,1,NULL,2,3),('003004',3,4,1,NULL,2,0),('003005',3,5,3,NULL,5,3),('004006',4,6,1,NULL,2,2),('005024',5,24,1,NULL,2,0),('006007',6,7,1,NULL,2,0),('006008',6,8,3,NULL,5,3),('007009',7,9,1,NULL,2,0),('008025',8,25,1,NULL,3,0),('009010',9,10,1,NULL,2,0),('009011',9,11,3,NULL,5,3),('010012',10,12,1,NULL,2,0),('011032',11,32,1,NULL,2,0),('012013',12,13,1,NULL,2,0),('012014',12,14,3,NULL,5,3),('013015',13,15,1,NULL,2,0),('014033',14,33,1,NULL,3,0),('015016',15,16,1,NULL,2,0),('015017',15,17,1,NULL,5,3),('016018',16,18,1,NULL,2,0),('017040',17,40,1,NULL,2,0),('018019',18,19,1,NULL,2,0),('018020',18,20,1,NULL,5,3),('019021',19,21,1,NULL,2,0),('020041',20,41,1,NULL,2,3),('021022',21,22,1,NULL,2,2),('021023',21,23,1,NULL,5,3),('022049',22,49,1,NULL,2,0),('023048',23,48,1,NULL,2,0),('024145',24,145,1,NULL,14,0),('025146',25,146,1,NULL,14,0),('026147',26,147,1,NULL,14,0),('027148',27,148,1,NULL,14,0),('028149',28,149,1,NULL,14,0),('029150',29,150,1,NULL,14,0),('030151',30,151,NULL,NULL,14,0),('031152',31,152,NULL,NULL,14,0),('032153',32,153,NULL,NULL,14,0),('033154',33,154,NULL,NULL,14,0),('034155',34,155,NULL,NULL,14,0),('035156',35,156,NULL,NULL,14,0),('036157',36,157,NULL,NULL,14,0),('037158',37,158,NULL,NULL,14,0),('038159',38,159,NULL,NULL,14,0),('039160',39,160,NULL,NULL,14,0),('040161',40,161,NULL,NULL,14,0),('041162',41,162,NULL,NULL,14,0),('042163',42,163,NULL,NULL,14,0),('043164',43,164,NULL,NULL,14,0),('044165',44,165,NULL,NULL,14,0),('045166',45,166,NULL,NULL,14,0),('046167',46,167,NULL,NULL,14,0),('047168',47,168,NULL,NULL,14,0),('048169',48,169,NULL,NULL,14,0),('049170',49,170,NULL,NULL,14,0),('050171',50,171,NULL,NULL,14,0),('051172',51,172,NULL,NULL,14,0),('052173',52,173,NULL,NULL,14,0),('053174',53,174,NULL,NULL,14,0),('054175',54,175,NULL,NULL,14,0),('055176',55,176,NULL,NULL,14,0),('056245',56,245,1,NULL,14,3),('057246',57,246,1,NULL,14,3),('058247',58,247,1,NULL,14,3),('059248',59,248,1,NULL,14,3),('060003',60,3,1,NULL,3,3),('061001',61,1,1,NULL,2,2),('115002',115,2,1,NULL,1,4),('116001',116,1,1,NULL,1,4),('117061',117,61,1,NULL,1,2),('145',145,-1,NULL,NULL,13,0),('145000',145,0,NULL,NULL,6,9),('146000',146,0,NULL,NULL,7,8),('146026',146,26,NULL,NULL,3,0),('147000',147,0,NULL,NULL,7,8),('147027',147,27,NULL,NULL,3,0),('148000',148,0,NULL,NULL,7,8),('148028',148,28,NULL,NULL,3,0),('149000',149,0,NULL,NULL,7,8),('149029',149,29,NULL,NULL,3,0),('150000',150,0,NULL,NULL,7,8),('150030',150,30,NULL,NULL,3,0),('151000',151,0,NULL,NULL,7,8),('151031',151,31,NULL,NULL,3,0),('152',152,-1,NULL,NULL,13,0),('152000',152,0,NULL,NULL,7,8),('153',153,-1,NULL,NULL,13,0),('153000',153,0,NULL,NULL,6,9),('154000',154,0,NULL,NULL,7,8),('154034',154,34,NULL,NULL,3,0),('155000',155,0,NULL,NULL,7,8),('155035',155,35,NULL,NULL,3,0),('156000',156,0,NULL,NULL,7,8),('156036',156,36,NULL,NULL,3,0),('157000',157,0,NULL,NULL,7,8),('157037',157,37,NULL,NULL,3,0),('158000',158,0,NULL,NULL,7,8),('158038',158,38,NULL,NULL,3,0),('159000',159,0,NULL,NULL,7,8),('159039',159,39,NULL,NULL,3,0),('160',160,-1,NULL,NULL,13,0),('160000',160,0,NULL,NULL,7,8),('161',161,-1,NULL,NULL,13,0),('161000',161,0,NULL,NULL,6,9),('162000',162,0,NULL,NULL,7,8),('162042',162,42,NULL,NULL,3,0),('163000',163,0,NULL,NULL,7,8),('163043',163,43,NULL,NULL,3,0),('164000',164,0,NULL,NULL,7,8),('164044',164,44,NULL,NULL,3,0),('165000',165,0,NULL,NULL,7,8),('165045',165,45,NULL,NULL,3,0),('166000',166,0,NULL,NULL,7,8),('166046',166,46,NULL,NULL,3,0),('167000',167,0,NULL,NULL,7,8),('167047',167,47,NULL,NULL,3,0),('168',168,-1,NULL,NULL,13,0),('168000',168,0,NULL,NULL,7,8),('169',169,-1,NULL,NULL,13,0),('169000',169,0,NULL,NULL,6,9),('170000',170,0,NULL,NULL,7,8),('170050',170,50,NULL,NULL,3,0),('171000',171,0,NULL,NULL,7,8),('171051',171,51,NULL,NULL,3,0),('172000',172,0,NULL,NULL,7,8),('172052',172,52,NULL,NULL,3,0),('173000',173,0,NULL,NULL,7,8),('173053',173,53,NULL,NULL,3,0),('174000',174,0,NULL,NULL,7,8),('174054',174,54,NULL,NULL,3,0),('175000',175,0,NULL,NULL,7,8),('175055',175,55,NULL,NULL,3,0),('176',176,-1,NULL,NULL,13,0),('176000',176,0,NULL,NULL,7,8),('245000',245,0,NULL,NULL,8,11),('245057',245,57,NULL,NULL,3,14),('246000',246,0,NULL,NULL,8,11),('246058',246,58,NULL,NULL,3,14),('247000',247,0,NULL,NULL,8,11),('247059',247,59,NULL,NULL,3,14),('248000',248,0,NULL,NULL,8,11),('248060',248,60,NULL,NULL,3,14);
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

-- Dump completed on 2021-03-08  1:02:47
