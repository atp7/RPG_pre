using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHealthPoints = 100f;
    float currentHealthPoints = 105.31f;
    public float healthAsPercentage = 99;
    AICharacterControl ai = null;
    public float attackRadius = 5f;

    // Start is called before the first frame update
    GameObject player = null;
    void Start()
    {
        //healtAsPercentage = 99;
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GetComponent<AICharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //whether should attack , chase ,follow , or not ;[
        float distanceToPlayer = Vector3.Distance(player.transform.position,
            transform.position);
        if(distanceToPlayer < attackRadius)
        {
            ai.SetTarget(player.transform);
        }
        else
        {
            ai.SetTarget(transform);
        }
    }

    public float healtAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
    }
}
