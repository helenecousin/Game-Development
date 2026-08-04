using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    private int score = 0;

    public void CollectIngredient()
    {

        //defining the range limits
        int minRange = 1;
        int maxRange = 11;

        int randomIncrement = UnityEngine.Random.Range(minRange, maxRange);
        score += randomIncrement ;

        //later on add broom mechanic here: potionAmount++; if (potionAmount >= potionMax){ActivateBroom();}

        Debug.Log("Score: " + score + "(+ " + randomIncrement + ")");
    }
}