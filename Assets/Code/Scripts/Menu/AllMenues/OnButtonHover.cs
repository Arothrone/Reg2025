using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject textGOToShow;
    private Coroutine coroutine;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        coroutine = StartCoroutine(Show());
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
            textGOToShow.SetActive(false);
        }
    }

    private IEnumerator Show()
    {
        yield return  new WaitForSeconds(2.0f);
        textGOToShow.SetActive(true);
    }
}
