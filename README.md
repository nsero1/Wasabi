# Wasabi
Clanovi tima:                   
1. Ajdin Hrelja                                  
2. Mesud Pestek                   
3. Muaz Kasumovic                                  
4. Rasim Kaleta                       

## Opis teme
Prodavnica sportske opreme predstavlja program koji će korisnicima (uposlenicima)
omogućiti da jednostavnije i brže obavljaju neke od svojih radnih dužnosti.
Jedan od zadataka sistema je da čuva podatke o robi kojom prodavnica raspolaže.
U to se podrazumijevaju informacije o količini pojedinog artikla, njegovu cijenu,
te podatke koje su specifične za svaki artikal. 
Također, sistem treba da dozoli uposleniku dodavanje novih artikala, kao i brisanje
postojećih.
Pored toga, bilježi se aktivnost pojedinih uposlenika, količina prodane robe, kao
i količina nabavljene, te mjesečni izvještaj koji piše nadležna osoba prema pregledanim
aktivnostima.
Ovakav program će korisniku omogućiti efikasnije poslovanje, pogotovo ako je riječ
o većim prodajnim centrima, gdje je količina robe znatno veća. Samim tim evidencija
postaje težak zadatak koji zahtijeva dodatnu radnu snagu i resurse.

## Funkcionalnosti
* Pri prodaji artikla omogućuje pronalazak istog, očitavanje cijene, obračun
popusta (ukoliko postoji) i uklanjanje iz inventara
* Mogućnost praćenja uvezene robe, robe na stanju te robe koja je prodana
* Prijava na sistem uposlenika, sa različitim nivoima pristupa koji zavise
od uloge koju uposlenik izvršava
* Sistem upozorava uposlenika ukoliko količina robe padne ispod granice koju
zadaje sam uposlenik
* Mogućnost modifikacije liste uposlenika, robe, itd. ovisno o nivou pristupa
* Bilježi sve radnje zaposlenika, koji koriste ovaj sistem

## Akteri
* Prodavač - Pod prodavačem se podrazumijeva osoba s najnižim pristupom sistemu.
To su osobe koje su u direktnom kontatku s kupcima, vrše naplatu, asistiraju kupcima
pri odabiru artikla i sl.
* Supervizor - Supervizor je osoba koja nadgleda uži krug prodavača i koja ima nivo pristupa
za jedan viši od prodavača. Šalje eventualne prijedloge ili primjedbe direktoru.
* Menadžer - Menadžer je osoba pristupa svim bilješkama o dešavanjima u prodavnici.
To se odnosi na prodaju, uvoz i sve ostale radnje koje uključuju neku transakciju.
Njegov nivo pritupa je viši od supervizora. Na osnovu stečenih informacija on piše 
mjesečni izvještaj koji proslijeđuje direktoru.
* Direktor - Osoba sa najvišim pristupom. On ima mogućnost unosa novih zaposlenika, 
te uklanjanje starih, kao i sve ostale privilegije. Ima uvid u primjedbe/prijedloge
koje dobija od supervizora i u izvještaj koji mu šalje menadžer.