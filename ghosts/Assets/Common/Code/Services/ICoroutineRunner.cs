using System.Collections;
using UnityEngine;

namespace Common.Code.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);

        void StopCoroutine(Coroutine routine);
    }
}