using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class Game : MonoBehaviour
{
    [SerializeField] private Transform _cards;
    [SerializeField] private List<Card> _listCards;

    [SerializeField] private int _numberCrad;
    [SerializeField] private bool _findCard;

    [SerializeField] private GameObject _winPanel;
    public bool FindCard => _findCard;

    public void Awake()
    {
        for (int i = 0; i < _cards.childCount; i++)
        {
            _cards.GetChild(i).transform.SetSiblingIndex(Random.Range(0, _cards.childCount));
        }
    }

    public void Start()
    {
        for (int i = 0; i < _cards.childCount; i++)
        {
            _listCards.Add(_cards.GetChild(i).GetComponent<Card>());
        }
    }

    public void OpenCard()
    {
        int openCard = 0;

        foreach (Card card in _listCards)
        {
            if (card.Down)
            {
                if (openCard == 0)
                {
                    _numberCrad = card.Number;
                }
                openCard++;
            }
        }

        if (openCard == 2)
        {
            CheackCard();
        }
    }

    public void CheackCard()
    {
        int a = 0;

        foreach(Card card in _listCards)
        {
            if(card.Down)
            {
                if(card.Down && card.Number == _numberCrad)
                {
                    a++;
                }
            }
        }

        if(a == 2)
        {
            FindCards();
        }
        else
        {
            NoFindCards();
        }
    }

    public void FindCards()
    {
        foreach (Card card in _listCards)
        {
            if (card.Down)
            {
                StartCoroutine(Find(card));
            }
        }
    }

    public void NoFindCards()
    {
        foreach (Card card in _listCards)
        {
            if (card.Down)
            {
                StartCoroutine(NoFind(card));
            }
        }
    }

    IEnumerator NoFind(Card card)
    {
        _findCard = true;
        yield return new WaitForSeconds(1f);
        card.GetComponent<Card>().NoFindCards();
        _findCard = false;
    }

    IEnumerator Find(Card card)
    {
        _findCard = true;
        yield return new WaitForSeconds(1f);
        card.GetComponent<Card>().FindCards();
        ChaeckWin();
        _findCard = false;
    }

    public void ChaeckWin()
    {
        int a = 0;

        foreach(Card card in _listCards)
        {
            if(card.Find)
            {
                a++;
            }
        }

        if(a == _listCards.Count - 1)
        {
            _winPanel.SetActive(true);
        }
    }
}
