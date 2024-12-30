using UnityEngine;
using UnityEngine.EventSystems;

public class CardInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public CardDisplay cardDisplay { get; private set; }
    Vector3 originalPosition;
    float liftAmount = 30f;
    bool isSelected = false;

    void Start()
    {
        cardDisplay = GetComponent<CardDisplay>();
        originalPosition = transform.localPosition;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected)
        {
            LiftCard(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected) // Chỉ hạ bài nếu chưa được chọn
        {
            LiftCard(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (cardDisplay.Owner.IsHuman)
        {
            ToggleSelection(); // Chọn hoặc bỏ chọn lá bài
        }
    }

    void LiftCard(bool lift)
    {
        if (lift && cardDisplay.Owner.IsHuman)
        {
            transform.localPosition = originalPosition + new Vector3(0, liftAmount, 0);
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }

    void ToggleSelection()
    {
        isSelected = !isSelected; // Đảo trạng thái chọn
        Debug.Log($"{gameObject.name} isSelected: {isSelected}");
        if (isSelected)
        {
            transform.localPosition = originalPosition + new Vector3(0, liftAmount, 0); // Nâng bài lên
        }
        else
        {
            transform.localPosition = originalPosition; // Đưa bài về vị trí ban đầu
        }
    }

    public bool IsSelected => isSelected; // Cung cấp trạng thái chọn ra ngoài

}
