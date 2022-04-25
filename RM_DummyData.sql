USE rmdb; 

-- GENERATE USERS 
-- (username, password, email, mobile_number)
CALL sp_insertUser('nikolamarin','nikolamarin1', 'nikola@fake.com', '1234567890');
CALL sp_insertUser('stefanstefanov','stefastefanov1', 'stefan@fake.com', '1234567891');
CALL sp_insertUser('angelangelov','angelangelov1', 'angel@fake.com', '1234567892');
CALL sp_insertUser('ivanivanov','ivanivanov1', 'ivan@fake.com', '1234567893');
CALL sp_insertUser('petarpetrov','petarpetrov1', 'petar@fake.com', '1234567894');
CALL sp_insertUser('maximmaximov','maximmaximov1', 'maxim@fake.com', '1234567895');
CALL sp_insertUser('stamatstamatov','stamatstamatov1', 'stamat@fake.com', '1234567896'); 
CALL sp_insertUser('sotirsotirov','sotirsotirov1', 'sotir@fake.com', '1234567897'); 
CALL sp_insertUser('kirilkirilov','kirilkirilov1', 'kiril@fake.com', '1234567898');
CALL sp_insertUser('ivailoivailov','ivailoivailov1', 'ivailo@fake.com', '1234567899');   
 
 
# ALL sp_insertUser... GENERATE DATA FOR THEIR RESPECTIVE PARENT TABLES.
-- GENERATE CITIES
-- (city, user_id)
CALL sp_insertUserCity('Varna', 1);
CALL sp_insertUserCity('Burgas', 1);
CALL sp_insertUserCity('Sofia', 1);
CALL sp_insertUserCity('Plovdiv', 1);
CALL sp_insertUserCity('Veliko Tarnovo', 1);
CALL sp_insertUserCity('Stara Zagora', 1);
CALL sp_insertUserCity('Shumen', 1);
CALL sp_insertUserCity('Lom', 1);
CALL sp_insertUserCity('Pernik', 1);
CALL sp_insertUserCity('Montana', 1);

CALL sp_insertUserCity('Varna', 2);
CALL sp_insertUserCity('Burgas', 2);
CALL sp_insertUserCity('Sofia', 2);
CALL sp_insertUserCity('Plovdiv', 2);
CALL sp_insertUserCity('Veliko Tarnovo', 2);
CALL sp_insertUserCity('Stara Zagora', 2);
CALL sp_insertUserCity('Shumen', 2);
CALL sp_insertUserCity('Lom', 2);
CALL sp_insertUserCity('Pernik', 2);
CALL sp_insertUserCity('Montana', 2);


-- GENERATE LOCATIONS
-- (location, city_id, user_id)
CALL sp_insertUserLocation('The dog park', 2, 1);
CALL sp_insertUserLocation('The Cinema', 3, 1);
CALL sp_insertUserLocation('Ted\'s Cafe', 2, 1);
CALL sp_insertUserLocation('Secrets', 6, 1);
CALL sp_insertUserLocation('The gym', 10, 1);
CALL sp_insertUserLocation('The car fair', 4, 1);
CALL sp_insertUserLocation('The library', 1, 1);
CALL sp_insertUserLocation('Comic con', 8, 1);
CALL sp_insertUserLocation('The beach', 2, 1);
CALL sp_insertUserLocation('Sunday marathon', 6, 1);

CALL sp_insertUserLocation('The dog park', 2, 2);
CALL sp_insertUserLocation('The Cinema', 3, 2);
CALL sp_insertUserLocation('Ted\'s Cafe', 2, 2);
CALL sp_insertUserLocation('Secrets', 6, 2);
CALL sp_insertUserLocation('The gym', 10, 2);
CALL sp_insertUserLocation('The car fair', 4, 2);
CALL sp_insertUserLocation('The library', 4, 2);
CALL sp_insertUserLocation('Comic con', 8, 2);
CALL sp_insertUserLocation('The beach', 2, 2);
CALL sp_insertUserLocation('Sunday marathon', 6, 2);

