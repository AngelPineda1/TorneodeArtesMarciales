CREATE DATABASE  IF NOT EXISTS `torneo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `torneo`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: torneo
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Table structure for table `artesmarciales`
--

DROP TABLE IF EXISTS `artesmarciales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `artesmarciales` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Valores` varchar(100) DEFAULT NULL,
  `AñoOrigen` int DEFAULT NULL,
  `Variantes` int DEFAULT NULL,
  `LugarOrigen` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artesmarciales`
--

LOCK TABLES `artesmarciales` WRITE;
/*!40000 ALTER TABLE `artesmarciales` DISABLE KEYS */;
INSERT INTO `artesmarciales` VALUES (14,'Karate','Respeto Y La Cortesía',1230,15,'Japon'),(15,'Aikido','Respeto',1300,3,'Japon'),(17,'Judo','Respeto, Defensa, Armonia',1450,4,'Japon'),(18,'Kung-Fu','Esfuerzo, Humildad Confianza',1230,5,'China'),(19,'Capoeira','Igualdad, Justicia',1500,2,'Brasil'),(20,'Muay Thai','Respeto',1270,5,'Tailandia'),(21,'Krav Maga','Defensa, Esfuerzo',1700,4,'Israel'),(22,'Kendo','Respeto, Igualdad',1300,0,'Japon'),(23,'Taekwondo','Defensa, Respeto',1456,2,'Corea'),(24,'Jiu-Jitsu','Defensa, Eficiencia',1409,3,'Japon'),(25,'Box','Respeto, Ataque, Defensa',1200,2,'Grecia'),(26,'Kickboxing','Defensa, Respeto',1340,3,'Japon'),(27,'Sumo','Defensa, Rsistencia, Equilibrio',1450,0,'Japon'),(28,'Sankukai','Respeto, Ataque, Defensa, Equilibrio',1600,0,'Japon'),(29,'Jujutsu','Respeto, Defensa, Armonia',1100,0,'Japon'),(30,'Goshindo','Respeto,Defensa',1569,0,'Japon'),(31,'Daido-Juku Kudo','Respeto, Armonia',1490,2,'Japon'),(32,'Sambo','Respeto, Defensa',1600,2,'Rusia'),(33,'Wushu','Armonia, Equlibrio, Eficacia, Defensa',1500,4,'China'),(34,'Mugendo','Respeto, Defensa, Ataque',1950,5,'Japon'),(35,'Tai Chi','Armonia, Equlibrio',1400,3,'China'),(36,'Lucha Libre','Ataque',1500,8,'Occidente'),(37,'Hapkido','Defensa, Ataque',1200,3,'Corea'),(38,'Jiu-Jitsu Brasileño','Defensa, Ataque, Respeto',1450,0,'Brasil'),(39,'Shuai Jiao','Respeto, Defensa',1300,2,'China'),(40,'Kenjutsu','Eficiencia, Defensa, Ataque',1457,2,'Japon'),(41,'Kūdō','Ataque',1981,2,'Japon'),(42,'Systema','Respiracion, Agilidad',900,3,'Rusia'),(43,'Shotokan','Defensa, Respeto',1936,0,'Japon'),(44,'Shitō-Ryū','Respeto, Armoia, Equlibrio',1931,0,'Japon');
/*!40000 ALTER TABLE `artesmarciales` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-01 18:40:27
