using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HoverPreview : MonoBehaviour
{
    // PUBLIC FIELDS
    public GameObject TurnThisOffWhenPreviewing;  //  
    public Vector3 TargetPosition;
    public float TargetScale;
    public GameObject previewGameObject;
    public bool ActivateInAwake = false;
    // public PlayerArea p;

    // PRIVATE FIELDS
    private static HoverPreview currentlyViewing = null;

    // PROPERTIES WITH UNDERLYING PRIVATE FIELDS
    private static bool _PreviewsAllowed = true;
    public static bool PreviewsAllowed
    {
        get { return _PreviewsAllowed; }

        set
        {
            //Debug.Log("Hover Previews Allowed is now: " + value);
            _PreviewsAllowed = value;
            if (!_PreviewsAllowed)
                StopAllPreviews();
        }
    }

    private bool _thisPreviewEnabled = false;
    public bool ThisPreviewEnabled
    {
        get { return _thisPreviewEnabled; }

        set
        {
            _thisPreviewEnabled = value;
            if (!_thisPreviewEnabled)
                StopThisPreview();
        }
    }

    public bool OverCollider { get; set; }

    // MONOBEHVIOUR METHODS
    void Awake()
    {
        ThisPreviewEnabled = ActivateInAwake;
    }

    void OnMouseEnter()
    {
        OverCollider = true;
        if (PreviewsAllowed && ThisPreviewEnabled)
            PreviewThisObject();
    }

    void OnMouseExit()
    {
        OverCollider = false;

        if (!PreviewingSomeCard())
            StopAllPreviews();
    }

    // OTHER METHODS
    void PreviewThisObject()
    {
        // 1) duplikat objek kartu
        // menonaktifkan semua preview kartu
        StopAllPreviews();
        // 2) menyimpan data kartu
        currentlyViewing = this;
        // 3) mengaktifkan card preview
        previewGameObject.SetActive(true);
        // 4) menonkatifkan preview kartu
        if (TurnThisOffWhenPreviewing != null)
            TurnThisOffWhenPreviewing.SetActive(false);
        // 5) tween to target position
        previewGameObject.transform.localPosition = Vector3.zero;
        previewGameObject.transform.localScale = Vector3.one;

        previewGameObject.transform.DOLocalMove(TargetPosition, 1f).SetEase(Ease.OutQuint);
        previewGameObject.transform.DOScale(TargetScale, 1f).SetEase(Ease.OutQuint);
    }

    void StopThisPreview()
    {
        previewGameObject.SetActive(false);
        previewGameObject.transform.localScale = Vector3.one;
        previewGameObject.transform.localPosition = Vector3.zero;
        if (TurnThisOffWhenPreviewing != null)
            TurnThisOffWhenPreviewing.SetActive(true);
    }

    // STATIC METHODS
    private static void StopAllPreviews()
    {
        if (currentlyViewing != null)
        {
            currentlyViewing.previewGameObject.SetActive(false);
            currentlyViewing.previewGameObject.transform.localScale = Vector3.one;
            currentlyViewing.previewGameObject.transform.localPosition = Vector3.zero;
            if (currentlyViewing.TurnThisOffWhenPreviewing != null)
                currentlyViewing.TurnThisOffWhenPreviewing.SetActive(true);
        }

    }

    private static bool PreviewingSomeCard()
    {
        if (!PreviewsAllowed)
            return false;

        HoverPreview[] allHoverBlowups = GameObject.FindObjectsOfType<HoverPreview>();

        foreach (HoverPreview hb in allHoverBlowups)
        {
            if (hb.OverCollider && hb.ThisPreviewEnabled)
                return true;
        }

        return false;
    }


}
