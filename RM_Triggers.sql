USE rmdb;

-- TRIGGERS
-- Acquaintances ------------------------------------------------------------------------
/* CHECKED */
DELIMITER $ 
CREATE TRIGGER tg_ins_lowerAcquaintances BEFORE INSERT ON acquaintances FOR EACH ROW
BEGIN
	SET NEW.first_name = LOWER(NEW.first_name);
    SET NEW.last_name = LOWER(NEW.last_name);
    SET NEW.gender = LOWER(NEW.gender);
    SET NEW.address = LOWER(NEW.address);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE TRIGGER tg_upd_lowerAcquaintances BEFORE UPDATE ON acquaintances FOR EACH ROW
BEGIN
	SET NEW.first_name = LOWER(NEW.first_name);
    SET NEW.last_name = LOWER(NEW.last_name);
    SET NEW.gender = LOWER(NEW.gender);
    SET NEW.address = LOWER(NEW.address);
END$
DELIMITER ;


DELIMITER $
CREATE TRIGGER tg_del_checkAcquaintanceReferenceInUserAcquaintanceRelationships AFTER DELETE ON user_acquaintance_relationships FOR EACH ROW
BEGIN
	IF((SELECT COUNT(*) FROM user_acquaintance_relationships WHERE acquaintance_id = OLD.acquaintance_id) = 0)
    THEN DELETE FROM acquaintances WHERE id = OLD.acquaintance_id;
	END IF;
END$
DELIMITER ;
drop trigger tg_del_checkAcquaintanceReferenceInUserAcquaintanceRelationships;

-- Cities -------------------------------------------------------------------------------
/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_ins_lowerCities BEFORE INSERT ON cities FOR EACH ROW
BEGIN
	SET NEW.city = LOWER(NEW.city);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_upd_lowerCities BEFORE UPDATE ON cities FOR EACH ROW
BEGIN
	SET NEW.city = LOWER(NEW.city);
END$
DELIMITER ;


DELIMITER $
CREATE TRIGGER tg_del_checkWhetherToDeleteRecordFromCities AFTER DELETE ON user_cities FOR EACH ROW
BEGIN
	IF ((SELECT COUNT(*) FROM user_cities WHERE city_id = OLD.city_id) = 0)
    THEN DELETE FROM cities WHERE id = OLD.city_id;
    END IF;
END$
DELIMITER ;


#DELIMITER $
#CREATE TRIGGER tg_del_changeCityReferenceInAcquaintace BEFORE DELETE ON user_cities FOR EACH ROW
#BEGIN
#	IF


-- Occupations --------------------------------------------------------------------------
/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_ins_lowerOccupations BEFORE INSERT ON occupations FOR EACH ROW
BEGIN
	SET NEW.occupation = LOWER(NEW.occupation);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_upd_lowerOccupations BEFORE UPDATE ON occupations FOR EACH ROW
BEGIN
	SET NEW.occupation = LOWER(NEW.occupation);
END$
DELIMITER ;


-- Reasons ------------------------------------------------------------------------------
/* CHECK */
DELIMITER $
CREATE TRIGGER tg_ins_lowerReasons BEFORE INSERT ON reasons FOR EACH ROW
BEGIN
	SET NEW.reason = LOWER(NEW.reason);
END$
DELIMITER ;


/* CHECK */
DELIMITER $
CREATE TRIGGER tg_upd_lowerReasons BEFORE UPDATE ON reasons FOR EACH ROW
BEGIN
	SET NEW.reason = LOWER(NEW.reason);
END$
DELIMITER ;


-- Relationships ------------------------------------------------------------------------
/* CHECK */
DELIMITER $
CREATE TRIGGER tg_ins_lowerRelationships BEFORE INSERT ON relationships FOR EACH ROW
BEGIN
	SET NEW.relationship = LOWER(NEW.relationship);
END$
DELIMITER ;


/* CHECK */
DELIMITER $
CREATE TRIGGER tg_upd_lowerRelationships BEFORE UPDATE ON relationships FOR EACH ROW
BEGIN
	SET NEW.relationship = LOWER(NEW.relationship);
END$
DELIMITER ;

