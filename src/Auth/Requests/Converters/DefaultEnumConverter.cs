using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Godot;

namespace Firebase.Auth.Requests.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// Defaults enum values to the base value if 
    /// </summary>
    public class DefaultEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        /// <summary>
        /// The default value used to fallback on when a enum is not convertable.
        /// </summary>
        private readonly T defaultValue;

        private readonly Dictionary<string, T> enumKeys;
        private readonly Dictionary<T, string> enumStrings;

        public DefaultEnumConverter(T defaultValue = default)
        {
            this.defaultValue = defaultValue;

            enumKeys = new();
            enumStrings = new();

            foreach (T value in typeof(T).GetEnumValues())
            {
                string name = value.ToString();
                enumKeys.Add(name, value);

                MemberInfo memberInfo = typeof(T).GetMember(name).FirstOrDefault(m => m.DeclaringType == typeof(T));
                object[] valueAttributes = memberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);

                bool hasAttribute = false;
                foreach (EnumMemberAttribute attribute in valueAttributes.Cast<EnumMemberAttribute>())
                {
                    enumKeys.Add(attribute.Value, value);
                    enumStrings.Add(value, attribute.Value);
                    hasAttribute = true;
                }
                if (!hasAttribute) enumStrings.Add(value, name);
            }
        }

        public T Parse(string name)
        {
            if (enumKeys.TryGetValue(name, out T value))
                return value;

            return defaultValue;
        }

        public string EnumString(T value)
        {
            if (enumStrings.TryGetValue(value, out string name))
                return name;

            return null;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }

        /// <inheritdoc />
        /// <summary>
        /// Validates that this converter can handle the type that is being provided.
        /// </summary>
        /// <param name="typeToConvert">The type of the object being converted.</param>
        /// <returns>True if the base class says so, and if the value is an enum and has a default value to fall on.</returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.GetTypeInfo().IsEnum && typeToConvert == typeof(T);
        }
    }
}
