using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject birdWord;
    void Start()
    {
        StartCoroutine(RandomInOut());
    }
    IEnumerator RandomInOut()
    {
        Animator animator = GetComponent<Animator>();
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10));

            birdWord.SetActive(true);
            animator.Play("In");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

            yield return new WaitForSeconds(Random.Range(0.5f, 3));
            animator.Play("Out");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        }
    }
}
