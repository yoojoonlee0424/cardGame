using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public List<Sprite> Sprites = new();
    public List<Card> cards;

    public int cardCount = 4;

    public GameObject Card_ref;
    public Transform Container;

    private Card firstCard = null;
    private Card secondCard = null;
    private bool isChecking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        StartGame();
       


    }


    //카드 썩고 뒤집기
    void StartGame()
    {
        List<int> pairNumbers = GenPairNum();

        for (int i = 0; i < cardCount*2; i++)
        {
            GameObject EX = Instantiate(Card_ref, Container);

            cards.Add(EX.GetComponent<Card>());

            cards[i].SetCard(pairNumbers[i]);
            if(Sprites.Count > pairNumbers[i])
            {
                cards[i].Setimage(Sprites[pairNumbers[i]]);
            }
            

            cards[i].isFront = false;
        }

    }


    // 카드 채크
    public void CheckCard()
    {
        isChecking = true;

        if (firstCard.cardNumber == secondCard.cardNumber)
        {
            //정답
            firstCard.ChangeColor(Color.red);
            secondCard.ChangeColor(Color.red);
            //클릭 막기
            firstCard.isMatched = true;
            secondCard.isMatched= true;

            firstCard = null ;
            secondCard = null ;

            isChecking = false;
        }
        else
        {
            // 다시 뒤집기 1초
            Invoke("HideCard", 1.0f);
        }
    }


    public void OnClickCard(Card card)
    {
        if(isChecking == true)
        {
            return;
        }

        

        if (firstCard == null)
        {
            firstCard = card;
            firstCard.Flip(true);
        }
        else
        {
            secondCard = card;
            secondCard.Flip(true);
        }
        

        if(firstCard != null && secondCard != null)
        {
            CheckCard();
        }

    }


    //다시 숨기기
    void HideCard()
    {
        firstCard.isFront = false;
        secondCard.isFront = false;

        firstCard.Flip(false);
        secondCard.Flip(false);

        isChecking = false;

        firstCard = null;
        secondCard = null;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    //페어 생성
    List<int> GenPairNum()
    {
     
        int pairCount = this.cardCount;
        List<int> newCardNumbers = new();
        
        for(int i = 0; i < pairCount; i++)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }

        for (int i = 0; i < this.cardCount * 2; i++)
        {
            int temp = newCardNumbers[i];

            int rnd = Random.Range(0, this.cardCount * 2 - 1);

            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;

        }

        return newCardNumbers;
    }


    


}
