USE rmdb; 

-- GENERATE USERS 
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
 
 
-- GENERATE CITIES
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


-- GENERATE USER_OCCUPATIONS (The procedures generate data for 'Occupations' as well.)
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


-- GENERATE USER_REASONS (The procedures generate data for 'Reasons' as well.)
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


-- GENERATE USER_RELATIONSHIPS (The procedures generate data for 'Relatiships' as well.)
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

CALL sp_insertUserRelationship('Family', 2);
CALL sp_insertUserRelationship('Friend', 2);

-- GENERATE USER_ACQUAINTANCE_RELATIONSHIPS (The procedures generate data for 'Acquaintances' as well.)
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

CALL sp_insertUserAcquaintance(2, 'Yoana', 'Yoanova', 'F', 2, 2, null, 10);
CALL sp_insertUserAcquaintance(2, 'Angel', 'Angelov', 'M', 6, 1, null, 9);

-- GENERATE MEETINGS 
CALL sp_insertMeeting(1, 3, '2022-02-14 12:30', 2, null);
CALL sp_insertMeeting(1, 4, '2022-01-23 20:45', 5, null);
CALL sp_insertMeeting(1, 2, '2021-12-04 15:00', 1, null);
CALL sp_insertMeeting(1, 5, '2021-09-27 09:30', 8, null);
CALL sp_insertMeeting(1, 9, '2022-03-11 17:30', 7, null);
CALL sp_insertMeeting(1, 2, '2022-02-14 12:00', 10, null);
CALL sp_insertMeeting(1, 10, '2020-07-30 23:30', 4, null);
CALL sp_insertMeeting(1, 4, '2021-05-28 10:30', 3, null);
CALL sp_insertMeeting(1, 6, '2022-02-14 16:30', 8, null);
CALL sp_insertMeeting(1, 6, '2022-02-14 12:50', 4, null);
