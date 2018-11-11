using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INegativeCamera  {
    bool CheckMutant();
    bool CheckNormal();
    bool CheckFast();
    int GetNumberOfDeathOponent();
	
}
