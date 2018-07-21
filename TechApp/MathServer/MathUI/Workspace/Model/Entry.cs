using MathServer.MathUI.Workspace.Container;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServer.MathUI.Workspace.Model
{
    public class Entry
    {
        public Entry()
        {
            Input = null;
            Output = null;
            Steps = null;
            Solutions = null;
        }

        public Entry(Input input, Output output)
        {
            Input = input;
            Output = output;
        }

        public Entry(Input input, ObservableCollection<Step> steps, ObservableCollection<Solution> solutions)
        {
            Input = input;
            Output = null;
            Steps = steps;
            Solutions = solutions;
        }

        public Input Input { get; set; }
        public Output Output { get; set; }
        public ObservableCollection<Step> Steps { get; set; }
        public ObservableCollection<Solution> Solutions { get; set; }

    }

    public class Input
    {
        public Input(string input, string display)
        {
            Label = input;
            Display = display;
        }

        public string Label { get; set; }
        public string Display { get; set; }
    }

    public class Output
    {
        public Output(string input, string display)
        {
            Label = input;
            Display = display;
        }

        public string Label { get; set; }
        public string Display { get; set; }
    }

    public class Step
    {
        public Step(string description, string display)
        {
            Description = description;
            Display = display;
        }

        public string Description { get; set; }
        public string Display { get; set; }
    }

    public class Solution
    {
        public Solution(string label, string display)
        {
            Label = label;
            Display = display;
        }

        public string Label { get; set; }
        public string Display { get; set; }
    }
}