-- GENERATE USER_OCCUPATIONS
-- (occupation, user_id)
CALL sp_insertUserOccupation('Unemployed', 1);
CALL sp_insertUserOccupation('Attourney', 1);
CALL sp_insertUserOccupation('Cheff', 1);
CALL sp_insertUserOccupation('Taxi Driver', 1);
CALL sp_insertUserOccupation('Teacher', 1);
CALL sp_insertUserOccupation('Student', 1);
CALL sp_insertUserOccupation('Programmer', 1);
CALL sp_insertUserOccupation('Professor', 1);
CALL sp_insertUserOccupation('Yoga Instructor', 1);
CALL sp_insertUserOccupation('Bartender', 1);
CALL sp_insertUserOccupation('Drives a roocked to the moon', 1);

CALL sp_insertUserOccupation('Unemployed', 2);
CALL sp_insertUserOccupation('Attourney', 2);
CALL sp_insertUserOccupation('Cheff', 2);
CALL sp_insertUserOccupation('Taxi Driver', 2);
CALL sp_insertUserOccupation('Teacher', 2);
CALL sp_insertUserOccupation('Student', 2);
CALL sp_insertUserOccupation('Programmer', 2);
CALL sp_insertUserOccupation('Professor', 2);
CALL sp_insertUserOccupation('Yoga Instructor', 2);
CALL sp_insertUserOccupation('Bartender', 2);


-- GENERATE USER_REASONS
-- (reason, user_id)
CALL sp_insertUserReason('Working out', 1);
CALL sp_insertUserReason('Business meeting', 1);
CALL sp_insertUserReason('Study Session', 1);
CALL sp_insertUserReason('Hanging out', 1);
CALL sp_insertUserReason('Private lesson', 1);
CALL sp_insertUserReason('Chilling', 1);
CALL sp_insertUserReason('Catching up', 1);
CALL sp_insertUserReason('Training', 1);
CALL sp_insertUserReason('Date', 1);
CALL sp_insertUserReason('Seeing a movie', 1);

CALL sp_insertUserReason('Working out', 2);
CALL sp_insertUserReason('Business meeting', 2);
CALL sp_insertUserReason('Study Session', 2);
CALL sp_insertUserReason('Hanging out', 2);
CALL sp_insertUserReason('Private lesson', 2);
CALL sp_insertUserReason('Chilling', 2);
CALL sp_insertUserReason('Catching up', 2);
CALL sp_insertUserReason('Training', 2);
CALL sp_insertUserReason('Date', 2);
CALL sp_insertUserReason('Seeing a movie', 2);


-- GENERATE USER_RELATIONSHIPS
-- (relationship, user_id)
CALL sp_insertUserRelationship('Close Friend', 1);
CALL sp_insertUserRelationship('Colleague', 1);
CALL sp_insertUserRelationship('Acquaintance', 1);
CALL sp_insertUserRelationship('Teacher', 1);
CALL sp_insertUserRelationship('Client', 1);
CALL sp_insertUserRelationship('Employee', 1);
CALL sp_insertUserRelationship('Training partner', 1);
CALL sp_insertUserRelationship('Student', 1);
CALL sp_insertUserRelationship('Family', 1);
CALL sp_insertUserRelationship('Friend', 1);

CALL sp_insertUserRelationship('Close Friend', 2);
CALL sp_insertUserRelationship('Colleague', 2);
CALL sp_insertUserRelationship('Acquaintance', 2);
CALL sp_insertUserRelationship('Teacher', 2);
CALL sp_insertUserRelationship('Client', 2);
CALL sp_insertUserRelationship('Employee', 2);
CALL sp_insertUserRelationship('Training partner', 2);
CALL sp_insertUserRelationship('Student', 2);
CALL sp_insertUserRelationship('Family', 2);
CALL sp_insertUserRelationship('Friend', 2);


