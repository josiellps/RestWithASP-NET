CREATE TABLE IF NOT EXISTS `books`(
    `id` varchar(127) NOT NULL,
    `Author` longtext,
    `LaunchDate` DATETIME(6) NOT NULL,
    `Price` decimal(65,2) NOT null,
    `Title` longtext,
    PRIMARY KEY(`id`) 
)ENGINE=InnoDB DEFAULT CHARSET=latin1;