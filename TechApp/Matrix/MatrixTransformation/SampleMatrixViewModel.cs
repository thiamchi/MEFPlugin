using Caliburn.Micro;
using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using WpfMath;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;

namespace MatrixServer.MatrixTransformation
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SampleMatrixViewModel : Screen, IPlugin
    {
        private Matrix<double> matrix;
        private TexFormulaParser formulaParser;

        public SampleMatrixViewModel()
        {
            PluginName = PluginName.SampleMatrix;
            matrix = Matrix<double>.Build.Dense(3,3);
            formulaParser = new TexFormulaParser();
            InputText = "1+1=2";
        }

        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From SampleMatrixViewModel");
        }

        private string AddSVGHeader(string svgText)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>")
                .AppendLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" >")
                .AppendLine(svgText)
                .AppendLine("</svg>");

            return builder.ToString();
        }

        #region Bind to View
        private string m_InputText;
        public string InputText
        {
            get { return m_InputText; }
            set
            {
                m_InputText = value;
                NotifyOfPropertyChange(() => InputText);
                //NotifyOfPropertyChange(() => MathTexFormula);
            }
        }

        private TexFormula m_MathTexFormula;
        public TexFormula MathTexFormula
        {
            get { return m_MathTexFormula; }
            set
            {
                try
                {
                    m_MathTexFormula = Formula(InputText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("{0}", ex));
                }

                NotifyOfPropertyChange(() => MathTexFormula);
            }
        }

        public TexFormula Formula(string input)
        {
            TexFormula texFormula = null;
            try
            {
                texFormula = formulaParser.Parse(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0}", ex));
            }

            return texFormula;
        }

        public void Save()
        {
            //Create formula object 
            var formula = Formula(InputText);
            if (formula == null) return;
            var renderer = formula.GetRenderer(TexStyle.Display, TexScale, "Arial");

            //Choose file
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Image Files(*.BMP)|*.BMP"
            };
            var result = saveFileDialog.ShowDialog();
            if (result == false) return;

            //Open Stream
            var filename = saveFileDialog.FileName;
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                switch(saveFileDialog.FilterIndex)
                {
                    case 1:
                        var bitmap = renderer.RenderToBitmap(0.0, 0.0);
                        var encoder = new PngBitmapEncoder
                        {
                            Frames = { BitmapFrame.Create(bitmap) }
                        };
                        encoder.Save(stream);
                        break;

                    case 2:
                        var geometry = renderer.RenderToGeometry(1000, 1000);
                        var converter = new SVGConverter();
                        var svgPathText = converter.ConvertGeometry(geometry);
                        var svgText = AddSVGHeader(svgPathText);
                        using (var writer = new StreamWriter(stream))
                            writer.WriteLine(svgText);
                        break;

                    
                    default:
                        return;
                }
            }

        }

        

        private int m_TexScale;
        public int TexScale
        {
            get { return m_TexScale; }
            set
            {
                m_TexScale = value;
                NotifyOfPropertyChange(() => TexScale);
                //NotifyOfPropertyChange(() => MathTexFormula);
            }
        }
        #endregion
    }
}
