using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestDataBuilder<T>
{
    public abstract T Build();

    public static implicit operator T(TestDataBuilder<T> builder)
    {
        return builder.Build();
    }
}
