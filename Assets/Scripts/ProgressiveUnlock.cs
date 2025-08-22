using UnityEngine;

public class ProgressiveUnlock : MonoBehaviour
{
    [SerializeField] private SpriteRenderer visuals;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private GameObject unlock;

    [SerializeField] private int progress;

	private void Start()
	{
        UpdateVisual();
	}

    public int GetProgress()
    {
        return progress;
    }

	public void Progress()
    {
        progress++;
        UpdateVisual();
    }

    public void Regress()
    {
		progress--;
		UpdateVisual();
    }

    public bool DoneProgressing()
    {
        return progress >= (sprites.Length - 1);
    }

    public void UpdateVisual()
    {
        visuals.sprite = sprites[Mathf.Clamp(progress, 0, sprites.Length - 1)];
        if (progress >= sprites.Length - 1)
        {
			unlock.SetActive(true);
		} else
        {
            unlock.SetActive(false);
        }
	}
}
