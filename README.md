# DungeonCrawler
Programmering C#, Laboration 4

Lab 4
Er uppgift är att skriva ett program i form av ett spel, som använder objektorienterade principer.

Spelet
Målet med spelet är att hitta till utgången på så få drag som möjligt. Varje drag kan spelaren välja en riktning att gå. Varje förflyttning kostar ett drag.

Spelet utspelar sig på en tvådimensionell karta. Varje ruta på kartan är antingen ett rum, en vägg, en dörr eller utgången. Spelaren kan gå till angränsade rum horisontellt eller vertikalt. Dörrarna är ursprungligen låsta, men genom att besöka olika rum kan man plocka upp nycklar som låser upp dörrar.
Förutom kartan behöver spelet skriva ut vilka nycklar eller andra föremål man har plockat på sig och hur många drag man använt.

Använd en array för att representera kartan.
Rutor (rum, dörrar och väggar) ska vara klasser som har en gemensam, abstrakt basklass. Gemensamt för varje ruta är att det har ett tecken som ska visas när man skriver ut kartan på konsolen.
Ett rum kan vara tomt, ha en eller flera nycklar samt ha monster. Om spelaren går på en ruta med ett monster så kostar det många extra drag. Ni kan använda en klass för nycklar eller låta dem vara egenskaper i en klass. Nycklarna är engångsnycklar, som förstörs efter att man använt dem.
Använd en enum för att representera olika sorters rutor.
Använd ett interface för alla klasser som har ett tecken som kan visas på kartan.

