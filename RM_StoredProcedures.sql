USE rmdb;

-- STORED PROCEDURES
/* CHECKED */
DELIMITER $
CREATE PROCEDURE showt (tcode VARCHAR(5)) 
BEGIN
	IF tcode = 'a'
    THEN SELECT * FROM acquaintances;
    ELSEIF tcode = 'c'
    THEN SELECT * FROM cities;
    ELSEIF tcode = 'm'
    THEN SELECT * FROM meetings;
    ELSEIF tcode = 'o'
    THEN SELECT * FROM occupations;
    ELSEIF tcode = 'rea'
    THEN SELECT * FROM reasons;
    ELSEIF tcode = 'rel'
    THEN SELECT * FROM relationships;
    ELSEIF tcode = 'u'
    THEN SELECT * FROM users;
    ELSEIF tcode = 'ua'
    THEN SELECT * FROM user_acquaintance_relationships ORDER BY user_id, acquaintance_id;
    ELSEIF tcode = 'uc'
    THEN SELECT * FROM user_cities;
    ELSEIF tcode = 'uo'
    THEN SELECT * FROM user_occupations;
    ELSEIF tcode = 'urea'
    THEN SELECT * FROM user_reasons;
    ELSEIF tcode = 'urel'
    THEN SELECT * FROM user_relationships;
    ELSE SELECT 'There is no such table! Try: \'a\', \'c\', \'m\', \'o\', \'rea\', \'rel\', \'u\', \'ua\', \'uo\', \'urea\', \'urel\'.'
    AS 'Error!' FROM DUAL;
    END IF;
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertAcquaintance (fn VARCHAR(30) CHARACTER SET utf16,
										ln VARCHAR(30) CHARACTER SET utf16,
                                        gen CHAR(1),
                                        ocp_id INT,
                                        ct_id INT,
                                        adrs VARCHAR(40) CHARACTER SET utf16)
BEGIN
	INSERT INTO acquaintances(first_name, last_name, gender, occupation_id, city_id, address) VALUES (fn, ln, gen, ocp_id, ct_id, adrs);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertCity (ct VARCHAR(40) CHARACTER SET utf16)
BEGIN
	INSERT INTO cities(city) VALUES(ct);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertMeeting (usr_id INT, acq_id INT, dt DATETIME, rsn_id INT, cmnts VARCHAR(1000) CHARACTER SET utf16)
BEGIN
	INSERT INTO meetings(user_id, acquaintance_id, date_time, reason_id, comments) VALUES (usr_id, acq_id, dt, rsn_id, cmnts);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertOccupation (ocp VARCHAR(30) CHARACTER SET utf16)
BEGIN
	INSERT INTO occupations(occupation) VALUES(ocp);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertReason (rsn VARCHAR(50) CHARACTER SET utf16)
BEGIN
	INSERT INTO reasons(reason) VALUES(rsn);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE PROCEDURE sp_insertRelationship (IN rel VARCHAR(30) CHARACTER SET utf16)
BEGIN
	INSERT INTO relationships(relationship) VALUES(rel);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertUser (usrn VARCHAR(30), pwd VARCHAR(30), em VARCHAR(40), num CHAR(10))
BEGIN
	INSERT INTO users(username, password, email, mobile_number) VALUES(usrn, pwd, em, num);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE PROCEDURE sp_insertUserAcquaintance (usr_id INT, 
                                           fn VARCHAR(30) CHARACTER SET utf16,
										   ln VARCHAR(30) CHARACTER SET utf16,
										   gen CHAR(1),
                                           ocp_id INT,
                                           ct_id INT, 
                                           adrs VARCHAR(40) CHARACTER SET utf16,
                                           rel_id INT)
BEGIN
    ### If there are no matching records in acquaintances, insert a new one and retrieve its id, else retrieve its id.
	IF
		((SELECT COUNT(*) FROM acquaintances WHERE first_name = fn AND 
		 										  last_name =ln AND
                                                  city_id = ct_id) = 0)
	THEN 
		CALL sp_insertAcquaintance(fn, ln, gen, ocp_id, ct_id, adrs);
		SET @id := (SELECT id FROM acquaintances WHERE first_name = fn AND last_name = ln AND city_id = ct_id);
	ELSE
		SET @id := (SELECT id FROM acquaintances WHERE first_name = fn AND last_name = ln AND city_id = ct_id);
	END IF;
	
    IF
		(rel_id IN (SELECT relationship_id FROM user_relationships WHERE user_id = usr_id))
	THEN
		INSERT INTO user_acquaintance_relationships(user_id, acquaintance_id, relationship_id)
		VALUES (usr_id, @id, rel_id);
	ELSE
		SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Invalid relationship id!', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;


