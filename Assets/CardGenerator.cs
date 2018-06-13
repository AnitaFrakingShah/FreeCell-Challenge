using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {
    public float offsetX = 2;
    public float offsetY = 3;


    public GameObject cardPrefab;

    public GameObject columnPrefab;
    public float columnXOffset = 1.5f;
    public float columnYOffsetForCards = 0.75f;
    public GameObject[] allColumns = new GameObject[8];



    public GameObject[] allCards = new GameObject[52];




    public Sprite[] suitSprites = new Sprite[4];
    public Sprite[] cardValueSpritesRed = new Sprite[13];
    public Sprite[] cardValueSpritesBlack = new Sprite[13];



    // Use this for initialization
    void Start () {
        int allCardsIndex = 0;
        for (int i_suit = 1; i_suit <= 4; i_suit++) {
            for (int i_val = 1; i_val <= 13; i_val++) {
                GameObject  cardSTART = Instantiate(cardPrefab, new Vector2(i_suit * offsetX, -i_val *offsetY), Quaternion.identity);
                Card card = cardSTART.GetComponent<Card>();
                card.suit = i_suit-1;
                card.value = i_val;
                card.isUp = false;
                card.suitSR.sprite = suitSprites[i_suit-1];
                card.bigSuitSR.sprite = suitSprites[i_suit - 1];

                card.ApplyFeatures();
                if (card.isCardColorRed)
                {
                    card.valueSR.sprite = cardValueSpritesRed[i_val - 1];
                }
                else {
                    card.valueSR.sprite = cardValueSpritesBlack[i_val - 1];
                }
                card.name = "Card (" + card.value + ", " + (card.isCardColorRed ? "Red" : "Black") + " (" + card.suitSR.sprite.name + "))";


                allCards[allCardsIndex] = card.gameObject;
                allCardsIndex++;


            }

        }
        int[] allCardsIndexes = new int[52];
        for (int i = 0; i < allCardsIndexes.Length; i++)
        {
            allCardsIndexes[i] = i;
        }
        for (int i = 0; i < allCardsIndexes.Length; i++)
        {
            int index = allCardsIndexes[i];
            int randomIndex = UnityEngine.Random.Range(0, allCardsIndexes.Length - 1);
            allCardsIndexes[i] = allCardsIndexes[randomIndex];
            allCardsIndexes[randomIndex] = index;
        }



        for (int i = 0; i < allColumns.Length; i++) {
            Vector3 newPositionForColumn = new Vector3(columnPrefab.transform.position.x + i * columnXOffset, columnPrefab.transform.position.y, columnPrefab.transform.position.z);
            GameObject columnSTART = Instantiate(columnPrefab, newPositionForColumn, Quaternion.identity);
            allColumns[i] = columnSTART;
        }


        for (int i = 0; i < allCardsIndexes.Length; i++) {
                GameObject cardGO = allCards[allCardsIndexes[i]];
                Card card = cardGO.GetComponent<Card>();
                GameObject columnSTART = allColumns[i % 8];
                Column column = columnSTART.GetComponent<Column>();
                card.backgroundSR.sortingOrder = column.cardCount;
                card.suitSR.sortingOrder = column.cardCount + 1;
                card.bigSuitSR.sortingOrder = column.cardCount + 1;
                card.valueSR.sortingOrder = column.cardCount + 1;
                column.cardCount++;

                card.isUp = true;
                card.ApplyFeatures();
                Vector3 newPositionForCard = new Vector3(column.transform.position.x, column.transform.position.y - (i / 8) * columnYOffsetForCards, -column.cardCount);
                card.transform.position = newPositionForCard;
        }

    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
