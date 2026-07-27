using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    private int score = 0;

    public void CollectIngredient()
    {
        score ++ ;
        //later on add broom mechanic here: potionAmount++; if (potionAmount >= potionMax){ActivateBroom();}

        Debug.Log("Score: " + score);
    }
}
