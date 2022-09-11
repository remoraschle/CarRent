Vorstellung und Ziele
====

Es soll ein neues Autovermietungssystem „CarRent“ erstellt werden. Das System soll aus einem Server-Teil und optional einen Web-Client bestehen.

1. Die Daten sollen mittels Repository Pattern in eine Datenbank gespeichert werden können.
2. Die Business Logik soll auf dem Backend laufen und eine REST APIs anbieten.
3. Es soll zuerst ein Monolith erstellt werden und später auf eine Micro Service Architektur überführt
werden.
4. Der Web-Client benutzt die REST API um die Funktionen auszuführen. (Optinal)

Anforderungs Übersicht
---

| Nr | Role | Anforderung |
| --- | --- | --- |
| 1 | SB | Sachbearbeiter müssen Kunden verwalten können (CRUD) |
| 2 | SB | Sachbearbeiter müssen Kunden Suchen können, mittels Kundennummer oder Namen |
| 3 | SB | Sachbearbeiter müssen Fahrzeuge verwalten können (CRUD) |
| 4 | SB | Sachbearbeiter müssen Fahrzeuge Kategoriersen können (Luxusklasse, Mittelklasse, Einfachklasse) |
| 5 | SB | Sachbearbeiter müssen für jede Farzeug Kategorie einen Preis hinerlegen können (Tagespreis) |
| 6 | SB | Sachbearbeiter müssen Fahrzeuge Reservationen verwalten (CRUD)  |
| 7 | SB | Sachbeareiter müssen sobald ein Fahrzeug abegholt wurden den Status auf Vermietet seten |
| 8 | System | Anhand der Mietdauer müssen die Gesamkosten bestimmt werden  |
| 9 | System | Fahrzeuge besitzen die folgenden Infos (Marke, Typ, UID und Fahrzeug Kategorie) |
| 10 | System | Fahrzeug Kategorien haben einen Tagespreis |
| 11 | Kunde | Kunden erhalten bei einer Abgeschlossen Reservation eine Reservationsnummer |
| 12 | Kunde | Kunden sehen vor dem Abschliessen der Reservation die Gesamkosten |
| 13 | Kunde | Kunden müssen für einen Reservation Start und End Datum angeben |
| 14 | Kunde | Kunden können Fahrzeuge nach der Fahrzeug Kategorie suchen |