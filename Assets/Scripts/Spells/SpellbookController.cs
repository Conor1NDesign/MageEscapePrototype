using UnityEngine;

public class SpellbookController : MonoBehaviour
{
    [Tooltip("The element of this spellbook")]
    public PlayerController.PlayerCurrentElement element = PlayerController.PlayerCurrentElement.None;
}
