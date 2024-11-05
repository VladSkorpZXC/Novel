using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    [SerializeField] private Game _game;

    [SerializeField] private Sprite _backSprite;
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _findSprite;

    [SerializeField] private int _number;

    public bool Down => this.GetComponent<Image>().sprite == _frontSprite;
    public bool Find => this.GetComponent<Image>().sprite == _findSprite;
    public int Number {  get { return _number; } }

    public void OnMouseDown()
    {
        if (!Find)
        {
            if (!_game.FindCard)
            {
                if (!Down)
                {
                    this.GetComponent<Image>().sprite = _frontSprite;
                    _game.OpenCard();
                }
            }
        }
    }

    public void FindCards()
    {
        this.GetComponent<Image>().sprite = _findSprite;
    }

    public void NoFindCards()
    {
        this.GetComponent<Image>().sprite = _backSprite;
    }

}
