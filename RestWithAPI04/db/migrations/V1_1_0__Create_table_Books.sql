CREATE TABLE IF NOT EXISTS `books`(
    `id` INT(10) AUTO_INCREMENT PRIMARY KEY,
    `Author` longtext,
    `LaunchDate` DATETIME(6) NOT NULL,
    `Price`decimal(65,2) NOT NULL,
    `Title` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;