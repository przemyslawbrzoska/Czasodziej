using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runes : CreateRunes {

    //public Canvas runes;

    public Image earthImage;
    public Text earthQuantity;
    public Sprite earthSprite;

    public Image waterImage;
    public Text waterQuantity;
    public Sprite waterSprite;

    public Image airImage;
    public Text airQuantity;
    public Sprite airSprite;

    public Image fireImage;
    public Text fireQuantity;
    public Sprite fireSprite;


    void Start()
    {
      //  runes = runes.GetComponent<Canvas>();
    }

   void Update()
    {
        // runes.enabled = true;
        airQuantity.text = howManyA.ToString();
        fireQuantity.text = howManyF.ToString();
        earthQuantity.text = howManyE.ToString();
        waterQuantity.text = howManyW.ToString();

        if (airDelay > 0 || howManyA == 0)
        {
            airImage.overrideSprite = airSprite;
        }

        if (waterDelay > 0 || howManyW == 0)
        {
            waterImage.overrideSprite = waterSprite;
         
        }

        if (earthDelay > 0 || howManyE == 0)
        {
            earthImage.overrideSprite = earthSprite;
        }


        if (howManyF == 0)
        {
            fireImage.overrideSprite = fireSprite;
        }
    }
}
