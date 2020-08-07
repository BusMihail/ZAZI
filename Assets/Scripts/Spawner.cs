using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public GameObject animals;
    public int maxAnimals = 5;
    public Text scor;

    private int count = 0;
    private int totalAnimals = 0;

    private Vector3 spawnPos = new Vector3(23, -5f, 0);
    private Transform lastAnimal = null;

    void FixedUpdate()
    {
        if (!ScriptTara.endGame && count < maxAnimals && (lastAnimal == null || (lastAnimal != null && lastAnimal.position.x < 13)))
        {
            int min_random;
            int max_random;

            if(totalAnimals < 5)
            {
                min_random = 0;
                max_random = 4;
            }else if(totalAnimals < 20)
            {
                min_random = 2;
                max_random = 9;
            }
            else if(totalAnimals < 30)
            {
                min_random = 7;
                max_random = 14;
            }
            else
            {
                min_random = 12;
                max_random = animals.transform.childCount;
            }

            int id = Mathf.FloorToInt(Random.Range(min_random, max_random-0.01f));
            id = id % animals.transform.childCount;

            var animal = Instantiate(animals.transform.GetChild(id));
            animal.GetComponent<Rigidbody2D>().mass = 1000;

            SpriteRenderer spriteRenderer = animal.GetComponent<SpriteRenderer>();

            var bound = spriteRenderer.bounds;

            lastAnimal = animal;
            var y = (bound.extents.y);

            animal.transform.position = (spawnPos + (Vector3.up * y));

            var animalScript = animal.GetComponent<MoveAnimal>();
            animalScript.score = scor;
            animalScript.spawner = this;

            count++;
            totalAnimals ++;

            if (totalAnimals >= 40)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                ScriptTara.endGame = true;
            }
                
        }
    }

    public void DecCount()
    {
        count--;
    }
    

}
