using System.Numerics;
using Vector3 = UnityEngine.Vector3;

namespace EditorLogics
{
    public class ObjectData
    {
        //Object的图片名称，是否考虑添加一个唯一id用于标识
        private string image;
        //Object的坐标
        private Vector3 position;
        //Object介绍
        private string message;
    }
}