# Apollo - Exercice de recrutement

Chez Apollo, nous pensons qu'il est plus important d'évaluer un candidat sur les compétences qu'il met en œuvre au quotidien, plutôt que sur des exercices qui ne valident que des connaissances théoriques. 

C'est pourquoi nous avons créé ce test de recrutement basé sur le principe de revue de code.
Nous estimons que tout développeur, quel que soit son niveau, devrait savoir porter un regard critique sur le code produit par ses pairs. Il devrait être capable de mener une revue systématique amenant à l'amélioration de la qualité du code, tant sur le fond que sur la forme.

### Avant de commencer

Nous vous conseillons de vous réserver un créneau de 30-45 minutes maximum sans perturbations pour effectuer cet exercice.

### Contexte

Vous faites partie d'une équipe en charge du développement d'un nouveau logiciel ERP.\
L'un de vos collègues avait pour tâche d'initier une nouvelle API REST pour gérer les contrats conclus avec les clients de l'entreprise. Le code qu'il a produit pour créer ce socle applicatif est contenu dans ce dossier.

Votre travail est de relire ce code et de lui donner des indications pour l'améliorer.

### Attentes

Vous devrez saisir vos remarques dans un format imposé, en remplissant le fichier joint : \<NOM DU FICHIER\>

Toutes les remarques que vous ferez seront relues attentivement. Nous attacherons toutefois un peu plus d'importance aux remarques portant sur le fond que celles sur la forme. Ces dernières sont souvent subjectives et dépendent surtout des conventions suivies par l'équipe.

Afin de ne pas complexifier le projet, les données ont été écrites en dur dans des fichiers `*DbSet.cs`, ces fichiers peuvent être ignorés lors de la revue.

Nos attentes seront évidemment fonction de votre niveau et de votre profil.

### Exercice pratique

Votre revue étant terminée, vous pouvez désormais vous occuper des tâches qui vous ont été affectées.

En voici deux :
- Implémenter la création, la mise à jour et la suppression d'un contrat
- Tester unitairement ContractService.cs

Vous pouvez effectuer les modifications directement dans ce dossier. Vous retournerez ensuite une archive de ce dossier avec votre fichier de remarques rempli.