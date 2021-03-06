using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DroneDelivery.Providers
{
    public class FilesProvider
    {
        internal string getInputFilePath(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Constants.Application.FILES_PATH);
            builder.Append(Path.DirectorySeparatorChar);
            builder.Append(string.Format(Constants.Application.INPUT_FILENAME, id.ToString("D2")));                
            return  builder.ToString();
        }

        internal string getOutputFilePath(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Constants.Application.FILES_PATH);
            builder.Append(Path.DirectorySeparatorChar);
            builder.Append(string.Format(Constants.Application.OUTPUT_FILENAME, id.ToString("D2")));                
            return  builder.ToString();
        }

        internal string[] getInputs(string inputFile)
        {
            return File.ReadAllLines(inputFile);
        }

        internal void setOutput(string outputfilePaath, List<string> outputs)
        {
            outputs.Insert(0,Constants.Application.OUTPUT_HEADER);
            File.WriteAllLines(outputfilePaath, outputs);
        }
    }
}