CREATE DATABASE rmdb;

USE rmdb;

-- TABLES
CREATE TABLE users ( /* CHECKED */
	id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(30) UNIQUE NOT NULL,
    password VARCHAR(30) NOT NULL,
    email VARCHAR(40) UNIQUE NOT NULL,
    mobile_number CHAR(10) UNIQUE NOT NULL,
    
    CONSTRAINT chk_usersNoWhiteSpacesUsername 
    CHECK (REPLACE(username, ' ', '') = username),    
    
    CONSTRAINT chk_usersNoWhiteSpacesPassword
    CHECK (REPLACE(password, ' ', '') = password),
    
    CONSTRAINT chk_usersNoWhiteSpacesMail 
    CHECK (REPLACE(email, ' ', '') = email),
    
    CONSTRAINT chk_usersNoWhiteSpacesNumber 
    CHECK (REPLACE(mobile_number, ' ', '') = mobile_number),
		  
    CONSTRAINT chk_usersEmailFormat 
    CHECK (email LIKE '%@%_%.%' AND email != '@_.'),
    
    CONSTRAINT chk_usersMobileNumberValid
    CHECK (CAST(mobile_number AS UNSIGNED) > 0), 
    
    CONSTRAINT chk_usersMobileNumberLength
    CHECK (LENGTH(mobile_number) = 10)
	);
    
CREATE TABLE cities ( /* CHECKED */
	id INT PRIMARY KEY AUTO_INCREMENT,
	city VARCHAR(40) CHARACTER SET utf16 UNIQUE NOT NULL
	);

CREATE TABLE user_cities ( /* CHECKED */
    user_id INT NOT NULL,
    city_id INT NOT NULL,
    
    PRIMARY KEY (user_id, city_id),
    
    FOREIGN KEY (user_id)
    REFERENCES users(id),
    
    FOREIGN KEY (city_id)
    REFERENCES cities(id)
	);
   
CREATE TABLE locations ( /* CHECKED */
	id INT PRIMARY KEY AUTO_INCREMENT,
    location VARCHAR(60) CHARACTER SET utf16 UNIQUE NOT NULL
    );
    
CREATE TABLE user_locations ( /* CHECKED */
	user_id INT,
    location_id INT,
    
    PRIMARY KEY (user_id, location_id),
    
    FOREIGN KEY (user_id)
    REFERENCES users(id),
    
    FOREIGN KEY (location_id)
    REFERENCES locations(id)
    );
    
CREATE TABLE occupations ( /* CHECKED */
	id INT PRIMARY KEY AUTO_INCREMENT,
    occupation VARCHAR(30) CHARACTER SET utf16 UNIQUE NOT NULL
	);

CREATE TABLE user_occupations ( /* CHECKED */
    user_id INT NOT NULL,
    occupation_id INT NOT NULL,
    
    PRIMARY KEY (user_id, occupation_id),
    
    FOREIGN KEY (user_id)
    REFERENCES users(id),
    
    FOREIGN KEY (occupation_id)
    REFERENCES occupations(id)
	);

CREATE TABLE reasons ( /* CHECKED */
	id INT PRIMARY KEY AUTO_INCREMENT,
    reason VARCHAR(50) CHARACTER SET utf16 UNIQUE NOT NULL
	);

CREATE TABLE user_reasons ( /* CHECKED */
    user_id INT NOT NULL,
    reason_id INT NOT NULL,
    
    PRIMARY KEY (user_id, reason_id),
    
    FOREIGN KEY (user_id)
    REFERENCES users(id),
    
    FOREIGN KEY (reason_id)
    REFERENCES reasons(id)
    );
    
CREATE TABLE relationships ( /* CHECKED */
	id INT PRIMARY KEY AUTO_INCREMENT,
    relationship VARCHAR(30) CHARACTER SET utf16 UNIQUE NOT NULL
	);

CREATE TABLE user_relationships ( /* CHECKED */
    relationship_id INT NOT NULL,
    user_id INT NOT NULL,
    
    PRIMARY KEY (user_id, relationship_id),
    
    FOREIGN KEY (user_id)
    REFERENCES users(id),
    
    FOREIGN KEY (relationship_id)
    REFERENCES relationships(id)
    );
    
CREATE TABLE acquaintances ( /* CHECKED */
	id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(30) CHARACTER SET utf16 NOT NULL,
    last_name VARCHAR(30) CHARACTER SET utf16 NOT NULL,
    gender CHAR(1) NOT NULL,
    occupation_id INT NOT NULL,
    city_id INT NOT NULL,
    address VARCHAR(40) CHARACTER SET utf16,
    
    FOREIGN KEY (occupation_id)
    REFERENCES occupations(id),
    
    FOREIGN KEY (city_id)
    REFERENCES cities(id),
    
    CONSTRAINT uq_acquaintancesRecords
    UNIQUE (first_name, last_name, city_id),
    
    CONSTRAINT chk_genderValue
    CHECK (gender IN ('m','f'))
    );

CREATE TABLE user_meetings ( /* CHECKED */
	user_id INT,
    acquaintance_id INT,
    date_time DATETIME,
    reason_id INT NOT NULL,
    location_id INT NOT NULL,
    comments VARCHAR(1000) CHARACTER SET utf16,
    
    PRIMARY KEY (user_id, acquaintance_id, date_time),
    
    FOREIGN KEY (user_id)
    REFERENCES users(id),
    
    FOREIGN KEY (acquaintance_id)
    REFERENCES acquaintances(id),
    
    FOREIGN KEY (reason_id)
    REFERENCES reasons(id),
    
    FOREIGN KEY (location_id)
    REFERENCES locations(id)
    );
    
CREATE TABLE user_acquaintance_relationships ( /* CHECKED */
	user_id INT,
    acquaintance_id INT,
    relationship_id INT NOT NULL,
    
    PRIMARY KEY (user_id, acquaintance_id),
    
	FOREIGN KEY (user_id)
    REFERENCES users(id),
    
	FOREIGN KEY (acquaintance_id)
    REFERENCES acquaintances(id),
    
    FOREIGN KEY (relationship_id)
    REFERENCES relationships(id)
    );
        