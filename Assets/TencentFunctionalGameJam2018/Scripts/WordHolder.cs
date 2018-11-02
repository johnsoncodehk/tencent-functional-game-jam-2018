using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordHolder : MonoBehaviour
{

    public Animator animator;
    public Word current;
    public Transform startParent;

    Word m_WordToChange;

    /* Unity Events */
    void Awake()
    {
        startParent = transform.parent;
        transform.SetParent(null);
    }
    void Update()
    {
        if (current)
        {
            transform.position = startParent.position;
            current.transform.position = transform.position;
        }
    }

    /* Animation Events */
    void OnChange()
    {
        if (current)
        {
            Destroy(current.gameObject);
            current = null;
        }

        current = Instantiate(m_WordToChange);
        current.name = m_WordToChange.name;
        current.transform.SetParent(transform, false);
        m_WordToChange = null;
    }

    /* Public */
    public void ChangeWord(string word)
    {
        if (m_WordToChange)
            return;

        ChangeWord(Resources.Load<Word>("Words/" + word));
    }
    public void ChangeWord(Word word)
    {
        if (m_WordToChange)
            return;

        m_WordToChange = word;

        if (!current)
            OnChange();
        else
            animator.SetTrigger("Change");
    }
}
