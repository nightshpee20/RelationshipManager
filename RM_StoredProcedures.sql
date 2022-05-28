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
CREATE PROCEDURE sp_deleteUserAcquaintance_UserCities(usr_id INT, ct_id INT)
BEGIN
	DELETE FROM user_acquaintance_relationships WHERE user_id = usr_id AND acquaintance_id IN (SELECT id FROM acquaintances WHERE city_id = ct_id);
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE PROCEDURE sp_deleteUserAcquaintance_UserOccupations(usr_id INT, occ_id INT)
BEGIN
	DELETE FROM user_acquaintance_relationships WHERE user_id = usr_id AND acquaintance_id IN (SELECT id FROM acquaintances WHERE occupation_id = occ_id);
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
                                           occ_id INT,
                                           ct_id INT, 
                                           adrs VARCHAR(40) CHARACTER SET utf16,
                                           rel_id INT)
BEGIN
    ### If there are no matching records in acquaintances, insert a new one and retrieve its id, else retrieve its id.
	IF
		((SELECT COUNT(*) FROM acquaintances WHERE first_name = fn AND last_name = ln AND gender = gen 
                                                   AND occupation_id = occ_id AND city_id = ct_id) = 0)
	THEN 
		#IF (adrs = '') THEN SET adrs := null; END IF;
		CALL sp_insertAcquaintance(fn, ln, gen, occ_id, ct_id, adrs);
	END IF;
    
	SET @id := (SELECT id FROM acquaintances WHERE first_name = fn AND last_name = ln AND gender = gen 
                                                   AND occupation_id = occ_id AND city_id = ct_id);
    
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


/* CHECKED */
DELIMITER $
CREATE PROCEDURE sp_updateUserCity(old_ct_id INT, new_city VARCHAR(40) CHARACTER SET utf16, usr_id INT)
BEGIN
	DECLARE i INT;
    
    IF((SELECT COUNT(*) FROM cities WHERE city = new_city) = 0)
		THEN CALL sp_insertUserCity(new_city, usr_id);
	END IF;
    
    SET @new_ct_id := (SELECT id FROM cities WHERE city = new_city);
    SET @loc_count := (SELECT COUNT(*) FROM user_locations ul JOIN locations l ON ul.location_id = l.id
					   WHERE user_id = usr_id AND city_id = old_ct_id);
    SET @acq_count := (SELECT COUNT(*) FROM user_acquaintance_relationships ua JOIN acquaintances a ON ua.acquaintance_id = a.id
					  WHERE city_id = old_ct_id AND user_id = usr_id);
	SET i := 0;
    
	IF(@loc_count > 0)
		THEN
			loop1: LOOP
			
				SET @location := (SELECT location FROM user_locations ul JOIN locations l ON ul.location_id = l.id
								  WHERE user_id = usr_id AND city_id = old_ct_Id LIMIT 1);
	
				 
				CALL sp_updateUserLocation(@location, old_ct_id, @location, @new_ct_id, usr_id);
                
                SET i := i + 1;
                IF(i = @loc_count) THEN LEAVE loop1; END IF;
			END LOOP;
    END IF;
    SET i := 0;
    
    IF(@acq_count > 0)
		THEN
			loop2: LOOP
				
				SELECT first_name, last_name, gender, occupation_id, address, relationship_id
                INTO @fname, @lname, @gen, @occ_id, @adrs, @rel_id
                FROM user_acquaintance_relationships ua JOIN acquaintances a ON ua.acquaintance_id = a.id
                WHERE user_id = usr_id AND city_id = old_ct_id
                LIMIT 1;
                

                IF((SELECT COUNT(*) FROM acquaintances WHERE first_name = @fname AND last_name = @lname AND gender = @gen
					AND occupation_id = @occ_id AND city_id = @new_ct_id AND address = @adrs) = 0)
                    THEN CALL sp_insertAcquaintance(@fname, @lname, @gen, @occ_id, @new_ct_id, @adrs);
				END IF;
                
                SET @new_acq_id := (SELECT id FROM acquaintances WHERE first_name = @fname AND last_name = @lname
									AND gender = @gen AND occupation_id = @occ_id AND /**/city_id = @new_ct_id/**/ AND address = @adrs);
				SET @old_acq_id := (SELECT id FROM acquaintances WHERE first_name = @fname AND last_name = @lname
									AND gender = @gen AND occupation_id = @occ_id AND /**/city_id = old_ct_id/**/ AND address = @adrs);
				
				
				
                
				UPDATE user_acquaintance_relationships SET acquaintance_id = @new_acq_id
                WHERE user_id = usr_id AND acquaintance_id = @old_acq_id;
                
                UPDATE user_meetings SET acquaintance_id = @new_acq_id
				WHERE user_id = usr_id AND acquaintance_id = @old_acq_id;

				IF((SELECT COUNT(*) FROM user_acquaintance_relationships WHERE acquaintance_id = @old_acq_id) = 0) 
					THEN DELETE FROM acquaintances WHERE id = @old_acq_id;
				END IF;
                
                SET i := i + 1;
				IF(i = @acq_count) THEN LEAVE loop2; END IF;
			END LOOP;
	END IF;
	
    DELETE FROM user_cities WHERE user_id = usr_id AND city_id = old_ct_id;
    
	IF((SELECT COUNT(*) FROM user_cities WHERE city_id = old_ct_id) = 0)
		THEN DELETE FROM cities WHERE id = old_ct_id;
    END IF;
    
