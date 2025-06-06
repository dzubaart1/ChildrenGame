using JetBrains.Annotations;
using UnityEngine;

public abstract class MenuUIBase : MonoBehaviour
{
    [CanBeNull] public MenuCntrl MenuCntrl { get; private set; }

    public void Init(MenuCntrl menuCntrl)
    {
        MenuCntrl = menuCntrl;
    }
}
