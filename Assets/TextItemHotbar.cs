using System.Collections;
using TMPro;
using UnityEngine;

public class TextItemHotbar : MonoBehaviour
{
    [Header("Text Components")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private HotbarInputUI hotbarInputUI;

    [Header("Values")] 
    [SerializeField] private float delayBeforeFade;
    [SerializeField] private float fadeDuration;
    
    private Coroutine coroutine;
    
    private HotbarInput hotbarInput;
    private HotbarComponent hotbar;
    
    private void Start()
    {
        hotbar = GearSystems.Instance.Hotbar;
        hotbarInput = InputSystems.Instance.GetHotbarInput;
        
        hotbarInput.OnKeyPressed += UpdateText;
        hotbarInputUI.OnMouseScrolled += UpdateText;
    }

    private void UpdateText(int slotIndex)
    {
        Item item = hotbar.GetItem(slotIndex);

        if (item.data == null)
            return;
        
        ShowItemName(item);
        
        if (coroutine != null)
            StopCoroutine(coroutine);
        
        coroutine = StartCoroutine(DoFade());
    }

    private void ShowItemName(Item item)
    {
        tmp.text = item.data.name;
        canvasGroup.alpha = 1f;
    }

    private IEnumerator DoFade()
    {
        yield return new WaitForSeconds(delayBeforeFade);
        
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);

            yield return null;
        }
    }
}