-- Similar to sp_insertUserAcquaintance
/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertUserCity (ct VARCHAR(40) CHARACTER SET utf16, usr_id INT)
BEGIN
	IF 
		((SELECT COUNT(*) FROM cities WHERE city = ct) = 0)
    THEN 
		CALL sp_insertCity(ct);
		SET @id := (SELECT id FROM cities WHERE city = ct);
    ELSE
		SET @id := (SELECT id FROM cities WHERE city = ct);
    END IF;
    
    INSERT INTO user_cities(city_id, user_id) VALUES (@id, usr_id);
END$
DELIMITER ;


-- Similar to sp_insertUserAcquaintance
/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertUserOccupation (occ VARCHAR(30) CHARACTER SET utf16, usr_id INT)
BEGIN
	IF 
		((SELECT COUNT(*) FROM occupations WHERE occupation = occ) = 0)
    THEN 
		CALL sp_insertOccupation(occ);
		SET @id := (SELECT id FROM occupations WHERE occupation = occ);
    ELSE
		SET @id := (SELECT id FROM occupations WHERE occupation = occ);
    END IF;
    
    INSERT INTO user_occupations(occupation_id, user_id) VALUES (@id, usr_id);
END$
DELIMITER ;


-- Similar to sp_insertUserAcquaintance
/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertUserReason (rsn VARCHAR(30) CHARACTER SET utf16, IN usr_id INT)
BEGIN
	IF 
		((SELECT COUNT(*) FROM reasons WHERE reason = rsn) = 0)
    THEN 
		CALL sp_insertReason(rsn);
		SET @id := (SELECT id FROM reasons WHERE reason = rsn);
    ELSE
		SET @id := (SELECT id FROM reasons WHERE reason = rsn);
    END IF;
    
    INSERT INTO user_reasons(reason_id, user_id) VALUES (@id, usr_id);
END$
DELIMITER ;


-- Similar to sp_insertUserAcquaintance
/* CHECKED */
DELIMITER $
CREATE PROCEDURE sp_insertUserRelationship (rel VARCHAR(30) CHARACTER SET utf16, usr_id INT)
BEGIN
	IF 
		((SELECT COUNT(*) FROM relationships WHERE relationship = rel) = 0)
    THEN 
		INSERT INTO relationships(relationship) VALUES (rel);
		SET @id := (SELECT id FROM relationships WHERE relationship = rel);
    ELSE
		SET @id := (SELECT id FROM relationships WHERE relationship = rel);
    END IF;
    
    INSERT INTO user_relationships(relationship_id, user_id) VALUES (@id, usr_id);
END$
DELIMITER ;


-- EXPERIMENTAL ----------------------------------------------------------------------------------------------------------

DELIMITER $
CREATE PROCEDURE sp_deleteUserAcquaintance (usr_id INT, acq_id INT)
BEGIN
	DELETE FROM user_acquaintance_relationships WHERE user_id = usr_id AND acquaintance_id = acq_id;
END$
DELIMITER ;


DELIMITER $
CREATE TRIGGER tg_del_deleteAllAcquaintancesWhichIdIsNotReferencedInUserAcquaintanceRelationships AFTER DELETE ON user_acquaintance_relationships FOR EACH ROW
BEGIN
	IF((SELECT COUNT(*) FROM user_acquaintance_relationships WHERE acquaintance_id = OLD.acquaintance_id) = 0)
    THEN DELETE FROM acquaintances WHERE id = OLD.acquaintance_id;
	END IF;
END$
DELIMITER ;


DELIMITER $
CREATE PROCEDURE sp_deleteUserCity (usr_id INT, ct_id INT)
BEGIN
	DELETE FROM user_cities WHERE user_id = usr_id AND city_id = ct_id;
END$
DELIMITER $


DELIMITER $
CREATE TRIGGER tg_del_

CREATE PROCEDURE sp_deleteCity (ct_id INT)
BEGIN
	#MAKE INTO AN INDEPENDANT PROCEDURE
	DELETE FROM user_acquaintance_relationships 
	WHERE acquaintance_id IN (SELECT id FROM acquaintances WHERE city_id = ct);
    
    #MAKE INTO AN INDEPENDAT PROCEDURE
    DELETE FROM acquaintances WHERE city_id = ct;

    DELETE FROM user_cities WHERE city_id = ct;
END$
DELIMITER ;