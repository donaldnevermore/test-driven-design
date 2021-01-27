using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        void ReadAndPrint(string str, JToken message);
    }

    class FloatingPointField : AbstractField {
        public void ReadAndPrint(string str, JToken message) {
            Console.WriteLine((double)message[str]);
        }
    }

    public class Process {
        public static void Run() {
            var messagesJson = File.ReadAllText(@"E:/Monorepos/test-driven-design/src/messages.json");
            var messages = JsonConvert.DeserializeObject<JArray>(messagesJson);
            var descriptionJson = File.ReadAllText(@"E:/Monorepos/test-driven-design/src/description.json");
            var description = JsonConvert.DeserializeObject<JObject>(descriptionJson);

            var field = new AbstractField[(int)FieldType.Last];

            field[(int)FieldType.FloatingPoint] = new FloatingPointField();

            foreach (var message in messages) {
                var msgId = (int)message["id"];
                var fieldDescription = description[msgId.ToString()];
                var numFieldsInMessage = (int)fieldDescription["numFields"];

                var fieldIdx = 1;
                while (fieldIdx <= numFieldsInMessage) {
                    var fieldValue = fieldDescription[fieldIdx.ToString()];
                    var fieldName = (string)fieldValue["fieldName"];
                    var fieldType = (int)fieldValue["fieldType"];

                    var concreteField = field[fieldType];
                    concreteField.ReadAndPrint(fieldName, message);
                    fieldIdx++;
                }
            }
        }
    }
}
