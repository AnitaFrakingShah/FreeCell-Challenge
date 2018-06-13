using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    //State Features
    public bool mouseDragged = false;
    public bool inFoundation = false;
    public bool inColumn = true;
    public bool inFreeCell = false;


    Vector3 oldCardPosition;
    Vector3 oldCellPosition;
    Transform oldParent;

    // 4 Possible suits
    public int suit = 0;
    public SpriteRenderer suitSR;
    public SpriteRenderer bigSuitSR;





    // 2 Possible card colors
    // True = red
    // False = black
    public bool isCardColorRed = false;






    // Whether the card is facing up or down
    public bool isUp = false;
    public SpriteRenderer backgroundSR;
    public Sprite downCardTexture;
    public Sprite upCardTexture;



    // The card value: Ace, 2,... etc.
    // Ace = 1
    // Jack = 11
    // Queen = 12
    // King = 13

    public int value = 0;
    public SpriteRenderer valueSR;

    public int[] sortingOrder = new int[4];



    public void ApplyFeatures() {
        if (isUp)
        {
            backgroundSR.sprite = upCardTexture;
            suitSR.gameObject.SetActive(true);
            bigSuitSR.gameObject.SetActive(true);
            valueSR.gameObject.SetActive(true); 


        }
        else
        {
            backgroundSR.sprite = downCardTexture;
            suitSR.gameObject.SetActive(false);
            bigSuitSR.gameObject.SetActive(false);
            valueSR.gameObject.SetActive(false);
        }

        // Установить цвет
        if (suit < 2)
        {
            isCardColorRed = true;
        }
        else
        {
            isCardColorRed = false;
        }


    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag() {
        mouseDragged = true;
        if (inFoundation || inColumn || inFreeCell)
        {
            Vector3 newPosition = Camera.main.ScreenPointToRay(Input.mousePosition).origin + oldCardPosition;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

        }



    }


    //After Card released
    void OnMouseUp() {

        //Remove collider so doesn't interfere with conditionals
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;

        //Identify if collided with anything when released card
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position + (-oldCardPosition), Vector3.forward);

        //Identify what card was touching originally
        RaycastHit2D originHit;
        originHit = Physics2D.Raycast(oldCellPosition, -transform.up);

        //Identify the column that trying to place card on
        RaycastHit2D columnHit;
        columnHit = Physics2D.Raycast(transform.position, -Vector3.forward, 10f);
        
        //Reset Sorting Order
        transform.position = oldCellPosition;
        backgroundSR.sortingOrder = sortingOrder[0];
        suitSR.sortingOrder = sortingOrder[1];
        bigSuitSR.sortingOrder = sortingOrder[2];
        valueSR.sortingOrder = sortingOrder[3];


        Card otherCard = null;
        Column column = null;
        FreeCell freecell = null;
        Foundation_Spades fs = null;
        Foundation_Clubs fc = null;
        Foundation_Diamonds fd = null;
        Foundation_Hearts fh = null;

        Card otherCard_origin = null;
        Column column_origin = null;
        FreeCell freecell_origin = null;
        Foundation_Spades fs_origin = null;
        Foundation_Clubs fc_origin = null;
        Foundation_Diamonds fd_origin = null;
        Foundation_Hearts fh_origin = null;

        if (columnHit.collider != null) {
            column = columnHit.collider.GetComponent<Column>();

        }

        if (originHit.collider != null)
        {
            otherCard_origin =originHit.collider.GetComponent<Card>();
            column_origin = originHit.collider.GetComponent<Column>();
            freecell_origin = originHit.collider.GetComponent<FreeCell>();
            fs_origin = originHit.collider.GetComponent<Foundation_Spades>();
            fh_origin = originHit.collider.GetComponent<Foundation_Hearts>();
            fc_origin = originHit.collider.GetComponent<Foundation_Clubs>();
            fd_origin = originHit.collider.GetComponent<Foundation_Diamonds>();
        }


        if (hit.collider != null)
        {
            otherCard = hit.collider.GetComponent<Card>();
            freecell = hit.collider.GetComponent<FreeCell>();
            fs = hit.collider.GetComponent<Foundation_Spades>();
            fh = hit.collider.GetComponent<Foundation_Hearts>();
            fc = hit.collider.GetComponent<Foundation_Clubs>();
            fd = hit.collider.GetComponent<Foundation_Diamonds>();
        }

        //On click put card in an open freecell
        if (freecell == null && otherCard == null && otherCard_origin == null && column_origin == column &&
            fs == null && fd == null && fc == null && fh == null)
        {
            GameObject fc1 = GameObject.Find("Free Cell 1");
            FreeCell freecell1 = fc1.GetComponent<FreeCell>();
            GameObject fc2 = GameObject.Find("Free Cell 2");
            FreeCell freecell2 = fc2.GetComponent<FreeCell>();
            GameObject fc3 = GameObject.Find("Free Cell 3");
            FreeCell freecell3 = fc3.GetComponent<FreeCell>();
            GameObject fc4 = GameObject.Find("Free Cell 4");
            FreeCell freecell4 = fc4.GetComponent<FreeCell>();

            if (freecell1.isFree)
            {
                transform.position = freecell1.transform.position;
                freecell1.isFree = false;
                inFoundation = false;
                inFreeCell = true;
                inColumn = false;

            }

            else if (freecell2.isFree)
            {
                transform.position = freecell2.transform.position;
                freecell2.isFree = false;
                inFoundation = false;
                inFreeCell = true;
                inColumn = false;

            }
            else if (freecell3.isFree)
            {
                transform.position = freecell3.transform.position;
                freecell3.isFree = false;
                inFoundation = false;
                inFreeCell = true;
                inColumn = false;

            }
            else if (freecell4.isFree)
            {
                transform.position = freecell4.transform.position;
                freecell4.isFree = false;
                inFoundation = false;
                inFreeCell = true;
                inColumn = false;

            }
        }


        //If column is empty and the current card is a King, can be moved into the column
        else if (value == 13 && otherCard_origin == null && otherCard == null && column != null) {
            column.cardCount++;
            transform.position = new Vector3(column.transform.position.x, column.transform.position.y, -column.cardCount);
            backgroundSR.sortingOrder = (column.cardCount - 1);
            suitSR.sortingOrder = column.cardCount;
            bigSuitSR.sortingOrder = column.cardCount;
            valueSR.sortingOrder = column.cardCount;


        }

        //If dragged the card to the freecell and it's open, place card in free cell
        else if (freecell != null && freecell.isFree)
        {
            transform.position = freecell.transform.position;
            inFoundation = false;
            inFreeCell = true;
            inColumn = false;
            freecell.isFree = false;
            if (freecell_origin != null)
            {
                freecell_origin.isFree = true;
            }
            if (column_origin != null) {
                column_origin.cardCount--;

            }
        }

        //If placed card on the Foundation_spades spot, add to pile if proper suit and order of cards
        else if (fs != null && suit == 2)
        {
            if (fs.addCard(this))
            {

                if (freecell_origin != null)
                {
                    freecell_origin.isFree = true;
                }
                if (column_origin != null)
                {
                    column_origin.cardCount--;
                }
            }
            else { transform.position = oldCellPosition; }

        }

        //If placed card on the Foundation_Hearts spot, add to pile if proper suit and order of cards
        else if (fh != null && suit == 0)
        {
            if (fh.addCard(this))
            {
                if (freecell_origin != null)
                {
                    freecell_origin.isFree = true;
                }
                if (column_origin != null)
                {
                    column_origin.cardCount--;
                }
            }
            else { transform.position = oldCellPosition; }
        }

        //If placed card on the Foundation_Diamonds spot, add to pile if proper suit and order of cards
        else if (fd != null && suit == 1)
        {
            if (fd.addCard(this))
            {
                if (freecell_origin != null)
                {
                    freecell_origin.isFree = true;
                }
                if (column_origin != null)
                {
                    column_origin.cardCount--;
                }
            }
            else { transform.position = oldCellPosition; }
        }

        //If placed card on the Foundation_Clubs spot, add to pile if proper suit and order of cards
        else if (fc != null && suit == 3)
        {
            if (fc.addCard(this))
            {
                if (freecell_origin != null)
                {
                    freecell_origin.isFree = true;
                }
                else if (column_origin != null)
                {
                    column_origin.cardCount--;
                }
            }
            else { transform.position = oldCellPosition; }
        }


        //If placing a bottom card on another column card that is opposite color and the value above current card
        else if (otherCard_origin == null && otherCard != null && value == (otherCard.value - 1) && isCardColorRed != otherCard.isCardColorRed)
        {

            if (column != null)
            {
                column.cardCount++;
                transform.position = new Vector3(column.transform.position.x, otherCard.transform.position.y - column.columnYOffsetForCards, -column.cardCount);
                backgroundSR.sortingOrder = (column.cardCount - 1);
                suitSR.sortingOrder = column.cardCount;
                bigSuitSR.sortingOrder = column.cardCount;
                valueSR.sortingOrder = column.cardCount;
                if (freecell_origin != null) {
                    freecell_origin.isFree = true;

                }
            }
            else { transform.position = oldCellPosition; }
        }

        //Otherwise illegal move and return to original position
        else
        {
            transform.position = oldCellPosition;
            backgroundSR.sortingOrder = sortingOrder[0];
            suitSR.sortingOrder= sortingOrder[1];
            bigSuitSR.sortingOrder= sortingOrder[2];
            valueSR.sortingOrder= sortingOrder[3];
        }
        boxCollider.enabled = true;
    }


    //calculate position before the card has been moved
    void OnMouseDown()
    {
        oldCellPosition = transform.position;
        oldCardPosition = transform.position - Camera.main.ScreenPointToRay(Input.mousePosition).origin;

        isUp = true;
        ApplyFeatures();

        sortingOrder[0] = backgroundSR.sortingOrder;
        sortingOrder[1] = suitSR.sortingOrder;
        sortingOrder[2] = bigSuitSR.sortingOrder;
        sortingOrder[3] = valueSR.sortingOrder;





        backgroundSR.sortingOrder = 20;
        suitSR.sortingOrder = 21;
        bigSuitSR.sortingOrder = 21;
        valueSR.sortingOrder = 21;


    }


}
