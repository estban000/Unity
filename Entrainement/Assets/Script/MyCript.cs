using UnityEngine;

public class MyCript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Bonjour");
        int Addition(int num1, int num2)
        {
            return num1 + num2;
        }
        int somme = Addition(2, 7);
        Debug.Log("Regarde le resultat : " + somme);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
        // Mes instructions
        Debug.Log("Maman je sais appuyer sur une touche de l'ordinateur :D");
        }
    }
}
