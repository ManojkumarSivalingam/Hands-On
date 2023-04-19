﻿using System.Text.Json;
using System;
using System.Text.Json.Serialization;

namespace API.Data.Converters
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string Format;
        public JsonDateTimeConverter(string format)
        {
            Format = format;
        }
        public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
        {
            writer.WriteStringValue(date.ToString(Format));
        }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), Format, null);
        }
    }
}
