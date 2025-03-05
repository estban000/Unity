using UnityEngine;

public class premierScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int Chiffre (int num1)
        {
            return num1 * num1;
        }
        int total= Chiffre(10);
        Debug.Log("Résultat = " + total);

        string Personnage = "Leon S. Kennedy";

        int[] Petitlist = {2, 4, 6, 8, 10};
        Debug.Log("Bonjour " + Personnage);
        Debug.Log(Petitlist);
        Debug.Log(Personnage);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
        // Mes instructions
        Debug.Log("Saviez-Vous que les IA domineront le monde ?");
        }
    }
}
