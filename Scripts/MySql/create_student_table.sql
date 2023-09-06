
CREATE TABLE `students` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `RollNo` int(11) NOT NULL,
  `Section` varchar(15) NOT NULL,
  `BirthDate` varchar(15) NOT NULL,
  `BloodGroup` varchar(4) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `CreatedAt` date NOT NULL,
  `ModifiedBy` int(11) NOT NULL,
  `ModifiedAt` date NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
