using System.Runtime.Serialization;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField]
    private float axisX = 0f;

    [SerializeField]
    private float axisY = 0f;

    [SerializeField]
    private float axisZ = 0f;

    [SerializeField]
    [Tooltip("Temps en seconde pour faire l'aller.")]
    private float timeToComplete = 1f;

    [SerializeField, InspectorName("Easing (^1 to ^3)")]
    [Tooltip("Exposant utilisé dans la courbe. 0 donne un exposant 1, 0.5 un exposant 2 et 1 donne un exposant 3.")]
    [Range(0f, 1f)]
    private float ease = 0f;

    [SerializeField]
    [Tooltip("Multiplie une valeur à l'exposant maximal du slider Ease. Une valeur de 3 ici donnera un exposant 9 comme valeur maximale au champ Ease.")]
    private float easeMultiplier = 1f;

    [SerializeField]
    [Tooltip("Permet d'activer ou désactiver le easing-in et easing-out pour obtenir une courbe linéaire.")]
    private bool useEase = true;

    private float startPosX;
    private float startPosY;
    private float startPosZ;

    private float endPosX;
    private float endPosY;
    private float endPosZ;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private float progression;
    private float elapsedTime = 0;
    

    void Start()
    {
        // on donne la position initale de l'objet
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        startPosZ = transform.position.z;
        startPosition = new Vector3(startPosX, startPosY, startPosZ);

        // on donne la position finale désirée
        endPosX = startPosX + axisX;
        endPosY = startPosY + axisY;
        endPosZ = startPosZ + axisZ;
        endPosition = new Vector3(endPosX, endPosY, endPosZ);
    }

    // Update is called once per frame
    void Update()
    {  
        Vector3 pos = transform.position;
        float exposant = Mathf.Lerp(1,(3 * easeMultiplier),ease);

        // gestion de la progression dans le temps
        elapsedTime += Time.deltaTime;
        progression =  elapsedTime / timeToComplete;

        // calcul de la courbe de position
        float angleProgression = progression * Mathf.PI; // me donne un angle qui couvre de 0 à 1
        float angleInverse = 1 - Mathf.Sin(angleProgression);
        float cosinusAngle = Mathf.Cos(angleProgression);

        float courbeLineaire = Mathf.PingPong(progression, 1f);
        float courbe = (1 - cosinusAngle) / 2; // me donne la formule de la courbe de progression avec un ease in ease out

        float courbeMoitie1 = courbe * 2;
        float courbeMoitie1Exp = Mathf.Pow(courbeMoitie1, exposant) * 0.5f;

        float courbeMoitie2 = (1 - courbe) * 2;
        float courbeMoitie2Exp = 1 - (Mathf.Pow(courbeMoitie2, exposant) *0.5f);

        Vector3 positionUpdate;

        // gestion du easing on/off
        if (useEase) {
            if (courbe <= 0.5)
                {
                    positionUpdate = Vector3.Lerp(startPosition, endPosition, courbeMoitie1Exp);  
                } else
                {
                    positionUpdate = Vector3.Lerp(startPosition, endPosition, courbeMoitie2Exp);
                }   
        } else {
            positionUpdate = Vector3.Lerp(startPosition, endPosition, courbeLineaire);   
        }

        transform.position = positionUpdate;        
    }
}

