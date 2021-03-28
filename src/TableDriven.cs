using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TestDrivenDesign {
    enum FieldType {
        FloatingPoint,
        Integer,
        String,
        TimeOfDay,
        Boolean,

        BitField,
        Last = BitField,
    }

    interface AbstractField {
        void ReadAndPrint(string str, JsonElement message);
    }

    class FloatingPointField : AbstractField {
        public void ReadAndPrint(string str, JsonElement message) {
            Console.WriteLine(message.GetProperty(str).GetDouble());
        }
    }

    public class Process {
        public static void Run() {
            var messagesJson = File.ReadAllText(AppContext.BaseDirectory + "src/messages.json");
            var messages = JsonSerializer.Deserialize<List<JsonElement>>(messagesJson);
            if (messages is null) {
                throw new Exception("messages cannot be null.");
            }

            var descriptionJson = File.ReadAllText(AppContext.BaseDirectory + "src/description.json");
            var description = JsonSerializer.Deserialize<JsonElement>(descriptionJson);

            var field = new AbstractField[(int) FieldType.Last];

            field[(int) FieldType.FloatingPoint] = new FloatingPointField();

            foreach (var message in messages) {
                var msgId = message.GetProperty("id").GetInt32();
                var fieldDescription = description.GetProperty(msgId.ToString());
                var numFieldsInMessage = fieldDescription.GetProperty("numFields").GetInt32();

                var fieldIdx = 1;
                while (fieldIdx <= numFieldsInMessage) {
                    var fieldValue = fieldDescription.GetProperty(fieldIdx.ToString());
                    var fieldName = fieldValue.GetProperty("fieldName").GetString();
                    var fieldType = fieldValue.GetProperty("fieldType").GetInt32();

                    var concreteField = field[fieldType];
                    concreteField.ReadAndPrint(fieldName, message);
                    fieldIdx++;
                }
            }
        }
    }
}
