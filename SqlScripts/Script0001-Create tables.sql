CREATE  TABLE person(
                        id SERIAL  PRIMARY KEY ,
                       name VARCHAR(255)
 );

CREATE TABLE payable_item(id SERIAL PRIMARY KEY ,
                             item_name varchar(255),
                             amount int,
                             person_id int NOT NULL ,
                             FOREIGN KEY (person_id) REFERENCES  Person(id)
);

CREATE TABLE deducting_item(id SERIAL Primary Key ,
                           item_name varchar(256),
                           amount Int,
                            person_id int NOT NULL ,
                            FOREIGN KEY (person_id) REFERENCES  Person(id)
);
