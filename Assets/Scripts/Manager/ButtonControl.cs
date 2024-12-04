using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultSprite;
    public Sprite pressedImage;
    public KeyCode ketToPress;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ketToPress))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(ketToPress))
        {
            theSR.sprite = defaultSprite;
        }
    }
}
