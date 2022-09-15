using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorChudicks : MonoBehaviour
{
    private float smoothTime = 0.1f;
    private float playerSPeed = 10f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 direction;
    private Rigidbody2D playerBody;


    public Sprite[] sprite;
    public Sprite[] spriteforanim;

    private const string SelectedSkin = "SelectedSkin";

    private bool x = true;

    int pr;
    int Stop;
    public float time;
    public int num;
    public bool arenamanager = true;
    public bool imagemanager = false;
    public bool playermanager = false;
    public float Speedroad;
    public float coeficient;

    void Awake()
    {
      pr = PlayerPrefs.GetInt(SelectedSkin, 0);
      playerBody = GetComponent<Rigidbody2D>();
    if(playermanager == true)
    {
      pr = num;
    }
    GetComponent<SpriteRenderer>().sprite = sprite[pr];
    }

    void Start()
  {
    pr = PlayerPrefs.GetInt(SelectedSkin, 0);
    playerBody = GetComponent<Rigidbody2D>();
    if(playermanager == true)
    {
      pr = num;
    }
    GetComponent<SpriteRenderer>().sprite = sprite[pr];
    Debug.Log(pr);

   ForCoroutine();
  }

  void ForCoroutine()
  {
    if(pr >= 0 && pr <= sprite.Length)
    {
        if(arenamanager == true)
        {
          Debug.Log("ChudicksStartCoroutine");
          StartCoroutine(AnimChudicks());
        }

        if(imagemanager == true)
        {
          Debug.Log("ChudicksStartCoroutine");
          StartCoroutine(AnimChudicksImage());
        }
    }
  }

    void Update()
    {
        Stop = PlayerPrefs.GetInt("StopRoad");
        Speedroad = PlayerPrefs.GetFloat("RoadUpdateSpeed");
    }

    IEnumerator AnimChudicks()
    {
        while (true)
        {
            if(Stop == 1)
            {
            if(x == true)
        {
            Debug.Log("Chudicksspriteforanim");
            GetComponent<SpriteRenderer>().sprite = spriteforanim[pr];
            x = false;
        }
        else
        {
            Debug.Log("Chudickssprite");
            GetComponent<SpriteRenderer>().sprite = sprite[pr];
            x = true;
        }
            }

            time = time - (float)(Speedroad * coeficient);
            if(time < 0)
            {
                time = 0;
            }
          yield return new WaitForSeconds(time);
        }
    }

    IEnumerator AnimChudicksImage()
    {
        while (true)
        {
            if(Stop == 1)
            {
            if(x == true)
        {
            Debug.Log("Chudicksspriteforanim");
            GetComponent<Image>().sprite = spriteforanim[pr];
            x = false;
        }
        else
        {
            Debug.Log("pr = " + pr);
            Debug.Log("Chudickssprite");
            GetComponent<Image>().sprite = sprite[pr];
            x = true;
        }
            }
          yield return new WaitForSeconds(time);
        }
    }
}
