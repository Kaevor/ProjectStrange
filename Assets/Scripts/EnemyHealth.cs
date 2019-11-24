using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float healthStart = 2;
    public float Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = healthStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
