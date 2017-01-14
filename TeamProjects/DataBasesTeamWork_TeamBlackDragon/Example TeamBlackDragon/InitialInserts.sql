USE [TeamworkBlackDragon]

INSERT INTO Clients (Name) VALUES ('Big Fat Joe')
INSERT INTO Clients (Name) VALUES ('Don Korleone')
INSERT INTO Clients (Name) VALUES ('Don Kapisaro')
INSERT INTO Clients (Name) VALUES ('NDT Coorporation (TM)')
INSERT INTO Clients (Name) VALUES ('Stinger Donny Fryer')
INSERT INTO Clients (Name) VALUES ('Little-Big man Freddy')
INSERT INTO Clients (Name) VALUES ('Ricky, the Holly One')
INSERT INTO Clients (Name) VALUES ('Stink Eye Stanly')
INSERT INTO Clients (Name) VALUES ('Gustav Shuler')
INSERT INTO Clients (Name) VALUES ('Margaret O-Raily')
INSERT INTO Clients (Name) VALUES ('James, The Cliche, Bond')

INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Cleaning', 15, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Cooking', 30, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Searching for lost items', 100, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Teaching to children', 500, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Selling chockolate', 1500, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Stealing', 2000, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Spying', 2500, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Guarding', 6500, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Killing', 13000, 0)
INSERT INTO Speciality (Name, MinimalCompanyPrice, IsDeleted) VALUES ('Slaying a demon', 500000, 0)

INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Michusi Savara', 1, 'Sai', 0, 1, 25)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Aiko Hero', 0, 'Katana', 0, 1, 35)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Hideaki Dragon', 2, 'Katana', 0, 1, 30)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Yumiko Reptile', 12, 'Wooden Staff', 0, 2, 35)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Shinobu Zero', 13, 'Long Spear', 0, 2, 60)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Okakura Morishige', 11, 'Katana', 0, 2, 55)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Koin Muto', 23, 'Wooden Staff', 0, 3, 135)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Katsunosuki Oye', 25, 'Pistol', 0, 3, 105)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Shizue Sama', 21, 'Sai', 0, 3, 305)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Eizan Amano', 44, 'Katana', 0, 4, 455)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Toki Okuma', 55, 'Katana', 0, 4, 600)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Kikunojo Inaba', 41, 'Ton-Fa', 0, 4, 300)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Kensaku Konya', 51, 'Two Handed Sword', 0, 5, 1000)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Tanjiro Ige', 53, 'Short Spear', 0, 5, 2000)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Oda Mano', 80, 'Katana', 0, 5, 1800)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Ryoichi Oishi', 112, 'Long Spear', 0, 6, 2000)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Kado Hata', 172, 'Wooden Staff', 0, 6, 3500)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Narahiko Amano', 153, 'Ninja Stars', 0, 6, 1200)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Yachi Iida', 328, 'Katana', 0, 7, 3500)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Ippei Noguchi', 314, 'Sai', 0, 7, 2500)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Ichi Touske', 302, 'Katana', 0, 7, 2500)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Torajiro Iseri', 506, 'Ninja Stars', 0, 8, 5000)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Tadayoshi Ogino', 835, 'Pistol', 0, 9, 10000)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Kioshi Shimabukuro', 1024, 'Silent Pistol', 0, 9, 35000)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Eizan Mita', 63567, 'Katana', 0, 10, 100000)
INSERT INTO Ninjas (Name, KillCount, WeaponOfChoice, IsDeleted, SpecialityId, MinimalPersonalPrice)
VALUES ('Aki Komatsu', 70846, 'Heavy Chain', 0, 10, 150000)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (1, 
	'Clean Toilets', 
	50,
	1,
	CONVERT(datetime, '10/23/2013', 101), 
	CONVERT(datetime, '10/24/2013', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (2, 
	'Clean a house', 
	55,
	1,
	CONVERT(datetime, '10/28/2013', 101), 
	CONVERT(datetime, '10/30/2013', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (3, 
	'Clean a house', 
	50,
	1,
	CONVERT(datetime, '11/20/2013', 101), 
	NULL,  
	NULL,
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (1, 
	'Clean toilets', 
	50,
	2,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/26/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Clean a shop',  
	60,
	2,
	CONVERT(datetime, '07/26/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Clean a park', 
	50,
	2,
	CONVERT(datetime, '07/29/2014', 101), 
	CONVERT(datetime, '07/30/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (5, 
	'Clean a house', 
	50,
	3,
	CONVERT(datetime, '08/02/2014', 101), 
	CONVERT(datetime, '08/03/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Clean toilets',  
	50,
	3,
	CONVERT(datetime, '08/03/2014', 101), 
	CONVERT(datetime, '08/05/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (9, 
	'Clean a house', 
	55,
	3,
	CONVERT(datetime, '08/06/2014', 101), 
	CONVERT(datetime, '08/08/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Cook for homeless people', 
	100,
	4,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/29/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (9, 
	'Cook for old people', 
	120,
	4,
	CONVERT(datetime, '07/30/2014', 101), 
	CONVERT(datetime, '08/03/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Cook for old people',
	150,
	5,
	CONVERT(datetime, '07/30/2014', 101), 
	CONVERT(datetime, '08/03/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Cook for a rich family', 
	100,
	5,
	CONVERT(datetime, '08/12/2014', 101), 
	CONVERT(datetime, '08/20/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Cook for a rich family', 
	100,
	5,
	CONVERT(datetime, '08/23/2014', 101), 
	CONVERT(datetime, '08/26/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (5, 
	'Cook for a rich family', 
	110,
	5,
	CONVERT(datetime, '08/28/2014', 101),
	NULL,
	NULL, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (3, 
	'Cook for some fishermen',  
	100,
	6,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Cook for a bear',  
	200,
	6,
	CONVERT(datetime, '07/26/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (2, 
	'Look for an infant', 
	250,
	7,
	CONVERT(datetime, '07/27/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (1, 
	'Look for a book',  
	250,
	7,
	CONVERT(datetime, '07/28/2014', 101), 
	CONVERT(datetime, '07/30/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (1, 
	'Look for secret book', 
	300,
	8,
	CONVERT(datetime, '08/23/2014', 101), 
	CONVERT(datetime, '08/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (3, 
	'Look for a recepie', 
	300,
	8,
	CONVERT(datetime, '08/26/2014', 101), 
	CONVERT(datetime, '08/26/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (2, 
	'Look for an unicorn', 
	500,
	9,
	CONVERT(datetime, '08/27/2014', 101),
	NULL, 
	NULL, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Look for an old umbrella', 
	550,
	9,
	CONVERT(datetime, '07/20/2014', 101), 
	CONVERT(datetime, '07/25/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Look for a book', 
	550,
	9,
	CONVERT(datetime, '07/26/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (5, 
	'Look for the holly grail', 
	5000,
	9,
	CONVERT(datetime, '01/20/2013', 101), 
	CONVERT(datetime, '07/20/2014', 101), 
	0, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Look for an infant', 
	450,
	9,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/25/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (9, 
	'Teach Math', 
	1000,
	10,
	CONVERT(datetime, '07/26/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (10, 
	'Teach Phisics', 
	1000,
	10,
	CONVERT(datetime, '07/28/2014', 101), 
	CONVERT(datetime, '07/29/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Teach Movie Producing',  
	1200,
	11,
	CONVERT(datetime, '07/20/2014', 101), 
	CONVERT(datetime, '07/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Teach Ninja Arts',  
	1500,
	12,
	CONVERT(datetime, '05/13/2014', 101), 
	CONVERT(datetime, '05/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (10, 
	'Teach Ninja Arts', 
	1500,
	12,
	CONVERT(datetime, '05/24/2014', 101), 
	CONVERT(datetime, '05/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (10, 
	'Teach Ninja Arts', 
	1500,
	12,
	CONVERT(datetime, '05/29/2014', 101), 
	CONVERT(datetime, '06/05/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (11, 
	'Teach Ninja Arts',  
	1500,
	12,
	CONVERT(datetime, '06/05/2014', 101), 
	NULL, 
	NULL, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (11, 
	'Sell chockolate', 
	3500,
	13,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/24/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (11, 
	'Sell chockolate',  
	3500,
	13,
	CONVERT(datetime, '07/24/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (5, 
	'Sell chockolate',  
	3500,
	13,
	CONVERT(datetime, '07/29/2014', 101), 
	CONVERT(datetime, '08/03/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Sell chockolate',  
	3500,
	14,
	CONVERT(datetime, '07/29/2014', 101), 
	CONVERT(datetime, '08/03/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Sell chockolate',  
	3500,
	14,
	CONVERT(datetime, '08/15/2014', 101), 
	CONVERT(datetime, '08/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (9, 
	'Sell chockolate', 
	3500,
	15,
	CONVERT(datetime, '07/25/2014', 101), 
	CONVERT(datetime, '07/26/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (3, 
	'Sell chockolate', 
	4000,
	15,
	CONVERT(datetime, '07/27/2014', 101), 
	CONVERT(datetime, '07/30/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (1, 
	'Sell chockolate',  
	4000,
	15,
	CONVERT(datetime, '08/23/2014', 101), 
	NULL, 
	NULL, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (2, 
	'Steal kandy from a child', 
	500,
	16,
	CONVERT(datetime, '07/15/2014', 101), 
	CONVERT(datetime, '07/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Steal kandy from a child', 
	4000,
	16,
	CONVERT(datetime, '07/25/2014', 101), 
	CONVERT(datetime, '07/26/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Steal kandy from a child',  
	4000,
	16,
	CONVERT(datetime, '07/26/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Steal a secret treasure', 
	5500,
	17,
	CONVERT(datetime, '05/01/2014', 101), 
	CONVERT(datetime, '07/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Steal some gold from a bank',  
	6500,
	17,
	CONVERT(datetime, '07/25/2014', 101), 
	CONVERT(datetime, '08/23/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Steal an old painting', 
	6500,
	17,
	CONVERT(datetime, '08/25/2014', 101), 
	CONVERT(datetime, '08/26/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Steal money from highschoolers',  
	5500,
	17,
	CONVERT(datetime, '08/27/2014', 101), 
	NULL, 
	NULL, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Steal a book from a library',  
	3500,
	18,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/29/2014', 101), 
	1, 
	0)
 
 INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Steal a musical notebook', 
	3500,
	18,
	CONVERT(datetime, '08/03/2014', 101), 
	CONVERT(datetime, '08/20/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (9, 
	'Spy on the CIA', 
	10500,
	19,
	CONVERT(datetime, '07/23/2013', 101), 
	CONVERT(datetime, '02/20/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Spy on the goverment', 
	6500,
	19,
	CONVERT(datetime, '03/30/2014', 101), 
	NULL, 
	NULL, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Spy on the police', 
	5500,
	20,
	CONVERT(datetime, '05/20/2014', 101), 
	CONVERT(datetime, '07/20/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (5, 
	'Spy on a bank manager', 
	5500,
	20,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/28/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Spy on a factory owner', 
	6500,
	20,
	CONVERT(datetime, '07/30/2014', 101), 
	CONVERT(datetime, '08/01/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Spy on an oil magnat', 
	7500,
	21,
	CONVERT(datetime, '07/01/2014', 101), 
	CONVERT(datetime, '07/21/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (3, 
	'Spy on a cheathing husband', 
	8500,
	21,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/30/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Spy on a stake owner', 
	7500,
	21,
	CONVERT(datetime, '08/23/2014', 101), 
	CONVERT(datetime, '08/27/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (2, 
	'Guard a money car', 
	15000,
	22,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/24/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Guard a politician', 
	13500,
	22,
	CONVERT(datetime, '07/26/2014', 101), 
	CONVERT(datetime, '07/30/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (1, 
	'Guard a convoy', 
	14500,
	22,
	CONVERT(datetime, '08/23/2014', 101), 
	CONVERT(datetime, '08/25/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (5, 
	'Kill a witness', 
	25000,
	23,
	CONVERT(datetime, '06/05/2014', 101), 
	CONVERT(datetime, '07/13/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (9, 
	'Kill a serial killer', 
	35000,
	23,
	CONVERT(datetime, '07/15/2014', 101), 
	CONVERT(datetime, '07/23/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Kill a politician', 
	35000,
	23,
	CONVERT(datetime, '07/25/2014', 101), 
	NULL, 
	NULL, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (11, 
	'Kill a cheathing husband', 
	5500,
	24,
	CONVERT(datetime, '07/23/2014', 101), 
	CONVERT(datetime, '07/30/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (10, 
	'Kill some innocent people', 
	6500,
	24,
	CONVERT(datetime, '08/05/2014', 101), 
	CONVERT(datetime, '08/20/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (10, 
	'Kill a dictator', 
	10000,
	24,
	CONVERT(datetime, '08/23/2014', 101), 
	CONVERT(datetime, '08/25/2014', 101), 
	0, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (7, 
	'Kill a politician', 
	5500,
	24,
	CONVERT(datetime, '08/26/2014', 101), 
	CONVERT(datetime, '08/27/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (3, 
	'Slay a demon', 
	1000000,
	25,
	CONVERT(datetime, '01/01/2011', 101), 
	CONVERT(datetime, '05/05/2012', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (1, 
	'Slay a demon', 
	700000,
	25,
	CONVERT(datetime, '06/15/2012', 101),
	CONVERT(datetime, '12/25/2012', 101), 
	0, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (5, 
	'Slay a demon', 
	3500000,
	25,
	CONVERT(datetime, '02/06/2013', 101), 
	CONVERT(datetime, '07/20/2014', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Slay a demon', 
	2000000,
	26,
	CONVERT(datetime, '06/15/2012', 101),
	CONVERT(datetime, '12/25/2012', 101), 
	0, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (4, 
	'Slay a demon', 
	553500,
	26,
	CONVERT(datetime, '02/06/2013', 101), 
	CONVERT(datetime, '06/20/2013', 101),  
	0, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (6, 
	'Slay a demon', 
	1500000,
	26,
	CONVERT(datetime, '08/11/2013', 101), 
	CONVERT(datetime, '11/20/2013', 101), 
	1, 
	0)

INSERT INTO Jobs (ClientId, Name, Price, NinjaId, StartDate, EndDate, IsSuccessFull, IsDeleted)
VALUES (8, 
	'Slay a demon', 
	5000000,
	26,
	CONVERT(datetime, '02/01/2014', 101), 
	NULL, 
	NULL, 
	0)