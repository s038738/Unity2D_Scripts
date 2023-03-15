using UnityEngine;


public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //GameManager.instance.health = GameManager.instance.max_health;
            //Teleport player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

            if (GameManager.instance.inDungeon == false)
            {
                GameManager.instance.inDungeon = true;
            }
            else
            {
                GameManager.instance.inDungeon = false;
            }
        }
    }
}
