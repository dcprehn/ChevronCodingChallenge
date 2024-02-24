using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aoiti.Techs
{
    [CreateAssetMenu(menuName="GameCore/new Tech")]

    public class Tech : ScriptableObject
    {
        public string definition;
        public Texture2D image;
    }

}
