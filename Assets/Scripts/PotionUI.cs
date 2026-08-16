using UnityEngine;
using UnityEngine.UI;

public class PotionUI : MonoBehaviour
{
    // reference to the UI Image that visually represents the potion meter
    // Its Fill Amount will be changed as the player collects ingredients
    [SerializeField] private Image potionFill;


    // reference to the PlayerCollection script so that the UI can retrieve
    // the player's current potion amount and maximum potion amount.
    private PlayerCollection playerCollection;


    private void Update()
    {
        // Find the current player in the scene.
        // This is necessary because the player is destroyed when they die
        // and a new Player prefab is created when the game starts again.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // If a player currently exists, look for its PlayerCollection component.
        if (player != null)
        {
            playerCollection = player.GetComponent<PlayerCollection>();
        }


        // Only update the meter if a PlayerCollection component was found.
        if (playerCollection != null)
        {
            // Get the player's current number of collected ingredients.
            float currentAmount = playerCollection.GetPotionAmount();

            // Get the number of ingredients required to completely fill the potion.
            float maximumAmount = playerCollection.GetMaxPotion();

            // Convert the potion amount into a value between 0 and 1.
            // Unity's Image Fill Amount uses 0 for empty and 1 for completely full.
            potionFill.fillAmount = currentAmount / maximumAmount;
        }
        else
        {
            // If there is currently no player, display an empty potion meter.
            // This prevents the UI from keeping the previous game's value.
            potionFill.fillAmount = 0f;
        }
    }
}