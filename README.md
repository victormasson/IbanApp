# IbanApi

## Points manquants :

- Commentaires en plus
- Gestion des logs
- HealthCheck pour v�rifier que le service fonctionne
- Authentification (jwt)
	- Pour l'appel GetInformationBancaireFromSalarie du controller, utiliser l'identifiant du token
- Tests e2e
- Ajouter une vue pour InformationBancaire par idSalarie avec pg materialized view
	ou ajouter les donn�es dans ELK

## Am�liorations :

- Cr�ation de table en SQL
- Mapping des entit�s avec automapper entre les entit�s du domain et les DTO
- FluentValidation
- Evenements � l'ajout
- Regex sur l'Iban + calcul pour v�rifier
	- Cr�er un type sp�cifique Iban pour simplifier les checks et am�liorer la lisibilit�
- Enlever EntityFrameworkCore du IApplicationDbContext et faire un repository sp�cifique � InformationBancaire
	- �a permettra de changer facilement de source de donn�es (autre microservice, autre database, ect...)
- Compl�ter le controller avec les exceptions possibles, le type retourn�.