END$
DELIMITER ;


/* CHECKED */
DELIMITER $ 
CREATE PROCEDURE sp_updateUserLocation (old_location VARCHAR(40) CHARACTER SET utf16, old_city INT, new_location VARCHAR(40) CHARACTER SET utf16, new_city INT, usr_id INT)
BEGIN

	IF 
		((SELECT COUNT(*) FROM locations WHERE location = new_location AND city_id = new_city) = 0)
    THEN 
		CALL sp_insertLocation(new_location, new_city);
    END IF; 

	SET @new_location_id := (SELECT id FROM locations WHERE location = new_location AND city_id = new_city);
    SET @old_location_id := (SELECT id FROM locations WHERE location = old_location AND city_id = old_city);
    
	UPDATE user_locations SET location_id = @new_location_id WHERE user_id = usr_id AND location_id = @old_location_id;
    UPDATE user_meetings SET location_id = @new_location_id WHERE location_id = @old_location_id AND user_id = usr_id;
    
    IF
		((SELECT COUNT(*) FROM user_locations WHERE location_id = @old_location_id) = 0)
	THEN
		DELETE FROM locations WHERE id = @old_location_id;
	END IF;
END$
DELIMITER ;


/* CHECKED */
DELIMITER $
CREATE PROCEDURE sp_updateUserOccupation(old_occ_id INT, new_occupation VARCHAR(30) CHARACTER SET utf16, usr_id INT)
BEGIN
	DECLARE i INT;
    
    IF((SELECT COUNT(*) FROM occupations WHERE occupation = new_occupation) = 0)
		THEN CALL sp_insertUserOccupation(new_occupation, usr_id);
	END IF;
    
    SET @new_occ_id := (SELECT id FROM occupations WHERE occupation = new_occupation);
    SET @acq_count := (SELECT COUNT(*) FROM user_acquaintance_relationships ua JOIN acquaintances a ON ua.acquaintance_id = a.id
					  WHERE occupation_id = old_occ_id AND user_id = usr_id);
	SET i := 0;
    
    IF(@acq_count > 0)
		THEN
			loops: LOOP
				
				SELECT first_name, last_name, gender, city_id, address, relationship_id
                INTO @fname, @lname, @gen, @ct_id, @adrs, @rel_id
                FROM user_acquaintance_relationships ua JOIN acquaintances a ON ua.acquaintance_id = a.id
                WHERE user_id = usr_id AND occupation_id = old_occ_id
                LIMIT 1;
                
				
                IF((SELECT COUNT(*) FROM acquaintances WHERE first_name = @fname AND last_name = @lname AND gender = @gen
					AND occupation_id = @new_occ_id AND city_id = @ct_id AND address = @adrs) = 0)
                    THEN CALL sp_insertAcquaintance(@fname, @lname, @gen, @new_occ_id, @ct_id, @adrs);
				END IF;
                
                SET @new_acq_id := (SELECT id FROM acquaintances WHERE first_name = @fname AND last_name = @lname
									AND gender = @gen AND occupation_id = @new_occ_id AND city_id = @ct_id AND address = @adrs);
				SET @old_acq_id := (SELECT id FROM acquaintances WHERE first_name = @fname AND last_name = @lname
									AND gender = @gen AND occupation_id = old_occ_id AND city_id = @ct_id AND address = @adrs);
                                   
				UPDATE user_acquaintance_relationships SET acquaintance_id = @new_acq_id
                WHERE user_id = usr_id AND acquaintance_id = @old_acq_id;
                
                UPDATE user_meetings SET acquaintance_id = @new_acq_id
				WHERE user_id = usr_id AND acquaintance_id = @old_acq_id;
                

				IF((SELECT COUNT(*) FROM user_acquaintance_relationships WHERE acquaintance_id = @old_acq_id) = 0) 
					THEN DELETE FROM acquaintances WHERE id = @old_acq_id;
				END IF;
                
                SET i := i + 1;
				IF(i = @acq_count) THEN LEAVE loops; END IF;
			END LOOP;
	END IF;
	
    DELETE FROM user_occupations WHERE user_id = usr_id AND occupation_id = old_occ_id;
    
	IF((SELECT COUNT(*) FROM user_occupations WHERE occupation_id = old_occ_id) = 0)
		THEN DELETE FROM occupations WHERE id = old_occ_id;
    END IF;
