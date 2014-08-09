using System.Linq;
using System.Management.Automation;
using Humanizer;

namespace CodeOwls.PowerShell.Humanize
{
    [OutputType(typeof(string))]    
    [Cmdlet(VerbsData.Limit, "String", ConfirmImpact = ConfirmImpact.Low)]
    public class LimitStringCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public string[] InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        public int Length { get; set; }

        [Parameter(Mandatory = false, Position = 2)]
        public string Truncation { get; set; }

        /*[Parameter(Mandatory = false, ParameterSetName = "Fixed")]
        public SwitchParameter Fixed { get; set; }*/
        [Parameter(Mandatory = false)]
        public SwitchParameter Characters { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Words { get; set; }

        private ITruncator _truncator;

        protected override void BeginProcessing()
        {
            _truncator = Truncator.FixedLength;
            if (Characters.ToBool())
            {
                _truncator = Truncator.FixedNumberOfCharacters;
            }
            else if (Words.ToBool())
            {
                _truncator = Truncator.FixedNumberOfWords;
            }
            
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {            
            WriteObject(InputObject.ToList().ConvertAll(s => null != Truncation ? s.Truncate(Length, Truncation, _truncator) : s.Truncate(Length, _truncator)));
        }
    }
}