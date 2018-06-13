using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foundation_Clubs : MonoBehaviour {
    public Stack<Card> stack = new Stack<Card>();
    public int count = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool addCard(Card c)
    {
        if (count > 0 && c.value - 1 == stack.Peek().value)
        {
            c.valueSR.sortingOrder = stack.Peek().valueSR.sortingOrder + 1;
            c.backgroundSR.sortingOrder = stack.Peek().backgroundSR.sortingOrder + 1;
            c.suitSR.sortingOrder = stack.Peek().suitSR.sortingOrder + 1;
            c.bigSuitSR.sortingOrder = stack.Peek().bigSuitSR.sortingOrder + 1;
            c.transform.position = transform.position;
            c.inFoundation = true;
            c.inFreeCell = false;
            c.inColumn = false;
            stack.Push(c);
            count++;
            return true;
        }
        else if (c.value == 1)
        {
            c.backgroundSR.sortingOrder++;
            c.suitSR.sortingOrder++;
            c.bigSuitSR.sortingOrder++;
            c.valueSR.sortingOrder++;
            c.transform.position = transform.position;
            c.inFoundation = true;
            c.inFreeCell = false;
            c.inColumn = false;
            stack.Push(c);
            count++;
            return true;
        }
        return false;

    }
}
