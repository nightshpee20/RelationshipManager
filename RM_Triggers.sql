USE rmdb;

-- TRIGGERS
-- Acquaintances ------------------------------------------------------------------------
/* CHECKED */
DELIMITER $ 
CREATE TRIGGER tg_ins_lowerAcquaintances BEFORE INSERT ON acquaintances FOR EACH ROW
BEGIN
	SET NEW.first_name := LOWER(NEW.first_name);
    SET NEW.last_name := LOWER(NEW.last_name);
    SET NEW.gender := LOWER(NEW.gender);
    SET NEW.address := LOWER(NEW.address);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE TRIGGER tg_upd_lowerAcquaintances BEFORE UPDATE ON acquaintances FOR EACH ROW
BEGIN
	SET NEW.first_name := LOWER(NEW.first_name);
    SET NEW.last_name := LOWER(NEW.last_name);
    SET NEW.gender := LOWER(NEW.gender);
    SET NEW.address := LOWER(NEW.address);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_deleteAcquaintanceFromParentTable BEFORE DELETE ON user_acquaintance_relationships FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_acquaintance_relationships WHERE acquaintance_id = OLD.acquaintance_id) = 0)
	THEN
		DELETE FROM acquaintances WHERE id = OLD.acquaintance_id;
	END IF;
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_abortDeleteAcquaintaces BEFORE DELETE ON acquaintances FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_acquaintance_relationships WHERE acquaintance_id = OLD.id) > 0)
	THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Deletion aborted! There are child tables referencing this value.', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;


-- Cities -------------------------------------------------------------------------------
/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_ins_lowerCities BEFORE INSERT ON cities FOR EACH ROW
BEGIN
	SET NEW.city := LOWER(NEW.city);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_upd_lowerCities BEFORE UPDATE ON cities FOR EACH ROW
BEGIN
	SET NEW.city := LOWER(NEW.city);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_deleteCitiesFromParentTable AFTER DELETE ON user_cities FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_cities WHERE city_id = OLD.city_id) = 0)
	THEN
		DELETE FROM cities WHERE id = OLD.city_id;
	END IF;
    
    CALL sp_deleteUserAcquaintance_UserCities(OLD.user_id, OLD.city_id);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_abortDeleteCities BEFORE DELETE ON cities FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_cities WHERE city_id = OLD.id) > 0)
	THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Deletion aborted! There are child tables referencing this value.', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;


-- Locations ----------------------------------------------------------------------------
/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_ins_lowerLocations BEFORE INSERT ON locations FOR EACH ROW
BEGIN
	SET NEW.location := LOWER(NEW.location);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_upd_lowerLocation BEFORE UPDATE ON locations FOR EACH ROW
BEGIN
	SET NEW.location := LOWER(NEW.location);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_deleteLocationFromParentTable AFTER DELETE ON user_locations FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_locations WHERE location_id = OLD.location_id) = 0)
	THEN
		DELETE FROM locations WHERE id = OLD.location_id;
	END IF;
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_abortDeleteLocations BEFORE DELETE ON locations FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_locations WHERE location_id = OLD.id) > 0)
	THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Deletion aborted! There are child tables referencing this value.', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;


-- Occupations --------------------------------------------------------------------------
/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_ins_lowerOccupations BEFORE INSERT ON occupations FOR EACH ROW
BEGIN
	SET NEW.occupation := LOWER(NEW.occupation);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_upd_lowerOccupations BEFORE UPDATE ON occupations FOR EACH ROW
BEGIN
	SET NEW.occupation := LOWER(NEW.occupation);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_deleteOccupationFromParentTable AFTER DELETE ON user_occupations FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_occupations WHERE occupation_id = OLD.occupation_id) = 0)
	THEN
		DELETE FROM occupations WHERE id = OLD.occupation_id;
	END IF;
    
    CALL sp_deleteUserAcquaintance_UserOccupations(OLD.user_id, OLD.occupation_id);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_abortDeleteOccupations BEFORE DELETE ON occupations FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_occupations WHERE occupation_id = OLD.id) > 0)
	THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Deletion aborted! There are child tables referencing this value.', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;


-- Reasons ------------------------------------------------------------------------------
/* CHECK */
DELIMITER $
CREATE TRIGGER tg_ins_lowerReasons BEFORE INSERT ON reasons FOR EACH ROW
BEGIN
	SET NEW.reason := LOWER(NEW.reason);
END$
DELIMITER ;


/* CHECK */
DELIMITER $
CREATE TRIGGER tg_upd_lowerReasons BEFORE UPDATE ON reasons FOR EACH ROW
BEGIN
	SET NEW.reason := LOWER(NEW.reason);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_deleteReasonFromParentTable AFTER DELETE ON user_reasons FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_reasons WHERE reason_id = OLD.reason_id) = 0)
	THEN
		DELETE FROM reasons WHERE id = OLD.reason_id;
	END IF;
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_abortDeleteReasons BEFORE DELETE ON reasons FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_reasons WHERE reason_id = OLD.id) > 0)
	THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Deletion aborted! There are child tables referencing this value.', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;


-- Relationships ------------------------------------------------------------------------
/* CHECK */
DELIMITER $
CREATE TRIGGER tg_ins_lowerRelationships BEFORE INSERT ON relationships FOR EACH ROW
BEGIN
	SET NEW.relationship := LOWER(NEW.relationship);
END$
DELIMITER ;


/* CHECK */
DELIMITER $
CREATE TRIGGER tg_upd_lowerRelationships BEFORE UPDATE ON relationships FOR EACH ROW
BEGIN
	SET NEW.relationship := LOWER(NEW.relationship);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_deleteRelationshipFromParentTable AFTER DELETE ON user_relationships FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_relationships WHERE relationship_id = OLD.relationship_id) = 0)
	THEN
		DELETE FROM relationships WHERE id = OLD.relationship_id;
	END IF;
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE TRIGGER tg_del_abortDeleteRelationship BEFORE DELETE ON relationships FOR EACH ROW
BEGIN
	IF
		((SELECT COUNT(*) FROM user_relationships WHERE relationship_id = OLD.id) > 0)
	THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Deletion aborted! There are child tables referencing this value.', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;
