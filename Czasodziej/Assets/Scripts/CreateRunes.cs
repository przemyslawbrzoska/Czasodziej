using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // private Vector2 changeMonsterPosition;
    private GameObject player;
    public int howManyE = 0, howManyF = 0, howManyW = 0, howManyA = 0;
    private float airDelay = 0, waterDelay = 0, earthDelay = 0;
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

        if (Input.GetKey(KeyCode.H) && earthDelay<=0)
        {
            RuneOfTheEarth();
            earthDelay = 5;
        }

        if (Input.GetKey(KeyCode.J) && waterDelay<=0 && howManyW<10)
        {
            RuneOfTheWater();
            waterDelay = 10;
        }

        if (Input.GetKey(KeyCode.K) && howManyF <= 1)
        {
            RuneOfTheFire();
        }

        if (Input.GetKey(KeyCode.L) && airDelay<=0 && howManyA<5)
        {
            RuneOfTheAir();
            airDelay = 8;
        }
    }

    void RuneOfTheEarth()
    {
        //isEarth = true;
        var runeOfTheEarth = Instantiate(earth);
        runeOfTheEarth.transform.position = transform.position;
        // runeOfTheEarth.transform.rotation = transform.rotation;

        // var earthRb = runeOfTheEarth.GetComponent<Rigidbody2D>();
        // earthRb.velocity = transform.right;
    }

    void RuneOfTheWater()
    {
        // isWater = true;
        howManyW += 1;
        var runeOFTheWater = Instantiate(water);
        runeOFTheWater.transform.position = transform.position;


    }

    void RuneOfTheFire()
    {
        //isFire = true;
        howManyF += 1;
        var runeOFTheFire = Instantiate(fire);
        runeOFTheFire.transform.position = transform.position;

    }

    void RuneOfTheAir()
    {
        //isAir = true;
        player = GameObject.FindWithTag("Player");
        howManyA += 1;
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
                refMonster.speed-= 3.0f;
            }



        }


    }


}
