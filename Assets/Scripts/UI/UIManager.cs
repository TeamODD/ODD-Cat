using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static Icons.Icon;

public class UIManager : MonoBehaviour
{

    [SerializeField] public GameObject background;
    [SerializeField] public GameObject play;
    [SerializeField] public GameObject pause;
    [SerializeField] public GameObject rewind;
    [SerializeField] public GameObject fastRewind;

    private GameObject icon;
    private IconType iconType;

    public void show(IconType i)
    {
        Color c = background.GetComponent<Image>().color;
        c.a = 0.3f;
        background.GetComponent<Image>().color = c;

        if(icon != null)
        {
            icon.SetActive(false);
        }

        iconType = i;
        switch (i)
        {
            case IconType.play:
                icon = play;
                break;
            case IconType.pause:
                icon = pause;
                break;
            case IconType.rewind:
                icon = rewind;
                break;
            case IconType.fastRewind:
                icon = fastRewind;
                break;
            default:
                icon = null;
                return;
        }

        StartCoroutine(flicker(icon, i));
    }

    private IEnumerator flicker(GameObject icon, IconType i)
    {
        while(iconType == i)
        {
            icon.SetActive(true);
            yield return new WaitForSeconds(1f);
            icon.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
        icon.SetActive(false);
        yield break;
    }

    public void hide()
    {
        Color c = background.GetComponent<Image>().color;
        c.a = 0f;
        background.GetComponent<Image>().color = c;
        icon.SetActive(false);
        icon = null;
        iconType = IconType.none;
    }
}
