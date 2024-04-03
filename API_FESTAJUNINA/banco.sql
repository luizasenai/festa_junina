-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bd_festa_junina
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `evento`
--

DROP TABLE IF EXISTS `evento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
  `id_evento` int NOT NULL AUTO_INCREMENT,
  `valor_unitario` double DEFAULT NULL,
  `quantidade_total` varchar(45) DEFAULT NULL,
  `saldo` varchar(45) DEFAULT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `data_evento` datetime DEFAULT NULL,
  `imagem_url` varchar(45) DEFAULT NULL,
  `local` varchar(45) DEFAULT NULL,
  `ativo` bit(1) DEFAULT b'1',
  PRIMARY KEY (`id_evento`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evento`
--

LOCK TABLES `evento` WRITE;
/*!40000 ALTER TABLE `evento` DISABLE KEYS */;
INSERT INTO `evento` VALUES (1,10,'700','700',NULL,NULL,NULL,NULL,_binary '');
/*!40000 ALTER TABLE `evento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingresso`
--

DROP TABLE IF EXISTS `ingresso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingresso` (
  `id_ingresso` int NOT NULL AUTO_INCREMENT,
  `valor` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `tipo` varchar(45) DEFAULT NULL,
  `codigo_qr` varchar(45) NOT NULL,
  `lotes_id_lotes` int NOT NULL,
  `pedido_id_pedido` int NOT NULL,
  `data_utilizacao` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_ingresso`,`codigo_qr`,`lotes_id_lotes`),
  KEY `fk_ingresso_lotes1_idx` (`lotes_id_lotes`),
  KEY `fk_ingresso_pedido1_idx` (`pedido_id_pedido`),
  CONSTRAINT `fk_ingresso_lotes1` FOREIGN KEY (`lotes_id_lotes`) REFERENCES `lotes` (`id_lotes`),
  CONSTRAINT `fk_ingresso_pedido1` FOREIGN KEY (`pedido_id_pedido`) REFERENCES `pedido` (`id_pedido`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingresso`
--

LOCK TABLES `ingresso` WRITE;
/*!40000 ALTER TABLE `ingresso` DISABLE KEYS */;
INSERT INTO `ingresso` VALUES (1,'string','RESERVADO','string','5aa2a0b3-758f-47b3-9f6e-dc0e6e329d73',1,1,'2024-04-03 15:18:16');
/*!40000 ALTER TABLE `ingresso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lotes`
--

DROP TABLE IF EXISTS `lotes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lotes` (
  `id_lotes` int NOT NULL AUTO_INCREMENT,
  `valor_unitario` double DEFAULT NULL,
  `quantidade_total` int DEFAULT NULL,
  `saldo` int DEFAULT NULL,
  `evento_id_evento` int NOT NULL,
  `data_inicio` datetime DEFAULT NULL,
  `data_final` datetime DEFAULT NULL,
  `ativo` bit(1) DEFAULT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_lotes`,`evento_id_evento`),
  KEY `fk_lotes_evento1_idx` (`evento_id_evento`),
  CONSTRAINT `fk_lotes_evento1` FOREIGN KEY (`evento_id_evento`) REFERENCES `evento` (`id_evento`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lotes`
--

LOCK TABLES `lotes` WRITE;
/*!40000 ALTER TABLE `lotes` DISABLE KEYS */;
INSERT INTO `lotes` VALUES (1,10,200,200,1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `lotes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedido` (
  `id_pedido` int NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `total` double NOT NULL,
  `quantidade` int NOT NULL,
  `forma_pagamento` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `validacao_id_usuario` int DEFAULT NULL,
  `usuario_id_usuario` int NOT NULL,
  PRIMARY KEY (`id_pedido`),
  KEY `fk_pedido_usuario1_idx` (`usuario_id_usuario`),
  CONSTRAINT `fk_pedido_usuario1` FOREIGN KEY (`usuario_id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedido`
--

LOCK TABLES `pedido` WRITE;
/*!40000 ALTER TABLE `pedido` DISABLE KEYS */;
INSERT INTO `pedido` VALUES (1,'2024-04-03 14:50:36',40,4,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `pedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `nome_inteiro` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `senha` varchar(45) DEFAULT NULL,
  `telefone` varchar(100) DEFAULT NULL,
  `perfil` varchar(45) DEFAULT NULL,
  `status` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Lucas Unzer',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-03 15:20:50
