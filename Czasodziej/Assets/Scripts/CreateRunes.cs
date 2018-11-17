using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRunes : MonoBehaviour
{

    [Header("Type of rune")]
    public bool isEarth = false;
    public bool isWater = false;
    public bool isFire = false;
    public bool isAir = false;

    [Header("Rune's objects")]
    public GameObject earth;
    public GameObject water;
    public GameObject fire;
    public GameObject air;

    //[Header("Sprite of rune")]
    public Image earthImage;
    public Text earthQuantity;
    public Text earthDelayText;
    public Sprite earthSprite;
    public Sprite noEarthSprite;

    public Image waterImage;
    public Text waterQuantity;
    public Text waterDelayText;
    public Sprite waterSprite;
    public Sprite noWaterSprite;

    public Image airImage;
    public Text airQuantity;
    public Text airDelayText;
    public Sprite airSprite;
    public Sprite noAirSprite;

    public Image fireImage;
    public Text fireQuantity;
    // public Sprite fireSprite;
    public Sprite noFireSprite;
    // private Vector2 changeMonsterPosition;
    private GameObject player;
    protected int howManyE = 10, howManyF = 1, howManyW = 5, howManyA = 3;
    protected float airDelay = 0, waterDelay = 0, earthDelay = 0;
  //  private int aDelay, wDelay, eDelay;
    MonsterMovement refMonster;



    void Start()
    {
        refMonster = GameObject.FindWithTag("Monster").GetComponent<MonsterMovement>();
        var script = (MonsterMovement)refMonster.GetComponent(typeof(MonsterMovement));
    }

    void Update()
    {
        airDelay -= Time.deltaTime;
        waterDelay -= Time.deltaTime;
        earthDelay -= Time.deltaTime;

        DelayOrNot();
       // aDelay = (int)airDelay;

        airQuantity.text = howManyA.ToString();
        fireQuantity.text = howManyF.ToString();
        earthQuantity.text = howManyE.ToString();
        waterQuantity.text = howManyW.ToString();

      //  airDelayText.text = aDelay.ToString("f0");
       // waterDelayText.text = waterDelay.ToString("f0");
       // earthDelayText.text = earthDelay.ToString("f0");

        Click();


    }

    void DelayOrNot()
    {
        if (airDelay > 0 || howManyA == 0)
        {
            airImage.overrideSprite = noAirSprite;
        }

        if (airDelay <= 0)
        {
            airDelay = 0;
        }

        if (airDelay == 0 && howManyA > 0)
        {
            airImage.overrideSprite = airSprite;
        }


        if (waterDelay > 0 || howManyW == 0)
        {
            waterImage.overrideSprite = noWaterSprite;

        }

        if (waterDelay <= 0)
        {
            waterDelay = 0;
        }

        if (waterDelay == 0 && howManyW > 0)
        {
            waterImage.overrideSprite = waterSprite;

        }

        if (earthDelay > 0 || howManyE == 0)
        {
            earthImage.overrideSprite = noEarthSprite;
        }

        if (earthDelay <= 0)
        {
            earthDelay = 0;
        }

        if (earthDelay == 0 && howManyE > 0)
        {
            earthImage.overrideSprite = earthSprite;
        }

        if (howManyF == 0)
        {
            fireImage.overrideSprite = noFireSprite;
        }
    }
    void Click()
    {
        if (Input.GetKeyDown(KeyCode.G) && earthDelay <= 0 && howManyE > 0)
        {
            RuneOfTheEarth();
            earthDelay = 5;
        }

        if (Input.GetKeyDown(KeyCode.H) && waterDelay <= 0 && howManyW > 0)
        {
            RuneOfTheWater();
            waterDelay = 10;
        }

        if (Input.GetKeyDown(KeyCode.J) && howManyF > 0)
        {
            RuneOfTheFire();
        }

        if (Input.GetKeyDown(KeyCode.K) && airDelay <= 0 && howManyA > 0)
        {
            RuneOfTheAir();
            airDelay = 8;
        }

    }

    void RuneOfTheEarth()
    {
        //isEarth = true;
        howManyE -= 1;
        var runeOfTheEarth = Instantiate(earth);
        runeOfTheEarth.transform.position = transform.position;

        // runeOfTheEarth.transform.rotation = transform.rotation;
        // var earthRb = runeOfTheEarth.GetComponent<Rigidbody2D>();
        // earthRb.velocity = transform.right;
    }

    void RuneOfTheWater()
    {
        // isWater = true;
        howManyW -= 1;
        var runeOFTheWater = Instantiate(water);
        runeOFTheWater.transform.position = transform.position;
    }

    void RuneOfTheFire()
    {
        //isFire = true;
        howManyF -= 1;
        var runeOFTheFire = Instantiate(fire);
        runeOFTheFire.transform.position = transform.position;
    }

    void RuneOfTheAir()
    {
        //isAir = true;
        player = GameObject.FindWithTag("Player");
        howManyA -= 1;
        var runeOFTheAir = Instantiate(air);
        runeOFTheAir.transform.position = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Monster")
        {
            if (isFire == true)
            {
                Destroy(collision.gameObject);
            }

            else if (isAir == true)
            {
                // changeMonsterPosition = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime);
                collision.transform.position = new Vector2(player.transform.position.x - 12, player.transform.position.y - 12);
            }

            else if (isWater == true)
            {
                refMonster.speed -= 3.0f;
            }



        }


    }


}
