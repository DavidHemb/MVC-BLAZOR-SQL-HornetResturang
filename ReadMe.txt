README

--------------------------------------------------------------------------------------------------------------------------
Configure Startup
--------------------------------------------------------------------------------------------------------------------------
Startup guide

"Multiple Startup Projects" (Hornet, Hornet_Proj_API)
"update-database" 
"debug"

--------------------------------------------------------------------------------------------------------------------------
Accounts
--------------------------------------------------------------------------------------------------------------------------
ADMINS

Admin@mail.com
Admin1!

Employees

David@mail.com
Employee1!

Emanuel@mail.com
Employee21!

Robin@mail.com
Employee3!

Fredrik@mail.com
Employee4!

Sanna@mail.com
Employee5!

--------------------------------------------------------------------------------------------------------------------------
SEEDS
-------------------------------------------------------------------------------------------------------------------------

CATEGORIES

INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Mains', 0, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Desserts', 0, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Sides', 0, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Snacks', 0, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Cocktails', 1, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Beers', 1, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Soft Drinks', 1, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Books', 0, 0)
INSERT INTO Categories (Name, Liquid, IsDeleted) Values('Clothing', 0, 0)

FOOD

INSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
VALUES 
	('Fettisdubbelburgare', 'Dubbla k�ttburgare, extra ost, doppad i sm�lt sm�r och str�sslad med baconflarn.', 109, 0, 0, 0, 0, 0, '/assets/img/fettisdubbelburgare.jpg'),
	('Br�drockad Baconbomb', 'En hamburgare inlindad i friterad ost och t�ckt med krispigt bacon, serverad p� en s�ng av pommes frites.', 12.99, 0, 0, 0, 0, 0, 'assets/img/br�drockad-baconbomb.jpg'),
	('Sm�ltande Sm�rkalv', 'En saftig kalvburgare dr�nkt i sm�lt sm�r, toppad med l�kstrimlor och sm�lt ost.', 119, 0, 0, 0, 0, 0, 'assets/img/Sm�ltande-sm�rkalv.jpg'),
	('Kr�kfr�ck Kycklingknyckare', 'Panerad och friterad kycklingfil�, �verdr�nkt i kr�mig ranchdressing, med extra pickles.', 99, 0, 0, 1, 0, 0, 'assets/img/kr�kfr�ck-kycklingknyckare.jpg'),
	('Flottiga Friterade L�kloopar', 'Friterade l�kringar dr�nkta i ost- och jalape�os�s, serverade med en extra sida av fet majonn�s.', 79, 0, 0, 1, 0, 0, 'assets/img/flottiga-friterade-l�kloopar.jpg'),
	('Svettig Slaskkorv Deluxe', 'En j�ttekorv inlindad i bacon, toppad med grillad l�k, pickles och senap.', 89, 0, 0, 1, 0, 0, 'assets/img/Svettig-Slaskkorv-Deluxe.jpg'),
	('Klibbiga Kycklingnaglar', 'Heta kycklingvingar doppade i klibbig BBQ-s�s, serverade med en sida av blekta sellerist�nger.', 99, 0, 0, 1, 0, 0, 'assets/img/Klibbiga-Kycklingnaglar.jpg'),
	('Grisgyttelicious Gr�ddpaj', 'En kolossal k�ttpaj fylld med bacon, korv, och gr�ddig ost, serverad med extra gr�ddfil.', 149, 0, 0, 1, 0, 0, 'assets/img/Grisgyttelicious-Gr�ddpaj.jpg'),
	('Sm�rig Skr�pburgare', 'En blandning av diverse k�ttrester, �verh�lld med sm�lt sm�r och ost, serverad i ett mosat br�d.', 139, 0, 0, 1, 0, 0, 'assets/img/Sm�rig-Skr�pburgare.jpg'),
	('S�tsliskig Sm�ltchoklad-Baconboll', 'En j�ttestor chokladboll fylld med sm�lt marshmallow, choklads�s och krispigt bacon.', 69, 0, 1, 0, 0, 0, 'assets/img/S�tsliskig-Sm�ltchoklad-Baconboll.jpg');

