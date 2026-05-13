using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] private Animator anims;

    public void OnHover()
    {
        anims.SetBool("Hover", true);
    }

    public void OutHover()
    {
        anims.SetBool("Hover", false);
    }
}
