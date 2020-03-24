using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private string[] tags =
    {
        "PlayerBullet", "EnemyBullet"
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tags.Length > 0)
        {
            for (int i = 0; i < tags.Length; i++)
            {
                if (other.CompareTag(tags[i]))
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
