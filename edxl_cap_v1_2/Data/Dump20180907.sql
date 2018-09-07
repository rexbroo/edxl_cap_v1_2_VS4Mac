-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: localhost    Database: edxl_cap_v1_2
-- ------------------------------------------------------
-- Server version	5.7.21

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
-- Table structure for table `Alert`
--

DROP TABLE IF EXISTS `Alert`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Alert` (
  `AlertIndex` int(11) NOT NULL AUTO_INCREMENT,
  `Alert_Identifier` varchar(150) DEFAULT NULL,
  `Addresses` text,
  `Code` text,
  `DataCategory_Id` int(11) NOT NULL,
  `Incidents` text,
  `MsgType` int(11) NOT NULL,
  `Note` text,
  `References` text,
  `Restriction` text,
  `Scope` int(11) NOT NULL,
  `Sender` text,
  `Sent` datetime NOT NULL,
  `Source` text,
  `Status` int(11) NOT NULL,
  `SelectedAlertIndex` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`AlertIndex`),
  UNIQUE KEY `IX_Alert_Alert_Identifier` (`Alert_Identifier`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Alert`
--

LOCK TABLES `Alert` WRITE;
/*!40000 ALTER TABLE `Alert` DISABLE KEYS */;
INSERT INTO `Alert` VALUES (1,'NOAA-NWS-ALERTS-CA125838F5ECFC.WinterStormWarning.125838F803C0CA.-EKAWSWEKA.d2e18d2b81b08f7bcd9e6fadde0ff6db','NULL','NULL',1,'NULL',0,'Alert for CAZ107; CAZ108 (California) Issued by the National Weather Service','NULL','NULL',0,'w-nws.webmaster@noaa.gov','2017-01-22 22:31:08','nws',0,0),(2,'NOAA-NWS-ALERTS-CA125A9F5E174C.WinterWeatherAdvisory.125AA39AAE60CA.-REVWSWREV.58c9bead01ca6732bc88705059f76f46','NULL','NULL',1,'NULL',0,'Alert for Mono (California) Issued by the National Weather Service','NULL','NULL',0,'w-nws.webmaster@noaa.gov','2018-04-30 03:03:00','nws',0,0),(3,'NOAA-NWS-ALERTS-AK125AA3AA1EB8.FloodAdvisory.125AA3B95FCCAK.AFCFLSAFC.026e2b11e582dbb6bd863dfa37b89739<','NULL','NULL',1,'NULL',0,'Alert for Lower Kuskokwim Valley (Alaska) Issued by the National Weather Service','NULL','NULL',0,'w-nws.webmaster@noaa.gov','2018-05-02 11:18:00','nws',1,0);
/*!40000 ALTER TABLE `Alert` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Area`
--

DROP TABLE IF EXISTS `Area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Area` (
  `AreaIndex` int(11) NOT NULL AUTO_INCREMENT,
  `Altitude` text,
  `AreaDesc` text,
  `Ceiling` text,
  `Circle` text,
  `DataCategory_Id` int(11) NOT NULL,
  `Geocode` text,
  `Polygon` text,
  `Alert_Identifier` varchar(150) NOT NULL,
  PRIMARY KEY (`AreaIndex`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Area`
--

LOCK TABLES `Area` WRITE;
/*!40000 ALTER TABLE `Area` DISABLE KEYS */;
INSERT INTO `Area` VALUES (1,'NULL','CAZ107; CAZ108','NULL','NULL',3,'FIPS6, , UGC, CAZ107, UGC, CAZ108','39.99, -122.90 39.99, -123.54 40.80, -123.56 40.92, -123.60 40.92, -123.49 41.05, -123.41 41.09, -123.47 41.17, -123.40 41.13, -123.29 40.99, -122.94 41.08, -122.74 40.57, -123.95 41.33, -122.53 41.10, -122.46 40.70, -122.74 40.57, -122.71 40.36, -123.02 39.99, -122.90',''),(2,'NULL','Mono','NULL','NULL',3,'FIPS6, 006051, UGC, CAZ073','NULL',''),(3,'NULL','Lower Kuskokwim Valley','NULL','NULL',3,'FIPS6,002050,UGC,AKZ152','1.53,-159.4 61.5,-159.81 61.6,-159.81 61.62,-159.4 61.53,-159.4','');
/*!40000 ALTER TABLE `Area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetRoleClaims`
--

DROP TABLE IF EXISTS `AspNetRoleClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` text,
  `ClaimValue` text,
  `RoleId` varchar(200) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_IdentityRole<string>_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `IdentityRole<string>` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoleClaims`
--

LOCK TABLES `AspNetRoleClaims` WRITE;
/*!40000 ALTER TABLE `AspNetRoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoleClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserClaims`
--

DROP TABLE IF EXISTS `AspNetUserClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` text,
  `ClaimValue` text,
  `UserId` varchar(200) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_IdentityUser<string>_UserId` FOREIGN KEY (`UserId`) REFERENCES `IdentityUser<string>` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserClaims`
--

LOCK TABLES `AspNetUserClaims` WRITE;
/*!40000 ALTER TABLE `AspNetUserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserLogins`
--

DROP TABLE IF EXISTS `AspNetUserLogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(200) NOT NULL,
  `ProviderKey` varchar(200) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(200) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_IdentityUser<string>_UserId` FOREIGN KEY (`UserId`) REFERENCES `IdentityUser<string>` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserLogins`
--

LOCK TABLES `AspNetUserLogins` WRITE;
/*!40000 ALTER TABLE `AspNetUserLogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserLogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserRoles`
--

DROP TABLE IF EXISTS `AspNetUserRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(200) NOT NULL,
  `RoleId` varchar(200) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_IdentityRole<string>_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `IdentityRole<string>` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_IdentityUser<string>_UserId` FOREIGN KEY (`UserId`) REFERENCES `IdentityUser<string>` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserRoles`
--

LOCK TABLES `AspNetUserRoles` WRITE;
/*!40000 ALTER TABLE `AspNetUserRoles` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserTokens`
--

DROP TABLE IF EXISTS `AspNetUserTokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(200) NOT NULL,
  `LoginProvider` varchar(200) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_IdentityUser<string>_UserId` FOREIGN KEY (`UserId`) REFERENCES `IdentityUser<string>` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserTokens`
--

LOCK TABLES `AspNetUserTokens` WRITE;
/*!40000 ALTER TABLE `AspNetUserTokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserTokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DataCategory`
--

DROP TABLE IF EXISTS `DataCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `DataCategory` (
  `DataCategory_Id` int(11) NOT NULL AUTO_INCREMENT,
  `DataCategoryName` text,
  PRIMARY KEY (`DataCategory_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DataCategory`
--

LOCK TABLES `DataCategory` WRITE;
/*!40000 ALTER TABLE `DataCategory` DISABLE KEYS */;
/*!40000 ALTER TABLE `DataCategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EdxlCapMessageViewModel`
--

DROP TABLE IF EXISTS `EdxlCapMessageViewModel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `EdxlCapMessageViewModel` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AlertIndex` int(11) NOT NULL,
  `Alert_Identifier` text NOT NULL,
  `AreaIndex` int(11) NOT NULL,
  `InfoIndex` int(11) DEFAULT NULL,
  `ResourceIndex` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_EdxlCapMessageViewModel_Alert_AlertId` (`AlertIndex`),
  KEY `FK_EdxlCapMessageViewModel_Area_AreaIndex` (`AreaIndex`),
  KEY `FK_EdxlCapMessageViewModel_Info_InfoIndex` (`InfoIndex`),
  KEY `FK_EdxlCapMessageViewModel_Resource_ResourceIndex` (`ResourceIndex`),
  CONSTRAINT `FK_EdxlCapMessageViewModel_Alert_AlertId` FOREIGN KEY (`AlertIndex`) REFERENCES `Alert` (`AlertIndex`),
  CONSTRAINT `FK_EdxlCapMessageViewModel_Area_AreaIndex` FOREIGN KEY (`AreaIndex`) REFERENCES `Area` (`AreaIndex`),
  CONSTRAINT `FK_EdxlCapMessageViewModel_Info_InfoIndex` FOREIGN KEY (`InfoIndex`) REFERENCES `Info` (`InfoIndex`),
  CONSTRAINT `FK_EdxlCapMessageViewModel_Resource_ResourceIndex` FOREIGN KEY (`ResourceIndex`) REFERENCES `Resource` (`ResourceIndex`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EdxlCapMessageViewModel`
--

LOCK TABLES `EdxlCapMessageViewModel` WRITE;
/*!40000 ALTER TABLE `EdxlCapMessageViewModel` DISABLE KEYS */;
/*!40000 ALTER TABLE `EdxlCapMessageViewModel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EdxlCapMsg`
--

DROP TABLE IF EXISTS `EdxlCapMsg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `EdxlCapMsg` (
  `Alert_Identifier` varchar(150) NOT NULL,
  `AreaIndex` int(11) NOT NULL,
  `InfoIndex` int(11) NOT NULL,
  `ResourceIndex` int(11) NOT NULL,
  `AlertIndex` int(11) NOT NULL DEFAULT '0',
  `EdxlCapMsg_AlertIndex` int(11) NOT NULL DEFAULT '0',
  `AlertIndex1` int(11) DEFAULT NULL,
  `EdxlCapMsgAlertIndex` int(11) DEFAULT NULL,
  KEY `IX_EdxlCapMsg_AlertIndex` (`AlertIndex`),
  KEY `IX_EdxlCapMsg_AreaIndex` (`AreaIndex`),
  KEY `IX_EdxlCapMsg_InfoIndex` (`InfoIndex`),
  KEY `IX_EdxlCapMsg_ResourceIndex` (`ResourceIndex`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EdxlCapMsg`
--

LOCK TABLES `EdxlCapMsg` WRITE;
/*!40000 ALTER TABLE `EdxlCapMsg` DISABLE KEYS */;
INSERT INTO `EdxlCapMsg` VALUES ('\'NOAA-NWS-ALERTS-CA125838F5ECFC.WinterStormWarning.125838F803C0CA.EKAWSWEKA.d2e18d2b81b08f7bcd9e6fadde0ff6db\'',1,1,1,2,0,NULL,NULL),('\'NOAA-NWS-ALERTS-CA125A9F5E174C.WinterWeatherAdvisory.125AA39AAE60CA.REVWSWREV.58c9bead01ca6732bc88705059f76f46\'',2,2,2,2,0,NULL,NULL),('\'NOAA-NWS-ALERTS-AK125AA3AA1EB8.FloodAdvisory.125AA3B95FCCAK.AFCFLSAFC.026e2b11e582dbb6bd863dfa37b89739<\'',3,3,3,2,0,NULL,NULL);
/*!40000 ALTER TABLE `EdxlCapMsg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Element`
--

DROP TABLE IF EXISTS `Element`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Element` (
  `ElementIndex` int(11) NOT NULL,
  `ElementName` text,
  `Required` tinyint(4) DEFAULT NULL,
  `Conditional` tinyint(4) DEFAULT NULL,
  `Repeatable` tinyint(4) DEFAULT NULL,
  `DataCategory_Id` int(11) DEFAULT NULL,
  `Datatype` varchar(45) DEFAULT NULL,
  `Datatype_Size` int(11) DEFAULT NULL,
  PRIMARY KEY (`ElementIndex`),
  KEY `IX_Element_DataCategory_Id1` (`DataCategory_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Element`
--

LOCK TABLES `Element` WRITE;
/*!40000 ALTER TABLE `Element` DISABLE KEYS */;
INSERT INTO `Element` VALUES (1,'AlertIndex',1,0,0,1,'VARCHAR',150),(2,'alert_identifier',1,0,0,1,'VARCHAR',150),(3,'sender',1,0,0,1,'VARCHAR',100),(4,'sent',1,0,0,1,'DATETIME',NULL),(5,'status',1,0,0,1,'ENUM',NULL),(6,'msgType',1,0,0,1,'ENUM',NULL),(7,'source',0,0,0,1,'VARCHAR',200),(8,'scope',0,0,0,1,'ENUM',NULL),(9,'restriction',0,0,0,1,'VARCHAR',200),(10,'addresses',0,0,0,1,'VARCHAR',50),(11,'code',0,0,1,1,'VARCHAR',150),(12,'note',0,0,0,1,'VARCHAR',150),(13,'references',0,0,0,1,'VARCHAR',150),(14,'incidents',0,0,0,1,'VARCHAR',150),(15,'info',0,0,0,2,'VARCHAR',150),(16,'language',0,0,0,2,'VARCHAR',10),(17,'category',0,0,1,2,'ENUM',10),(18,'event',0,1,0,2,'VARCHAR',50),(19,'responseType',0,0,1,2,'VARCHAR',50),(20,'urgency',1,1,0,2,'ENUM',NULL),(21,'severity',1,1,0,2,'ENUM',NULL),(22,'certainty',1,1,0,2,'ENUM',NULL),(23,'audience',0,0,0,2,'VARCHAR',50),(24,'eventCode',0,0,1,2,'VARCHAR',50),(25,'effective',0,0,0,2,'DATETIME',NULL),(26,'onset',0,0,0,2,'DATETIME',NULL),(27,'expires',0,0,0,2,'DATETIME',NULL),(28,'senderName',0,0,0,2,'VARCHAR',50),(29,'headline',0,1,0,2,'VARCHAR',160),(30,'description',0,0,0,2,'VARCHAR',1500),(31,'instruction',0,0,0,2,'VARCHAR',1500),(32,'web',0,1,0,2,'VARCHAR',150),(33,'contact',0,0,0,2,'VARCHAR',250),(34,'parameter',0,0,1,2,'VARCHAR',150),(35,'resource',0,0,1,4,'VARCHAR',150),(36,'resourceDesc',1,0,0,4,'VARCHAR',300),(37,'mimeType',0,1,0,4,'VARCHAR',100),(38,'size',0,0,0,4,'INT',10),(39,'uri',0,0,0,4,'VARCHAR',150),(40,'derefUri',0,0,0,4,'VARCHAR',150),(41,'digest',0,0,0,4,'VARCHAR',50),(42,'area',0,1,1,3,'VARCHAR',150),(43,'areaDesc',0,1,0,3,'VARCHAR',350),(44,'polygon',0,0,1,3,'VARCHAR',350),(45,'circle',0,0,1,3,'VARCHAR',50),(46,'geocode',0,0,1,3,'VARCHAR',50),(47,'altitude',0,0,0,3,'VARCHAR',50),(48,'ceiling',0,0,0,3,'VARCHAR',50);
/*!40000 ALTER TABLE `Element` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `IdentityRole<string>`
--

DROP TABLE IF EXISTS `IdentityRole<string>`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `IdentityRole<string>` (
  `Id` varchar(200) NOT NULL,
  `ConcurrencyStamp` text,
  `Discriminator` text NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityRole<string>`
--

LOCK TABLES `IdentityRole<string>` WRITE;
/*!40000 ALTER TABLE `IdentityRole<string>` DISABLE KEYS */;
/*!40000 ALTER TABLE `IdentityRole<string>` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `IdentityUser<string>`
--

DROP TABLE IF EXISTS `IdentityUser<string>`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `IdentityUser<string>` (
  `Id` varchar(200) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` text,
  `Discriminator` text NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` text,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `IdentityUser<string>`
--

LOCK TABLES `IdentityUser<string>` WRITE;
/*!40000 ALTER TABLE `IdentityUser<string>` DISABLE KEYS */;
INSERT INTO `IdentityUser<string>` VALUES ('0fcbad9a-f3a8-4e87-8d70-56c43f58c1bb',0,'abe50a45-a05f-41cf-bf6b-46a6866f358f','ApplicationUser','rexbroo@gmail.com','\0','',NULL,'REXBROO@GMAIL.COM','REXBROO@GMAIL.COM','AQAAAAEAACcQAAAAEL6EXDQ9K+tXiY/l7oa1bHrin7g6rW/Z0wi4zobJVfx+XtzOth6A2La22/dpD1DCiA==',NULL,'\0','5e4419eb-ebc9-451b-8547-41d0eb4ca635','\0','rexbroo@gmail.com');
/*!40000 ALTER TABLE `IdentityUser<string>` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Info`
--

DROP TABLE IF EXISTS `Info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Info` (
  `InfoIndex` int(11) NOT NULL AUTO_INCREMENT,
  `Audience` text,
  `Category` int(11) NOT NULL,
  `Certainty` int(11) NOT NULL,
  `Contact` text,
  `DataCategory_Id` int(11) NOT NULL,
  `Description` text,
  `Effective` datetime NOT NULL,
  `Event` text,
  `EventCode` text,
  `Expires` datetime NOT NULL,
  `Headline` text,
  `Instruction` text,
  `Onset` datetime NOT NULL,
  `Parameter` text,
  `ResponseType` int(11) NOT NULL,
  `SenderName` text,
  `Severity` int(11) NOT NULL,
  `Urgency` int(11) NOT NULL,
  `Web` text,
  `Language` text NOT NULL,
  `Alert_Identifier` varchar(150) NOT NULL,
  PRIMARY KEY (`InfoIndex`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Info`
--

LOCK TABLES `Info` WRITE;
/*!40000 ALTER TABLE `Info` DISABLE KEYS */;
INSERT INTO `Info` VALUES (1,'NULL',1,1,'NULL',2,'SHOWER COVERAGE WILL CONTINUE DIMINISH THROUGH THE REMAINDER OF THE AFTERNOON...BUT BURSTS OF LIGHT SNOW CAN BE EXPECTED AT ELEVATIONS AT OR ABOVE 3500 FEET WITH LIGHT ACCUMULATIONS POSSIBLE... HEAVY SNOW WILL RETURN TO ELEVATIONS OF 3000 OR HIGHER OVERNIGHT SATURDAY THROUGH SUNDAY MORNING. SNOW SHOWERS WILL CONTINUE PERIODICALLY THROUGH MONDAY...WINTER STORM WARNING REMAINS IN EFFECT UNTIL NOON PST SUNDAY ABOVE 2500 FEET ... SNOW ACCUMULATIONS... 1 TO 4 NCHES BETWEEN 2500 AND 3000 FEET 4 TO 8 INCHES BETWEEN 3000 AND 4000 FEET, 8 TO 12 INCHES ABOVE 4000 FEET ...WITH LOCALLY HIGHER AMOUNT POSSIBLE. LOCATIONS IMPACTED...TRINITY CENTER...PEANUT...HETTENSHAW...RUTH...AND ELEVATED AREAS SURROUNDING WEAVERVILLE AND ... HAYFORK. HIGHWAYS IMPACTED...HIGHWAYS 36 AND3 WITH HIGH CERTAINTY. LIGHTER ACCUMULATIONS POSSIBLE AT BUCKHORN AND OREGON MOUNTAIN SUMMITS OF HIGHWAY 299. FOR A DETAILED VIEW OF THE HAZARD AREA ... VISIT HTTP://WWW.WEATHER.GOV/EUREKA/HAZARDS','2017-01-21 22:31:08','Winter Storm Warning','SAME,WSW','2017-01-22 12:00:00','Winter Storm Warning issued January 21 at 10:31PM PST until January 22 at 12:00PM PST by NWS Eureka','A WINTER STORM WARNING MEANS THERE IS HIGH CONFIDENCE THAT SIGNIFICANT SNOW, SLEET...OR ICE ACCUMULATIONS WILL IMPACT TRAVEL. CONTINUE TO MONITOR THE LATEST FORECASTS','2017-01-21 22:31:08','WMOHHEADER',0,'NWS Eureka (Northwest California Coast)',2,1,'NULL','',''),(2,'NULL',1,2,'NULL',2,'...WINTER WEATHER ADVISORY IN EFFECT FROM 8 PM THIS EVENING TO\n\n11 AM PDT TUESDAY ABOVE 7000 FEET...\n\n* WHAT...Snow expected. Total snow accumulations of 2 to 4 inches,\n\nwith localized amounts up to 6 inches, are expected above 7000\n\nfeet.\n\n* WHERE...Mono County south of Bridgeport.\n\n* WHEN...From 8 PM this evening to 11 AM PDT Tuesday.\n\n* ADDITIONAL DETAILS...Plan on slippery road conditions. Be\n\nprepared for reduced visibilities at times.','2018-04-30 20:00:00','Winter Weather Advisory','SAME','2018-05-01 11:00:00','Winter Weather Advisory issued April 30 at 3:03AM PDT until May 01 at 11:00AM PDT by NWS Reno','Be sure to allow extra time to reach your destination. Leave\n\nextra space between vehicles since it takes longer to stop on\n\nslick roadways. Check for the latest road conditions by calling\n\n5 1 1 or visiting the CALTRANS website.','2018-04-30 20:00:00','WMOHEADER, UGC, CAZ073, VTEC, /O.NEW.KREV.WW.Y.0017.180501T0300Z-180501T1800Z/',0,'NWS Reno (Western Nevada)',4,2,'NULL','',''),(3,'NULL',1,2,'NULL',2,'The National Weather Service in Anchorage has issued a\r\n* Flood Advisory for...\r\nAn Ice Jam in...\r\nAniak along the Kuskokwim River\r\n* Until 1115 AM AKDT Thursday\r\n* Ice on the Kuskokwim River at Aniak started moving Monday evening.\r\nStarting Tuesday morning, water levels at Aniak began rising\r\nsteadily and the ice has stopped moving. Some minor flooding of\r\nlow lying roads is being reported at Aniak. Additional ice runs\r\nare moving down river toward Aniak. Flooding will continue to\r\noccur in Aniak and additional water levels increases are likely\r\nuntil the Kuskokwim River ice goes out in the vicinity of Aniak.','2018-05-02 11:18:00','Flood Advisory','SAME','2018-05-03 11:15:00','Flood Advisory issued May 02 at 11:18AM AKDT  by NWS Anchorage','Stay away or be swept away. River banks and culverts can become\r\nunstable and unsafe.\r\nA Flood Advisory means river or stream flows are elevated, or ponding\r\nof water in urban or other areas is occurring or is imminent.','2018-05-02 11:18:00','WMOHEADER,UGC,AKZ152,VTEC,/O.NEW.PAFC.FA.Y.0003.180502T1918Z-180503T1915Z//00000.N.IJ.000000T0000Z.000000T0000Z.000000T0000Z.OO/',0,'NWS Anchorage (Southern Alaska - Anchorage)',4,2,'NULL','','');
/*!40000 ALTER TABLE `Info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Person`
--

DROP TABLE IF EXISTS `Person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Person` (
  `PersonId` int(11) NOT NULL AUTO_INCREMENT,
  `PersonName` text,
  PRIMARY KEY (`PersonId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Person`
--

LOCK TABLES `Person` WRITE;
/*!40000 ALTER TABLE `Person` DISABLE KEYS */;
/*!40000 ALTER TABLE `Person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Resource`
--

DROP TABLE IF EXISTS `Resource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Resource` (
  `ResourceIndex` int(11) NOT NULL AUTO_INCREMENT,
  `DataCategory_Id` int(11) NOT NULL,
  `DerefUri` text,
  `Digest` text,
  `Info_Alert_Identifier` text,
  `MimeType` text,
  `ResourceDesc` text,
  `Size` int(11) NOT NULL,
  `Uri` text,
  `Alert_Identifier` varchar(150) NOT NULL,
  PRIMARY KEY (`ResourceIndex`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Resource`
--

LOCK TABLES `Resource` WRITE;
/*!40000 ALTER TABLE `Resource` DISABLE KEYS */;
INSERT INTO `Resource` VALUES (1,4,'NULL','NULL','NOAA-NWS-ALERTS-CA1258388FSECFC.WinterStormWarning.125838f803C0CA.EKAWSWEKA.d2e18d2b81b08f7bcd9e6fadde0ff6ddb','NULL','NULL',0,'NULL',''),(2,4,'NULL','NULL','NOAA-NWS-ALERTS-CA125A9F5E174C.WinterWeatherAdvisory.125AA39AAE60CA.REVWSWREV.58c9bead01ca6732bc88705059f76f46','NULL','NULL',0,'NULL','');
/*!40000 ALTER TABLE `Resource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('00000000000000_CreateIdentitySchema','2.0.1-rtm-125'),('20180409184005_CreateInitial','2.0.2-rtm-10011'),('20180418022502_CreateIdentitySchema','2.0.2-rtm-10011'),('20180718172519_20180718_MasterBranchUpdate','2.0.2-rtm-10011'),('20180718175140_Empty_Test','2.0.2-rtm-10011'),('20180806194626_Adjustment','2.0.2-rtm-10011'),('20180824181542_SelectedAlertIdentifier','2.0.2-rtm-10011');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-09-07  8:22:56
