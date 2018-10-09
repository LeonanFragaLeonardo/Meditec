-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.22-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.5.0.5280
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for meditec
CREATE DATABASE IF NOT EXISTS `meditec` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `meditec`;

-- Dumping structure for table meditec.agenda
CREATE TABLE IF NOT EXISTS `agenda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(255) NOT NULL,
  `title` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`,`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.agenda: ~1 rows (approximately)
/*!40000 ALTER TABLE `agenda` DISABLE KEYS */;
INSERT INTO `agenda` (`id`, `userid`, `title`) VALUES
	(1, 'HSDA40', 'Meditec 9');
/*!40000 ALTER TABLE `agenda` ENABLE KEYS */;

-- Dumping structure for table meditec.agenda_events
CREATE TABLE IF NOT EXISTS `agenda_events` (
  `agenda` int(11) NOT NULL,
  `user` varchar(255) NOT NULL,
  `event` int(11) NOT NULL,
  PRIMARY KEY (`agenda`,`user`,`event`),
  KEY `FK_agenda_events_event` (`event`),
  CONSTRAINT `FK_agenda_events_agenda` FOREIGN KEY (`agenda`, `user`) REFERENCES `agenda` (`id`, `userid`),
  CONSTRAINT `FK_agenda_events_event` FOREIGN KEY (`event`) REFERENCES `event` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.agenda_events: ~0 rows (approximately)
/*!40000 ALTER TABLE `agenda_events` DISABLE KEYS */;
/*!40000 ALTER TABLE `agenda_events` ENABLE KEYS */;

-- Dumping structure for table meditec.event
CREATE TABLE IF NOT EXISTS `event` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT 'Not Defined',
  `description` varchar(255) DEFAULT 'Not Defined',
  `type` int(2) DEFAULT NULL COMMENT '1 - Minicurso, 2 - Palestra, 3 Apresentação..',
  `place` varchar(50) DEFAULT NULL,
  `start_datetime` datetime DEFAULT NULL,
  `end_datetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.event: ~17 rows (approximately)
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
INSERT INTO `event` (`id`, `title`, `description`, `type`, `place`, `start_datetime`, `end_datetime`) VALUES
	(1, 'Web design, usabilidade e experiência do usuário', 'Not Defined', 1, 'L20', '2018-10-15 13:30:00', '2018-10-15 17:30:00'),
	(2, 'Abertura IX Meditec ', 'Not Defined', 2, 'L20', '2018-10-15 18:30:00', '2018-10-15 19:00:00'),
	(3, 'Perícia Forense em Informática ', 'Not Defined', 2, 'L20', '2018-10-15 19:00:00', '2018-10-15 20:15:00'),
	(4, 'Profissionais de T.I. ', 'Not Defined', 2, 'L20', '2018-10-15 20:15:00', '2018-10-15 22:00:00'),
	(5, 'Modelagem de Uma Carga Eletrolítica Trifásica - Corrente em Função da Inserção dos Eletrodos', 'Not Defined', 3, 'L20', '2018-10-16 08:00:00', '2018-10-16 08:20:00'),
	(6, 'Desenvolvimento de Robô Trekking Autônomo Integrando Sensoriamento Inercial, Geoespacial e Visual', 'Not Defined', 3, 'L20', '2018-10-16 08:25:00', '2018-10-16 08:45:00'),
	(7, 'Pesquisa em ataques e defesas usando exemplos adversários', 'Not Defined', 3, 'L20', '2018-10-16 08:50:00', '2018-10-16 09:10:00'),
	(8, 'Desenvolvimento de Módulo de Análise de Dados de Movimentação Corporal em uma Plataforma Lúdica para o Tratamento da Encefalopatia Crônica Não Progressiva da Infância', 'Not Defined', 3, 'L20', '2018-10-16 09:15:00', '2018-10-16 09:35:00'),
	(9, 'Rede Neural Convolucional treinada de ponta a ponta aplicado a identificação de locutores', 'Not Defined', 3, 'L20', '2018-10-16 09:40:00', '2018-10-16 10:00:00'),
	(10, 'Apresentação de Posters', 'Not Defined', 3, 'L20', '2018-10-16 10:00:00', '2018-10-16 10:30:00'),
	(11, 'Descomplicando a Blockchain', 'Not Defined', 2, 'L20', '2018-10-16 10:30:00', '2018-10-16 12:00:00'),
	(12, 'Reconhecimento de Espécies Florestais sob a perspectiva de descritores baseados em Pontos de Atenção', 'Not Defined', 2, 'L20', '2018-10-16 13:30:00', '2018-10-16 13:50:00'),
	(13, 'Elaboração de Software de Rastreamento de Aves em Aviários', 'Not Defined', 2, 'L20', '2018-10-16 13:55:00', '2018-10-16 14:15:00'),
	(14, 'Simulação da irrigação por aspersão utilizando redes neurais artificiais treinadas com e sem termo momentum', 'Not Defined', 2, 'L20', '2018-10-16 14:20:00', '2018-10-16 14:40:00'),
	(15, 'Reconhecimento de Espécies Florestais: uma estratégia baseada na combinação de classificadores em dois níveis', 'Not Defined', 2, 'L20', '2018-10-16 14:45:00', '2018-10-16 15:05:00'),
	(16, 'Apresentação de Posters', 'Not Defined', 3, 'L20', '2018-10-16 15:05:00', '2018-10-16 15:30:00'),
	(17, 'Mesa Redonda - Uso da Inteligência Artificial na Computação', 'Not Defined', 2, 'L20', '2018-10-16 15:30:00', '2018-10-16 17:30:00');
