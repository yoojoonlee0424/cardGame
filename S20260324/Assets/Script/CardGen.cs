
using UnityEngine;

public class CardGen : MonoBehaviour
{
    public GameObject card;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Vector2 SpwanPoint = new Vector2();

        for(int i = 0; i < 10; i++)
        {
            Instantiate(card,SpwanPoint,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
