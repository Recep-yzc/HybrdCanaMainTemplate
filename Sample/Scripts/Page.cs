using UnityEngine;

public class Page : MonoBehaviour
{
    [Header("Properties")] public PageType PageType;

    [Header("References")]
    public RectTransform rectTransform;

    #region private
    private PageController pageController;
    #endregion

    private void Awake()
    {
        FetchReferences();
    }

    private void FetchReferences()
    {
        pageController = PageController.Instance;
    }

    private void Start()
    {
        rectTransform.sizeDelta = pageController.PageSize;
    }

    public void Open()
    {
        PageController.OnPageOpen?.Invoke(PageType);
    }

    public void Close()
    {
        PageController.OnPageClose?.Invoke(PageType);
    }
}
