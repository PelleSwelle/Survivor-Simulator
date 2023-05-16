using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Eater
{
    float hunger { get; set; }
    float thirst { get; set; }
    float hungryThreshold { get; set; }

    void eat(Eatable eatable);
    void drink();
}
