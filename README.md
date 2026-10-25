# OutilsUnity
Des outils Unity développés pour apprendre C# tout en aillant des buts tangibles.

## Comment utiliser les outils

Simplement ajouter les dossiers des outils au dossier Assets d'un projet Unity.

## Oscillator

### Objectif
Créer un script permettant de faire faire des allez-retour à un objet entre sa position de départ et une position modifiée par l'entrée de offsets par l'utilisateur. Je voulais également avoir un effet de ease-in et ease-out par défaut et que celui-ci soit désactivable pour avoir une transition linéaire. C'est un script que j'ai déjà utilisé comme Atiste 3D sur la création de niveaux chez un ancien employeur, j'ai voulu voir comment je pourrais le recréer.

### Fontionnalités

<img width="593" height="182" alt="Oscfunctions" src="https://github.com/user-attachments/assets/998ed487-53ff-4c65-b132-e34e3f06ac7f" />

| Champ | Fonction |
|-----------|-----------|
| Axis X, Y, Z  | Valeurs à ajouter aux valeur de depart, determinent le point d'arrivée  |
| Time to Complete  | Temps en seconde nécessaire pour faire un aller  |
| Ease  | Détermine l'exposant qui affecte la courbe de easing (0 = ^1, 0.5 = ^2, 1 = ^3)  |
| Ease Multiplier | Multiplie la valeur de la limite supérieur du Ease |
| Use Ease | Si désactivé, les deux champs précédents sont désactivés et la courbe utilisée est linéaire |

### Demo
Le cube rouge utilise la courbe linéaire (pas de easing) et les vert utilisent différentes valeurs de Ease.
<img width="1015" height="714" alt="Oscillator" src="https://github.com/user-attachments/assets/024fcff8-84c9-4643-952a-d9e74894f9bd" />



