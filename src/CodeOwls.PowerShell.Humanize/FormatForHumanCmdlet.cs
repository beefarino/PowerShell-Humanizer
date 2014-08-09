using System;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.InteropServices;
using Humanizer;

namespace CodeOwls.PowerShell.Humanize
{
    [OutputType(typeof(string))]
    [Cmdlet( VerbsCommon.Format, "ForHuman", ConfirmImpact = ConfirmImpact.Low,DefaultParameterSetName = "ST")]
    public class FormatForHumanCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "ST")]
        public string[] InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,ParameterSetName = "Timespan")]
        public TimeSpan[] TimeSpanInputObject { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "ST")]
        public SwitchParameter LowerCase { get; set; }
        [Parameter(Mandatory = false, ParameterSetName = "ST")]
        public SwitchParameter UpperCase { get; set; }
        [Parameter(Mandatory = false, ParameterSetName = "ST")]
        public SwitchParameter TitleCase { get; set; }
        [Parameter(Mandatory = false, ParameterSetName = "ST")]
        public SwitchParameter SentenceCase { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "ST")]
        public SwitchParameter Singular { get; set; }
        [Parameter(Mandatory = false, ParameterSetName = "ST")]
        public SwitchParameter Plural { get; set; }

        protected override void ProcessRecord()
        {
            if (null != TimeSpanInputObject)
            {
                WriteObject(TimeSpanInputObject.ToList().ConvertAll( d=> d.Humanize()));
                return;
            }

            foreach (var input in InputObject)
            {
                string humanized = null;

                if (LowerCase.ToBool())
                    humanized = input.Transform(To.LowerCase);
                else if (LowerCase.ToBool())
                    humanized = input.Transform(To.UpperCase);
                else if (LowerCase.ToBool())
                    humanized = input.Transform(To.TitleCase);
                else if (LowerCase.ToBool())
                    humanized = input.Transform(To.SentenceCase);
                else if (Singular.ToBool())
                    humanized = input.Singularize( false );
                else if (Plural.ToBool())
                    humanized = input.Pluralize(false);
                else
                    humanized = (input ?? String.Empty).Humanize();

                WriteObject(humanized);
            }
        }
    }
}
