using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EventReceiver<T>
{
    // Start is called before the first frame update
    void Listen(Action<T> action);

}
