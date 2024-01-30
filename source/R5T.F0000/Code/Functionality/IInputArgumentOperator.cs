using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
    [FunctionalityMarker]
    public partial interface IInputArgumentOperator : IFunctionalityMarker
    {
        public void DescribeTo(
            TextWriter writer,
            IEnumerable<string> arguments,
            int startIndex = 0)
        {
            // Start at 1.
            var counter = startIndex;

            var anyInputArguments = false;

            foreach (var argument in arguments)
            {
                anyInputArguments = true;

                Console.WriteLine($"{counter++}, {argument}");
            }

            if(!anyInputArguments)
            {
                Console.WriteLine("<No input arguments>");
            }
        }

        public void DescribeTo(
            TextWriter writer)
        {
            var inputArguments = this.GetInputArguments();

            this.DescribeTo(
                writer,
                inputArguments,
                1);
        }

        /// <inheritdoc cref="GetInputArguments_IncludingZeroth"/>
        public void DescribeTo_IncludingZeroth(
            TextWriter writer)
        {
            var inputArguments = this.GetInputArguments_IncludingZeroth();

            this.DescribeTo(
                writer,
                inputArguments,
                0);
        }

        /// <summary>
        /// Gets input arguments as they would appear in the Program.Main(string[] args) call.
        /// </summary>
        public string[] GetInputArguments()
        {
            var inputArguments = this.GetInputArguments_IncludingZeroth()
                .Skip_First()
                .ToArray();

            return inputArguments;
        }

        /// <summary>
        /// Gets all input arguments, including the zeroth input argument (which is the path of the entry-point binary).
        /// </summary>
        public string[] GetInputArguments_IncludingZeroth()
        {
            var inputArguments = Environment.GetCommandLineArgs();
            return inputArguments;
        }
    }
}
