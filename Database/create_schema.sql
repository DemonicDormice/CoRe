-- MySQL Script generated by MySQL Workbench
-- Wed Nov 22 08:49:27 2017
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema d02852e4
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema d02852e4
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `d02852e4` DEFAULT CHARACTER SET utf8 ;
USE `d02852e4` ;

-- -----------------------------------------------------
-- Table `d02852e4`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `password` CHAR(128) NOT NULL,
  `salt` CHAR(128) NOT NULL,
  `active` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `d02852e4`.`login_attempts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`login_attempts` (
  `users_id` INT NOT NULL,
  `time` VARCHAR(30) NOT NULL,
  INDEX `fk_login_attempts_users_idx` (`users_id` ASC),
  CONSTRAINT `fk_login_attempts_users`
    FOREIGN KEY (`users_id`)
    REFERENCES `d02852e4`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `d02852e4`.`player`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`player` (
  `idplayer` INT NOT NULL AUTO_INCREMENT,
  `users_id` INT NOT NULL,
  `level` INT NOT NULL,
  `attitude` INT NOT NULL,
  `playername` VARCHAR(45) NOT NULL,
  INDEX `fk_character_users1_idx` (`users_id` ASC),
  PRIMARY KEY (`idplayer`),
  CONSTRAINT `fk_character_users1`
    FOREIGN KEY (`users_id`)
    REFERENCES `d02852e4`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `d02852e4`.`world`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`world` (
  `idworld` INT NOT NULL,
  `endtime` TIMESTAMP(0) NOT NULL,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`idworld`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `d02852e4`.`realm`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`realm` (
  `idrealm` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `type` VARCHAR(45) NULL,
  `world_idworld` INT NOT NULL,
  `x` INT NOT NULL,
  `y` INT NOT NULL,
  PRIMARY KEY (`idrealm`, `world_idworld`),
  UNIQUE INDEX `idrealm_UNIQUE` (`idrealm` ASC),
  INDEX `fk_realm_world1_idx` (`world_idworld` ASC),
  CONSTRAINT `fk_realm_world1`
    FOREIGN KEY (`world_idworld`)
    REFERENCES `d02852e4`.`world` (`idworld`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `d02852e4`.`army`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`army` (
  `idarmy` INT NOT NULL,
  `player_idplayer` INT NOT NULL,
  PRIMARY KEY (`idarmy`, `player_idplayer`),
  INDEX `fk_army_player1_idx` (`player_idplayer` ASC),
  CONSTRAINT `fk_army_player1`
    FOREIGN KEY (`player_idplayer`)
    REFERENCES `d02852e4`.`player` (`idplayer`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `d02852e4`.`tile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`tile` (
  `idtile` INT NOT NULL,
  `realm_idrealm` INT NOT NULL,
  `type` INT NULL,
  PRIMARY KEY (`idtile`, `realm_idrealm`),
  INDEX `fk_tile_realm1_idx` (`realm_idrealm` ASC),
  CONSTRAINT `fk_tile_realm1`
    FOREIGN KEY (`realm_idrealm`)
    REFERENCES `d02852e4`.`realm` (`idrealm`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `d02852e4`.`move`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`move` (
  `idmove` INT NOT NULL,
  `army_idarmy` INT NOT NULL,
  `army_users_id` INT NOT NULL,
  `tile_idtile` INT NOT NULL,
  `tile_realm_idrealm` INT NOT NULL,
  `entertime` TIMESTAMP(0) NULL,
  INDEX `fk_army_tile_tile1_idx` (`tile_idtile` ASC, `tile_realm_idrealm` ASC),
  PRIMARY KEY (`idmove`),
  CONSTRAINT `fk_army_tile_army1`
    FOREIGN KEY (`army_idarmy`)
    REFERENCES `d02852e4`.`army` (`idarmy`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_army_tile_tile1`
    FOREIGN KEY (`tile_idtile` , `tile_realm_idrealm`)
    REFERENCES `d02852e4`.`tile` (`idtile` , `realm_idrealm`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `d02852e4`.`unit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`unit` (
  `idunit` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `strength` VARCHAR(45) CHARACTER SET 'utf8' NULL,
  `player_idplayer` INT NOT NULL,
  `army_idarmy` INT NOT NULL,
  `army_player_idplayer` INT NOT NULL,
  PRIMARY KEY (`idunit`, `player_idplayer`),
  INDEX `fk_unit_player1_idx` (`player_idplayer` ASC),
  INDEX `fk_unit_army1_idx` (`army_idarmy` ASC, `army_player_idplayer` ASC),
  CONSTRAINT `fk_unit_player1`
    FOREIGN KEY (`player_idplayer`)
    REFERENCES `d02852e4`.`player` (`idplayer`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_unit_army1`
    FOREIGN KEY (`army_idarmy` , `army_player_idplayer`)
    REFERENCES `d02852e4`.`army` (`idarmy` , `player_idplayer`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = tis620;


-- -----------------------------------------------------
-- Table `d02852e4`.`settlement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d02852e4`.`settlement` (
  `tile_idtile` INT NOT NULL,
  `tile_realm_idrealm` INT NOT NULL,
  `player_idplayer` INT NOT NULL,
  `name` VARCHAR(45) NULL,
  `type` INT NOT NULL DEFAULT 0,
  `population` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`tile_idtile`, `tile_realm_idrealm`, `player_idplayer`),
  INDEX `fk_settlement_player1_idx` (`player_idplayer` ASC),
  CONSTRAINT `fk_settlement_tile1`
    FOREIGN KEY (`tile_idtile` , `tile_realm_idrealm`)
    REFERENCES `d02852e4`.`tile` (`idtile` , `realm_idrealm`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_settlement_player1`
    FOREIGN KEY (`player_idplayer`)
    REFERENCES `d02852e4`.`player` (`idplayer`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
