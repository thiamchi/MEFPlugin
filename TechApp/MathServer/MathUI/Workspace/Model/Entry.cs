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
            Id = Guid.Empty;
            Input = null;
            Output = null;
            Steps = null;
            Solutions = null;
        }

        public Entry(Input input, Output output)
        {
            Id = Guid.NewGuid();
            Input = input;
            Output = output;

            InputVM = new DisplayViewModel(Input.Label, Input.Display);
            OutputVM = new DisplayViewModel(Output.Label, Output.Display);
        }

        public Entry(Input input, ObservableCollection<Step> steps, ObservableCollection<Solution> solutions)
        {
            Id = Guid.NewGuid();
            Input = input;
            Output = null;
            Steps = steps;
            Solutions = solutions;

            InputVM = new DisplayViewModel(Input.Label, Input.Display);
            OutputVM = new DisplayViewModel(Output.Label, Output.Display);
            StepsVM = new StepDisplayViewModel("", Steps);
            SolutionVM = new ObservableCollection<DisplayViewModel>();
            foreach(Solution sol in solutions)
            {
                (SolutionVM as ObservableCollection<DisplayViewModel>).Add(new DisplayViewModel(sol.Label, sol.Display));
            }
        }

        public Guid Id { get; set; }
        public Input Input { get; set; }
        public Output Output { get; set; }
        public ObservableCollection<Step> Steps { get; set; }
        public ObservableCollection<Solution> Solutions { get; set; }
        public object InputVM { get; set; }
        public object OutputVM { get; set; }
        public object StepsVM { get; set; }
        public object SolutionVM { get; set; }

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
