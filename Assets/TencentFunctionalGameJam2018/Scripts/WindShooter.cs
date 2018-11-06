using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShooter : MonoBehaviour
{
    public static WindShooter instance;
    public GameObject wind;
    public float minDelayTime = 0.3f;
    public float maxDelayTime = 0.7f;

    void Awake()
    {
        instance = this;
    }
    public void StartShoot()
    {
        StartCoroutine(StartShootCoroutine());
    }
    IEnumerator StartShootCoroutine()
    {
        Vector2 boxSize = GetComponent<BoxCollider2D>().size;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelayTime, maxDelayTime));
            Vector2 pos = new Vector2(
                Random.Range(transform.position.x - boxSize.x * 0.5f, transform.position.x + boxSize.x * 0.5f),
                Random.Range(transform.position.y - boxSize.y * 0.5f, transform.position.y + boxSize.y * 0.5f)
            );
            GameObject w = Instantiate(wind, pos, Quaternion.identity);
        }
    }
}
