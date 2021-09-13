CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'Keep Name',
  description varchar(2000) COMMENT 'keep description',
  img varchar(255) COMMENT 'Keep Picture',
  views INT COMMENT 'keep views',
  shares INT comment 'shares',
  keeps INT COMMENT 'keeps',
  creatorId VARCHAR(255) NOT NULL COMMENT 'creator Id',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'Keep Name',
  description varchar(2000) COMMENT 'keep description',
  img varchar(2000) COMMENT 'vault picture',
  isPrivate TINYINT COMMENT 'is vault private?',
  creatorId VARCHAR(255) NOT NULL COMMENT 'creator Id',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


-- NOTE i want to add the creatorId option on the vaultKeeps but it likes to throw a wacky error when I do...
CREATE TABLE IF NOT EXISTS vaultKeeps(
  id int NOT NULL AUTO_INCREMENT primary key  comment 'primary key',
  vaultId int NOT NULL comment 'vault Id',
  keepId int NOT NULL comment 'keep id',
  creatorId VARCHAR(255) NOT NULL comment 'creator id',
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE
  ) default charset utf8 COMMENT '';