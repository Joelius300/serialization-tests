﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Desired
{
    internal class IndexableOptionBaseConverter : Base.WriteOnlyConverterSystemTextJson<IndexableOptionBase>
    {
        public override void Write(System.Text.Json.Utf8JsonWriter writer, IndexableOptionBase value, System.Text.Json.JsonSerializerOptions options)
        {
            System.Text.Json.JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
        }
    }
}
