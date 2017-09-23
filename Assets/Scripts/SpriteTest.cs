using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTest : MonoBehaviour
{
    public enum SpriteStates { UNTRACKED, TRACKED }
    public SpriteStates currentState;

    void Start()
    {
        currentState = SpriteStates.UNTRACKED;
    }

    public void FoundSprite()
    {
        currentState = SpriteStates.TRACKED;
        //Debug.Break();
    }

    public void LostSprite()
    {
        currentState = SpriteStates.UNTRACKED;

    }
}
