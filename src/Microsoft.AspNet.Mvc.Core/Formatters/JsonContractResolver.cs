// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.AspNet.Mvc
{
    /// <summary>
    /// The default <see cref="IContractResolver"/> for <see cref="JsonInputFormatter"/>.
    /// It determines if a value type member has <see cref="RequiredAttribute"/> and sets the appropriate 
    /// JsonProperty settings.
    /// </summary>
    public class JsonContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property =  base.CreateProperty(member, memberSerialization);

            var required = member.GetCustomAttribute(typeof(RequiredAttribute), inherit: true);
            if (required != null)
            {
                var propertyType = ((PropertyInfo)member).PropertyType;

                // Check if the property type is a primitive or struct and is also non-nullable.
                // Nullable properties are validated by DefaultObjectValidator and so we do not 
                // handle them here.
                if (propertyType.IsValueType() && !propertyType.IsNullableValueType())
                {
                    property.Required = Required.AllowNull;
                }
            }

            return property;
        }
    }
}