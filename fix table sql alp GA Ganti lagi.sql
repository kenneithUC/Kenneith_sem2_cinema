create database if not exists db_cinema;
use db_cinema;

drop table if exists jadwal cascade;
drop table if exists film cascade;
drop table if exists `user` cascade;
drop table if exists tiket cascade;
drop table if exists transaksi cascade;
drop table if exists kursi cascade;
drop table if exists studio cascade;

CREATE TABLE `user`(
    kodeuser VARCHAR(4) PRIMARY KEY,
    namauser VARCHAR(20) NOT NULL,
    pin INT(10) NOT NULL,
    pinmd5converter varchar(100) not null,
    tanggallahir VARCHAR(20),
    umur VARCHAR(10),
    saldo DOUBLE,
    statususer VARCHAR(12) DEFAULT 'user',
    CONSTRAINT statusch CHECK (statususer = 'admin' OR statususer = 'user')
);

insert into `user` values(001,'albin',123453,"0f3e84acb19dff22f695f31dbe3e972a",str_to_date('07/09/1977','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),600000,'user');
insert into `user` values(002,'alvin',12233,"b53086d558f1127993271e8c504ded45",str_to_date('14/09/1979','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),600000,'user');
insert into `user` values(003,'akin',1234523,"a420d72d627949c31a64280bbd4d1a68",str_to_date('15/09/1976','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),700000,'user');
insert into `user` values(004,'bacin',12213,"98f2d76d4d9caf408180b5abfa83ae87",str_to_date('18/09/1980','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),1000000,'user');
insert into `user` values(005,'bokin',123423,"43f6ba1dfda6b8106dc7cf1155f37fdb",str_to_date('07/09/1967','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),300000,'user');
insert into `user` values(006,'carin',12231,"c851a9fd59eb3a9185457daa22f95c96",str_to_date('27/09/1995','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),400000,'user');
insert into `user` values(007,'caren',123453,"0f3e84acb19dff22f695f31dbe3e972a",str_to_date('17/09/1986','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),600000,'user');
insert into `user` values(008,'dickto',1265456,"d1279f40d14f4782cc74f28e4117dbb3",str_to_date('17/09/1988','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),500000,'user');
insert into `user` values(009,'elfin',1235567,"0ebcffa33210b41b36e04bd326091b85",str_to_date('19/09/1956','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),700000,'user');
insert into `user` values(010,'fajin',1567356,"899c24f3b60d4a6cd5c7983ea668ed21",str_to_date('20/09/1967','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),100000,'user');
insert into `user` values(011,'gojin',125673,"136b327d1fa48afb3fbc01e281fc392a",str_to_date('27/09/1979','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),600000,'user');
insert into `user` values(012,'hasan',1265753,"ea7defa7877da20c0a9298e30109f616",str_to_date('22/09/1999','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),150000,'user');
insert into `user` values(013,'indran',125675,"2f88d41fed016cd1f8b5d359ebc017ad",str_to_date('26/09/1976','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),70000,'user');
insert into `user` values(014,'jolin',12456,"6a9edcb7b63821802aa44d35d531c9fc",str_to_date('13/09/1957','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),200000,'user');
insert into `user` values(015,'kulin',6566753,"94a50e6807ebb7769a1e5a4cbc933046",str_to_date('10/09/1976','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),600000,'user');
insert into `user` values(016,'lolin',167863,"1eccaf3326411febec3d5b869b0b9021",str_to_date('08/09/1973','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),300000,'user');
insert into `user` values(017,'monica',127868,"f1e36ab2ff876a5d8b87f782e598a76c",str_to_date('05/09/1982','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),700000,'user');
insert into `user` values(018,'nori',122253,"464b8ffaa28b46c1b2026dedb063f488",str_to_date('23/09/1999','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),600000,'user');
insert into `user` values(019,'opera',145653,"62c237e40c008cda8c221a4d1231f790",str_to_date('25/09/1984','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),800000,'user');
insert into `user` values(020,'peri',18793,"cd2b3387c4709f14cd79ed5995aba48e",str_to_date('26/09/1985','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),600000,'user');
insert into `user` values(021,'pelo',1543,"819c9fbfb075d62a16393b9fe4fcbaa5",str_to_date('26/09/1984','%d/%m/%Y'), concat((year(curdate()) - year(tanggallahir))),0,'admin');

create table film(
kodefilm varchar(70) primary key,
judulfilm varchar(70) not null,
gambarfilm varchar(30) not null,
genre varchar(40) not null,
rating varchar(5) not null,
statusfilm varchar(20) default'coming soon',
synopsis mediumtext not null,
constraint statusfilmtayang check(statusfilm='order now' or statusfilm='coming soon'or statusfilm='expired')
);

insert into film values('001','Avengers: Endgame','\\alp_cinema\\1.jpeg','Action',"8.4","order now","A drift in space with no food or water, Tony Stark sends a message to Pepper Potts as his oxygen supply starts to dwindle. Meanwhile, the remaining Avengers -- Thor,Black Widow, Captain America and Bruce Banner -- must figure out a way to bring back their vanquished allies for an epic showdown with Thanos -- the evil demigod who decimated the planet and the universe.");
insert into film values('002','Thor: Ragnarok','\\alp_cinema\\2.jpeg','Action',"7.9","order now","Imprisoned on the other side of the universe, the mighty Thor finds himself in a deadly gladiatorial contest that pits him against the Hulk, his former ally and fellow Avenger. Thors quest for survival leads him in a race against time to prevent the all-powerful Hela from destroying his home world and the Asgardian civilization.");
insert into film values('003','The Amazing Spider-Man','\\alp_cinema\\3.jpeg','Action',"6.9","order now","Abandoned by his parents and raised by an aunt and uncle, teenager Peter Parker (Andrew Garfield), AKA Spider-Man, is trying to sort out who he is and exactly what his feelings are for his first crush, Gwen Stacy (Emma Stone). When Peter finds a mysterious briefcase that was his father's, he pursues a quest to solve his parents' disappearance. His search takes him to Oscorp and the lab of Dr. Curt Connors (Rhys Ifans), setting him on a collision course with Connors' alter ego, the Lizard.");
insert into film values('004','Ant-Man','\\alp_cinema\\4.jpeg','Action',"6.2","order now","Forced out of his own company by former protégé Darren Cross, Dr. Hank Pym (Michael Douglas) recruits the talents of Scott Lang (Paul Rudd), a master thief just released from prison. Lang becomes Ant-Man, trained by Pym and armed with a suit that allows him to shrink in size, possess superhuman strength and control an army of ants. The miniature hero must use his new skills to prevent Cross, also known as Yellowjacket, from perfecting the same technology and using it as a weapon for evil.");
insert into film values('005','Harry Potter and the Philosophers Stone','\\alp_cinema\\5.jpeg','Fantasy/Adventure',"7.6","order now","Adaptation of the first of J.K. Rowling's popular children's novels about Harry Potter, a boy who learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.");
insert into film values('006','Inception','\\alp_cinema\\6.jpeg','Science Fiction/Action/Thriller',"8.8","order now","Dom Cobb (Leonardo DiCaprio) is a thief with the rare ability to enter people's dreams and steal their secrets from their subconscious. His skill has made him a hot commodity in the world of corporate espionage but has also cost him everything he loves. Cobb gets a chance at redemption when he is offered a seemingly impossible task: Plant an idea in someone's mind. If he succeeds, it will be the perfect crime, but a dangerous enemy anticipates Cobb's every move.");
insert into film values('007','Jurassic Park','\\alp_cinema\\7.jpeg','Science Fiction/Adventure',"8.2","order now","In Steven Spielberg's massive blockbuster, paleontologists Alan Grant (Sam Neill) and Ellie Sattler (Laura Dern) and mathematician Ian Malcolm (Jeff Goldblum) are among a select group chosen to tour an island theme park populated by dinosaurs created from prehistoric DNA. While the park's mastermind, billionaire John Hammond (Richard Attenborough), assures everyone that the facility is safe, they find out otherwise when various ferocious predators break free and go on the hunt.");
insert into film values('008','Star Wars: A New Hope','\\alp_cinema\\8.jpeg','Science Fiction/Adventure',"8.6","order now","The Imperial Forces -- under orders from cruel Darth Vader (David Prowse) -- hold Princess Leia (Carrie Fisher) hostage, in their efforts to quell the rebellion against the Galactic Empire. Luke Skywalker (Mark Hamill) and Han Solo (Harrison Ford), captain of the Millennium Falcon, work together with the companionable droid duo R2-D2 (Kenny Baker) and C-3PO (Anthony Daniels) to rescue the beautiful princess, help the Rebel Alliance, and restore freedom and justice to the Galaxy.");
insert into film values('009','Forrest Gump','\\alp_cinema\\9.jpg','Drama/Comedy',"8.8","coming soon","Slow-witted Forrest Gump (Tom Hanks) has never thought of himself as disadvantaged, and thanks to his supportive mother (Sally Field), he leads anything but a restricted life. Whether dominating on the gridiron as a college football star, fighting in Vietnam or captaining a shrimp boat, Forrest inspires people with his childlike optimism. But one person Forrest cares about most may be the most difficult to save -- his childhood love, the sweet but troubled Jenny (Robin Wright).");
insert into film values('010','Titanic','\\alp_cinema\\10.jpg','Romance/Drama',"7.9","coming soon","James Cameron's Titanic is an epic, action-packed romance set against the ill-fated maiden voyage of the R.M.S. Titanic; the pride and joy of the White Star Line and, at the time, the largest moving object ever built. She was the most luxurious liner of her era -- the ship of dreams -- which ultimately carried over 1,500 people to their death in the ice cold waters of the North Atlantic in the early hours of April 15, 1912.");
insert into film values('011','The Lord of the Rings: The Fellowship of the Ring','\\alp_cinema\\11.jpg','Fantasy/Adventure',"6.9","coming soon","The future of civilization rests in the fate of the One Ring, which has been lost for centuries. Powerful forces are unrelenting in their search for it. But fate has placed it in the hands of a young Hobbit named Frodo Baggins (Elijah Wood), who inherits the Ring and steps into legend. A daunting task lies ahead for Frodo when he becomes the Ringbearer - to destroy the One Ring in the fires of Mount Doom where it was forged.");
insert into film values('012','The Dark Knight','\\alp_cinema\\12.jpg','Action/Crime/Drama',"9.0","coming soon","With the help of allies Lt. Jim Gordon (Gary Oldman) and DA Harvey Dent (Aaron Eckhart), Batman (Christian Bale) has been able to keep a tight lid on crime in Gotham City. But when a vile young criminal calling himself the Joker (Heath Ledger) suddenly throws the town into chaos, the caped Crusader begins to tread a fine line between heroism and vigilantism.");
insert into film values('013','The Shawshank Redemption','\\alp_cinema\\13.jpg','Drama',"9.3","coming soon","Andy Dufresne (Tim Robbins) is sentenced to two consecutive life terms in prison for the murders of his wife and her lover and is sentenced to a tough prison. However, only Andy knows he didn't commit the crimes. While there, he forms a friendship with Red (Morgan Freeman), experiences brutality of prison life, adapts, helps the warden, etc., all in 19 years.");
insert into film values('014','The Godfather','\\alp_cinema\\14.jpg','Crime/Drama',"9.2","coming soon","Widely regarded as one of the greatest films of all time, this mob drama, based on Mario Puzo's novel of the same name, focuses on the powerful Italian-American crime family of Don Vito Corleone (Marlon Brando). When the don's youngest son, Michael (Al Pacino), reluctantly joins the Mafia, he becomes involved in the inevitable cycle of violence and betrayal. Although Michael tries to maintain a normal relationship with his wife, Kay (Diane Keaton), he is drawn deeper into the family business.");
insert into film values('015','Fight Club','\\alp_cinema\\15.jpg','Drama/Thriller',"8.8","coming soon","A depressed man (Edward Norton) suffering from insomnia meets a strange soap salesman named Tyler Durden (Brad Pitt) and soon finds himself living in his squalid house after his perfect apartment is destroyed. The two bored men form an underground club with strict rules and fight other men who are fed up with their mundane lives. Their perfect partnership frays when Marla (Helena Bonham Carter), a fellow support group crasher, attracts Tyler's attention.");
insert into film values('016','The Matrix','\\alp_cinema\\16.jpg','Science Fiction/Action',"8.7","coming soon","Neo (Keanu Reeves) believes that Morpheus (Laurence Fishburne), an elusive figure considered to be the most dangerous man alive, can answer his question -- What is the Matrix? Neo is contacted by Trinity (Carrie-Anne Moss), a beautiful stranger who leads him into an underworld where he meets Morpheus. They fight a brutal battle for their lives against a cadre of viciously intelligent secret agents. It is a truth that could cost Neo something more precious than his life.");
insert into film values('017','Goodfellas','\\alp_cinema\\17.jpg','Crime/Drama',"8.7","coming soon","A young man grows up in the mob and works very hard to advance himself through the ranks. He enjoys his life of money and luxury, but is oblivious to the horror that he causes. A drug addiction and a few mistakes ultimately unravel his climb to the top. Based on the book Wiseguy by Nicholas Pileggi.");
insert into film values('018','The Silence of the Lambs','\\alp_cinema\\18.jpg','Thriller/Horror',"8.6","coming soon","Jodie Foster stars as Clarice Starling, a top student at the FBI's training academy. Jack Crawford (Scott Glenn) wants Clarice to interview Dr. Hannibal Lecter (Anthony Hopkins), a brilliant psychiatrist who is also a violent psychopath, serving life behind bars for various acts of murder and cannibalism. Crawford believes that Lecter may have insight into a case and that Starling, as an attractive young woman, may be just the bait to draw him out.");
insert into film values('019','The Prestige','\\alp_cinema\\19.jpg','Drama/Mystery',"8.6","coming soon","Period thriller set in Edwardian London where two rival magicians, partners until the tragic death of an assistant during a show, feud bitterly after one of them performs the ultimate magic trick - teleportation. His rival tries desperately to uncover the secret of his routine, experimenting with dangerous new science as his quest takes him to the brink of insanity and jeopardises the lives of everyone around the pair.");
insert into film values('020','The Departed','\\alp_cinema\\20.jpg','Crime/Drama/Thriller',"8.5","coming soon","South Boston cop Billy Costigan (Leonardo DiCaprio) goes under cover to infiltrate the organization of gangland chief Frank Costello (Jack Nicholson). As Billy gains the mobster's trust, a career criminal named Colin Sullivan (Matt Damon) infiltrates the police department and reports on its activities to his syndicate bosses. When both organizations learn they have a mole in their midst, Billy and Colin must figure out each other's identities to save their own lives");


create table studio(
kodefilm varchar(10) references film(kodefilm),
kodestudio varchar(3) primary key,
namastudio varchar(10),
`row` varchar(3) not null,
`column` varchar(3) not null
);
-- --studio1 kapasitas 120 film ada 4
insert into studio values('001',00101,'studio1','12','10');
insert into studio values('002',00201,'studio1','12','10'); 
insert into studio values('003',00301,'studio1','12','10');
insert into studio values('004',00401,'studio1','12','10');

-- --studio2 kapasitas 110 film ada 3
insert into studio values('005',00502,'studio2','11','10'); 
insert into studio values('006',00602,'studio2','11','10'); 
insert into studio values('007',00702,'studio2','11','10');

-- --studio3 kapasitas 100 film ada 3
insert into studio values('006',00603,'studio3','10','10'); 
insert into studio values('007',00703,'studio3','10','10');
insert into studio values('008',00803,'studio3','10','10');

-- --studio5 kapasitas 90 film ada 3
insert into studio values('001',00105,'studio5','9','10');
insert into studio values('004',00405,'studio5','9','10');
insert into studio values('008',00805,'studio5','9','10'); 

-- --studio4 kapasitas 80 film ada 3
insert into studio values('001',00104,'studio4','8','10');
insert into studio values('007',00704,'studio4','8','10');
insert into studio values('008',00804,'studio4','8','10');



create table jadwal(
filmmulai varchar(20),
filmselesai varchar(20),
kodefilm varchar(10) references film(kodefilm),
kodestudio varchar(3) references studio(kodestudio)
);
-- durasi film di studio1
insert into jadwal values('08:00','11:10','001',00101);-- film1
insert into jadwal values('11:20','14:30','001',00101);-- film1
insert into jadwal values('14:40','16:50','002',00201);-- film2
insert into jadwal values('17:00','19:10','002',00201);-- film2
insert into jadwal values('19:20','21:40','003',00301);-- film3
insert into jadwal values('21:50','24:00','003',00301);-- film3
-- durasi film di studio2
insert into jadwal values('08:00','11:10','005',00502);-- film5
insert into jadwal values('11:20','14:30','005',00502);-- film5
insert into jadwal values('14:40','16:50','006',00602);-- film6
insert into jadwal values('17:00','19:10','006',00602);-- film6
insert into jadwal values('19:20','21:40','007',00702);-- film7
insert into jadwal values('21:50','24:00','007',00702);-- film7

-- durasi film di studio3
insert into jadwal values('08:00','11:10','006',00603);-- film6
insert into jadwal values('11:20','14:30','006',00603);-- film6
insert into jadwal values('14:40','16:50','007',00703);-- film7
insert into jadwal values('17:00','19:10','007',00703);-- film7
insert into jadwal values('19:20','21:40','008',00803);-- film8
insert into jadwal values('21:50','24:00','008',00803);-- film8
-- durasi film di studio4
insert into jadwal values('08:00','10:20','007',00704);-- film7
insert into jadwal values('10:30','12:40','007',00704);-- film7
insert into jadwal values('13:50','16:00','001',00104);-- film1
insert into jadwal values('16:10','19:30','001',00104);-- film1
insert into jadwal values('19:40','21:50','008',00804);-- film8
insert into jadwal values('22:00','24:00','008',00804);-- film8
-- durasi film di studio5
insert into jadwal values('08:00','11:10','004',00405);-- film4
insert into jadwal values('11:20','14:30','004',00405);-- film4 
insert into jadwal values('14:40','16:50','008',00805);-- film8
insert into jadwal values('17:00','19:10','008',00805);-- film8
insert into jadwal values('19:20','21:40','001',00105);-- film1
insert into jadwal values('21:50','24:00','001',00105);-- film1

create table kursi(
-- kodejumlahtiket varchar(10),
-- jumlahtiketpesan varchar(3),
hargatiket int,
kodefilm varchar(10) references jadwal(kodefilm),
kodeuser VARCHAR(4) not null,
filmmulai varchar(20),
filmselesai varchar(20),
kodestudio varchar(3) references studio(kodestudio),
kursipilih mediumtext
);
-- kapasitas 120 film 1 studio 1
insert into kursi values(35000,001,'001','08:00','11:10',00101,'A2,A4,D5,E6,A3,A8,B9');
-- kapasitas 120 film 2 studio 1
insert into kursi values(35000,004,'002','14:40','16:50',00201,'E9,F5,C8,H3');
-- kapasitas 120 film 3 studio 1
insert into kursi values(35000,001,'003','19:20','21:40',00301,'A7,G10,J6,D12,H1,F3,A2');
-- kapasitas 120 film 3 studio 1
insert into kursi values(35000,001,'003','19:20','21:40',00301,'H3,B12');

-- kapasitas 110 film 5 studio 2
insert into kursi values(35000,007,'005','11:20','14:30',00502,'B9,E4');
-- kapasitas 110 film 6 studio 2
insert into kursi values(35000,008,'006','17:00','19:10',00602,'G7');
-- kapasitas 110 film 7 studio 2
insert into kursi values(35000,009,'007','19:20','21:40',00702,'H5,C3,D8');

-- kapasitas 100 film 6 studio 3
insert into kursi values(35000,014,'006','08:00','11:10',00603,'A9,B4,C7,D2,E8');
-- kapasitas 100 film 7 studio 3
insert into kursi values(35000,015,'007','17:00','19:10',00703,'F5,G10,H3,I10,J6,A1,B5,C8,D3,E7');
-- kapasitas 100 film 8 studio 3
insert into kursi values(35000,016,'008','21:50','24:00',00803,'F2,G9,H4,I10,J7,A3');

-- kapasitas 90 film 1 studio 5
insert into kursi values(35000,017,'001','19:20','21:40',00105,'B7');
-- kapasitas 90 film 4 studio 5
insert into kursi values(35000,018,'004','08:00','11:10',00405,'C9,D5,E9,F4,G8,H6,I2,J8');
-- kapasitas 90 film 8 studio 5
insert into kursi values(35000,019,'008','17:00','19:10',00805,'A6,B,C4,D8,E3,F7,G2,H5,I9');

-- kapasitas 80 film 1 studio 4
insert into kursi values(35000,002,'001','13:50','16:00',00104,'J1,A4,B8,C3,D7,E2,F6,G1,H4,I8,J3');
-- kapasitas 80 film 7 studio 4
insert into kursi values(35000,003,'007','08:00','10:20',00704,'A7,B3,C8,D2,E7,F5,G8,H4,I6,J1,A4,B9,C2,D6,E8,F3,G7,H5');
-- kapasitas 80 film 8 studio 4
insert into kursi values(35000,005,'008','19:40','21:50',00804,'I10,J4,A2,B8,C5,D9');

create table tiket(
kodeuser varchar(4) references `user`(kodeuser),
kodefilm varchar(10) references film(kodefilm),
filmmulai varchar(20),
filmselesai varchar(20),
kodestudio varchar(3) references studio(kodestudio),
nomerkursi varchar(5)
);

insert into tiket values (001,'001','08:00','11:10',00101,'A2');
INSERT INTO tiket values (001,'001','08:00','11:10',00101,'A4');
INSERT INTO tiket VALUES (001, '001', '08:00', '11:10', 00101,'D5');
INSERT INTO tiket VALUES (001, '001', '08:00', '11:10', 00101, 'E6');
INSERT INTO tiket VALUES (001, '001', '08:00', '11:10', 00101, 'A3');
INSERT INTO tiket VALUES (001, '001', '08:00', '11:10', 00101, 'A8');
INSERT INTO tiket VALUES (001, '001', '08:00', '11:10', 00101, 'B9');

insert into tiket values (004,'002','14:40','16:50',00201,'E9');
insert into tiket values (004,'002','14:40','16:50',00201,'F5');
insert into tiket values (004,'002','14:40','16:50',00201,'C8');
insert into tiket values (004,'002','14:40','16:50',00201,'H3');

INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'A7');
INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'G10');
INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'J6');
INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'D12');
INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'H1');
INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'F3');
INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'A2');

INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'H3');
INSERT INTO tiket VALUES (001, '003', '19:20', '21:40', 00301, 'B12');

INSERT INTO tiket VALUES (007,'005','11:20','14:30',00502,'B9');
INSERT INTO tiket VALUES (007,'005','11:20','14:30',00502,'E4');

INSERT INTO tiket VALUES (008,'006','17:00','19:10',00602,'G7');

INSERT INTO tiket VALUES (009,'007','19:20','21:40',00702,'H5');
INSERT INTO tiket VALUES (009,'007','19:20','21:40',00702,'C3');
INSERT INTO tiket VALUES (009,'007','19:20','21:40',00702,'D8');

INSERT INTO tiket VALUES (014, '006', '08:00', '11:10', 00603, 'A9');
INSERT INTO tiket VALUES (014, '006', '08:00', '11:10', 00603, 'B4');
INSERT INTO tiket VALUES (014, '006', '08:00', '11:10', 00603, 'C7');
INSERT INTO tiket VALUES (014, '006', '08:00', '11:10', 00603, 'D2');
INSERT INTO tiket VALUES (014, '006', '08:00', '11:10', 00603, 'E8');

INSERT INTO tiket
VALUES
  (015, '007', '17:00', '19:10', 00703, 'F5'),
  (015, '007', '17:00', '19:10', 00703, 'G10'),
  (015, '007', '17:00', '19:10', 00703, 'H3'),
  (015, '007', '17:00', '19:10', 00703, 'I10'),
  (015, '007', '17:00', '19:10', 00703, 'J6'),
  (015, '007', '17:00', '19:10', 00703, 'A1'),
  (015, '007', '17:00', '19:10', 00703, 'B5'),
  (015, '007', '17:00', '19:10', 00703, 'C8'),
  (015, '007', '17:00', '19:10', 00703, 'D3'),
  (015, '007', '17:00', '19:10', 00703, 'E7');
  
INSERT INTO tiket 
VALUES
  (016, '008', '21:50', '24:00', 00803, 'F2'),
  (016, '008', '21:50', '24:00', 00803, 'G9'),
  (016, '008', '21:50', '24:00', 00803, 'H4'),
  (016, '008', '21:50', '24:00', 00803, 'I10'),
  (016, '008', '21:50', '24:00', 00803, 'J7'),
  (016, '008', '21:50', '24:00', 00803, 'A3');
  
INSERT INTO tiket VALUES (017,'001','19:20','21:40',00105,'B7');

INSERT INTO tiket 
VALUES
  (018, '004', '08:00', '11:10', 00405, 'C9'),
  (018, '004', '08:00', '11:10', 00405, 'D5'),
  (018, '004', '08:00', '11:10', 00405, 'E9'),
  (018, '004', '08:00', '11:10', 00405, 'F4'),
  (018, '004', '08:00', '11:10', 00405, 'G8'),
  (018, '004', '08:00', '11:10', 00405, 'H6'),
  (018, '004', '08:00', '11:10', 00405, 'I2'),
  (018, '004', '08:00', '11:10', 00405, 'J8');
  
INSERT INTO tiket 
VALUES
  (019, '008', '17:00', '19:10', 00805, 'A6'),
  (019, '008', '17:00', '19:10', 00805, 'B'),
  (019, '008', '17:00', '19:10', 00805, 'C4'),
  (019, '008', '17:00', '19:10', 00805, 'D8'),
  (019, '008', '17:00', '19:10', 00805, 'E3'),
  (019, '008', '17:00', '19:10', 00805, 'F7'),
  (019, '008', '17:00', '19:10', 00805, 'G2'),
  (019, '008', '17:00', '19:10', 00805, 'H5'),
  (019, '008', '17:00', '19:10', 00805, 'I9');
  
INSERT INTO tiket 
VALUES
  (002, '001', '13:50', '16:00', 00104, 'J1'),
  (002, '001', '13:50', '16:00', 00104, 'A4'),
  (002, '001', '13:50', '16:00', 00104, 'B8'),
  (002, '001', '13:50', '16:00', 00104, 'C3'),
  (002, '001', '13:50', '16:00', 00104, 'D7'),
  (002, '001', '13:50', '16:00', 00104, 'E2'),
  (002, '001', '13:50', '16:00', 00104, 'F6'),
  (002, '001', '13:50', '16:00', 00104, 'G1'),
  (002, '001', '13:50', '16:00', 00104, 'H4'),
  (002, '001', '13:50', '16:00', 00104, 'I8'),
  (002, '001', '13:50', '16:00', 00104, 'J3');
  
insert into tiket  
VALUES
  (003, '007', '08:00', '10:20', 00704, 'A7'),
  (003, '007', '08:00', '10:20', 00704, 'B3'),
  (003, '007', '08:00', '10:20', 00704, 'C8'),
  (003, '007', '08:00', '10:20', 00704, 'D2'),
  (003, '007', '08:00', '10:20', 00704, 'E7'),
  (003, '007', '08:00', '10:20', 00704, 'F5'),
  (003, '007', '08:00', '10:20', 00704, 'G8'),
  (003, '007', '08:00', '10:20', 00704, 'H4'),
  (003, '007', '08:00', '10:20', 00704, 'I6'),
  (003, '007', '08:00', '10:20', 00704, 'J1'),
  (003, '007', '08:00', '10:20', 00704, 'A4'),
  (003, '007', '08:00', '10:20', 00704, 'B9'),
  (003, '007', '08:00', '10:20', 00704, 'C2'),
  (003, '007', '08:00', '10:20', 00704, 'D6'),
  (003, '007', '08:00', '10:20', 00704, 'E8'),
  (003, '007', '08:00', '10:20', 00704, 'F3'),
  (003, '007', '08:00', '10:20', 00704, 'G7'),
  (003, '007', '08:00', '10:20', 00704, 'H5');
  
 insert into tiket
 VALUES
  (005, '008', '19:40', '21:50', 00804, 'I10'),
  (005, '008', '19:40', '21:50', 00804, 'J4'),
  (005, '008', '19:40', '21:50', 00804, 'A2'),
  (005, '008', '19:40', '21:50', 00804, 'B8'),
  (005, '008', '19:40', '21:50', 00804, 'C5'),
  (005, '008', '19:40', '21:50', 00804, 'D9');
  
create table transaksi(
kodeuser varchar(4) references `user`(kodeuser),
kodefilm varchar(10) references jadwal(kodefilm),
kodestudio varchar(3) references studio(kodestudio),
kodejumlahtiket varchar(10),
jumlahtiketpesan varchar(3),
totalharga int(10),
bookingfee int(20)
);
-- studio 1 
insert into transaksi values(001,'001',00101,001007,007,245000,24500);
insert into transaksi values(004,'002',00201,004004,004,140000,14000);
insert into transaksi values(001,'003',00301,001007,007,245000,24500);
insert into transaksi values(001,'003',00301,001002,002,60000,6000);

-- studio2
insert into transaksi values(007,'005',00502,007002,002,70000,7000);
insert into transaksi values(008,'006',00602,008001,001,35000,3500);
insert into transaksi values(009,'007',00702,009003,003,105000,10500);

-- studio3
insert into transaksi values(014,'006',00603,014005,005,175000,17500);
insert into transaksi values(015,'007',00703,015010,010,350000,35000);
insert into transaksi values(016,'008',00803,016006,006,210000,21000);

-- studio 4
insert into transaksi values(002,'001',00104,002011,011,385000,38500);
insert into transaksi values(003,'007',00704,003018,018,630000,63000);
insert into transaksi values(005,'008',00804,005006,006,210000,21000);

-- studio5
insert into transaksi values(017,'001',00105,017001,001,35000,3500);
insert into transaksi values(018,'004',00405,018008,008,280000,28000);
insert into transaksi values(019,'008',00805,019009,009,315000,31500);

select*from `user`;
select*from film;
select*from studio;
select*from jadwal;
select*from kursi;
select*from tiket;
select*from transaksi;