SIDES

INSERT INTO products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
VALUES
  ('Kladdkakskrispiga Kryddn�tter', 'Rostade n�tter insvepta i en kladdig choklad- och kakaostr�ssel, med en hint av kanel och socker.', 39.90, 0, 0, 0, 1, 0, 'assets/img/Kladdkakskrispiga-Kryddn�tter.jpg'),
  ('Flottiga Ostbollar', 'Ostbollar doppade i sm�lt sm�r och rullade i en mix av smulig bacon och ostflingor.', 49.90, 0, 0, 0, 0, 0, 'assets/img/Flottiga-Ostbollar.jpg'),
  ('Krispiga Krispsm�rvar', 'Potatischips �verstr�sslade med sm�lt sm�r och sm�rkryddat popcorn, f�r en dubbel dos av sm�rigt n�je.', 29.90, 0, 0, 0, 0, 0, 'assets/img/Krispiga-Krispsm�rvar.jpg'),
  ('Saltlakrits-Sirapspopcorn', 'Popcorn dr�nkta i saltlakritssirap och toppade med sm�godisbitar f�r en explosiv s�t-och-salt smakupplevelse.', 45.90, 0, 0, 0, 1, 0, 'assets/img/Saltlakrits-Sirapspopcorn.jpg'),
  ('Choklad�vert�ckta Ostb�gar', 'Ostb�gar dr�nkta i m�rk choklad och pudrade med florsocker, f�r den ultimata kontrasten mellan salt och s�tt.', 59.90, 0, 0, 0, 0, 0, 'assets/img/Choklad�vert�ckta-Ostb�gar.jpg'),
  ('Sockerstinna Salta Spretb�nor', 'Spretiga gr�na b�nor doppade i sockerlag och rullade i krossade salta kex, f�r en konstig men beroendeframkallande smakkombination.', 34.90, 0, 0, 0, 0, 0, 'assets/img/Sockerstinna-Salta-Spretb�nor.jpg'),
  ('Snaskiga Sillchips', 'L�ttsaltade chips med en s�lta av inlagd sill och en touch av syrlig gr�ddfil, f�r den ultimata sm�riga och havsiga crunchen.', 42.90, 0, 0, 0, 0, 0, 'assets/img/Snaskiga-Sillchips.jpg'),
  ('Chokladpuffade Pretzelknyten', 'Pretzelknyten �verdragna med m�rk choklad och puffade rispuffar, f�r en krispig och chokladig snacksensation.', 55.90, 0, 0, 0, 0, 0, 'assets/img/Chokladpuffade-Pretzelknyten.jpg'),
  ('L�kpulverdr�nkta L�skiga Lakritsbitar', 'Lakritsbitar doppade i l�kpulver f�r en �verraskande och t�rdrypande smakupplevelse.', 38.90, 0, 0, 0, 0, 0, 'assets/img/L�kpulverdr�nkta-L�skiga-Lakritsbitar.jpg'),
  ('Bubblig Blandning av Buggchips', 'Chips kryddade med en bubblig blandning av s�ta och kolsyrehaltiga l�skedrycker, f�r den ultimata snacksfestivalen.', 44.90, 0, 0, 0, 0, 0, 'assets/img/Bubblig-Blandning-Buggchips.jpg');

DRINKS

INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
VALUES
  ('Frossar-Fizz', 'En explosiv blandning av sockerstinna l�skedrycker, toppad med fluffig vispgr�dde och �verstr�sslad med sm�godis.', 59, 10.0,  0, 0, 0, 0, 'assets/img/Frozzar-fizzz.jpg'),
  ('Slemmig Sockershocktail', 'En bl�ndande f�rgglad cocktail av sockers�ta lik�rer, serverad i ett kladdigt sockerrimmat glas.', 79, 15.0, 0, 0, 0, 0, 'assets/img/Slemmig-sockershocktail.jpg'),
  ('Griniga Gr�ten-Grogg', 'En v�rmande blandning av havregrynssprit, kanelvodka och gr�ddig mj�lk, toppad med en klick sm�r.', 89, 20.0, 0, 1, 0, 0, 'assets/img/Griniga-gr�ten-grogg.jpg'),
  ('Snaskiga Smultronskakern', 'En fruktig mix av smultronlik�r, vaniljvodka och en touch av skvalande sm�lt glass.', 69, 18.0, 0, 0, 0, 0, ''),
  ('R�dvinsr�nnstens-Razzia', 'En robust blandning av billig r�dvin, cola och en skv�tt tequila - serverad i en plastmugg f�r den autentiska k�nslan.', 49, 12.0, 0, 0, 0, 0, 'assets/img/r�dvinsr�nnstens.jpg'),
  ('Kladdkaka-Kaskad', 'En chokladig kaskad av Baileys, chokladlik�r och �verd�dig choklads�s, garnerad med smulig kladdkaka.', 99, 15.0, 0, 0, 0, 0, 'assets/img/kladdkaka-kaskad.jpg'),
  ('Skumma Skrubbsoda', 'En �verraskande bubblig mix av citronvodka, tandl�karens favoritl�sk och en citronskiva som f�rl�telse.', 79, 14.0, 0, 0, 0, 0, ''),
  ('Br�kig Bl�b�rsbl�ckpatrull', 'En skarp blandning av bl�b�rslik�r, gin och ett st�nk av bl�ck fr�n fiskstimuleringssprutan.', 89, 22.0, 0, 0, 0, 0, 'assets/img/br�kig-bl�b�rsbl�ckpatrull.jpg'),
  ('Kr�mig Karamellkaos', 'En kr�mig cocktail av karamellvodka, kolasnaps och en kolas�srand, serverad med extra s�tsliskiga kolor.', 109, 16.0, 0, 0, 0, 0, ''),
  ('Sur�ls-Snuttarita', 'En sur twist p� en klassisk margarita, med en touch av sur�l och en saltkant av krossade surisar.', 69, 14.0, 0, 0, 0, 0, 'assets/img/sur�ls-snuttarita.jpg');

  MISC
	INSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES 
		('Bubbens kokbok', 'Bubben eller Morran fr�n tv serien Morran och Tobias egna kokbok (Bubbens egna citat kring boken: Alla andra matr�tter i kokb�ker saknar nikotin eller bensin de g�r bannemig inte min serru).', 2599, 0, 0, 0, 0, 0, 'img')

	INSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES 
		('H�RNET TSHIRT MERCH', 'Storlek(S). Best�llningsvara, leveranstid ca 32 veckor. Kravm�rkta produkter. Made in Indian sweetshops by kinda well paid somewhat adults. Wear whit pride(not gay pride(unless you want it to be(then it most defenitly is)))!', 799, 0, 0, 0, 0, 0, 'img')

	BEERS NOT IN SEEDS

	INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES
    ('G�te Guld', 'Ett riktigt g�tt G�te �l med smak av hembygd.', 45.99, 6.5, 0, 0, 1, 0, 'assets/img/G�teGuld.jpg'),
    ('V�stra Stoutet', 'Ett riktigt m�rkt och tufft stout fr�n v�st.', 55.50, 7.0, 0, 0, 1, 0, 'assets/img/V�straStoutet.jpg'),
    ('G�ta L�tt�l', 'En frisk och l�tt �l direkt fr�n g�tarnas land.', 32.75, 2.5, 0, 1, 1, 0, 'assets/img/G�taL�tt�l.jpg'),
    ('H�rlig Pale Ale', 'En pale ale s� h�rlig att den g�r rakt in i hj�rtat.', 42.25, 5.2, 0, 1, 1, 0, 'assets/img/H�rligPaleAle.jpg'),
    ('V�stra Vetet', 'Ett ljust och fruktigt vet�l som bara g�tar f�rst�r.', 38.99, 4.8, 0, 1, 1, 0, 'assets/img/V�straVetet.jpg'),
    ('R�d G�te Ale', 'En r�d ale med smak av �kta g�tekarakt�r.', 47.75, 6.0, 0, 1, 1, 0, 'assets/img/R�dG�teAle.jpg'),
    ('Belgisk G�te', 'En stark och komplex belgisk g�te med smak av frihet och kryddor.', 65.00, 8.5, 0, 0, 1, 0, 'assets/img/BelgiskG�te.jpg'),
    ('Klassisk G�te Pils', 'En klassisk och frisk g�te pilsner f�r �kta g�tek�nsla.', 36.50, 4.5, 0, 1, 1, 0, 'assets/img/KlassiskG�tePils.jpg'),
    ('Surt G�te', 'Ett surt g�te �l som f�r munnen att vattnas.', 40.25, 4.2, 0, 1, 1, 0, 'assets/img/SurtG�te.jpg'),
    ('G�te Porter Excellence', 'En m�rk och uts�kt g�te porter med smak av g�tak�rlek.', 52.99, 6.8, 0, 0, 0, 0, 'assets/img/G�tePorterExcellence.jpg');

	SOFTDRINKS SEED

	INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES
    ('G�ttiga Citrusspraket', 'En ruggigt g�tt l�skedryck me smak av citrus o bubblor.', 25.99, 0, 0, 0, 0, 0, 'assets/img/G�ttigaCitrusspraket.jpg'),
    ('Bubblig B�rnrajs', 'En saftig b�rsmakad l�skedryck me bubblande bubblor.', 22.50, 0, 0, 0, 0, 0,'assets/img/BubbligB�rnrajs.jpg'),
    ('Zero Sugar Cola', 'Gammaldags colasmak uta tillsatt socker, perfekt f�r di som h�ller koll p� sockerintaget.', 18.75, 0, 0, 0, 0, 0, 'assets/img/ZeroSugarCola.jpg'),
    ('Koffeinfri Citronad Skval', 'En riktigt g�tt koffeinfri citronad me ett skv�tta citronsmak.', 20.25, 0, 0, 0, 0, 0, 'assets/img/KoffeinfriCitronadSkval.jpg'),
    ('Ingef�rs Njutning', 'En lugnande ingef�rsdusch me en touch av s�tma o bubblor.', 19.99, 0, 0, 0, 0, 0, 'assets/img/Ingef�rsNjutning.jpg');

    ('K�rsb�rs-Vanilj R�k', 'K�rsb�rs- o vaniljsmakad l�skedryck f�r en unik o r�kig smakupplevelse.', 27.75, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Gr�nt Te R�kelse', 'En icke kolsyrad r�kelse av gr�nt te me en antydan av naturlig s�tma.', 30.00, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Soda Pop Kanon', 'En kanon av olika l�skedryckssmaker i en riktigt bubblande blandning.', 24.50, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Tropisk Punch Himmel', 'En tropisk punch-l�skedryck som tar dig till en himmel av smaker.', 28.25, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Lime Zest Sprakelse', 'En lime-smaksatt sprakande l�skedryck me en sk�n twist.', 23.99, 0, 0, 0, 0, 0, 'assets/img/');

	CATEPROD SEED
		Mains
		Desserts
		Sides
		Snacks
		Cocktails
		Beers
		Soft Drinks
		Books
		Clothing
	
	INSERT INTO ProductCategories(CategoryId, ProductId)
	VALUES 
	(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),
	(2,25),(2,28),(2,29),(2,21),(2,22),
	(3,23),(3,24),(3,26),(3,27),(3,30),

	(5, 11),(5,12),(5,13),(5,14),(5,16),(5,17),(5,18),(5,19),(5,20),
	(6, 33),(6, 34),(6, 35),(6, 36),(6, 37),(6, 38),(6, 39),(6, 40),(6, 41),(6, 42),
	(7, 43),(7, 44),(7, 45),(7, 46),(7, 47),
	(8,31),
	(9,32);