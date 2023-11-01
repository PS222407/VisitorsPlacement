# VisitorsPlacement
Dit is een schoolopdracht voor algoritmiek aan te tonen.

## Opdracht
Zie PDF voor een overzichtelijker beschrijving van wat hieronder beschreven staat.

Visitors placement tool voor events
Voor de organisator van evenementen moet een tool worden gemaakt die aan elke bezoeker een
plek toewijst. Langs het parcours, dat elk keer anders is, worden vakken gemaakt met daarin rijen
met stoelen.
Indeling in vakken
1. Elk vak kan in grootte verschillen doordat er obstakels langs het parcours staan. Een vak is
minimaal 1 tot maximaal 3 rijen groot.
2. Alle rijen in een vak zijn even lang.
3. Een rij is tussen de 3 en 10 stoelen lang.
4. Per evenement heeft elk vak een unieke letter. Binnen een vak heeft elke rij een uniek
nummer en elke stoel heeft een unieke code die bestaat uit vakletter, rijnummer en stoel
volgnummer bijv. A1-2 is vak A, rij 1 stoel 2. B2-2 is vak B, rij 2 stoel 2.
Bezoekers
5. Bezoekers kunnen zich individueel aanmelden of in groepen. Een bezoeker is een
volwassene of een kind (t/m 12 jaar). Leeftijd kind wordt bepaald a.d.h.v. zijn leeftijd bij
aanvang van het evenement, niet bij aanmeldingsdatum.
6. Het kan zijn dat een bezoeker (al dan niet uit een groep) zich te laat aanmeld. Deze krijgt dan
geen toegang. Groepsgenoten die zich wel op tijd hebben aangemeld krijgen uiteraard wel
toegang. Ook kan het zijn dat er teveel bezoekers zich hebben aangemeld. Bezoekers krijgen
o.b.v. first come first serve (d.w.z. aanmeldingsdatum) toegang.
7. Als een bezoeker nog nooit een evenement van de organisator heeft bezocht dan moet deze
zich eenmalig registreren met zijn naam en geboortedatum. De bezoeker krijgt vervolgens
een uniek nummer.
8. Als het kan iedereen zo ver mogelijk in een vak vooraan plaatsen. Echter kinderen worden
altijd op de 1e
rij geplaatst zodat ze het parcours en de atleten goed kunnen zien.
Volwassenen zijn meestal een stuk langer uiteraard en kunnen eventueel indien nodig ook
prima op bijv. 1 van de achterste rijen zitten.
9. Een kind mag zich nooit alleen aanmelden maar alleen in een groep waar minimaal 1
volwassene bij zit. De kinderen uit de groep worden altijd samen met minimaal 1 volwassene
naast elkaar geplaatst. De voorkeur gaat uit om iedereen uit de groep in 1 rij te plaatsen.
Lukt dat niet dan mogen de eventuele overige volwassenen uit de groep ook op een andere
Versie 07-09-2021
rij (of rijen) worden geplaatst maar wel weer naast elkaar en altijd qua rij nummer zo dicht
mogelijk bij de overige deel van groep.
Let op: het kan voorkomen dat een groep uit zoveel kinderen bestaat dat deze niet in 1
(voorste) rij past (en zelfs van geen één enkel vak). De kinderen zullen dan gesplitst moeten
worden waarbij elk subgroep uiteraard weer minimaal 1 volwassen heeft. Deze subgroepen
zullen dan over meerdere vakken moeten worden verdeeld.
10. Het is de bedoeling zo min mogelijk vakken te gebruiken (d.w.z. vakken met minimaal 1
persoon) aangezien dit veel tijd en werk voor de organisatie kost om te maken en dus
kostbaar is. Zorg ook voor zo min mogelijk lege stoelen in de vakken en rijen. Je mag een vak
C openen terwijl vak B leeg blijft, je hoeft dus niet per se in volgorde de vakken A, B, C … te
openen.
11. Een evenement heeft een maximum aantal bezoekers waarvoor een vergunning is
afgegeven en daarmee dus ook een bepaald aantal vakken waarvan alle stoelen samen
opgeteld dit maximum is.
12. Bezoekers mogen zich niet dubbel aanmelden voor een evenement.
13. Elke groep die zich heeft aangemeld heeft een uniek nummer voor dat evenement.
Visualiseren van de resultaten
14. Maak ook een visualisatie waarin de persoon en groep-id’s worden weergegeven op de
stoelen. Dit kan eenvoudigweg met ASCII art, Unity 3D (in 2D of zelfs 3D, zie
ContainerVervoer Visualizer als voorbeeld/inspiratie) of als Bitmap (.png/.jpg). Gebruik
kleurtjes om een en ander te verduidelijken, dit kan zelfs in een ASCII/Console applicatie.
15. Toon ook een lijst van bezoekers die geen toegang hebben gekregen incl. de reden.
16. Handig is ook als je een random bezoekerslijst generator hebt en/of waarbij jouw
programma makkelijk bezoekerslijst bestanden kan inlezen (zie meegeleverde (incomplete)
.json bestanden als inspiratie).
17. Tip: zorg voor unittests!
Probeer zoveel mogelijk van bovenstaande eisen te implementeren.