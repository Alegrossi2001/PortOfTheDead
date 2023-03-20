using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private bool isMoving = true;
    [SerializeField] private GameObject player;
    private Animator anim;
    private float enemyHealth = 100f;
    private PlayerStats damagePlayer;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        damagePlayer = GameObject.Find("HealthPanel").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 relativePos = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damagePlayer.playerHealth -= 20;
            isMoving= false;
            Destroy(gameObject);
        }
    }

    public void KillEnemy()
    {

        enemyHealth -= 34f;
        if (enemyHealth < 0)
        {
            StartCoroutine(EnemyDead());
        }
    }

    IEnumerator EnemyDead()
    {
        isMoving = false;
        anim.SetBool("HasDied", true);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
