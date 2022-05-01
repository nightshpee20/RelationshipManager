USE rmdb;

-- STORED PROCEDURES
/* CHECKED */
DELIMITER $
CREATE PROCEDURE showt (tcode VARCHAR(5)) 
BEGIN
	IF tcode = 'a'
    THEN SELECT * FROM acquaintances ORDER BY id;
    ELSEIF tcode = 'c'
    THEN SELECT * FROM cities ORDER BY id;
    ELSEIF tcode = 'o'
    THEN SELECT * FROM occupations ORDER BY id;
    ELSEIF tcode = 'l'
    THEN SELECT * FROM locations ORDER BY id;
    ELSEIF tcode = 'rea'
    THEN SELECT * FROM reasons ORDER BY id;
    ELSEIF tcode = 'rel'
    THEN SELECT * FROM relationships ORDER BY id;
    ELSEIF tcode = 'u'
    THEN SELECT * FROM users ORDER BY id;
    ELSEIF tcode = 'ua'
    THEN SELECT * FROM user_acquaintance_relationships ORDER BY user_id, acquaintance_id;
    ELSEIF tcode = 'uc'
    THEN SELECT * FROM user_cities ORDER BY user_id;
    ELSEIF tcode = 'ul'
    THEN SELECT * FROM user_locations ORDER BY user_id;
	ELSEIF tcode = 'um'
    THEN SELECT * FROM user_meetings ORDER BY user_id;
    ELSEIF tcode = 'uo'
    THEN SELECT * FROM user_occupations ORDER BY user_id;
    ELSEIF tcode = 'urea'
    THEN SELECT * FROM user_reasons ORDER BY user_id;
    ELSEIF tcode = 'urel'
    THEN SELECT * FROM user_relationships ORDER BY user_id;
    ELSE SELECT 'There is no such table! Try: \'a\', \'c\', \'l\', \'o\', \'rea\', \'rel\', \'u\', \'ua\', \'uc\', \'ul\', \'um\', \'uo\', \'urea\', \'urel\'.'
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
CREATE PROCEDURE sp_insertLocation (loc VARCHAR(40) CHARACTER SET utf16, ct_id INT)
BEGIN
	INSERT INTO locations(location, city_id) VALUES(loc, ct_id);
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
		IF 
			(adrs = '') 
        THEN
			SET adrs := null;
		END IF;
        
		CALL sp_insertAcquaintance(fn, ln, gen, ocp_id, ct_id, adrs);
	END IF;
    
	SET @id := (SELECT id FROM acquaintances WHERE first_name = fn AND last_name = ln AND city_id = ct_id);
    
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
    END IF;
    
    SET @id := (SELECT id FROM cities WHERE city = ct);
    INSERT INTO user_cities(city_id, user_id) VALUES (@id, usr_id);
END$
DELIMITER ;


-- Similar to sp_insertUserAcquaintance
/* CHECKED */
DELIMITER $
CREATE PROCEDURE sp_insertUserLocation (loc VARCHAR(40) CHARACTER SET utf16, ct_id INT, usr_id INT)
BEGIN
	IF
		((SELECT COUNT(city_id) FROM user_cities WHERE user_id = usr_id AND city_id = ct_id) = 1)
	THEN
		IF
			((SELECT COUNT(*) FROM locations WHERE location = loc AND city_id = ct_id) = 0) 
		THEN
			CALL sp_insertLocation(loc, ct_id);
		END IF;
            SET @id := (SELECT id FROM locations WHERE location = loc AND city_id = ct_id);
			INSERT INTO user_locations(user_id, location_id) VALUES(usr_id, @id);
	ELSE
		SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Invalid city_id and user_id combination!', MYSQL_ERRNO = 1001;
	END IF;
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_insertUserMeeting (usr_id INT, acq_id INT, dt DATETIME, rsn_id INT, loc_id INT, cmnts VARCHAR(1000) CHARACTER SET utf16)
BEGIN
	IF
		((SELECT COUNT(*) FROM user_reasons WHERE user_id = usr_id AND reason_id = rsn_id) = 0)
        OR ((SELECT COUNT(*) FROM user_locations WHERE user_id = usr_id AND location_id = loc_id) = 0)
	THEN
		SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Invalid reason_id or location_id for this user!', MYSQL_ERRNO = 1001;
	ELSE
		INSERT INTO user_meetings(user_id, acquaintance_id, date_time, reason_id, location_id, comments) VALUES (usr_id, acq_id, dt, rsn_id, loc_id, cmnts);
	END IF;
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
    END IF;
    
    SET @id := (SELECT id FROM occupations WHERE occupation = occ);
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
    END IF;
    
    SET @id := (SELECT id FROM reasons WHERE reason = rsn);
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
    END IF;
    
    SET @id := (SELECT id FROM relationships WHERE relationship = rel);
    INSERT INTO user_relationships(relationship_id, user_id) VALUES (@id, usr_id);
END$
DELIMITER ;
