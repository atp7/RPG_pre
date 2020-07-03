using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxHealthPoints = 100f;
    float currentHealthPoints = 105.31f;
    public float healthAsPercentage=99;
    // Start is called before the first frame update
    void Start()
    {
        //healtAsPercentage = 99;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float healtAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
    }
}
