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
	('Fettisdubbelburgare', 'Dubbla köttburgare, extra ost, doppad i smält smör och strösslad med baconflarn.', 109, 0, 0, 0, 0, 0, '/assets/img/fettisdubbelburgare.jpg'),
	('Brödrockad Baconbomb', 'En hamburgare inlindad i friterad ost och täckt med krispigt bacon, serverad på en säng av pommes frites.', 12.99, 0, 0, 0, 0, 0, 'assets/img/brödrockad-baconbomb.jpg'),
	('Smältande Smörkalv', 'En saftig kalvburgare dränkt i smält smör, toppad med lökstrimlor och smält ost.', 119, 0, 0, 0, 0, 0, 'assets/img/Smältande-smörkalv.jpg'),
	('Kräkfräck Kycklingknyckare', 'Panerad och friterad kycklingfilé, överdränkt i krämig ranchdressing, med extra pickles.', 99, 0, 0, 1, 0, 0, 'assets/img/kräkfräck-kycklingknyckare.jpg'),
	('Flottiga Friterade Lökloopar', 'Friterade lökringar dränkta i ost- och jalapeñosås, serverade med en extra sida av fet majonnäs.', 79, 0, 0, 1, 0, 0, 'assets/img/flottiga-friterade-lökloopar.jpg'),
	('Svettig Slaskkorv Deluxe', 'En jättekorv inlindad i bacon, toppad med grillad lök, pickles och senap.', 89, 0, 0, 1, 0, 0, 'assets/img/Svettig-Slaskkorv-Deluxe.jpg'),
	('Klibbiga Kycklingnaglar', 'Heta kycklingvingar doppade i klibbig BBQ-sås, serverade med en sida av blekta selleristänger.', 99, 0, 0, 1, 0, 0, 'assets/img/Klibbiga-Kycklingnaglar.jpg'),
	('Grisgyttelicious Gräddpaj', 'En kolossal köttpaj fylld med bacon, korv, och gräddig ost, serverad med extra gräddfil.', 149, 0, 0, 1, 0, 0, 'assets/img/Grisgyttelicious-Gräddpaj.jpg'),
	('Smörig Skräpburgare', 'En blandning av diverse köttrester, överhälld med smält smör och ost, serverad i ett mosat bröd.', 139, 0, 0, 1, 0, 0, 'assets/img/Smörig-Skräpburgare.jpg'),
	('Sötsliskig Smältchoklad-Baconboll', 'En jättestor chokladboll fylld med smält marshmallow, chokladsås och krispigt bacon.', 69, 0, 1, 0, 0, 0, 'assets/img/Sötsliskig-Smältchoklad-Baconboll.jpg');

SIDES

INSERT INTO products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
VALUES
  ('Kladdkakskrispiga Kryddnötter', 'Rostade nötter insvepta i en kladdig choklad- och kakaoströssel, med en hint av kanel och socker.', 39.90, 0, 0, 0, 1, 0, 'assets/img/Kladdkakskrispiga-Kryddnötter.jpg'),
  ('Flottiga Ostbollar', 'Ostbollar doppade i smält smör och rullade i en mix av smulig bacon och ostflingor.', 49.90, 0, 0, 0, 0, 0, 'assets/img/Flottiga-Ostbollar.jpg'),
  ('Krispiga Krispsmörvar', 'Potatischips överströsslade med smält smör och smörkryddat popcorn, för en dubbel dos av smörigt nöje.', 29.90, 0, 0, 0, 0, 0, 'assets/img/Krispiga-Krispsmörvar.jpg'),
  ('Saltlakrits-Sirapspopcorn', 'Popcorn dränkta i saltlakritssirap och toppade med smågodisbitar för en explosiv söt-och-salt smakupplevelse.', 45.90, 0, 0, 0, 1, 0, 'assets/img/Saltlakrits-Sirapspopcorn.jpg'),
  ('Chokladövertäckta Ostbågar', 'Ostbågar dränkta i mörk choklad och pudrade med florsocker, för den ultimata kontrasten mellan salt och sött.', 59.90, 0, 0, 0, 0, 0, 'assets/img/Chokladövertäckta-Ostbågar.jpg'),
  ('Sockerstinna Salta Spretbönor', 'Spretiga gröna bönor doppade i sockerlag och rullade i krossade salta kex, för en konstig men beroendeframkallande smakkombination.', 34.90, 0, 0, 0, 0, 0, 'assets/img/Sockerstinna-Salta-Spretbönor.jpg'),
  ('Snaskiga Sillchips', 'Lättsaltade chips med en sälta av inlagd sill och en touch av syrlig gräddfil, för den ultimata smöriga och havsiga crunchen.', 42.90, 0, 0, 0, 0, 0, 'assets/img/Snaskiga-Sillchips.jpg'),
  ('Chokladpuffade Pretzelknyten', 'Pretzelknyten överdragna med mörk choklad och puffade rispuffar, för en krispig och chokladig snacksensation.', 55.90, 0, 0, 0, 0, 0, 'assets/img/Chokladpuffade-Pretzelknyten.jpg'),
  ('Lökpulverdränkta Läskiga Lakritsbitar', 'Lakritsbitar doppade i lökpulver för en överraskande och tårdrypande smakupplevelse.', 38.90, 0, 0, 0, 0, 0, 'assets/img/Lökpulverdränkta-Läskiga-Lakritsbitar.jpg'),
  ('Bubblig Blandning av Buggchips', 'Chips kryddade med en bubblig blandning av söta och kolsyrehaltiga läskedrycker, för den ultimata snacksfestivalen.', 44.90, 0, 0, 0, 0, 0, 'assets/img/Bubblig-Blandning-Buggchips.jpg');

