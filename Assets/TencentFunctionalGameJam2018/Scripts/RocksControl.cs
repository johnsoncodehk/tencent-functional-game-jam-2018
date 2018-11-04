using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksControl : MonoBehaviour
{
    public static RocksControl instance;

    public List<GameObject> rocks;
    public List<GameObject> destroyEffects;
    public Animator godAnimator1, godAnimator2;
    public Animator[] thunderAnimators;

    void Awake()
    {
        instance = this;
    }
    public void DestroyRock()
    {
        if (rocks.Count == 0)
            return;

        GameObject rock = rocks[rocks.Count - 1];
        rocks.RemoveAt(rocks.Count - 1);
        rock.SetActive(false);

        GameObject effect = destroyEffects[destroyEffects.Count - 1];
        destroyEffects.RemoveAt(destroyEffects.Count - 1);
        effect.SetActive(true);

        int i = 0;
        foreach (var thunderAnimator in thunderAnimators)
        {
            thunderAnimator.gameObject.SetActive(true);
            thunderAnimator.Play("Flash", 0, 0);
            if (i == 0)
                thunderAnimator.transform.position = effect.transform.position;
            i++;
        }

        if (rocks.Count == 3)
        {
            godAnimator1.Play("Flash", 0, 0);
        }
        else if (rocks.Count == 2)
        {
            godAnimator2.Play("Flash", 0, 0);
        }
        else if (rocks.Count == 1)
        {
            godAnimator1.Play("Flash", 0, 0);
            godAnimator2.Play("Flash", 0, 0);
        }
        else if (rocks.Count == 0)
        {
            godAnimator1.Play("Flash_Final", 0, 0);
            godAnimator2.Play("Flash_Final", 0, 0);
        }
    }
}