END$
DELIMITER ;

######################################################### EXPERIMENTAL
DELIMITER $
CREATE PROCEDURE sp_updateUserAcquaintance(old_acq_id INT, new_first_name VARCHAR(30) CHARACTER SET utf16,
														   new_last_name VARCHAR(30) CHARACTER SET utf16,
														   new_gender CHAR(1),
														   new_occupation_id INT,
														   new_city_id INT,
														   new_address VARCHAR(40) CHARACTER SET utf16,
														   new_relationship_id INT,
														   usr_id INT)
BEGIN
	IF
		((SELECT COUNT(*) FROM acquaintances WHERE first_name = new_first_name AND last_name = new_last_name AND city_id = new_city_id) = 0)
	THEN
		CALL sp_insertAcquaintance(new_first_name, new_last_name, new_gender, new_occupation_id, new_city_id, new_address);
	END IF;
	
    SET @new_acq_id := (SELECT id FROM acquaintances WHERE first_name = new_first_name AND
														   last_name = new_last_name AND
														   city_id = new_city_id);
																
	UPDATE user_acquaintance_relationships SET acquaintance_id = @new_acq_id, relationship_id = new_relationship_id 
    WHERE user_id = usr_id AND acquaintance_id = old_acq_id;

	UPDATE user_meetings SET acquaintance_id = @new_acq_id WHERE user_id = usr_id AND
																 acquaintance_id = old_acq_id;
																		
	IF
		((SELECT COUNT(*) FROM user_acquaintance_relationships WHERE acquaintance_id = old_acq_id) = 0)
	THEN
		DELETE FROM acquaintances WHERE id = old_acq_id;
	END IF;
END$
DELIMITER ;





DELIMITER $
CREATE PROCEDURE sp_updateUserMeeting (old_acq_id INT, old_dt DATETIME,
									   new_acq_id INT, new_dt DATETIME, new_rea_id INT, new_loc_id INT, usr_id INT)
BEGIN
	UPDATE user_meetings SET date_time = new_dt, acquaintance_id = new_acq_id, reason_id = new_rea_id, location_id = new_loc_id
    WHERE user_id = usr_id AND acquaintance_id = old_acq_id AND date_time = old_dt;
END$
DELIMITER ;


DELIMITER $
CREATE PROCEDURE sp_updateUserReason(old_reason VARCHAR(50) CHARACTER SET utf16, new_reason VARCHAR(50) CHARACTER SET utf16, usr_id INT)
BEGIN
	IF
		((SELECT COUNT(*) FROM reasons WHERE reason = new_reason) = 0)
	THEN
		CALL sp_insertReason(new_reason);
	END if;
    
    SET @new_reason_id := (SELECT id FROM reasons WHERE reason = new_reason);
	SET @old_reason_id := (SELECT id FROM reasons WHERE reason = old_reason);
    
	UPDATE user_reasons SET reason_id = @new_reason_id WHERE reason_id = @old_reason_id AND user_id = usr_id;
    UPDATE user_meetings SET reason_id = @new_reason_id WHERE reason_id = @old_reason_id AND user_id = usr_id;
    
    IF
		((SELECT COUNT(*) FROM user_reasons WHERE reason_id = @old_reason_id) = 0)
	THEN
		DELETE FROM reasons WHERE id = @old_reason_id;
	END IF;
END$
DELIMITER ; 


DELIMITER $
CREATE PROCEDURE sp_updateUserRelationship(old_rel_id INT, new_relationship VARCHAR(30) CHARACTER SET utf16, usr_id INT)
BEGIN
	IF
		((SELECT COUNT(*) FROM relationships WHERE relationship = new_relationship) = 0)
	THEN
		CALL sp_insertRelationship(new_relationship);
    END IF;
    
    SET @new_rel_id := (SELECT id FROM relationships WHERE relationship = new_relationship);
    
    UPDATE user_relationships SET relationship_id = @new_rel_id WHERE user_id = usr_id AND relationship_id = old_rel_id;
    UPDATE user_acquaintance_relationships SET relationship_id = @new_rel_id WHERE user_id = usr_id AND relationship_id = old_rel_id;

	IF
		((SELECT COUNT(*) FROM user_relationships WHERE relationship_id = old_rel_id) = 0)
	THEN
		DELETE FROM relationships WHERE id = old_rel_id;
    END IF;
END$
DELIMITER ;


## EXTRA EXPERIMENTAL
