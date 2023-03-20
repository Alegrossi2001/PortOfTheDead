using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{
    private AudioSource audioPlayer;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip pistolShot;
    [SerializeField] private AudioClip pistolEmpty;
    [SerializeField] private AudioClip pistolReload;
    private int bullets = 10;
    [SerializeField] private Image pistolImage;
    [SerializeField] private bool canShoot = true;


    // Start is called before the first frame update
    void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(bullets > 0 && canShoot == true)
            {
                audioPlayer.clip = pistolShot;
                audioPlayer.PlayDelayed(0.1f);
                bullets--;
                pistolImage.fillAmount -= 0.1f;
                ShootRayCast();
            }
            else if(bullets <= 0)
            {
                audioPlayer.clip = pistolEmpty;
                audioPlayer.PlayDelayed(0.1f);
            }
            
        }
            
    }

    private void ShootRayCast()
    {

        RaycastHit hit;
        Physics.Raycast(transform.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 1000f);
        if(hit.collider.gameObject.tag == "Enemy")
        {
            MoveTowardsPlayer enemyHit = hit.transform.gameObject.GetComponent<MoveTowardsPlayer>();
            enemyHit.KillEnemy();
            //EnemyStats.enemyHealth -= 20f;
        }
        else
        {
            UnityEngine.Debug.Log("You didn't hit an enemy :(");
        }
    }
    public void ReloadButton()
    {
        StartCoroutine(Reload());

    }
    private IEnumerator Reload()
    {
        audioPlayer.clip = pistolReload;
        audioPlayer.Play();
        bullets = 10;
        canShoot = false;
        yield return new WaitForSeconds(2f);
        canShoot = true;
        pistolImage.fillAmount = 1.0f;
    }

}
