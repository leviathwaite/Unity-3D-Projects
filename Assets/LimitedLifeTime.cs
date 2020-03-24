using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLifeTime : MonoBehaviour
{
    public enum AfterTimeUp
    {
        DESTROY, DISABLE
    }

    [SerializeField]
    private AfterTimeUp afterTimeUp = AfterTimeUp.DESTROY;
    [SerializeField]
    private float lifeTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(afterTimeUp == AfterTimeUp.DESTROY)
        {
            Destroy(gameObject, lifeTime);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        TickTimer();
    }

    private void TickTimer()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            // Time is up
            if(afterTimeUp == AfterTimeUp.DISABLE)
            {
                lifeTime = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
