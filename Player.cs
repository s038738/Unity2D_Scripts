using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerMover
{
   private SpriteRenderer spriteRenderer;
   private static GameObject instance;

   protected override void Start()
   {
      base.Start();
      spriteRenderer = GetComponent<SpriteRenderer>();
      DontDestroyOnLoad(gameObject);

      if (instance == null)
         instance = gameObject;
      else
         Destroy(gameObject);
   }


   private void FixedUpdate() 
   {
      float x = Input.GetAxisRaw("Horizontal");
      float y = Input.GetAxisRaw("Vertical");
      UpdateMotor(new Vector3(x, y, 0));
   }
}
