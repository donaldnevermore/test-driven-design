namespace TestDrivenDesign
{
    enum FieldType
    {
        FloatingPoint,
        Integer,
        String,
        TimeOfDay,
        Boolean,
        BitField,
        Last = BitField
    }

    enum FileStatus
    {
        Ok,
        Error
    }

    interface IField
    {
        void ReadAndPrint(string str, FileStatus fileStatus);
    }

    class FloatingPointField : IField
    {
        public void ReadAndPrint(string str, FileStatus fileStatus)
        {
        }
    }

    public class TableDriven
    {
        public void Run()
        {
            // var fieldIndex = 1;
            // while (fieldIndex<=numFieldsInMessage && fileStatus==OK) {
            //     var fieldType = fieldDescription[fieldIndex].FieldType;
            //     var fieldName = fieldDescription[fieldIndex].FieldName;
            //     field[fieldType].ReadAndPrint(fieldName,fileStatus);
            //
            // }
        }
    }
}
