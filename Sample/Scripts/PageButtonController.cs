using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButtonController : Singleton<PageButtonController>
{
    [Header("Properties")]
    public PageType StartPageType;
    public float SelectedY = 260;
    public float UnselectedY = 260;

    public float Duration = 0.3f;
    public Ease Ease = Ease.Linear;

    [Header("References")]
    [SerializeField] private RectTransform panelRectTransform;
    [SerializeField] private List<PageButton> pageButtons = new();

    #region Private
    private PageController pageController;

    public float SelectedX { get; private set; }
    public float UnselectedX { get; private set; }

    private PageType selectedPageType;
    public PageType SelectedPageType
    {
        get => selectedPageType;
        set
        {
            selectedPageType = value;

            foreach (var pageButton in pageButtons)
            {
                if (pageButton.PageType == value)
                {
                    pageButton.Selected();
                }
                else
                {
                    pageButton.UnSelected(value);
                }
            }
        }
    }

    #endregion

    private void Awake()
    {
        FetchReferences();
    }

    private void Start()
    {
        InitPageSize();
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0f);
            SelectedPage(StartPageType);
        }
    }

    private void FetchReferences()
    {
        pageController = PageController.Instance;
    }

    public void SelectedPage(PageType _pageType)
    {
        SelectedPageType = _pageType;
        pageController.SelectedPageType = _pageType;
    }

    private void InitPageSize()
    {
        var width = panelRectTransform.rect.width;
        var buttonCount = pageButtons.Count;
        var perWidth = width / buttonCount;

        var pieceWidth = 20f;

        UnselectedX = perWidth - pieceWidth;
        SelectedX = perWidth + (pieceWidth * (buttonCount - 1));
    }
}