/*!40000 ALTER TABLE `event` ENABLE KEYS */;

-- Dumping structure for table meditec.event_trainers
CREATE TABLE IF NOT EXISTS `event_trainers` (
  `event` int(11) NOT NULL,
  `trainer` int(11) NOT NULL,
  PRIMARY KEY (`event`,`trainer`),
  KEY `FK_event_trainers_trainer` (`trainer`),
  CONSTRAINT `FK_event_trainers_event` FOREIGN KEY (`event`) REFERENCES `event` (`id`),
  CONSTRAINT `FK_event_trainers_trainer` FOREIGN KEY (`trainer`) REFERENCES `trainer` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.event_trainers: ~20 rows (approximately)
/*!40000 ALTER TABLE `event_trainers` DISABLE KEYS */;
INSERT INTO `event_trainers` (`event`, `trainer`) VALUES
	(5, 1),
	(6, 1),
	(7, 1),
	(8, 1),
	(9, 1),
	(10, 1),
	(12, 1),
	(13, 1),
	(14, 1),
	(15, 1),
	(16, 1),
	(4, 2),
	(11, 3),
	(2, 4),
	(17, 4),
	(1, 5),
	(1, 6),
	(3, 7),
	(17, 8),
	(17, 9);
/*!40000 ALTER TABLE `event_trainers` ENABLE KEYS */;

-- Dumping structure for table meditec.social_network
CREATE TABLE IF NOT EXISTS `social_network` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(50) DEFAULT NULL,
  `icon_code` varchar(15) DEFAULT NULL,
  `html_icon` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.social_network: ~5 rows (approximately)
/*!40000 ALTER TABLE `social_network` DISABLE KEYS */;
INSERT INTO `social_network` (`id`, `title`, `icon_code`, `html_icon`) VALUES
	(1, 'Facebook', '&#x3030;', NULL),
	(2, 'Twitter', '&#x3030;', NULL),
	(3, 'LinkedIn', '&#x3030;', NULL),
	(4, 'Wordpress', '&#x3030;', NULL),
	(5, 'Lattes', '&#x3030;', NULL);
/*!40000 ALTER TABLE `social_network` ENABLE KEYS */;

-- Dumping structure for table meditec.trainer
CREATE TABLE IF NOT EXISTS `trainer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(60) DEFAULT 'Not Defined',
  `resume` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.trainer: ~8 rows (approximately)
/*!40000 ALTER TABLE `trainer` DISABLE KEYS */;
INSERT INTO `trainer` (`id`, `name`, `resume`) VALUES
	(1, 'Unknown', 'Not Defined'),
	(2, 'Miguel Diogenes Matrakas ', 'Engenheiro da Computação pela Pontifícia Universidade Católica do Paraná (1996) e mestre em Informática Aplicada pela Pontifícia Universidade Católica do Paraná (2000). Atuando como professor e integrante do núcleo docente estruturante (NDE) do curso de Ciência da Computação da Faculdade Anglo-Americano Foz do Iguaçu. Experiência como professor do ensino superior na área de Ciência da Computação a 20 anos, com ênfase nas disciplinas de Programação de computadores em Linguagens C/C++ e Java, Processamento de Imagens e Computação Gráfica. Com participação em projetos de pesquisa nas áreas de Processamento Digital de Imagens, Computação Gráfica, e projetos de desenvolvimento tecnológico com foco na orientação e iniciação científica de alunos de graduação de Ciência da Computação.'),
	(3, 'Cassiano Ricardo de Oliveira Peres', 'Graduado em Tecnologia em Análise e Desenvolvimentos pela UTFPR Câmpus medianeira, mestrando em Tecnologias Computacionais para o Agornegócio na mesma universidade, atualmente empreendedor do ramo de Bitcoin e outras criptomoedas.'),
	(4, 'Arnaldo Candido Junior', 'Arnaldo Candido Junior é graduado em Ciência da Computação pela Universidade Estadual Paulista Julio de Mesquita Filho (UNESP), possui mestrado e doutorado em doutorado em Ciências de Computação e Matemática Computacional pela Universidade de São Paulo (NILC, ICMC, USP). Pesquisa na grande área de Inteligência Computacional, atuando na área de Processamento de Língua Natural, nos tópicos de análise sintática automática, análise semântica automática e simplificação sintática automática. Atualmente trabalha na Universidade Tecnológica Federal do Paraná (UTFPR).'),
	(5, 'Lucas Henrique', 'Not Defined'),
	(6, 'Marco Bagdal', 'Not Defined'),
	(7, 'Perito Policia Federal', 'Not Defined'),
	(8, 'Wesley Kleweton Guez Assunção ', 'Not Defined'),
	(9, 'Daniel Cavalcanti Jeronymo', 'Not Defined'),
	(10, 'Poster', 'Apresentação de Poster');
/*!40000 ALTER TABLE `trainer` ENABLE KEYS */;

-- Dumping structure for table meditec.trainer_contact
CREATE TABLE IF NOT EXISTS `trainer_contact` (
  `trainer` int(11) NOT NULL,
  `socialnetwork` int(11) NOT NULL,
  `link` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`trainer`,`socialnetwork`),
  KEY `FK_trainer_contact_social_network` (`socialnetwork`),
  CONSTRAINT `FK_trainer_contact_social_network` FOREIGN KEY (`socialnetwork`) REFERENCES `social_network` (`id`),
  CONSTRAINT `FK_trainer_contact_trainer` FOREIGN KEY (`trainer`) REFERENCES `trainer` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.trainer_contact: ~1 rows (approximately)
/*!40000 ALTER TABLE `trainer_contact` DISABLE KEYS */;
INSERT INTO `trainer_contact` (`trainer`, `socialnetwork`, `link`) VALUES
	(4, 1, 'arnaldoc'),
	(4, 3, 'https://www.linkedin.com/in/leonan-fraga-leonardo-42a283104/');
/*!40000 ALTER TABLE `trainer_contact` ENABLE KEYS */;

-- Dumping structure for table meditec.user
CREATE TABLE IF NOT EXISTS `user` (
  `id` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table meditec.user: ~0 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
