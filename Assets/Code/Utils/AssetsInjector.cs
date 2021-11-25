using System;
using System.Reflection;

namespace Utils
{
    public static class AssetsInjector
    {
        private static Type _injectAssetAttributeType = typeof(InjectAssetAttribute);

        public static T Inject<T>(this AssetsContext context, T target)
        {
            Type targetType = target.GetType();
            do {
                var allFields = targetType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                for (var i = 0; i < allFields.Length; i++)
                {
                    var currentField = allFields[i];
                    var injectAssetAttribute = currentField.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;
                    if (injectAssetAttribute == null)
                        continue;
                
                    var objectToInject = context.GetObjectOfType(currentField.FieldType, injectAssetAttribute.AssetName);
                    currentField.SetValue(target, objectToInject);
                }
                targetType = targetType.BaseType;
            }
            while (targetType != null);

            return target;
        }
    }
}
