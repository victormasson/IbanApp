# IbanApi

## Points manquants :

- Commentaires en plus
- Gestion des logs
- HealthCheck pour vérifier que le service fonctionne
- Authentification (jwt)
	- Pour l'appel GetInformationBancaireFromSalarie du controller, utiliser l'identifiant du token
- Tests e2e
- Ajouter une vue pour InformationBancaire par idSalarie avec pg materialized view
	ou ajouter les données dans ELK

## Améliorations :

- Création de table en SQL
- Mapping des entités avec automapper entre les entités du domain et les DTO
- FluentValidation
- Evenements à l'ajout
- Regex sur l'Iban + calcul pour vérifier
	- Créer un type spécifique Iban pour simplifier les checks et améliorer la lisibilité
- Enlever EntityFrameworkCore du IApplicationDbContext et faire un repository spécifique à InformationBancaire
	- ça permettra de changer facilement de source de données (autre microservice, autre database, ect...)
- Compléter le controller avec les exceptions possibles, le type retourné.