using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum Cards { Water, Earth, Fire, Arcane, Air }

    // Drawn cards container
    public int[] cardsDrawn = new int[100];
    public int numberOfCardsDrawn= 0;

    public int P1Health = 100;
    public int P2Health = 100;
    public int WaterDmg = 20;
    public int EarthDmg = 20;
    public int FireDmg = 20;
    public int ArcaneDmg = 20;
    public int AirDmg = 0;

    public bool P1ArcanePlayed = false;
    public bool P1AirPlayed = false;
    public bool P2ArcanePlayed = false;
    public bool P2AirPlayed = false;

    public int P1ActiveCard = -1;
    public int P2ActiveCard = -1;


    public void DrawnCard(string cardName)
    {
        Debug.Log("GAME MANAGER FUNCTION TRIGGERED! ->" + cardName);

        int cardDrawn = -1;
        if(cardName == "Water")
            cardDrawn = 1;
        else if (cardName == "Earth")
            cardDrawn = 2;
        else if (cardName == "Fire")
            cardDrawn = 3;
        else if (cardName == "Arcane")
            cardDrawn = 4;
        else if (cardName == "Air")
            cardDrawn = 5;

        // Determine which player's card is drawn
        if ((numberOfCardsDrawn % 2) == 0)
        {
            P1ActiveCard = cardDrawn;
            if (cardDrawn == 4)
                P1ArcanePlayed = true;
            else if (cardDrawn == 5)
                P1AirPlayed = true;
        }
        else
        {
            P2ActiveCard = cardDrawn;
            if (cardDrawn == 4)
                P2ArcanePlayed = true;
            else if (cardDrawn == 5)
                P2AirPlayed = true;
        }
            
        
        // Add the drawn card to the container
        cardsDrawn[numberOfCardsDrawn++] = cardDrawn;
        
        Debug.Log("P1 active card: " + P1ActiveCard + " .\nP2 active card: " + P2ActiveCard );

        // Proceed to interactions phase
        if (numberOfCardsDrawn > 1 && (numberOfCardsDrawn % 2 == 0))
            CalculateDamage();
            

    }


    void CalculateDamage()
    {
        int P1DamageTaken = 0, P2DamageTaken = 0;

        if (P1ActiveCard < 3 && P2ActiveCard < 3)
        {
            if (P1ActiveCard == (int)Cards.Water && P2ActiveCard == (int)Cards.Fire)
                P2DamageTaken = WaterDmg;
                //BattleInteractions(P1DamageTaken, P2DamageTaken, P1ActiveCard, P2InteractionType)
            else if (P1ActiveCard == (int)Cards.Water && P2ActiveCard == (int)Cards.Earth)
                P1DamageTaken = EarthDmg;
            else if (P1ActiveCard == (int)Cards.Water && P2ActiveCard == (int)Cards.Water)
                P1DamageTaken = 0; // Same suit cancellation!!!!!!!

            else if (P1ActiveCard == (int)Cards.Earth && P2ActiveCard == (int)Cards.Water)
                P2DamageTaken = EarthDmg;
            else if (P1ActiveCard == (int)Cards.Earth && P2ActiveCard == (int)Cards.Fire)
                P1DamageTaken = FireDmg;
            else if (P1ActiveCard == (int)Cards.Earth && P2ActiveCard == (int)Cards.Earth)
                P2DamageTaken = 0; // Same suit cancellation!!!!!!!

            else if (P1ActiveCard == (int)Cards.Fire && P2ActiveCard == (int)Cards.Water)
                P1DamageTaken = WaterDmg;
            else if (P1ActiveCard == (int)Cards.Fire && P2ActiveCard == (int)Cards.Earth)
                P2DamageTaken = FireDmg;
            else if (P1ActiveCard == (int)Cards.Fire && P2ActiveCard == (int)Cards.Fire)
                P1DamageTaken = 0; // Same suit cancellation!!!!!!!
        }

        else if (P1ArcanePlayed)
        {
            if (P2ActiveCard < 3)
                P2DamageTaken = ArcaneDmg;
        }
        else if (P2ArcanePlayed)
        {
            if (P1ActiveCard < 3)
                P1DamageTaken = ArcaneDmg;
        }


        // Damages are calculated in P1 and P2DamageTaken
        // BattleInteractions(P1DamageTaken, P2DamageTaken, P1InteractionType, P2InteractionType)
       

    }



    // Use this for initialization
    void Start () {
        for (int i = 0; i < 100; i++)
            cardsDrawn[i] = -1;
	}
	
	// Update is called once per frame
	void Update () {
        /* List all items in the container
        if (Input.anyKeyDown)
            foreach (int item in cardsDrawn)
                Debug.Log(item);
		*/
	}
}
