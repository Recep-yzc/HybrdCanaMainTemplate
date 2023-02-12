using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PageController : Singleton<PageController>
{
    public static bool IsBottomMenuButtonLock;
    public static Action<PageType> OnPageOpen;
    public static Action<PageType> OnPageClose;

    [Header("References")]
    [SerializeField] private Scrollbar ScrollBar;
    [SerializeField] private RectTransform panelRectTransform;
    [SerializeField] private List<Page> pages = new();

    [Header("Properties")]
    [SerializeField] private float pageSlideDuration = 0.3f;
    [SerializeField] private Ease pageSlideEase = Ease.Unset;

    #region private   
    public Vector2 PageSize { get; private set; }

    private Page lastOpenPage;
    private Tween pageScrollTween;
    private float[] pos;
    private float distance;

    private PageType selectedPageType;
    public PageType SelectedPageType
    {
        get => selectedPageType;
        set
        {
            selectedPageType = value;
            for (var i = 0; i < pages.Count; i++)
            {
                if (pages[i].PageType == selectedPageType)
                {
                    lastOpenPage?.Close();
                    lastOpenPage = pages[i];
                    lastOpenPage?.Open();

                    ChangePageIndex(i);
                    break;
                }
            }
        }
    }
    #endregion

    private void Start()
    {
        PageSetupInit();
    }

    private void PageSetupInit()
    {
        pos = new float[pages.Count];
        distance = 1f / (pos.Length - 1f);
        for (var i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        PageSize = panelRectTransform.rect.size;
    }

    private void ChangePageIndex(int _pageIndex)
    {
        pageScrollTween.Kill();
        pageScrollTween = DOTween.To(() => ScrollBar.value, x => ScrollBar.value = x, pos[_pageIndex], pageSlideDuration)
            .SetEase(pageSlideEase)
            .OnComplete(() => { });
    }

}
