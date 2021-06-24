using UnityEngine;

public class SpellbookController : MonoBehaviour
{
    [Tooltip("The element of this spellbook")]
    public PlayerController.PlayerCurrentElement element = PlayerController.PlayerCurrentElement.None;
    [Tooltip("The player holding this spellbook")]
    public GameObject playerHolding = null;
}
