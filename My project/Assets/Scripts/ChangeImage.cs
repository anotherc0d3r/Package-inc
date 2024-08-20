using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
public Image image;
public List<Sprite> spriteChoices;

private int counter;
private int currentSprite = 0;

public void NextSprite() {
    counter++;
    print(counter);
    if (counter == 1) {
        currentSprite++;
        counter = 0;
        if (currentSprite >= spriteChoices.Count) {
            currentSprite = 0;
        }
        image.sprite = spriteChoices[currentSprite];
        }
    }
}
