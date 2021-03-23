using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace UnityExLib
{
    public static class ComponentExtension
    {
        /// <summary>
        /// コンポーネントがアタッチされているかどうかを調べる
        /// </summary>
        /// <typeparam name="T">Component</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Tがnullの場合true</returns>
        public static bool IsComponent<T>(this GameObject obj) where T : class
        {
            return obj.GetComponent<T>() == null;
        }

        /// <summary>
        /// コンポーネントがアタッチされているかどうかを調べる
        /// </summary>
        /// <typeparam name="T">Component</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Tがnullの場合true</returns>
        public static bool IsComponentInParent<T>(this GameObject obj) where T : class
        {
            return obj.GetComponentInParent<T>() == null;
        }

        /// <summary>
        /// コンポーネントがアタッチされているかどうかを調べる
        /// </summary>
        /// <typeparam name="T">Component</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Tがnullの場合true</returns>
        public static bool IsComponentInChildren<T>(this GameObject obj) where T : class
        {
            return obj.GetComponentInChildren<T>() == null;
        }

        /// <summary>
        /// コンポーネントの取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetComponentToNullCheck<T>(this GameObject obj) where T : class
        {
            T type = obj.GetComponent<T>();

            if (type.Equals(null))
                return ComponentErrorLog<T>(obj.name);

            return type;
        }

        /// <summary>
        /// 親のコンポーネント取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetComponentInParentToNullCheck<T>(this GameObject obj) where T : class
        {
            T type = obj.GetComponentInParent<T>();

            if (type.Equals(null))
                return ComponentErrorLog<T>(obj.name);

            return type;
        }

        /// <summary>
        /// 子供のコンポーネント取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetComponentInChildrenToNullCheck<T>(this GameObject obj) where T : class
        {
            T type = obj.GetComponentInChildren<T>();

            if (type.Equals(null))
                return ComponentErrorLog<T>(obj.name);

            return type;
        }

        /// <summary>
        /// 自分を含めない子オブジェクトの要素を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T[] GetComponentsInChildrenNoIncSelf<T>(this GameObject obj) where T : Component
        {
            return obj.GetComponentsInChildren<T>().Where(c => obj != c.gameObject).ToArray();
        }

        /// <summary>
        /// 自信を含めない親オブジェクトの要素を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T[] GetComponentsInParentNoIncSelf<T>(this GameObject obj) where T : Component
        {
            return obj.GetComponentsInParent<T>().Where(c => obj != c.gameObject).ToArray();
        }

        /// <summary>
        /// エラーログの表示
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="name">オブジェクトの型</param>
        /// <returns></returns>
        private static T ComponentErrorLog<T>(string name)
        {
            Debug.LogError($"Component:{typeof(T).ToString()}はGameObject:" +
                $"{name}にアタッチされていません");

            return default;
        }
    }
}
