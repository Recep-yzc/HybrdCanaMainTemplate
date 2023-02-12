using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PageButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform Parent;
    [SerializeField] private Button button;

    [Header("Properties")]
    public PageType PageType;

    #region private
    private PageButtonController pageButtonController;
    #endregion

    private void Awake()
    {
        FetchReferences();
    }

    private void FetchReferences()
    {
        pageButtonController = PageButtonController.Instance;
        button.onClick.AddListener(ClickButton);
    }

    public void ClickButton()
    {
        pageButtonController.SelectedPage(PageType);
    }

    public void Selected(bool isFast = false)
    {
        var newDuration = isFast ? 0 : pageButtonController.Duration;

        Parent.DOSizeDelta(new Vector2(pageButtonController.SelectedX, pageButtonController.SelectedY), newDuration).SetEase(pageButtonController.Ease);
        //child.DOScale(Vector3.one * 1.5f, newDuration).SetEase(ease);
        //child.DOAnchorPosY(60, newDuration).SetEase(ease);

        switch (PageType)
        {
            case PageType.Main:
                Parent.DOAnchorPosX(0, newDuration);
                break;
            case PageType.Market:
                Parent.DOAnchorPosX(0, newDuration);
                break;
            case PageType.Training:
                Parent.DOAnchorPosX(pageButtonController.UnselectedX, newDuration);
                break;
            case PageType.Item:
                Parent.DOAnchorPosX(0, newDuration);
                break;
            case PageType.League:
                Parent.DOAnchorPosX(-pageButtonController.UnselectedX, newDuration);
                break;
        }
    }

    public void UnSelected(PageType _pageType, bool isFast = false)
    {
        var newDuration = isFast ? 0 : pageButtonController.Duration;

        Parent.DOSizeDelta(new Vector2(pageButtonController.UnselectedX, pageButtonController.UnselectedY), newDuration).SetEase(pageButtonController.Ease);
        //child.DOScale(Vector3.one, newDuration).SetEase(ease);
        //child.DOAnchorPosY(50, newDuration).SetEase(ease);

        switch (PageType)
        {
            case PageType.Main:

                switch (_pageType)
                {
                    case PageType.Main:


                        break;
                    case PageType.Market:
                        Parent.DOAnchorPosX(50, newDuration);

                        break;
                    case PageType.Training:

                        Parent.DOAnchorPosX(50, newDuration);

                        break;
                    case PageType.Item:
                        Parent.DOAnchorPosX(-50, newDuration);

                        break;
                    case PageType.League:
                        Parent.DOAnchorPosX(-50, newDuration);

                        break;
                }

                break;
            case PageType.Market:

                switch (_pageType)
                {
                    case PageType.Main:

                        Parent.DOAnchorPosX(0, newDuration);
                        break;
                    case PageType.Market:


                        break;
                    case PageType.Training:

                        Parent.DOAnchorPosX(0, newDuration);

                        break;
                    case PageType.Item:

                        Parent.DOAnchorPosX(0, newDuration);
                        break;
                    case PageType.League:

                        Parent.DOAnchorPosX(0, newDuration);
                        break;
                }

                break;
            case PageType.Training:

                switch (_pageType)
                {
                    case PageType.Main:

                        Parent.DOAnchorPosX(pageButtonController.UnselectedX, newDuration);
                        break;
                    case PageType.Market:

                        Parent.DOAnchorPosX(pageButtonController.SelectedX, newDuration);
                        break;
                    case PageType.Training:


                        break;
                    case PageType.Item:

                        Parent.DOAnchorPosX(pageButtonController.UnselectedX, newDuration);
                        break;
                    case PageType.League:

                        Parent.DOAnchorPosX(pageButtonController.UnselectedX, newDuration);
                        break;
                }

                break;
            case PageType.Item:

                switch (_pageType)
                {
                    case PageType.Main:
                        Parent.DOAnchorPosX(0, newDuration);
                        break;
                    case PageType.Market:
                        Parent.DOAnchorPosX(0, newDuration);
                        break;
                    case PageType.Training:
                        Parent.DOAnchorPosX(0, newDuration);
                        break;
                    case PageType.Item:
                        break;
                    case PageType.League:

                        Parent.DOAnchorPosX(0, newDuration);
                        break;
                }

                break;
            case PageType.League:

                switch (_pageType)
                {
                    case PageType.Main:

                        Parent.DOAnchorPosX(-pageButtonController.UnselectedX, newDuration);
                        break;
                    case PageType.Market:

                        Parent.DOAnchorPosX(-pageButtonController.UnselectedX, newDuration);
                        break;
                    case PageType.Training:

                        Parent.DOAnchorPosX(-pageButtonController.UnselectedX, newDuration);
                        break;
                    case PageType.Item:

                        Parent.DOAnchorPosX(-pageButtonController.SelectedX, newDuration);
                        break;
                    case PageType.League:
                        break;
                }

                break;
        }
    }
}