DRINKS

INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
VALUES
  ('Frossar-Fizz', 'En explosiv blandning av sockerstinna läskedrycker, toppad med fluffig vispgrädde och överströsslad med smågodis.', 59, 10.0,  0, 0, 0, 0, 'assets/img/Frozzar-fizzz.jpg'),
  ('Slemmig Sockershocktail', 'En bländande färgglad cocktail av sockersöta likörer, serverad i ett kladdigt sockerrimmat glas.', 79, 15.0, 0, 0, 0, 0, 'assets/img/Slemmig-sockershocktail.jpg'),
  ('Griniga Gröten-Grogg', 'En värmande blandning av havregrynssprit, kanelvodka och gräddig mjölk, toppad med en klick smör.', 89, 20.0, 0, 1, 0, 0, 'assets/img/Griniga-gröten-grogg.jpg'),
  ('Snaskiga Smultronskakern', 'En fruktig mix av smultronlikör, vaniljvodka och en touch av skvalande smält glass.', 69, 18.0, 0, 0, 0, 0, ''),
  ('Rödvinsrännstens-Razzia', 'En robust blandning av billig rödvin, cola och en skvätt tequila - serverad i en plastmugg för den autentiska känslan.', 49, 12.0, 0, 0, 0, 0, 'assets/img/rödvinsrännstens.jpg'),
  ('Kladdkaka-Kaskad', 'En chokladig kaskad av Baileys, chokladlikör och överdådig chokladsås, garnerad med smulig kladdkaka.', 99, 15.0, 0, 0, 0, 0, 'assets/img/kladdkaka-kaskad.jpg'),
  ('Skumma Skrubbsoda', 'En överraskande bubblig mix av citronvodka, tandläkarens favoritläsk och en citronskiva som förlåtelse.', 79, 14.0, 0, 0, 0, 0, ''),
  ('Bråkig Blåbärsbläckpatrull', 'En skarp blandning av blåbärslikör, gin och ett stänk av bläck från fiskstimuleringssprutan.', 89, 22.0, 0, 0, 0, 0, 'assets/img/bråkig-blåbärsbläckpatrull.jpg'),
  ('Krämig Karamellkaos', 'En krämig cocktail av karamellvodka, kolasnaps och en kolasåsrand, serverad med extra sötsliskiga kolor.', 109, 16.0, 0, 0, 0, 0, ''),
  ('Suröls-Snuttarita', 'En sur twist på en klassisk margarita, med en touch av suröl och en saltkant av krossade surisar.', 69, 14.0, 0, 0, 0, 0, 'assets/img/suröls-snuttarita.jpg');

  MISC
	INSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES 
		('Bubbens kokbok', 'Bubben eller Morran från tv serien Morran och Tobias egna kokbok (Bubbens egna citat kring boken: Alla andra maträtter i kokböker saknar nikotin eller bensin de gör bannemig inte min serru).', 2599, 0, 0, 0, 0, 0, 'img')

	INSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES 
		('HÖRNET TSHIRT MERCH', 'Storlek(S). Beställningsvara, leveranstid ca 32 veckor. Kravmärkta produkter. Made in Indian sweetshops by kinda well paid somewhat adults. Wear whit pride(not gay pride(unless you want it to be(then it most defenitly is)))!', 799, 0, 0, 0, 0, 0, 'img')

	BEERS NOT IN SEEDS

	INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES
    ('Göte Guld', 'Ett riktigt gött Göte öl med smak av hembygd.', 45.99, 6.5, 0, 0, 1, 0, 'assets/img/GöteGuld.jpg'),
    ('Västra Stoutet', 'Ett riktigt mörkt och tufft stout från väst.', 55.50, 7.0, 0, 0, 1, 0, 'assets/img/VästraStoutet.jpg'),
    ('Göta Lättöl', 'En frisk och lätt öl direkt från götarnas land.', 32.75, 2.5, 0, 1, 1, 0, 'assets/img/GötaLättöl.jpg'),
    ('Härlig Pale Ale', 'En pale ale så härlig att den går rakt in i hjärtat.', 42.25, 5.2, 0, 1, 1, 0, 'assets/img/HärligPaleAle.jpg'),
    ('Västra Vetet', 'Ett ljust och fruktigt vetöl som bara götar förstår.', 38.99, 4.8, 0, 1, 1, 0, 'assets/img/VästraVetet.jpg'),
    ('Röd Göte Ale', 'En röd ale med smak av äkta götekaraktär.', 47.75, 6.0, 0, 1, 1, 0, 'assets/img/RödGöteAle.jpg'),
    ('Belgisk Göte', 'En stark och komplex belgisk göte med smak av frihet och kryddor.', 65.00, 8.5, 0, 0, 1, 0, 'assets/img/BelgiskGöte.jpg'),
    ('Klassisk Göte Pils', 'En klassisk och frisk göte pilsner för äkta götekänsla.', 36.50, 4.5, 0, 1, 1, 0, 'assets/img/KlassiskGötePils.jpg'),
    ('Surt Göte', 'Ett surt göte öl som får munnen att vattnas.', 40.25, 4.2, 0, 1, 1, 0, 'assets/img/SurtGöte.jpg'),
    ('Göte Porter Excellence', 'En mörk och utsökt göte porter med smak av götakärlek.', 52.99, 6.8, 0, 0, 0, 0, 'assets/img/GötePorterExcellence.jpg');

	SOFTDRINKS SEED

	INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)
	VALUES
    ('Göttiga Citrusspraket', 'En ruggigt gött läskedryck me smak av citrus o bubblor.', 25.99, 0, 0, 0, 0, 0, 'assets/img/GöttigaCitrusspraket.jpg'),
    ('Bubblig Bärnrajs', 'En saftig bärsmakad läskedryck me bubblande bubblor.', 22.50, 0, 0, 0, 0, 0,'assets/img/BubbligBärnrajs.jpg'),
    ('Zero Sugar Cola', 'Gammaldags colasmak uta tillsatt socker, perfekt för di som håller koll på sockerintaget.', 18.75, 0, 0, 0, 0, 0, 'assets/img/ZeroSugarCola.jpg'),
    ('Koffeinfri Citronad Skval', 'En riktigt gött koffeinfri citronad me ett skvätta citronsmak.', 20.25, 0, 0, 0, 0, 0, 'assets/img/KoffeinfriCitronadSkval.jpg'),
    ('Ingefärs Njutning', 'En lugnande ingefärsdusch me en touch av sötma o bubblor.', 19.99, 0, 0, 0, 0, 0, 'assets/img/IngefärsNjutning.jpg');

    ('Körsbärs-Vanilj Rök', 'Körsbärs- o vaniljsmakad läskedryck för en unik o rökig smakupplevelse.', 27.75, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Grönt Te Rökelse', 'En icke kolsyrad rökelse av grönt te me en antydan av naturlig sötma.', 30.00, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Soda Pop Kanon', 'En kanon av olika läskedryckssmaker i en riktigt bubblande blandning.', 24.50, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Tropisk Punch Himmel', 'En tropisk punch-läskedryck som tar dig till en himmel av smaker.', 28.25, 0, 0, 0, 0, 0, 'assets/img/'),
    ('Lime Zest Sprakelse', 'En lime-smaksatt sprakande läskedryck me en skön twist.', 23.99, 0, 0, 0, 0, 0, 'assets/img/');

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