-- GENERATE USER_ACQUAINTANCE_RELATIONSHIPS 
-- (user_id, first_name, last_name, gender, occupation_id, city_id, address, relationship_id)
CALL sp_insertUserAcquaintance(1, 'Georgi', 'Georgiev', 'M', 1, 4, null, 1);
CALL sp_insertUserAcquaintance(1, 'Nikola', 'Nikolov', 'M', 2, 1, null, 2);
CALL sp_insertUserAcquaintance(1,'Vanesa', 'Vanesova', 'F', 1, 6, null, 2);
CALL sp_insertUserAcquaintance(1, 'Elena', 'Elenova', 'F', 7, 3, null, 5);
CALL sp_insertUserAcquaintance(1, 'Stoyan', 'Stoyanov', 'M', 1, 8, null, 6);
CALL sp_insertUserAcquaintance(1, 'Kiril', 'Kirilov', 'M', 3, 7, null, 7);
CALL sp_insertUserAcquaintance(1, 'Gergana', 'Gerganova', 'F', 3, 10, null, 3);
CALL sp_insertUserAcquaintance(1, 'Yoana', 'Yoanova', 'F', 2, 1, null, 10);
CALL sp_insertUserAcquaintance(1, 'Angel', 'Angelov', 'M', 6, 1, null, 9);
CALL sp_insertUserAcquaintance(1, 'Martin', 'Martinov', 'M', 1,  8, null, 4);

CALL sp_insertUserAcquaintance(2, 'Georgi', 'Georgiev', 'M', 1, 4, null, 1);
CALL sp_insertUserAcquaintance(2, 'Nikola', 'Nikolov', 'M', 4, 2, null, 2);
CALL sp_insertUserAcquaintance(2,'Vanesa', 'Vanesova', 'F', 1, 6, null, 2);
CALL sp_insertUserAcquaintance(2, 'Elena', 'Elenova', 'F', 7, 3, null, 5);
CALL sp_insertUserAcquaintance(2, 'Stoyan', 'Stoyanov', 'M', 4, 3, null, 6);
CALL sp_insertUserAcquaintance(2, 'Kiril', 'Kirilov', 'M', 3, 7, null, 7);
CALL sp_insertUserAcquaintance(2, 'Gergana', 'Gerganova', 'F', 2, 2, null, 3);
CALL sp_insertUserAcquaintance(2, 'Yoana', 'Yoanova', 'F', 2, 2, null, 10);
CALL sp_insertUserAcquaintance(2, 'Angel', 'Angelov', 'M', 6, 2, null, 9);
CALL sp_insertUserAcquaintance(2, 'Martin', 'Martinov', 'M', 2,  8, null, 4);


-- GENERATE MEETINGS 
-- (user_id, acquaintance_id, datetime, reason_id, location_id, comments)
CALL sp_insertUserMeeting(1, 1, '2022-02-14 12:30', 2, 4, null);
CALL sp_insertUserMeeting(1, 4, '2022-01-23 20:45', 5, 2, null);
CALL sp_insertUserMeeting(1, 2, '2021-12-04 15:00', 1, 7, null);
CALL sp_insertUserMeeting(1, 5, '2021-09-27 09:30', 8, 8, null);
CALL sp_insertUserMeeting(1, 9, '2022-03-11 17:30', 7, 1, null);
CALL sp_insertUserMeeting(1, 2, '2022-02-14 12:00', 10, 9, null);
CALL sp_insertUserMeeting(1, 10, '2020-07-30 23:30', 4, 10, null);
CALL sp_insertUserMeeting(1, 4, '2021-05-28 10:30', 3, 2, null);
CALL sp_insertUserMeeting(1, 6, '2022-02-14 16:30', 8, 4, null);
CALL sp_insertUserMeeting(1, 6, '2022-02-14 12:50', 4, 1, null);

CALL sp_insertUserMeeting(2, 1, '2022-02-14 12:30', 2, 4, null);
CALL sp_insertUserMeeting(2, 4, '2022-01-23 20:45', 5, 2, null);
CALL sp_insertUserMeeting(2, 3, '2021-12-04 15:00', 2, 4, null);
CALL sp_insertUserMeeting(2, 5, '2021-09-27 09:30', 8, 8, null);
CALL sp_insertUserMeeting(2, 3, '2022-03-11 17:30', 3, 4, null);
CALL sp_insertUserMeeting(2, 4, '2022-02-14 12:00', 10, 9, null);
CALL sp_insertUserMeeting(2, 10, '2020-07-30 23:30', 4, 10, null);
CALL sp_insertUserMeeting(2, 4, '2021-05-28 10:30', 3, 2, null);
CALL sp_insertUserMeeting(2, 3, '2022-02-14 16:30', 8, 4, null);
CALL sp_insertUserMeeting(2, 3, '2022-02-14 12:50', 4, 1, null);
