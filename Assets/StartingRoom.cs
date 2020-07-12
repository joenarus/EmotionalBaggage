using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoom : MonoBehaviour
{
    public Sprite insaneRoom;
    public Sprite officeRoom;

    public SpriteRenderer currentSprite;
    public void ChangeRoom() {
        currentSprite.sprite = insaneRoom;
    }
}
