using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{ public bool showMenu;
    // Start is called before the first frame update
    //para cambiar variable a falso¡e o true.
   public void ButtonShowMenu()
    {
        if (!showMenu)
        {
            showMenu = true;
        }
        else if (showMenu)
            showMenu = false;

    }
}
