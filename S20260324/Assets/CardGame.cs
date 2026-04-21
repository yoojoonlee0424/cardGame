using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();
    public List<Card> cards = new List<Card>();
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
        List<int> pairNumbers = GenPairNum(cards.Count);

        for (int i = 0; i < pairNumbers.Count; i++)
        {
            cards[i].SetCard(pairNumbers[i]);

            cards[i].Setimage(Sprites[pairNumbers[i]]);
        }

        for (int i = 0; i < pairNumbers.Count; i++)
        {
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
    List<int> GenPairNum(int cardCount)
    {
     
        int pairCount = cardCount / 2;
        List<int> newCardNumbers = new List<int>();
        
        for(int i = 0;i < pairCount;i++)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }

        for (int i = newCardNumbers.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);

            int temp = newCardNumbers[i];

            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;

        }

        return newCardNumbers;
    }


}
